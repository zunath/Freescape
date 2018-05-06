using System;
using System.Linq;
using Autofac;
using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Event;
using Freescape.Game.Server.Helper;
using Freescape.Game.Server.Service;
using Freescape.Game.Server.Service.Contracts;
using NWN;

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

        public static bool RunEvent<T>(params object[] args)
            where T: IRegisteredEvent
        {
            IRegisteredEvent @event = _container.ResolveNamed<IRegisteredEvent>(typeof(T).ToString());
            return @event.Run(args);
        }

        public static T ResolveByInterface<T>()
        {
            if (!typeof(T).IsInterface)
            {
                throw new Exception(nameof(T) + " must be an interface.");
            }

            return _container.ResolveNamed<T>(typeof(T).ToString());
        }
        
        public static T ResolveByInterface<T>(Type type)
        {
            if (!typeof(T).IsInterface)
            {
                throw new Exception(nameof(T) + " must be an interface.");
            }
            
            return _container.ResolveNamed<T>(type.ToString());
        }

        private static void BuildIOCContainer()
        {
            var builder = new ContainerBuilder();

            // Types
            builder.RegisterType<DataContext>();

            // Services
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<NWScript>().As<INWScript>().SingleInstance();
            builder.RegisterType<ColorTokenService>().As<IColorTokenService>().SingleInstance();
            
            // Interfaces
            RegisterInterfaceImplementations<IRegisteredEvent>(builder);
            RegisterInterfaceImplementations<IConversation>(builder);

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
