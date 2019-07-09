using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public static class StaticDemoConverter
    {
        public static double ToFarenheit(double celcius)
        {
            return (celcius * 9 / 5) + 32;
        }

        public static double ToCelcius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}
