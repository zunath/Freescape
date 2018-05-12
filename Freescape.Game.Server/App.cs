using System;
using System.Linq;
using Autofac;
using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Event;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.GameObject.Contracts;
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

        public static T Resolve<T>()
        {
            return (T)_container.Resolve(typeof(T));
        }

        private static void BuildIOCContainer()
        {
            var builder = new ContainerBuilder();

            // Types
            builder.RegisterType<DataContext>();

            // Game Objects
            builder.RegisterType<NWObject>().As<INWObject>();
            builder.RegisterType<NWCreature>().As<INWCreature>();
            builder.RegisterType<NWItem>().As<INWItem>();
            builder.RegisterType<NWPlayer>().As<INWPlayer>();

            // Services
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<NWScript>().As<INWScript>().SingleInstance();
            builder.RegisterType<ColorTokenService>().As<IColorTokenService>().SingleInstance();
            builder.RegisterType<PlayerInitializationService>().As<IPlayerInitializationService>();
            builder.RegisterType<DurabilityService>().As<IDurabilityService>();
            builder.RegisterType<SkillService>().As<ISkillService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<BackgroundService>().As<IBackgroundService>();
            builder.RegisterType<DeathService>().As<IDeathService>();

            // Interfaces
            RegisterInterfaceImplementations<IRegisteredEvent>(builder);
            RegisterInterfaceImplementations<IConversation>(builder);
            RegisterInterfaceImplementations<IChatCommand>(builder);

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
