using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    public sealed class Singleton
    {
        private static int counter = 0;
        private static readonly object obj = new object();
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                /// Double checking of instance is called Double Check Locking
                /// https://en.wikipedia.org/wiki/Double-checked_locking

                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value : {0}", counter);
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
