using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton fromEmployee = Singleton.GetInstance;
            //fromEmployee.PrintDetails("From Employee");

            //Singleton fromStudent = Singleton.GetInstance;
            //fromStudent.PrintDetails("From Student");

            //Parallel.Invoke(
            //    () => PrintStudentDetails(),
            //    () => PrintEmployeeDetails()
            //    );

            //Parallel.Invoke(
            //    () => PrintStudentDetailsLazy(),
            //    () => PrintEmployeeDetailsLazy()
            //    );



            #region Static Class
            double celcius = 37; double fahrenheit = 98.6;
            Console.WriteLine("Value of {0} celcius to fahrenheit is {1}",
                celcius, StaticDemoConverter.ToFarenheit(celcius));
            Console.WriteLine("Value of {0} fahrenheit to celcius is {1}",
                fahrenheit, StaticDemoConverter.ToCelcius(fahrenheit));
            #endregion


            Console.ReadKey();
        }

        private static void PrintStudentDetails()
        {
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");
        }

        private static void PrintEmployeeDetails()
        {
            Singleton fromEmployee = Singleton.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }

        private static void PrintStudentDetailsLazy()
        {
            SingletonLazyEager fromStudent =  SingletonLazyEager.GetInstance;
            fromStudent.PrintDetails("From Student");
        }

        private static void PrintEmployeeDetailsLazy()
        {
            SingletonLazyEager fromEmployee = SingletonLazyEager.GetInstance;
            fromEmployee.PrintDetails("From Employee");
        }
    }
}
