using System.Data;
using System.Data.SqlClient;
using MiniDARMAS.Models;

namespace MiniDARMAS.Data
{
    public class MeetingRepository
    {
        public List<Meeting> GetAllMeetings()
        {
            List<Meeting> meetings = new List<Meeting>();
            string query = "SELECT MeetingId, MeetingNo, MeetingDate, Location, Chairperson, CreatedBy, CreatedDate, IsFinalApproved FROM Meetings";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                meetings.Add(new Meeting
                {
                    MeetingId = Convert.ToInt32(row["MeetingId"]),
                    MeetingNo = row["MeetingNo"].ToString() ?? "",
                    MeetingDate = Convert.ToDateTime(row["MeetingDate"]),
                    Location = row["Location"].ToString() ?? "",
                    Chairperson = row["Chairperson"].ToString() ?? "",
                    CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    IsFinalApproved = Convert.ToBoolean(row["IsFinalApproved"])
                });
            }
            return meetings;
        }

        public Meeting? GetMeetingById(int meetingId)
        {
            string query = "SELECT MeetingId, MeetingNo, MeetingDate, Location, Chairperson, CreatedBy, CreatedDate, IsFinalApproved " +
                          "FROM Meetings WHERE MeetingId = @MeetingId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MeetingId", meetingId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Meeting
                {
                    MeetingId = Convert.ToInt32(row["MeetingId"]),
                    MeetingNo = row["MeetingNo"].ToString() ?? "",
                    MeetingDate = Convert.ToDateTime(row["MeetingDate"]),
                    Location = row["Location"].ToString() ?? "",
                    Chairperson = row["Chairperson"].ToString() ?? "",
                    CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    IsFinalApproved = Convert.ToBoolean(row["IsFinalApproved"])
                };
            }
            return null;
        }

        public bool CreateMeeting(Meeting meeting)
        {
            string query = "INSERT INTO Meetings (MeetingNo, MeetingDate, Location, Chairperson, CreatedBy) " +
                          "VALUES (@MeetingNo, @MeetingDate, @Location, @Chairperson, @CreatedBy)";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@MeetingNo", meeting.MeetingNo),
                new SqlParameter("@MeetingDate", meeting.MeetingDate),
                new SqlParameter("@Location", meeting.Location),
                new SqlParameter("@Chairperson", meeting.Chairperson),
                new SqlParameter("@CreatedBy", meeting.CreatedBy));

            return result > 0;
        }

        public bool UpdateMeeting(Meeting meeting)
        {
            string query = "UPDATE Meetings SET MeetingNo = @MeetingNo, MeetingDate = @MeetingDate, " +
                          "Location = @Location, Chairperson = @Chairperson " +
                          "WHERE MeetingId = @MeetingId";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@MeetingId", meeting.MeetingId),
                new SqlParameter("@MeetingNo", meeting.MeetingNo),
                new SqlParameter("@MeetingDate", meeting.MeetingDate),
                new SqlParameter("@Location", meeting.Location),
                new SqlParameter("@Chairperson", meeting.Chairperson));

            return result > 0;
        }

        public bool DeleteMeeting(int meetingId)
        {
            string query = "DELETE FROM Meetings WHERE MeetingId = @MeetingId";
            int result = DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MeetingId", meetingId));
            return result > 0;
        }

        public bool IsMeetingNoExists(string meetingNo, int? excludeMeetingId = null)
        {
            string query = "SELECT COUNT(*) FROM Meetings WHERE MeetingNo = @MeetingNo";
            if (excludeMeetingId.HasValue)
            {
                query += " AND MeetingId != @MeetingId";
            }
            
            SqlParameter[] parameters = excludeMeetingId.HasValue
                ? new SqlParameter[] {
                    new SqlParameter("@MeetingNo", meetingNo),
                    new SqlParameter("@MeetingId", excludeMeetingId.Value)
                }
                : new SqlParameter[] { new SqlParameter("@MeetingNo", meetingNo) };

            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool MarkMeetingAsFinalApproved(int meetingId)
        {
            string query = "UPDATE Meetings SET IsFinalApproved = 1 WHERE MeetingId = @MeetingId";
            int result = DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@MeetingId", meetingId));
            return result > 0;
        }
    }
}

