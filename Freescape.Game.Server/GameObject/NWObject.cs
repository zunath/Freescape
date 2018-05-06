using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWObject : Object
    {
        private readonly INWScript _script;

        public NWObject(INWScript script)
        {
            _script = script;
        }

        public string Name
        {
            get => _script.GetName(this);
            set => _script.SetName(this, value);
        }

        public string Tag
        {
            get => _script.GetTag(this);
            set => _script.SetTag(this, value);
        }

        public string Resref => _script.GetResRef(this);

        public Location Location
        {
            get => _script.GetLocation(this);
            set
            {
                _script.AssignCommand(this, () => _script.JumpToLocation(value));
            }
        }

        public Object Area => _script.GetArea(this);

        public Vector Position => _script.GetPosition(this);

        public bool IsPlot
        {
            get => _script.GetPlotFlag(this) == 1;
            set => _script.SetPlotFlag(this, value ? 1 : 0);
        }

        public float Facing
        {
            get => _script.GetFacing(this);
            set => _script.AssignCommand(this, () => _script.SetFacing(value));
        }

        public int CurrentHP => _script.GetCurrentHitPoints(this);

        public int MaxHP => _script.GetMaxHitPoints(this);

        public int GetLocalInt(string name)
        {
            return _script.GetLocalInt(this, name);
        }

        public void SetLocalInt(string name, int value)
        {
            _script.SetLocalInt(this, name, value);
        }


        public string GetLocalString(string name)
        {
            return _script.GetLocalString(this, name);
        }

        public void SetLocalString(string name, string value)
        {
            _script.SetLocalString(this, name, value);
        }


        public float GetLocalFloat(string name)
        {
            return _script.GetLocalFloat(this, name);
        }

        public void SetLocalFloat(string name, float value)
        {
            _script.SetLocalFloat(this, name, value);
        }


        public Location GetLocalLocation(string name)
        {
            return _script.GetLocalLocation(this, name);
        }

        public void SetLocalLocation(string name, Location value)
        {
            _script.SetLocalLocation(this, name, value);
        }


        public Object GetLocalObject(string name)
        {
            return _script.GetLocalObject(this, name);
        }

        public void SetLocalObject(string name, Object value)
        {
            _script.SetLocalObject(this, name, value);
        }

    }
}
