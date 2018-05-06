using System;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWObject : INWObject
    {
        public Object Object { get; protected set; }
        private readonly INWScript _;

        public NWObject(INWScript script)
        {
            _ = script;
        }

        public static NWObject Wrap(Object @object)
        {
            var obj = (NWObject)App.Resolve<INWObject>();
            obj.Object = @object;
            
            return obj;
        }


        public string Name
        {
            get => _.GetName(Object);
            set => _.SetName(Object, value);
        }

        public string Tag
        {
            get => _.GetTag(Object);
            set => _.SetTag(Object, value);
        }

        public string Resref => _.GetResRef(Object);

        public Location Location
        {
            get => _.GetLocation(Object);
            set
            {
                _.AssignCommand(Object, () => _.JumpToLocation(value));
            }
        }

        public Object Area => _.GetArea(Object);

        public Vector Position => _.GetPosition(Object);

        public bool IsPlot
        {
            get => _.GetPlotFlag(Object) == 1;
            set => _.SetPlotFlag(Object, value ? 1 : 0);
        }

        public float Facing
        {
            get => _.GetFacing(Object);
            set => _.AssignCommand(Object, () => _.SetFacing(value));
        }

        public int CurrentHP => _.GetCurrentHitPoints(Object);

        public int MaxHP => _.GetMaxHitPoints(Object);

        public bool IsValid => Object != null && _.GetIsObjectValid(Object) == 1;

        public int GetLocalInt(string name)
        {
            return _.GetLocalInt(Object, name);
        }

        public void SetLocalInt(string name, int value)
        {
            _.SetLocalInt(Object, name, value);
        }

        public void DeleteLocalInt(string name)
        {
            _.DeleteLocalInt(Object, name);
        }


        public string GetLocalString(string name)
        {
            return _.GetLocalString(Object, name);
        }

        public void SetLocalString(string name, string value)
        {
            _.SetLocalString(Object, name, value);
        }

        public void DeleteLocalString(string name)
        {
            _.DeleteLocalString(Object, name);
        }


        public float GetLocalFloat(string name)
        {
            return _.GetLocalFloat(Object, name);
        }

        public void SetLocalFloat(string name, float value)
        {
            _.SetLocalFloat(Object, name, value);
        }

        public void DestroyAllInventoryItems()
        {
            NWItem item = NWItem.Wrap(_.GetFirstItemInInventory(Object));
            while (item.IsValid)
            {
                _.DestroyObject(item.Object);
                item = NWItem.Wrap(_.GetNextItemInInventory(Object));
            }
        }

        public void DeleteLocalFloat(string name)
        {
            _.DeleteLocalFloat(Object, name);
        }


        public Location GetLocalLocation(string name)
        {
            return _.GetLocalLocation(Object, name);
        }

        public void SetLocalLocation(string name, Location value)
        {
            _.SetLocalLocation(Object, name, value);
        }

        public void DeleteLocalLocation(string name)
        {
            _.DeleteLocalLocation(Object, name);
        }


        public Object GetLocalObject(string name)
        {
            return _.GetLocalObject(Object, name);
        }

        public void SetLocalObject(string name, Object value)
        {
            _.SetLocalObject(Object, name, value);
        }

        public void DeleteLocalObject(string name)
        {
            _.DeleteLocalObject(Object, name);
        }

    }
}
