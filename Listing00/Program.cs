using System;
using System.Linq.Expressions;
using System.Threading;

namespace Listing00
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Console.WriteLine(Thread.CurrentThread.Name);

            Thread thread = new Thread(()=>
            {
                Thread.CurrentThread.Name = "Add";
                Console.WriteLine(Thread.CurrentThread.Name);
            }
                );

            thread.Start();
            Console.ReadKey();

        }
    }
}
