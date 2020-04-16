using System.Collections.Generic;

namespace csharp_garbage_collector
{
    internal struct StructFoo
    {
        public readonly int Index;
        public readonly List<double> ListDoubles;
        public string Name;

        public StructFoo(int index, List<double> listDoubles, string name)
        {
            Index = index;
            ListDoubles = listDoubles;
            Name = name;
        }
    }
}