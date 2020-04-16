using System.Collections.Generic;

namespace csharp_garbage_collector
{
    internal class ClassFoo
    {
        public readonly int Index;
        public readonly List<double> ListDoubles;
        public string Name;

        public ClassFoo(int index, List<double> listDoubles, string name)
        {
            Index = index;
            ListDoubles = listDoubles;
            Name = name;
        }
    }
}