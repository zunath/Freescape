using System;
using System.Linq;
using Autofac;
using Freescape.Game.Server.Contracts;
using Freescape.Game.Server.Data;

namespace Freescape.Game.Server
{
    // Compositional root for the app.
    internal class App
    {
        private IContainer _container;

        public App()
        {
            BuildIOCContainer();
        }

        public void RunEvent<T>()
            where T: IRegisteredEvent
        {
            IRegisteredEvent @event = _container.ResolveNamed<IRegisteredEvent>(typeof(T).ToString());
            @event.Run();
        }
        
        private void BuildIOCContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataContext>().As<IDataContext>();

            RegisterInterfaceImplementations<IRegisteredEvent>(builder);

            _container = builder.Build();
        }


        private static void RegisterInterfaceImplementations<T>(ContainerBuilder builder)
        {
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
