using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Extensions;
using Data;
using NLog;

namespace Database
{
    public class Repository
    {
        private const string SERVER = "TSTEODSERVER01V";
        private const string DATABASE = "testy";
        private const string USER = "Patryk_workshop";
        private const string PASSWORD = "12345678";

        private const string CONNECTION_STRING = "Server=" + SERVER + ";Database=" + DATABASE + "; Integrated Security=true";

        public static T FillObject<T>(string storedProcedure, object args) where T : class, new()
        {
            T result = default(T);
            var enumerable = ExecQuery<T>(storedProcedure, args);

            if (enumerable.HasValue())
                result = enumerable.AsEnumerable().FirstOrDefault();

            return result;
        }

        public static List<T> FillCollection<T>(string storedProcedure, object args) where T : class, new()
        {
            List<T> result = new List<T>();
            var enumerable = ExecQuery<T>(storedProcedure, args);

            if (enumerable.HasValue())
                result = enumerable.AsEnumerable().ToList();

            return result;
        }

        public static DMLResult InsertObject(string storedProcedure, object args)
        {
            return FillObject<DMLResult>(storedProcedure, args);
        }

        private static List<T> ExecQuery<T>(string storedProcedure, object args)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try {
                    return (List<T>)conn.Query<T>(storedProcedure, args, commandType: CommandType.StoredProcedure);
                }
                catch (SqlException e)
                {
                    Logger logger = LogManager.GetCurrentClassLogger();
                    logger.Warn(e.Message);
                }
                return null;
            }
        }

    }
}
