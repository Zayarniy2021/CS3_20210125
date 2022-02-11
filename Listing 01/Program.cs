using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listing_01
{
    class Program
    {
        // A method to be run as a task. 
        static void MyTask()
        {
            Thread.CurrentThread.IsBackground = false;//Фоновая или приоритетная

            Console.WriteLine("MyTask() starting");
            Console.WriteLine("IsBackground:" + Thread.CurrentThread.IsBackground);
            //Выполняет работу в потоке
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask(), count is " + count);
            }

            Console.WriteLine("MyTask terminating");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread starting.");

            // Construct a task. 
            Task tsk = new Task(MyTask);

            tsk.Start();
            // Keep Main() alive until MyTask() finishes. 
            for (int i = 0; i < 60; i++)
            {
                Console.Write(".");
                Thread.Sleep(10);
            }

            Console.WriteLine("Main thread ending.");

            // Console.Read();




        }
    }
}
