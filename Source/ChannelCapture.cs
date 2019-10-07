using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMUtility
{
    public class ChannelCapture
    {
        public ChannelCapture(byte channelNumber)
        {
            ChannelNumber = channelNumber;
        }

        public byte ChannelNumber = 0;
        public List<byte> ControlBytes = new List<byte>();
        public List<byte> FrequencyBytes = new List<byte>();

        public void Tick()
        {
            //the last value of both the control and frequency buffer is repeated
            if (ControlBytes.Count > 0)
            {
                byte lastControlByte = ControlBytes[ControlBytes.Count - 1];
                ControlBytes.Add(lastControlByte);
            }
            
            if (FrequencyBytes.Count > 0)
            {
                byte lastFrequencyByte = FrequencyBytes[FrequencyBytes.Count - 1];
                FrequencyBytes.Add(lastFrequencyByte);
            }
        }

        public void Clean()
        {
            //trim trailing zeros
            TrimZeros(ControlBytes);
            TrimZeros(FrequencyBytes);
        }

        private void TrimZeros(List<byte> list)
        {
            if (list != null && list.Count > 0)
            {
                //going backwards through the list... find the last index with a Zero
                int lastIndex = list.Count - 1;
                if (list[lastIndex] != 0) return;
                int maxZero = lastIndex;

                for(int i = lastIndex; i > 0; i--)
                {
                    if (list[i] != 0)
                    {
                        maxZero = i + 1;
                        break;
                    }
                }

                list.RemoveRange(maxZero, list.Count - maxZero);
            }
        }

        public string ToOutput(string prefix, OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.RawText:
                    return FormatRawText(prefix);
                case OutputFormat.RPM40:
                    return FormatRPM40(prefix);
            }
            return "Unsupported format!";
        }

        private string FormatRawText(string prefix)
        {
            StringBuilder sb = new StringBuilder();

            string identifier = prefix + "_c" + ChannelNumber.ToString();
            string controlID = identifier + "_ctrl";
            string frequencyID = identifier + "_freq";

            //write header
            sb.AppendLine("\t\tNEWTUNE(" + identifier + ")");
            sb.AppendLine("\t\tSETSNDFREQ(" + frequencyID + ")");
            sb.AppendLine("\t\tSETSNDCONT(" + controlID + ")");
            sb.AppendLine("");

            //output control bytes
            StringBuilder cb = new StringBuilder();
            cb.Append(controlID);
            byte lastCValue = 0;
            int valueCCount = 0;
            foreach (byte c in ControlBytes)
            {
                if (c != lastCValue || valueCCount > 15)
                {
                    cb.Append("\r\n\t\t.db $" + c.ToString("X2").ToUpper());
                    lastCValue = c;
                    valueCCount = 0;
                }
                else
                {
                    if (c == 0 && lastCValue == 0){
                        //end
                        break;
                    }
                    cb.Append(",$" + c.ToString("X2").ToUpper());
                    valueCCount++;
                }
            }
            sb.AppendLine(cb.ToString());
            sb.AppendLine("");

            //output frequency bytes
            StringBuilder fb = new StringBuilder();
            fb.Append(frequencyID);
            byte lastFValue = 0;
            int valueFCount = 0;
            foreach (byte f in FrequencyBytes)
            {
                if (f != lastFValue || valueFCount > 15)
                {
                    fb.Append("\r\n\t\t.db $" + f.ToString("X2").ToUpper());
                    lastFValue = f;
                    valueFCount = 0;
                }
                else
                {
                    if (f == 0 && lastFValue == 0)
                    {
                        //end
                        break;
                    }
                    fb.Append(",$" + f.ToString("X2").ToUpper());
                    valueFCount++;
                }
            }
            sb.AppendLine(fb.ToString());
            return sb.ToString();
        }

        private string FormatRPM40(string prefix)
        {
            StringBuilder sb = new StringBuilder();

            string identifier = prefix + "_c" + ChannelNumber.ToString();
            string controlID = identifier + "_ctrl";
            string frequencyID = identifier + "_freq";

            //write header
            sb.AppendLine("\t\tNEWTUNE(" + identifier + ")");
            sb.AppendLine("\t\tSETSNDFREQ(" + frequencyID + ")");
            sb.AppendLine("\t\tSETSNDCONT(" + controlID + ")");
            sb.AppendLine("");

            //Control Bytes...
            List<Tuple<byte, byte>> controlByteDeltas = GetControlDeltas(ControlBytes);
            
            foreach(Tuple<byte,byte> d in controlByteDeltas)
            {
                sb.AppendLine("\t\tSDCTRL(" + d.Item1.ToString() + "," + d.Item2.ToString() + ")");
            }
            sb.AppendLine("");

            //Frequency Bytes...
            List<Tuple<byte, int>> freqByteDeltas = GetFrequencyDeltas(FrequencyBytes);

            foreach (Tuple<byte, int> d in freqByteDeltas)
            {
                sb.AppendLine("\t\tSDFREQ(" + d.Item1.ToString() + "," + d.Item2.ToString() + ")");
            }

            return sb.ToString();       
        }

        private List<Tuple<byte,byte>> GetControlDeltas(List<byte> bytes)
        {
            List<Tuple<byte, byte>> deltas = new List<Tuple<byte, byte>>();

            byte lastValue = 0;
            byte lastDelta = 0;
            byte count = 0;
            foreach (byte b in bytes)
            {
                byte value = (byte)(b & 0xF);
                byte delta = (byte)(value - lastValue);

                if (delta == 0)
                {
                    count++;
                }
                else
                {
                    if (lastValue > 0)
                    {
                        //save this one..
                        deltas.Add(new Tuple<byte, byte>(delta, count));
                    }
                    lastValue = value;
                    lastDelta = delta;
                    count = 0;
                }
            }

            if (deltas.Count == 0)
            {
                //there has to be at least one entry, they will be all be the same value tho
                deltas.Add(new Tuple<byte, byte>(lastDelta, count));
            }
            return deltas;
        }

        private List<Tuple<byte, int>> GetFrequencyDeltas(List<byte> bytes)
        {
            List<Tuple<byte, int>> deltas = new List<Tuple<byte, int>>();

            var rle = Enumerable.Range(0, bytes.Count)
                    .Where(i => i == 0 || bytes[i - 1] != bytes[i])
                    .Select(i => new { Value = bytes[i], Count = bytes.Skip(i).TakeWhile(x => x == bytes[i]).Count() });

            byte lastValue = 0;
            int lastDelta = 0;
            byte count = 0;
            int deltaCount = -1;
            foreach(var b in rle)
            {
                byte value = b.Value;
                int delta = (int)(value - lastValue);

                //was this a repeating value that we need to target now?
                if (lastDelta != delta && lastDelta != 0)
                {
                    //save this one...
                    if (deltaCount <= 1)
                    {
                        deltas.Add(new Tuple<byte, int>(2, (lastDelta >> 1)));
                    }
                    else
                    {
                        deltas.Add(new Tuple<byte, int>(count, lastDelta));
                    }
                    deltaCount = 0;
                    count = 0;
                }
                count += (byte)(b.Count - 1);
                lastDelta = delta;
                lastValue = value;

                if (delta != lastDelta)
                {
                    deltaCount = 0;
                }
                else
                {
                    deltaCount++;
                }
            }
            return deltas;
        }
    }
}
