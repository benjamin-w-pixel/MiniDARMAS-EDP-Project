using System.Data;
using System.Data.SqlClient;
using MiniDARMAS.Models;

namespace MiniDARMAS.Data
{
    public class TranscriptionRepository
    {
        private DateTime EnsureValidSqlDate(DateTime date)
        {
            DateTime minSqlDate = new DateTime(1753, 1, 1);
            return date < minSqlDate ? DateTime.Now : date;
        }

        public bool CreateOrUpdateTranscription(Transcription transcription)
        {
            // Check if transcription exists
            string checkQuery = "SELECT COUNT(*) FROM Transcriptions WHERE AssignmentId = @AssignmentId";
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery,
                new SqlParameter("@AssignmentId", transcription.AssignmentId)));

            if (count > 0)
            {
                // Update existing
                string updateQuery = "UPDATE Transcriptions SET TranscriptionText = @TranscriptionText, " +
                                    "Status = @Status, SubmittedDate = @SubmittedDate " +
                                    "WHERE AssignmentId = @AssignmentId";
                
                int result = DatabaseHelper.ExecuteNonQuery(updateQuery,
                    new SqlParameter("@AssignmentId", transcription.AssignmentId),
                    new SqlParameter("@TranscriptionText", transcription.TranscriptionText),
                    new SqlParameter("@Status", transcription.Status),
                    new SqlParameter("@SubmittedDate", EnsureValidSqlDate(transcription.SubmittedDate)));

                return result > 0;
            }
            else
            {
                // Insert new
                string insertQuery = "INSERT INTO Transcriptions (AssignmentId, TranscriptionText, Status, SubmittedDate) " +
                                   "VALUES (@AssignmentId, @TranscriptionText, @Status, @SubmittedDate)";
                
                int result = DatabaseHelper.ExecuteNonQuery(insertQuery,
                    new SqlParameter("@AssignmentId", transcription.AssignmentId),
                    new SqlParameter("@TranscriptionText", transcription.TranscriptionText),
                    new SqlParameter("@Status", transcription.Status),
                    new SqlParameter("@SubmittedDate", EnsureValidSqlDate(transcription.SubmittedDate)));

                return result > 0;
            }
        }

        public Transcription? GetTranscriptionByAssignmentId(int assignmentId)
        {
            string query = @"SELECT t.TranscriptionId, t.AssignmentId, t.TranscriptionText, t.Status, 
                           t.EditorComments, t.SubmittedDate, t.ReviewedDate, t.ReviewedBy,
                           m.MeetingNo, ag.AgendaTitle, u.FullName as TranscriberName
                           FROM Transcriptions t
                           INNER JOIN Assignments a ON t.AssignmentId = a.AssignmentId
                           INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                           INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                           INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                           INNER JOIN Users u ON a.TranscriberId = u.UserId
                           WHERE t.AssignmentId = @AssignmentId";
            
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@AssignmentId", assignmentId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Transcription
                {
                    TranscriptionId = Convert.ToInt32(row["TranscriptionId"]),
                    AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                    TranscriptionText = row["TranscriptionText"].ToString() ?? "",
                    Status = row["Status"].ToString() ?? "",
                    EditorComments = row["EditorComments"]?.ToString(),
                    SubmittedDate = Convert.ToDateTime(row["SubmittedDate"]),
                    ReviewedDate = row["ReviewedDate"] != DBNull.Value ? Convert.ToDateTime(row["ReviewedDate"]) : null,
                    ReviewedBy = row["ReviewedBy"] != DBNull.Value ? Convert.ToInt32(row["ReviewedBy"]) : null,
                    MeetingNo = row["MeetingNo"].ToString(),
                    AgendaTitle = row["AgendaTitle"].ToString(),
                    TranscriberName = row["TranscriberName"].ToString()
                };
            }
            return null;
        }

        public List<Transcription> GetTranscriptionsByStatus(string status)
        {
            List<Transcription> transcriptions = new List<Transcription>();
            string query = @"SELECT t.TranscriptionId, t.AssignmentId, t.TranscriptionText, t.Status, 
                           t.EditorComments, t.SubmittedDate, t.ReviewedDate, t.ReviewedBy,
                           m.MeetingNo, ag.AgendaTitle, u.FullName as TranscriberName
                           FROM Transcriptions t
                           INNER JOIN Assignments a ON t.AssignmentId = a.AssignmentId
                           INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                           INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                           INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                           INNER JOIN Users u ON a.TranscriberId = u.UserId
                           WHERE t.Status = @Status";
            
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@Status", status));

            foreach (DataRow row in dt.Rows)
            {
                transcriptions.Add(new Transcription
                {
                    TranscriptionId = Convert.ToInt32(row["TranscriptionId"]),
                    AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                    TranscriptionText = row["TranscriptionText"].ToString() ?? "",
                    Status = row["Status"].ToString() ?? "",
                    EditorComments = row["EditorComments"]?.ToString(),
                    SubmittedDate = Convert.ToDateTime(row["SubmittedDate"]),
                    ReviewedDate = row["ReviewedDate"] != DBNull.Value ? Convert.ToDateTime(row["ReviewedDate"]) : null,
                    ReviewedBy = row["ReviewedBy"] != DBNull.Value ? Convert.ToInt32(row["ReviewedBy"]) : null,
                    MeetingNo = row["MeetingNo"].ToString(),
                    AgendaTitle = row["AgendaTitle"].ToString(),
                    TranscriberName = row["TranscriberName"].ToString()
                });
            }
            return transcriptions;
        }

        public bool UpdateTranscriptionStatus(int transcriptionId, string status, string? comments, int? reviewedBy)
        {
            string query = "UPDATE Transcriptions SET Status = @Status, EditorComments = @EditorComments, " +
                          "ReviewedDate = @ReviewedDate, ReviewedBy = @ReviewedBy " +
                          "WHERE TranscriptionId = @TranscriptionId";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@TranscriptionId", transcriptionId),
                new SqlParameter("@Status", status),
                new SqlParameter("@EditorComments", (object?)comments ?? DBNull.Value),
                new SqlParameter("@ReviewedDate", EnsureValidSqlDate(DateTime.Now)),
                new SqlParameter("@ReviewedBy", (object?)reviewedBy ?? DBNull.Value));

            return result > 0;
        }

        public List<Transcription> GetApprovedTranscriptionsByMeetingId(int meetingId)
        {
            List<Transcription> transcriptions = new List<Transcription>();
            string query = @"SELECT t.TranscriptionId, t.AssignmentId, t.TranscriptionText, t.Status, 
                           t.EditorComments, t.SubmittedDate, t.ReviewedDate, t.ReviewedBy,
                           m.MeetingNo, ag.AgendaTitle, u.FullName as TranscriberName
                           FROM Transcriptions t
                           INNER JOIN Assignments a ON t.AssignmentId = a.AssignmentId
                           INNER JOIN Recordings r ON a.RecordingId = r.RecordingId
                           INNER JOIN Agendas ag ON r.AgendaId = ag.AgendaId
                           INNER JOIN Meetings m ON ag.MeetingId = m.MeetingId
                           LEFT JOIN Users u ON a.TranscriberId = u.UserId
                           WHERE m.MeetingId = @MeetingId AND UPPER(t.Status) = 'APPROVED'
                           ORDER BY ag.AgendaId";
            
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MeetingId", meetingId));

            foreach (DataRow row in dt.Rows)
            {
                transcriptions.Add(new Transcription
                {
                    TranscriptionId = Convert.ToInt32(row["TranscriptionId"]),
                    AssignmentId = Convert.ToInt32(row["AssignmentId"]),
                    TranscriptionText = row["TranscriptionText"].ToString() ?? "",
                    Status = row["Status"].ToString() ?? "",
                    EditorComments = row["EditorComments"]?.ToString(),
                    SubmittedDate = Convert.ToDateTime(row["SubmittedDate"]),
                    ReviewedDate = row["ReviewedDate"] != DBNull.Value ? Convert.ToDateTime(row["ReviewedDate"]) : null,
                    ReviewedBy = row["ReviewedBy"] != DBNull.Value ? Convert.ToInt32(row["ReviewedBy"]) : null,
                    MeetingNo = row["MeetingNo"].ToString(),
                    AgendaTitle = row["AgendaTitle"].ToString(),
                    TranscriberName = row["TranscriberName"].ToString()
                });
            }
            return transcriptions;
        }
    }
}

