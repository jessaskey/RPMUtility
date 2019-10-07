using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPMUtility.Extensions
{
    public static class MyStringBuilder
    {
        public static void Tabify(this StringBuilder sb, char c, int len)
        {
            if (sb != null)
            {
                if (sb.Length < len)
                {
                    sb.Append(new String(c, len - sb.Length));
                }
            }
        }
    }
}
