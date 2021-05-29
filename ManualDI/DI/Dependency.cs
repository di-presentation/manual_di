using System;

namespace ManualDI.DI
{
    public class Dependency
    {
        public Dependency(Type type, DependencyLifetime lifetime)
        {
            Type = type;
            Lifetime = lifetime;
        }
        public Type Type { get; }
        public DependencyLifetime Lifetime { get; }
        public object Implementation { get; set; }
        public bool Implemented { get; set; }

        public void AddImplementation(object implementation)
        {
            Implementation = implementation;
            Implemented = true;
        }
    }
}
