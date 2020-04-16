namespace csharp_garbage_collector
{
    internal static partial class Program
    {
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
    }
}