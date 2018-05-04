using System;
using System.Linq;
using Autofac;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Events.Contracts;

namespace Freescape.Game.Server
{
    // Compositional root for the app.
    internal static class App
    {
        private static IContainer _container;

        static App()
        {
            BuildIOCContainer();
        }

        public static void RunEvent<T>()
            where T: IRegisteredEvent
        {
            IRegisteredEvent @event = _container.ResolveNamed<IRegisteredEvent>(typeof(T).ToString());
            @event.Run();
        }
        
        private static void BuildIOCContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>();

            RegisterInterfaceImplementations<IRegisteredEvent>(builder);

            _container = builder.Build();
        }


        private static void RegisterInterfaceImplementations<T>(ContainerBuilder builder)
        {
            if (!typeof(T).IsInterface)
            {
                throw new Exception("Only interfaces may be used with " + nameof(RegisterInterfaceImplementations));
            }

            var classes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(T).IsAssignableFrom(p) && p.IsClass).ToArray();
            foreach (Type type in classes)
            {
                builder.RegisterType(type).As<T>().Named<T>(type.ToString());
            }
        }


    }
}
