using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWObject : INWObject
    {
        public virtual Object Object { get; protected set; }
        protected readonly INWScript _;

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


        public virtual string Name
        {
            get => _.GetName(Object);
            set => _.SetName(Object, value);
        }

        public virtual string Tag
        {
            get => _.GetTag(Object);
            set => _.SetTag(Object, value);
        }

        public virtual string Resref => _.GetResRef(Object);

        public virtual Location Location
        {
            get => _.GetLocation(Object);
            set
            {
                AssignCommand(() => _.JumpToLocation(value));
            }
        }

        public virtual NWArea Area => NWArea.Wrap(_.GetArea(Object));

        public virtual Vector Position => _.GetPosition(Object);

        public virtual bool IsPlot
        {
            get => _.GetPlotFlag(Object) == 1;
            set => _.SetPlotFlag(Object, value ? 1 : 0);
        }

        public virtual float Facing
        {
            get => _.GetFacing(Object);
            set => AssignCommand(() => _.SetFacing(value));
        }

        public virtual int CurrentHP => _.GetCurrentHitPoints(Object);

        public virtual int MaxHP => _.GetMaxHitPoints(Object);

        public virtual bool IsValid => Object != null && _.GetIsObjectValid(Object) == 1;

        public virtual int GetLocalInt(string name)
        {
            return _.GetLocalInt(Object, name);
        }

        public virtual void SetLocalInt(string name, int value)
        {
            _.SetLocalInt(Object, name, value);
        }

        public virtual void DeleteLocalInt(string name)
        {
            _.DeleteLocalInt(Object, name);
        }


        public virtual string GetLocalString(string name)
        {
            return _.GetLocalString(Object, name);
        }

        public virtual void SetLocalString(string name, string value)
        {
            _.SetLocalString(Object, name, value);
        }

        public virtual void DeleteLocalString(string name)
        {
            _.DeleteLocalString(Object, name);
        }


        public virtual float GetLocalFloat(string name)
        {
            return _.GetLocalFloat(Object, name);
        }

        public virtual void SetLocalFloat(string name, float value)
        {
            _.SetLocalFloat(Object, name, value);
        }

        public virtual void DestroyAllInventoryItems()
        {
            NWItem item = NWItem.Wrap(_.GetFirstItemInInventory(Object));
            while (item.IsValid)
            {
                _.DestroyObject(item.Object);
                item = NWItem.Wrap(_.GetNextItemInInventory(Object));
            }
        }

        public virtual void DeleteLocalFloat(string name)
        {
            _.DeleteLocalFloat(Object, name);
        }


        public virtual Location GetLocalLocation(string name)
        {
            return _.GetLocalLocation(Object, name);
        }

        public virtual void SetLocalLocation(string name, Location value)
        {
            _.SetLocalLocation(Object, name, value);
        }

        public virtual void DeleteLocalLocation(string name)
        {
            _.DeleteLocalLocation(Object, name);
        }


        public virtual Object GetLocalObject(string name)
        {
            return _.GetLocalObject(Object, name);
        }

        public virtual void SetLocalObject(string name, Object value)
        {
            _.SetLocalObject(Object, name, value);
        }

        public virtual void DeleteLocalObject(string name)
        {
            _.DeleteLocalObject(Object, name);
        }

        public virtual void Destroy(float delay = 0.0f)
        {
            _.DestroyObject(Object, delay);
        }

        public virtual void AssignCommand(ActionDelegate action, float delay = 0.0f)
        {
            if (delay <= 0.0f)
            {
                _.AssignCommand(Object, action);
            }
            else
            {
                _.DelayCommand(delay, action);
            }

        }
    }
}
