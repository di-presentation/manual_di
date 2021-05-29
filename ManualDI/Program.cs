using System;
using ManualDI.DI;

namespace ManualDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new DependencyContainer();
            var resolver = new DependencyResolver(container);
            
            container.AddTransient<ServiceConsumer>();
            container.AddTransient<HelloService>();
            container.AddSingleton<MessageService>();

            var consumer1 = resolver.GetService<ServiceConsumer>();
            var consumer2 = resolver.GetService<ServiceConsumer>();
            var consumer3 = resolver.GetService<ServiceConsumer>();
            consumer1.Print();
            consumer2.Print();
            consumer3.Print();
        }
    }
}
