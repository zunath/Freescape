﻿using System;
using System.Linq;
using Autofac;
using Freescape.Game.Server.Bioware;
using Freescape.Game.Server.Bioware.Contracts;
using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.Conversation;
using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.CustomEffect.Contracts;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Event;
using Freescape.Game.Server.Extension;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.GameObject.Contracts;
using Freescape.Game.Server.NWNX;
using Freescape.Game.Server.NWNX.Contracts;
using Freescape.Game.Server.Perk;
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
            try
            {
                IRegisteredEvent @event = _container.ResolveNamed<IRegisteredEvent>(typeof(T).ToString());
                return @event.Run(args);
            }
            catch (Exception ex)
            {
                IErrorService errorService = _container.Resolve<IErrorService>();
                errorService.LogError(ex);
                throw;
            }
        }

        public static bool RunEvent(Type type, params object[] args)
        {
            try
            {
                IRegisteredEvent @event = _container.ResolveNamed<IRegisteredEvent>(type.ToString());
                return @event.Run(args);
            }
            catch (Exception ex)
            {
                IErrorService errorService = _container.Resolve<IErrorService>();
                errorService.LogError(ex);
                throw;
            }
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

        public static T Resolve<T>(string key)
        {
            return (T) _container.ResolveNamed(key, typeof(T));
        }

        private static void BuildIOCContainer()
        {
            var builder = new ContainerBuilder();

            // Types
            builder.RegisterType<DataContext>().As<IDataContext>();

            // Game Objects
            builder.RegisterType<NWObject>().As<INWObject>();
            builder.RegisterType<NWCreature>().As<INWCreature>();
            builder.RegisterType<NWItem>().As<INWItem>();
            builder.RegisterType<NWPlayer>().As<INWPlayer>();
            builder.RegisterType<NWArea>().As<INWArea>();
            builder.RegisterType<NWModule>().As<INWModule>();
            builder.RegisterType<NWPlaceable>().As<INWPlaceable>();

            // Services
            builder.RegisterType<AbilityService>().As<IAbilityService>();
            builder.RegisterType<ActivityLoggingService>().As<IActivityLoggingService>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<AbilityService>().As<IAbilityService>();
            builder.RegisterType<BackgroundService>().As<IBackgroundService>();
            builder.RegisterType<ColorTokenService>().As<IColorTokenService>();
            builder.RegisterType<CraftService>().As<ICraftService>();
            builder.RegisterType<CustomEffectService>().As<ICustomEffectService>();
            builder.RegisterType<DeathService>().As<IDeathService>();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<DurabilityService>().As<IDurabilityService>();
            builder.RegisterType<EffectTrackerService>().As<IEffectTrackerService>();
            builder.RegisterType<ErrorService>().As<IErrorService>();
            builder.RegisterType<ExaminationService>().As<IExaminationService>();
            builder.RegisterType<FarmingService>().As<IFarmingService>();
            builder.RegisterType<FoodService>().As<IFoodService>();
            builder.RegisterType<HelmetToggleService>().As<IHelmetToggleService>();
            builder.RegisterType<ItemService>().As<IItemService>();
            builder.RegisterType<KeyItemService>().As<IKeyItemService>();
            builder.RegisterType<LocalVariableService>().As<ILocalVariableService>();
            builder.RegisterType<LootService>().As<ILootService>();
            builder.RegisterType<MapPinService>().As<IMapPinService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<MigrationService>().As<IMigrationService>();
            builder.RegisterType<ObjectProcessingService>().As<IObjectProcessingService>();
            builder.RegisterType<PerkService>().As<IPerkService>();
            builder.RegisterType<PlayerDescriptionService>().As<IPlayerDescriptionService>();
            builder.RegisterType<PlayerService>().As<IPlayerService>();
            builder.RegisterType<PVPSanctuaryService>().As<IPVPSanctuaryService>();
            builder.RegisterType<QuestService>().As<IQuestService>();
            builder.RegisterType<RandomService>().As<IRandomService>();
            builder.RegisterType<SearchService>().As<ISearchService>();
            builder.RegisterType<SkillService>().As<ISkillService>();
            builder.RegisterType<StorageService>().As<IStorageService>();
            builder.RegisterType<StructureService>().As<IStructureService>();
            builder.RegisterType<TimeService>().As<ITimeService>();
            
            // Interfaces
            RegisterInterfaceImplementations<IRegisteredEvent>(builder);
            RegisterInterfaceImplementations<ICustomEffect>(builder);
            RegisterInterfaceImplementations<IChatCommand>(builder);
            RegisterInterfaceImplementations<IConversation>(builder);

            // Conversations
            RegisterAbstractClass<ConversationBase>(builder);
            RegisterAbstractClass<PerkBase>(builder);

            // Third Party
            builder.RegisterType<BiowarePosition>().As<IBiowarePosition>();
            builder.RegisterType<BiowareXP2>().As<IBiowareXP2>();
            builder.RegisterType<NWNXChat>().As<INWNXChat>();
            builder.RegisterType<NWNXCreature>().As<INWNXCreature>();
            builder.RegisterType<NWNXEvents>().As<INWNXEvents>();
            builder.RegisterType<NWNXItem>().As<INWNXItem>();
            builder.RegisterType<NWNXObject>().As<INWNXObject>();
            builder.RegisterType<NWNXItem>().As<INWNXItem>();
            builder.RegisterType<NWNXPlayer>().As<INWNXPlayer>();
            builder.RegisterType<NWNXPlayerQuickBarSlot>().As<INWNXPlayerQuickBarSlot>();
            builder.RegisterType<NWScript>().As<INWScript>().SingleInstance();
            builder.RegisterType<SCORCO>().As<ISCORCO>();

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

        private static void RegisterAbstractClass<T>(ContainerBuilder builder)
            where T: class
        {
            if (!typeof(T).IsAbstract) throw new Exception(nameof(T) + " is not an abstract class.");

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes()
                    .Where(t => t.IsClass &&
                                !t.IsAbstract &&
                                t.IsSubclassOf(typeof(T)));

                foreach (var type in types)
                {
                    builder.RegisterType(type).Named<T>(type.Name);
                }
            }
        }
    }
}
