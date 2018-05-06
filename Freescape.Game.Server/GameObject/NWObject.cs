using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWObject : Object
    {
        public string Name
        {
            get => NWScript.GetName(this);
            set => NWScript.SetName(this, value);
        }

        public string Tag
        {
            get => NWScript.GetTag(this);
            set => NWScript.SetTag(this, value);
        }

        public string Resref => NWScript.GetResRef(this);

        public Location Location
        {
            get => NWScript.GetLocation(this);
            set
            {
                NWScript.AssignCommand(this, () => NWScript.JumpToLocation(value));
            }
        }

        public Object Area => NWScript.GetArea(this);

        public Vector Position => NWScript.GetPosition(this);

        public bool IsPlot
        {
            get => NWScript.GetPlotFlag(this) == 1;
            set => NWScript.SetPlotFlag(this, value ? 1 : 0);
        }

        public float Facing
        {
            get => NWScript.GetFacing(this);
            set => NWScript.AssignCommand(this, () => NWScript.SetFacing(value));
        }

        public int CurrentHP => NWScript.GetCurrentHitPoints(this);

        public int MaxHP => NWScript.GetMaxHitPoints(this);

        public int GetLocalInt(string name)
        {
            return NWScript.GetLocalInt(this, name);
        }

        public void SetLocalInt(string name, int value)
        {
            NWScript.SetLocalInt(this, name, value);
        }


        public string GetLocalString(string name)
        {
            return NWScript.GetLocalString(this, name);
        }

        public void SetLocalString(string name, string value)
        {
            NWScript.SetLocalString(this, name, value);
        }


        public float GetLocalFloat(string name)
        {
            return NWScript.GetLocalFloat(this, name);
        }

        public void SetLocalFloat(string name, float value)
        {
            NWScript.SetLocalFloat(this, name, value);
        }


        public Location GetLocalLocation(string name)
        {
            return NWScript.GetLocalLocation(this, name);
        }

        public void SetLocalLocation(string name, Location value)
        {
            NWScript.SetLocalLocation(this, name, value);
        }


        public Object GetLocalObject(string name)
        {
            return NWScript.GetLocalObject(this, name);
        }

        public void SetLocalObject(string name, Object value)
        {
            NWScript.SetLocalObject(this, name, value);
        }

    }
}
