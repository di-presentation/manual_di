using System;
using System.Linq;

namespace ManualDI.DI
{
    public class DependencyResolver
    {
        private DependencyContainer _container;

        public DependencyResolver(DependencyContainer container)
        {
            _container = container;
        }

        public object GetService(Type type)
        {
            var dependency = _container.GetDependency(type);
            var constructor = dependency.Type.GetConstructors().Single();
            var parameters = constructor.GetParameters().ToArray();
            if (parameters.Length > 0)
            {
                var parametersImplementations = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parametersImplementations[i] = GetService(parameters[i].ParameterType);
                }

                return CreateImplementation(dependency, t => Activator.CreateInstance(t, parametersImplementations));
            }
            return CreateImplementation(dependency, Activator.CreateInstance);
        }

        private object CreateImplementation(Dependency dependency, Func<Type, object> factory)
        {
            if (dependency.Implemented) return dependency.Implementation;
            var impl = factory(dependency.Type);
            if (dependency.Lifetime == DependencyLifetime.Singleton) dependency.AddImplementation(impl);
            return impl;
        }
        public T GetService<T>()
        {
            return (T) GetService(typeof(T));
        }
    }
}