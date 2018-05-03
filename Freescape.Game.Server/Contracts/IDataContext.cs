using System.Collections.Generic;
using System.Data.SqlClient;

namespace Freescape.Game.Server.Contracts
{
    internal interface IDataContext
    {
        List<T> List<T>(string sqlFilePath, params SqlParameter[] args);
        T Single<T>(string sqlFilePath, params SqlParameter[] args);
    }
}
