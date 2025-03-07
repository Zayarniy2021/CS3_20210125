﻿//TPL
// Use Parallel.Invoke() to execute methods concurrently. C# 4.0
// This version uses lambda expressions. 

using System;
using System.Threading;
using System.Threading.Tasks;

class DemoParallel
{

    static void Main()
    {

        Console.WriteLine("Main thread starting.");

        // Run two anonymous methods specified via lambda expressions. 



        #region Example 2 (more simple)
        //ParallelOptions parallel = new ParallelOptions();

        Parallel.Invoke(Method1, Method2);
        #endregion
        Console.WriteLine("Main thread ending.");

        Console.Read();

    }

    static void Method1()
    {
        Console.WriteLine("Expression #1 starting");

        for (int count = 0; count < 5; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("Expression #1 count is " + count);
        }

        Console.WriteLine("Expression #1 terminating");
    }

    static void Method2()
    {
        Console.WriteLine("Expression #2 starting");

        for (int count = 0; count < 10; count++)
        {
            Thread.Sleep(500);
            Console.WriteLine("Expression #2 count is " + count);
        }

        Console.WriteLine("Expression #2 terminating");

    }
}