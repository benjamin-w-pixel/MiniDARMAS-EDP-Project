using System.Data;
using System.Data.SqlClient;
using MiniDARMAS.Models;

namespace MiniDARMAS.Data
{
    public class RecordingRepository
    {
        public List<Recording> GetRecordingsByAgendaId(int agendaId)
        {
            List<Recording> recordings = new List<Recording>();
            string query = "SELECT RecordingId, AgendaId, AudioFileName, AudioFilePath, UploadedDate " +
                          "FROM Recordings WHERE AgendaId = @AgendaId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@AgendaId", agendaId));

            foreach (DataRow row in dt.Rows)
            {
                recordings.Add(new Recording
                {
                    RecordingId = Convert.ToInt32(row["RecordingId"]),
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    AudioFileName = row["AudioFileName"].ToString() ?? "",
                    AudioFilePath = row["AudioFilePath"].ToString() ?? "",
                    UploadedDate = Convert.ToDateTime(row["UploadedDate"])
                });
            }
            return recordings;
        }

        public Recording? GetRecordingById(int recordingId)
        {
            string query = "SELECT RecordingId, AgendaId, AudioFileName, AudioFilePath, UploadedDate " +
                          "FROM Recordings WHERE RecordingId = @RecordingId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@RecordingId", recordingId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Recording
                {
                    RecordingId = Convert.ToInt32(row["RecordingId"]),
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    AudioFileName = row["AudioFileName"].ToString() ?? "",
                    AudioFilePath = row["AudioFilePath"].ToString() ?? "",
                    UploadedDate = Convert.ToDateTime(row["UploadedDate"])
                };
            }
            return null;
        }

        public bool CreateRecording(Recording recording)
        {
            string query = "INSERT INTO Recordings (AgendaId, AudioFileName, AudioFilePath) " +
                          "VALUES (@AgendaId, @AudioFileName, @AudioFilePath)";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@AgendaId", recording.AgendaId),
                new SqlParameter("@AudioFileName", recording.AudioFileName),
                new SqlParameter("@AudioFilePath", recording.AudioFilePath));

            return result > 0;
        }

        public bool DeleteRecording(int recordingId)
        {
            string query = "DELETE FROM Recordings WHERE RecordingId = @RecordingId";
            int result = DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@RecordingId", recordingId));
            return result > 0;
        }
    }
}

