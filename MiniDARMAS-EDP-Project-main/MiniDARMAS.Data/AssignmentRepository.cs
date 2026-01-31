using System.Data;
using System.Data.SqlClient;
using MiniDARMAS.Models;

namespace MiniDARMAS.Data
{
    public class AssignmentRepository
    {
        public List<Assignment> GetAssignmentsByTranscriberId(int transcriberId)
        {
            List<Assignment> assignments = new List<Assignment>();
            string query = @"SELECT a.AssignmentId, a.RecordingId, a.TranscriberId, a.Status, a.AssignedDate,
                           m.MeetingNo, ag.AgendaTitle, r.AudioFileName, u.FullName as TranscriberName
                           FROM Assignments a
                           INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                           INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                           INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                           INNER JOIN Users u ON a.TranscriberId = u.UserId
                           WHERE a.TranscriberId = @TranscriberId";
            
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@TranscriberId", transcriberId));

            foreach (DataRow row in dt.Rows)
            {
                assignments.Add(new Assignment
                {
                    AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                    RecordingId = Convert.ToInt32(row["RecordingId"]),
                    TranscriberId = Convert.ToInt32(row["TranscriberId"]),
                    Status = row["Status"].ToString() ?? "",
                    AssignedDate = Convert.ToDateTime(row["AssignedDate"]),
                    MeetingNo = row["MeetingNo"].ToString(),
                    AgendaTitle = row["AgendaTitle"].ToString(),
                    AudioFileName = row["AudioFileName"].ToString(),
                    TranscriberName = row["TranscriberName"].ToString()
                });
            }
            return assignments;
        }

        public bool CreateAssignment(Assignment assignment)
        {
            string query = "INSERT INTO Assignments (RecordingId, TranscriberId, Status) " +
                          "VALUES (@RecordingId, @TranscriberId, @Status)";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@RecordingId", assignment.RecordingId),
                new SqlParameter("@TranscriberId", assignment.TranscriberId),
                new SqlParameter("@Status", assignment.Status));

            return result > 0;
        }

        public bool UpdateAssignmentStatus(int assignmentId, string status)
        {
            string query = "UPDATE Assignments SET Status = @Status WHERE AssignmentId = @AssignmentId";
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@AssignmentId", assignmentId),
                new SqlParameter("@Status", status));
            return result > 0;
        }

        public Assignment? GetAssignmentById(int assignmentId)
        {
            string query = @"SELECT a.AssignmentId, a.RecordingId, a.TranscriberId, a.Status, a.AssignedDate,
                           m.MeetingNo, ag.AgendaTitle, r.AudioFileName, u.FullName as TranscriberName
                           FROM Assignments a
                           INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                           INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                           INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                           INNER JOIN Users u ON a.TranscriberId = u.UserId
                           WHERE a.AssignmentId = @AssignmentId";
            
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@AssignmentId", assignmentId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Assignment
                {
                    AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                    RecordingId = Convert.ToInt32(row["RecordingId"]),
                    TranscriberId = Convert.ToInt32(row["TranscriberId"]),
                    Status = row["Status"].ToString() ?? "",
                    AssignedDate = Convert.ToDateTime(row["AssignedDate"]),
                    MeetingNo = row["MeetingNo"].ToString(),
                    AgendaTitle = row["AgendaTitle"].ToString(),
                    AudioFileName = row["AudioFileName"].ToString(),
                    TranscriberName = row["TranscriberName"].ToString()
                };
            }
            return null;
        }
    }
}

