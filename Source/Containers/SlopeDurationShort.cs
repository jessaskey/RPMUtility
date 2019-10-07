using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPMUtility.Interfaces;

namespace RPMUtility
{
    public class SlopeDurationShort : IEnvelopeItem
    {
        private sbyte _slope = 0;
        private byte _duration = 0;

        public SlopeDurationShort() { }

        public SlopeDurationShort(sbyte slope, byte duration)
        {
            _slope = slope;
            _duration = duration;
        }

        public sbyte Slope { get { return _slope; } set { _slope=value; } }
        public byte Duration { get { return _duration; } set { _duration = value; } }


    }
}
