namespace MiniDARMAS.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public int MeetingId { get; set; }
        public string AgendaTitle { get; set; } = string.Empty;
        public string Office { get; set; } = string.Empty;
        public string? SupportingDocument { get; set; }
    }
}

