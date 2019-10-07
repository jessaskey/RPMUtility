using RPMUtility.DataFormats;
using RPMUtility.Extensions;
using RPMUtility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPMUtility
{
    public class Envelope
    {
        private int _bitDepth = 8;
        private List<IEnvelopeItem> _slopeDurations = new List<IEnvelopeItem>();
        private ISlopeDataFormatter _formatter = null;

        public int MinValue { get { return 0; } }
        public int MaxValue { get{ return (int) Math.Pow(2, _bitDepth); }  }

        public Envelope() {}

        public int TotalLength
        {
            get
            {
                if (_formatter != null)
                {
                    return _formatter.TotalLength(_slopeDurations);
                }
                return 0;
            }
        }

        public void LoadFromBinary(List<byte> bytes, ISlopeDataFormatter formatter)
        {
            _slopeDurations.Clear();
            _formatter = formatter;            
            if (_formatter != null)
            {
                _slopeDurations.AddRange(_formatter.Load(bytes));
            }
        }

        public List<int> GetPcmData(int targetBitDepth)
        {
            int downSample = _bitDepth - targetBitDepth;
            double downSampleMultiplier = Math.Pow(2, downSample);

            if (_formatter != null)
            {
                return _formatter.GetPcmData(_slopeDurations, downSample, MinValue, MaxValue);
            }
            return null;
        }

        public List<string> GetSource(int bitDepth)
        {

            int originalSample = SoundUtility.PowerOfTwo(MaxValue);
            int downSample = originalSample - bitDepth;
            

            if (_formatter != null)
            {
                return _formatter.GetSource(_slopeDurations, downSample);
            }

            return null;
        }

        public string GetVisual(string linePrefix, int targetBitDepth )
        {
            int downSample = _bitDepth - targetBitDepth;
            double downSampleMultiplier = Math.Pow(2, downSample);

            StringBuilder finalBuilder = new StringBuilder();
            finalBuilder.AppendLine(linePrefix + StringRepeat("*", this.TotalLength));

            List<int> pcmData = GetPcmData(targetBitDepth);

            int chartMax = (int)Math.Pow(2, targetBitDepth);
            for (int i = 0; i < chartMax; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(linePrefix);

                int threshold = chartMax - i;

                foreach(int dataPoint in pcmData)
                {
                    if (dataPoint >= threshold)
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                finalBuilder.AppendLine(sb.ToString());
            }

            //StringBuilder footerBuilder = new StringBuilder();
            //footerBuilder.Append(linePrefix);
            //for (int j = 0; j < TotalLength; j++)
            //{
            //    footerBuilder.Append(" ");
            //    footerBuilder.Append(j.ToString("X2"));
            //}

            //finalBuilder.AppendLine(footerBuilder.ToString());

            return finalBuilder.ToString();
        }

        private string StringRepeat(string s, int n)
        {
            return new String('X', n).Replace("X", s);
        }
    }
}
