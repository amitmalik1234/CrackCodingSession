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

            Parallel.Invoke(
                () => PrintStudentDetailsLazy(),
                () => PrintEmployeeDetailsLazy()
                );

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
