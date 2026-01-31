using System.Data;
using System.Data.SqlClient;
using MiniDARMAS.Models;

namespace MiniDARMAS.Data
{
    public class UserRepository
    {
        public User? Authenticate(string username, string password)
        {
            string query = "SELECT UserId, FullName, Username, Password, Role, IsActive, CreatedDate " +
                          "FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = 1";
            
            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    FullName = row["FullName"].ToString() ?? "",
                    Username = row["Username"].ToString() ?? "",
                    Password = row["Password"].ToString() ?? "",
                    Role = row["Role"].ToString() ?? "",
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                };
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT UserId, FullName, Username, Password, Role, IsActive, CreatedDate FROM Users";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    FullName = row["FullName"].ToString() ?? "",
                    Username = row["Username"].ToString() ?? "",
                    Password = row["Password"].ToString() ?? "",
                    Role = row["Role"].ToString() ?? "",
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                });
            }
            return users;
        }

        public bool CreateUser(User user)
        {
            string query = "INSERT INTO Users (FullName, Username, Password, Role, IsActive) " +
                          "VALUES (@FullName, @Username, @Password, @Role, @IsActive)";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@IsActive", user.IsActive));

            return result > 0;
        }

        public bool UpdateUser(User user)
        {
            string query = "UPDATE Users SET FullName = @FullName, Username = @Username, " +
                          "Password = @Password, Role = @Role, IsActive = @IsActive " +
                          "WHERE UserId = @UserId";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@IsActive", user.IsActive));

            return result > 0;
        }

        public bool DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE UserId = @UserId";
            int result = DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@UserId", userId));
            return result > 0;
        }

        public bool IsUsernameExists(string username, int? excludeUserId = null)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            if (excludeUserId.HasValue)
            {
                query += " AND UserId != @UserId";
            }
            
            SqlParameter[] parameters = excludeUserId.HasValue
                ? new SqlParameter[] {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@UserId", excludeUserId.Value)
                }
                : new SqlParameter[] { new SqlParameter("@Username", username) };

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }
    }
}

