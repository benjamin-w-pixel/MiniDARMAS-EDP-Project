using System.Data;
using System.Data.SqlClient;
using MiniDARMAS.Models;

namespace MiniDARMAS.Data
{
    public class AgendaRepository
    {
        public List<Agenda> GetAgendasByMeetingId(int meetingId)
        {
            List<Agenda> agendas = new List<Agenda>();
            string query = "SELECT AgendaId, MeetingId, AgendaTitle, Office, SupportingDocument " +
                          "FROM Agendas WHERE MeetingId = @MeetingId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@MeetingId", meetingId));

            foreach (DataRow row in dt.Rows)
            {
                agendas.Add(new Agenda
                {
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    MeetingId = Convert.ToInt32(row["MeetingId"]),
                    AgendaTitle = row["AgendaTitle"].ToString() ?? "",
                    Office = row["Office"].ToString() ?? "",
                    SupportingDocument = row["SupportingDocument"]?.ToString()
                });
            }
            return agendas;
        }

        public Agenda? GetAgendaById(int agendaId)
        {
            string query = "SELECT AgendaId, MeetingId, AgendaTitle, Office, SupportingDocument " +
                          "FROM Agendas WHERE AgendaId = @AgendaId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new SqlParameter("@AgendaId", agendaId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Agenda
                {
                    AgendaId = Convert.ToInt32(row["AgendaId"]),
                    MeetingId = Convert.ToInt32(row["MeetingId"]),
                    AgendaTitle = row["AgendaTitle"].ToString() ?? "",
                    Office = row["Office"].ToString() ?? "",
                    SupportingDocument = row["SupportingDocument"]?.ToString()
                };
            }
            return null;
        }

        public bool CreateAgenda(Agenda agenda)
        {
            string query = "INSERT INTO Agendas (MeetingId, AgendaTitle, Office, SupportingDocument) " +
                          "VALUES (@MeetingId, @AgendaTitle, @Office, @SupportingDocument)";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@MeetingId", agenda.MeetingId),
                new SqlParameter("@AgendaTitle", agenda.AgendaTitle),
                new SqlParameter("@Office", agenda.Office),
                new SqlParameter("@SupportingDocument", (object?)agenda.SupportingDocument ?? DBNull.Value));

            return result > 0;
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            string query = "UPDATE Agendas SET AgendaTitle = @AgendaTitle, Office = @Office, " +
                          "SupportingDocument = @SupportingDocument WHERE AgendaId = @AgendaId";
            
            int result = DatabaseHelper.ExecuteNonQuery(query,
                new SqlParameter("@AgendaId", agenda.AgendaId),
                new SqlParameter("@AgendaTitle", agenda.AgendaTitle),
                new SqlParameter("@Office", agenda.Office),
                new SqlParameter("@SupportingDocument", (object?)agenda.SupportingDocument ?? DBNull.Value));

            return result > 0;
        }

        public bool DeleteAgenda(int agendaId)
        {
            string query = "DELETE FROM Agendas WHERE AgendaId = @AgendaId";
            int result = DatabaseHelper.ExecuteNonQuery(query, new SqlParameter("@AgendaId", agendaId));
            return result > 0;
        }
    }
}

