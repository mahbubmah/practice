using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorOopApp
{
    class Calculator
    {
        

        public double Addition(double aFirstNumber,double aLastNumber)
        {
            
            return aFirstNumber + aLastNumber;
        }

        public double Subtraction(double aFirstNumber, double aLastNumber)
        {

            return aFirstNumber - aLastNumber;
        }

        public double Multiplication(double aFirstNumber, double aLastNumber)
        {

            return aFirstNumber * aLastNumber;
        }

        public double Division(double aFirstNumber, double aLastNumber)
        {
            
            return aFirstNumber / aLastNumber;
        }
    }
}
