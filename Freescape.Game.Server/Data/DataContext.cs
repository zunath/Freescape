using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using Dapper;
using Freescape.Game.Server.Contracts;

namespace Freescape.Game.Server.Data
{
    internal class DataContext: IDisposable, IDataContext
    {
        private readonly IDbConnection _connection;

        public DataContext()
        {
            var connectionString = BuildConnectionString();
            
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }
        
        private static string BuildConnectionString()
        {
            var ipAddress = Environment.GetEnvironmentVariable("SQL_SERVER_IP_ADDRESS");
            var username = Environment.GetEnvironmentVariable("SQL_SERVER_USERNAME");
            var password = Environment.GetEnvironmentVariable("SQL_SERVER_PASSWORD");
            var database = Environment.GetEnvironmentVariable("SQL_SERVER_DATABASE");

            return $"server={ipAddress};database={database};user id={username};password={password};Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False";
        }

        private static string ReadSQLScript(string path)
        {
            const string prefix = "Freescape.Game.Server.Data.SQL.";
            path = path.Replace(".sql", "");
            path = prefix + path.Replace("/", ".") + ".sql";

            string sql;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path))
            {
                if (stream == null)
                {
                    throw new Exception("Unable to locate SQL script: " + path);
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    sql = reader.ReadToEnd();
                }
            }

            return sql;
        }

        private static DynamicParameters BuildParameters(SqlParameter[] parameters)
        {
            var args = new DynamicParameters(new { });
            foreach (var parm in parameters)
            {
                args.Add(parm.ParameterName, parm.Value);
            }

            return args;
        }

        public List<T> List<T>(string sqlFilePath, params SqlParameter[] parameters)
        {
            string sql = ReadSQLScript(sqlFilePath);
            return _connection.Query<T>(sql, BuildParameters(parameters)).ToList();
        }

        public T Single<T>(string sqlFilePath, params SqlParameter[] parameters)
        {
            string sql = ReadSQLScript(sqlFilePath);
            return _connection.QuerySingle<T>(sql, BuildParameters(parameters));
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
