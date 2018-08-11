using System;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class ObjectProcessingService : IObjectProcessingService
    {
        private readonly INWScript _;


        public ObjectProcessingService(INWScript script)
        {
            _ = script;
        }

        public void OnModuleLoad()
        {
            NWArea area = NWArea.Wrap(_.GetFirstArea());
            while (area.IsValid)
            {
                NWObject @object = NWObject.Wrap(_.GetFirstObjectInArea(area.Object));
                while (@object.IsValid)
                {
                    HandleSpawnWaypointRename(@object);
                }

                area = NWArea.Wrap(_.GetNextArea());
            }
        }

        // It's difficult to see what waypoint represents what in the toolset.
        // To fix this, we rename the waypoints on module load so that they function in-game.
        private void HandleSpawnWaypointRename(NWObject obj)
        {
            if (obj.ObjectType != OBJECT_TYPE_WAYPOINT) return;

            string name = obj.Name;
            
            
            string[] split = name.Split(new[] {"SP_"}, StringSplitOptions.None);
            
            if (split.Length <= 1) return;

            name = "SP_" + split[split.Length - 1];
            name = name.Trim();

            obj.Name = name;
        }
    }
}
