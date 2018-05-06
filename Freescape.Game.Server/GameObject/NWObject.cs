using System;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWObject : INWObject
    {
        public Object Object { get; protected set; }
        private readonly INWScript _script;

        public NWObject(INWScript script)
        {
            _script = script;
        }

        public static NWObject Wrap(Object @object)
        {
            var obj = (NWObject)App.Resolve<INWObject>();
            obj.Object = @object;

            return obj;
        }


        public string Name
        {
            get => _script.GetName(Object);
            set => _script.SetName(Object, value);
        }

        public string Tag
        {
            get => _script.GetTag(Object);
            set => _script.SetTag(Object, value);
        }

        public string Resref => _script.GetResRef(Object);

        public Location Location
        {
            get => _script.GetLocation(Object);
            set
            {
                _script.AssignCommand(Object, () => _script.JumpToLocation(value));
            }
        }

        public Object Area => _script.GetArea(Object);

        public Vector Position => _script.GetPosition(Object);

        public bool IsPlot
        {
            get => _script.GetPlotFlag(Object) == 1;
            set => _script.SetPlotFlag(Object, value ? 1 : 0);
        }

        public float Facing
        {
            get => _script.GetFacing(Object);
            set => _script.AssignCommand(Object, () => _script.SetFacing(value));
        }

        public int CurrentHP => _script.GetCurrentHitPoints(Object);

        public int MaxHP => _script.GetMaxHitPoints(Object);

        public bool IsValid => _script.GetIsObjectValid(Object) == 1;

        public int GetLocalInt(string name)
        {
            return _script.GetLocalInt(Object, name);
        }

        public void SetLocalInt(string name, int value)
        {
            _script.SetLocalInt(Object, name, value);
        }

        public void DeleteLocalInt(string name)
        {
            _script.DeleteLocalInt(Object, name);
        }


        public string GetLocalString(string name)
        {
            return _script.GetLocalString(Object, name);
        }

        public void SetLocalString(string name, string value)
        {
            _script.SetLocalString(Object, name, value);
        }

        public void DeleteLocalString(string name)
        {
            _script.DeleteLocalString(Object, name);
        }


        public float GetLocalFloat(string name)
        {
            return _script.GetLocalFloat(Object, name);
        }

        public void SetLocalFloat(string name, float value)
        {
            _script.SetLocalFloat(Object, name, value);
        }

        public void DeleteLocalFloat(string name)
        {
            _script.DeleteLocalFloat(Object, name);
        }


        public Location GetLocalLocation(string name)
        {
            return _script.GetLocalLocation(Object, name);
        }

        public void SetLocalLocation(string name, Location value)
        {
            _script.SetLocalLocation(Object, name, value);
        }

        public void DeleteLocalLocation(string name)
        {
            _script.DeleteLocalLocation(Object, name);
        }


        public Object GetLocalObject(string name)
        {
            return _script.GetLocalObject(Object, name);
        }

        public void SetLocalObject(string name, Object value)
        {
            _script.SetLocalObject(Object, name, value);
        }

        public void DeleteLocalObject(string name)
        {
            _script.DeleteLocalObject(Object, name);
        }

    }
}
