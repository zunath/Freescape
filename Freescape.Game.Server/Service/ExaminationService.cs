using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class ExaminationService: IExaminationService
    {
        public bool OnModuleExamine(NWPlayer examiner, NWObject examinedObject)
        {
            return false;
        }
    }
}
