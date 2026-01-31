using System;
using System.Data.SqlClient;
using MiniDARMAS.Data;

namespace MiniDARMAS.Business
{
    public class Logger
    {
        public void LogActivity(int userId, string type, string description)
        {
            try
            {
                string query = "INSERT INTO ActivityLogs (UserId, ActivityType, Description, LogDate) VALUES (@UserId, @Type, @Desc, @Date)";
                SqlParameter[] paras = {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@Type", type),
                    new SqlParameter("@Desc", description),
                    new SqlParameter("@Date", DateTime.Now)
                };
                DatabaseHelper.ExecuteNonQuery(query, paras);
            }
            catch { /* Ignore logging errors for now */ }
        }
    }
}
