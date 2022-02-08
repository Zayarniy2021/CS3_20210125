using System;
using System.Threading;

namespace Listing01
{
    class MyThread
    {
        public int Count;
        string thrdName;

        public MyThread(string name)
        {
            Count = 0;
            thrdName = name;
        }

        // Entry point of thread. 
        // Точка входа в поток
        public void Run()
        {
            Console.WriteLine(thrdName + " starting.");
            do
            {
                Thread.Sleep(1000);
                Console.WriteLine("In " + thrdName +
                                  ", Count is " + Count);
                Count++;
            } while (Count < 20);

            Console.WriteLine(thrdName + " terminating.");
        }
    }

    class MultiThread
    {
        static void Main()
        {
            Console.WriteLine("Main thread starting.");
            // First, construct a MyThread object. 
            // Сначала, создаем объект MyThread
            MyThread mt = new MyThread("Child #1");
            // Next, construct a thread from that object. 
            //Затем, создаем поток из этого объекта
            Thread newThrd = new Thread(new ThreadStart(mt.Run));
            newThrd.IsBackground = true;//Указываем, что поток фоновый (не приоритетный)
            // Finally, start execution of the thread. 
            newThrd.Start();
            do
            {
                Console.Write(".");
                Thread.Sleep(1000);//спим 100 миллисекунд
                //мы обращаемся к переменной, изменение которой происходит в другом потоке
            } while (mt.Count != 10);

            Console.WriteLine("Main thread ending.");
            // Console.ReadKey();
        }
    }
}

