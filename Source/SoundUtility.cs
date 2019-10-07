using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMUtility
{
    public static class SoundUtility
    {
        public static bool IsPowerOfTwo(int x)
        {
            // First x in the below expression 
            // is for the case when x is 0 
            return x != 0 && ((x & (x - 1)) == 0);
        }

        public static int PowerOfTwo(int x)
        {
            string binary = Convert.ToString(x, 2);
            int ones = binary.Count(c=>c == '1');
            if (ones == 1)
            {
                //valid power of two
                return binary.Count(c => c == '0');
            }
            return -1;
        }
    }
}
