using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMUtility
{
    public class EnvelopeBranch : IEnvelopeItem
    {
        public EnvelopeBranch(byte loops, byte branch)
        {
            Loops = loops;
            Branch = branch;
        }

        public int Loops { get; set; }
        
        public int Branch { get; set; }
    }
}
