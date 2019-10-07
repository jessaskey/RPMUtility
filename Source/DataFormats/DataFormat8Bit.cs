using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPMUtility.Extensions;
using RPMUtility.Interfaces;

namespace RPMUtility.DataFormats
{
    public class DataFormat8Bit : ISlopeDataFormatter
    {
        private string _lastError = String.Empty;
        private int _itemSize = 2;
        public double Slope { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Duration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ItemSize
        {
            get
            {
                return _itemSize;
            }
        }

        public int TotalLength(List<IEnvelopeItem> items)
        {
            int loopCounter = 1;
            int totalLength = 0;
            for (int i = 0; i < items.Count; i++)
            {
                IEnvelopeItem item = items[i];
                if (item is SlopeDurationLong)
                {
                    SlopeDurationLong duration = (SlopeDurationLong)item;
                    totalLength += duration.Duration;
                }
                if (item is EnvelopeBranch)
                {
                    totalLength += _itemSize + 1;       //extra byte for branches
                    if (loopCounter > 0)
                    {
                        EnvelopeBranch branch = (EnvelopeBranch)item;
                        i = i - (branch.Branch / _itemSize);
                        loopCounter--;
                    }
                }
            }
            return totalLength;
        }

        public List<IEnvelopeItem> Load(List<byte> bytes)
        {
            List<IEnvelopeItem> definitions = new List<IEnvelopeItem>();
            for (int i = 0; i < bytes.Count; i += _itemSize)
            {
                byte firstByte = bytes[i];
                if (firstByte == 0xFF)
                {
                    //branch instruction
                    EnvelopeBranch ev = new EnvelopeBranch(bytes[i + 1],bytes[i+2]);
                    i++;        //this is an extra bump because our branch instruction is 3-bytes, the SD's are all 2-byte.
                    definitions.Add(ev);
                }
                else
                {
                    byte duration = firstByte;
                    sbyte slope =  (sbyte)bytes[i + 1];
                    definitions.Add(new SlopeDurationShort((sbyte)(slope/2), duration));
                }
            }
            return definitions;
        }

        public List<int> GetPcmData(List<IEnvelopeItem> items, int downsampleAmount, int minValue, int maxValue)
        {
            int lastValue = 0;
            int loopCounter = 1;
            List<int> pcm = new List<int>();
            pcm.Add(lastValue);

            for (int i = 0; i < items.Count; i++)
            {
                IEnvelopeItem item = items[i];
                if (item is SlopeDurationShort)
                {
                    SlopeDurationShort duration = (SlopeDurationShort)item;
                    lastValue += (int)duration.Slope;
                    if (lastValue < minValue) lastValue = minValue;
                    if (lastValue > maxValue) lastValue = maxValue;
                    pcm.Add(lastValue >> downsampleAmount);
                }
                if (item is EnvelopeBranch)
                {
                    if (loopCounter > 0)
                    {
                        EnvelopeBranch branch = (EnvelopeBranch)item;
                        i = i - (branch.Branch / _itemSize);
                        loopCounter--;
                    }
                }
            }
            return pcm;
        }

        public List<string> GetSource(List<IEnvelopeItem> items, int downsampleAmount)
        {
            int netAmplitude = 0;
            int indents = 0;
            double downSampleMultiplier = Math.Pow(2, downsampleAmount);
            List<string> results = new List<string>();

            for(int i = 0; i < items.Count; i++)
            {
                IEnvelopeItem item = items[i];
                StringBuilder sourceBuilder = new StringBuilder();

                if (item is SlopeDurationShort)
                {
                    SlopeDurationShort sd = item as SlopeDurationShort;
                    //int effectiveSlope = sd.Slope >> 4;
                    netAmplitude += ((int)(sd.Slope * sd.Duration)) >> downsampleAmount;
                    sourceBuilder.Append("SCTRL(");
                    sourceBuilder.Append(sd.Slope.ToString());
                    sourceBuilder.Append(",");
                    sourceBuilder.Append(sd.Duration.ToString());
                    sourceBuilder.Append(")");
                    sourceBuilder.Tabify(' ', 25);
                    sourceBuilder.Append(";Eff Slope:");
                    sourceBuilder.Append((sd.Slope / downSampleMultiplier).ToString());
                    sourceBuilder.Tabify(' ', 43);
                    sourceBuilder.Append("Dur:");
                    sourceBuilder.Append(sd.Duration.ToString());
                    sourceBuilder.Tabify(' ', 52);
                    sourceBuilder.Append("Net:");
                    sourceBuilder.Append(netAmplitude.ToString());
                }
                if (item is EnvelopeBranch)
                {
                    EnvelopeBranch eb = item as EnvelopeBranch;
                    sourceBuilder.Append("SLOOP(");
                    sourceBuilder.Append(eb.Loops.ToString());
                    sourceBuilder.Append(")");
                    sourceBuilder.Tabify(' ', 25);
                    sourceBuilder.Append(";Loop Back ");
                    sourceBuilder.Append(eb.Loops.ToString());
                    sourceBuilder.Append(" times.");
                    //insert a branch start back where this loops
                    results.Insert(results.Count() - (eb.Branch/_itemSize) + 1, "SBEGIN");
                }
                results.Add(sourceBuilder.ToString());
            }
            return results;
        }
    }
}
