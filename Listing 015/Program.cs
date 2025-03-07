﻿// A Simple PLINQ Query. 

using System;
using System.Diagnostics;
using System.Linq;

class PLINQDemo
{

    static void Main()
    {

        int[] data = new int[900_000_000];

        // Initialize the data to positve values. 
        for (int i = 0; i < data.Length; i++) data[i] = i;

        // Now, insert some negative values. 
        data[1000] = -1;
        data[14000] = -2;
        data[15000] = -3;
        data[676000] = -4;
        data[8024540] = -5;
        data[9908000] = -6;

        var sw = new Stopwatch();
        sw.Start();
        // Use a PLINQ query to find the negative values. 
        //var negatives = from val in data.AsParallel()//Non ordered query
        var negatives = from val in data.AsParallel().AsOrdered() //Ordered query
                        where val < 0
                        select val;

        foreach (var v in negatives)
            Console.Write(v + " ");
        sw.Stop();
        Console.WriteLine("Time:" + sw.ElapsedMilliseconds);
        Console.WriteLine();

        Console.Read();

    }
}
/*
В этом запросе метод AsParallel () вызывается для источника данных, в качестве которого служит массив data. Благодаря этому разрешается параллельное выполнение операций над массивом data, а именно: поиск отрицательных значений параллельно в нескольких потоках. По мере обнаружения отрицательных значений они добавляются в последовательность вывода. Это означает, что порядок формирования последовательности вывода может и не отражать порядок расположения отрицательных значений в массиве data. В качестве примера ниже приведен результат выполнения приведенного выше кода в двухъядерной системе.
-5 -6 -1 -2 -3 -4
Как видите, в том потоке, где поиск выполнялся в верхней части массива, отрицательные значения -5 и -6 были обнаружены раньше, чем значение -1 в том потоке, где поиск происходил в нижней части массива. Следует, однако, иметь в виду, что из-за отличий в степени загрузки задачами, количества доступных процессоров и прочих факторов системного характера могут быть получены разные результаты. А самое главное, что результирующая последовательность совсем не обязательно будет отражать порядок формирования исходной последовательности.
*/
/*
Применение метода AsOrdered ()
 По умолчанию порядок формирования результирующей последовательности в параллельном запросе совсем не обязательно должен отражать порядок формирования исходной последовательности. Более того, результирующую последовательность следует рассматривать как практически неупорядоченную. Если же результат должен отражать порядок организации источника данных, то его нужно запросить специально с помощью метода AsOrdered (), определенного в классе ParallelEnumerable.
*/