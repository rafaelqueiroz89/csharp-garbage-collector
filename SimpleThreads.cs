using System;
using System.Threading;

namespace Threads_in_CSharp
{
    /// <summary>
    /// Note that the method Main is also a Thread. So Print1 will be executed 
    /// at the same time as the Main Thread.. so you can see some scrambled data 
    /// on your console.
    /// </summary>
    class SimpleThreads
    {
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(Print1);

        //    t.Start();

        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write(0);
        //    }
        //}

        //public static void Print1()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write(1);
        //    }
        //}
    }
}