using System;
using System.Data.SqlClient;
using Freescape.Game.Server.Contracts;
using Freescape.Game.Server.Data.Entities;

namespace Freescape.Game.Server.Events
{
    internal class OnModuleLoad: IRegisteredEvent
    {
        private readonly IDataContext _db;

        private bool _isSet;

        public OnModuleLoad(IDataContext db)
        {
            _db = db;
            _isSet = false;
        }

        public void Run()
        {
            Console.WriteLine("IsSet = " + _isSet);

            var record = _db.Single<Plant>("Farming/GetPlantByID", new SqlParameter("@plantID", 2));

            Console.WriteLine("record = " + record.Name);

            _isSet = true;
        }
    }
}
