namespace MiniDARMAS.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int RecordingId { get; set; }
        public int TranscriberId { get; set; }
        public string Status { get; set; } = "Assigned";
        public DateTime AssignedDate { get; set; }
        
        // Navigation properties (for display)
        public string? MeetingNo { get; set; }
        public string? AgendaTitle { get; set; }
        public string? AudioFileName { get; set; }
        public string? TranscriberName { get; set; }
    }
}

