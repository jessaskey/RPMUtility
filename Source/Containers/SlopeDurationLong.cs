using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPMUtility.Interfaces;

namespace RPMUtility
{
    public class SlopeDurationLong : IEnvelopeItem
    {
        private double _slope = 0;
        private int _duration = 0;

        public SlopeDurationLong() { }

        public SlopeDurationLong(int slope, int duration)
        {
            _slope = slope;
            _duration = duration;
        }

        public double Slope { get { return _slope; } set { _slope=value; } }
        public int Duration { get { return _duration; } set { _duration = value; } }


    }
}
