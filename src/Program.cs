using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_garbage_collector
{
    internal static class Program
    {
        private const int items = 3000;
        private const int iterations = int.MaxValue;

        private static void GetGCGeneration<T>(T obj, string op)
        {
            long memorySnapshot1 = GC.GetTotalMemory(false);

            GC.SuppressFinalize(obj);
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            long memorySnapshot2 = GC.GetTotalMemory(false);

            Console.WriteLine(
                @$"
                    Operation: {op}
                    Difference of memory used before and after GC {Math.Abs(memorySnapshot1 - memorySnapshot2)} bytes
                    Object deallocated on Gen: {GC.GetGeneration(obj)}
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
            Console.WriteLine("3 - List and Pre-sized List");
            Console.WriteLine("4 - Exit");

            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    WithBoxingUnboxing(items);
                    WithoutBoxingUnboxing(items);
                    return true;

                case "2":
                    ConcatenateString();
                    StringBuilder();
                    return true;

                case "3":
                    PreSizedList();
                    List();
                    return true;

                case "4":
                    return false;

                default:
                    return true;
            }
        }

        #region Pre-sized list vs Simple list

        private static void List()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < items; i++)
            {
                list.Add(i);
            }

            GetGCGeneration(list, $"List");
        }

        private static void PreSizedList()
        {
            List<int> list = new List<int>(items);

            for (int i = 0; i < items; i++)
            {
                list.Add(i);
            }

            GetGCGeneration(list, $"Pre-sized list");
        }

        #endregion Pre-sized list vs Simple list

        #region Concatenate with obj string vs String Builder

        private static void ConcatenateString()
        {
            string text = "";

            for (int i = 0; i < iterations; i++)
            {
                text += i;
            }

            GetGCGeneration(text, $"Concatenate String");
        }

        private static void StringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < iterations; i++)
            {
                stringBuilder.Append(i);
            }

            GetGCGeneration(stringBuilder, $"Concatenate String Builder");
        }

        #endregion Concatenate with obj string vs String Builder

        #region Boxing and Unboxing vs Avoiding it

        private static void WithBoxingUnboxing(object item)
        {
            for (int i = 0; i < iterations; i++)
            {
                _ = (int)item;
            }

            GetGCGeneration(item, $"With boxing and unboxing");
        }

        private static void WithoutBoxingUnboxing(int item)
        {
            for (int i = 0; i < iterations; i++)
            {
                _ = item;
            }

            GetGCGeneration(item, $"With value type declaration");
        }

        #endregion Boxing and Unboxing vs Avoiding it
    }
}