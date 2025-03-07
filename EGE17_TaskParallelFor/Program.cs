﻿using System;
using System.Threading.Tasks;

/*
ЕГЭ 17.

Определите количество принадлежащих отрезку [2·10^10; 4·10^10] натуральных 
чисел, которые делятся на 7 и на 100 000 и при этом не делятся на 13, 29, 43 и 
101, а также наименьшее из таких чисел. В ответе запишите два целых числа: 
сначала количество, затем наименьшее число. 
*/

namespace EGE17_TaskParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            ulong min=0;
            Parallel.For(20000000000, 40000000000, (i) =>
            {
                if (i % 7 == 0 && i % 10000 == 0 && i % 13 != 0 && i % 29 != 0 && i % 43 != 0 && i % 101 != 0)
                {
                    k++;
                    if (k == 1) min = (ulong) i;
                }

            });
            Console.WriteLine(k);
            Console.WriteLine(min);
        }
    }
}
