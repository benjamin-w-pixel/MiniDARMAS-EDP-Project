namespace MiniDARMAS.Models
{
    public class Transcription
    {
        public int TranscriptionId { get; set; }
        public int AssignmentId { get; set; }
        public string TranscriptionText { get; set; } = string.Empty;
        public string Status { get; set; } = "Submitted";
        public string? EditorComments { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public int? ReviewedBy { get; set; }
        
        // Navigation properties
        public string? MeetingNo { get; set; }
        public string? AgendaTitle { get; set; }
        public string? TranscriberName { get; set; }
    }
}

