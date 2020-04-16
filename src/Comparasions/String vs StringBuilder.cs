using System.Text;

namespace csharp_garbage_collector
{
    internal static partial class Program
    {
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
    }
}