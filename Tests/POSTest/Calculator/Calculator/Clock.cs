using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Clock
    {

        
        

      

        public double GetMinuteToHrAngle(int Hour, int Min)
        {
            double Angle = 0.0;

           
            int HourPosition = Hour * 5;

            Angle = Min * 6 - ((Hour % 12) * 30);

            return Angle; 

        }
    }
}
