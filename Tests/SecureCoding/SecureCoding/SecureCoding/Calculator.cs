using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureCoding
{
    public class Calculator
    {
        public double DivideTwoNumbers(int dividend, int divisor)
        {
            try
            {
                double quotient = 0;
                quotient = dividend / divisor;
                return quotient;
            }
            catch(FormatException e)
            {
                Console.WriteLine("Error: Invalid input format. Please enter valid integers.");
                return 0.0;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return 0.0;
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Error: Invalid operation. " + e.Message);
                return 0.0;
            }
            catch (Exception e)
            {
                Console.WriteLine("An unexpected error occurred: " + e.Message);
                return 0.0;
            }

        }
        public int DefaultPassing(int a)
        {
            return a++;
        }


        public int GetProduct(int a, int b)
        {
            int prod = -1;
            prod = a * b;
            return prod;
        }

        public int Addup(int a, int b = 0)
        {
            return a + b;
        }

        public bool GoodNumber(string strNum, out int outNum)
        {
            if (int.TryParse(strNum, out outNum))
            {
                return true;
            }

            return false;
        }

        public bool PassByRef(ref int Num)
        {
            if (++Num > 9)
            {
                return true;
            }
            return false;
        }
    }
}
