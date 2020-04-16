using System;
using System.Diagnostics;
using System.Text;

namespace csharp_garbage_collector
{
    internal static class Program
    {
        private const int _iterations = 10000000;

        private static void ConcatenateString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 50; i++)
            {
                stringBuilder.Append(i);
            }

            GetGCGeneration(stringBuilder, $"Concatenate String");
        }

        private static void GetGCGeneration<T>(T obj, string op)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            double memorySnapshot1 = (GC.GetTotalMemory(false) / 1024f);

            stopwatch.Start();

            GC.SuppressFinalize(obj);
            GC.Collect(2, GCCollectionMode.Forced);

            stopwatch.Stop();

            double memorySnapshot2 = (GC.GetTotalMemory(false) / 1024f);

            Console.WriteLine(
                @$"
                    Operation: {op}
                    Memory allocated before GC {memorySnapshot1} bytes
                    Memory after GC {memorySnapshot2} bytes
                    Object disposed on Gen: {GC.GetGeneration(obj)}
                    Done in {stopwatch.Elapsed.TotalMilliseconds} ms
                 ");
        }

        private static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("\n----------------------");
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Boxing and Unboxing operation");
            Console.WriteLine("2 - String and String Builder concatenation");
            Console.WriteLine("3 - Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    WithBoxingUnboxing(100);
                    WithoutBoxingUnboxing(100);
                    return true;

                case "2":
                    ConcatenateString();
                    StringBuilder();
                    return true;

                case "3":

                    return false;

                default:
                    return true;
            }
        }

        private static void StringBuilder()
        {
            string text = "";

            for (int i = 0; i < 50; i++)
            {
                text += i;
            }

            GetGCGeneration(text, $"Concatenate String Builder");
        }

        private static void WithBoxingUnboxing(object item)
        {
            for (int i = 0; i < _iterations; i++)
            {
                _ = (int)item;
            }

            GetGCGeneration(item, $"With boxing and unboxing");
        }

        private static void WithoutBoxingUnboxing(int item)
        {
            for (int i = 0; i < _iterations; i++)
            {
                _ = item;
            }

            GetGCGeneration(item, $"With value type declaration");
        }
    }
}