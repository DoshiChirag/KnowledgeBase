using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureCoding
{
    public class DemoClass
    {
        public int DemoMethod(int dividend, int divisor)
        {
            Debug.Assert(divisor != 0, "Divisor cannot be zero.");
            Debug.Assert(dividend < 100, "Dividend must be non-negative and less than 100.");
            return (dividend/divisor);
        }
    }
}
