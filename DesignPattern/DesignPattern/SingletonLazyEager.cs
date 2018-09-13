using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    public sealed class SingletonLazyEager
    {
        private static int counter = 0;
        /// <summary>
        ///  Eager initialization
        /// </summary>
        //private static readonly SingletonEager instance = new SingletonLazyEager();
        /// <summary>
        /// Lazy Initialization
        /// </summary>
        private static readonly Lazy<SingletonLazyEager> instance = new Lazy<SingletonLazyEager>(()=> new SingletonLazyEager());

        public static SingletonLazyEager GetInstance
        {
            get
            {
                /// Double checking of instance is called Double Check Locking
                /// https://en.wikipedia.org/wiki/Double-checked_locking                
                return instance.Value;
            }
        }

        private SingletonLazyEager()
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
