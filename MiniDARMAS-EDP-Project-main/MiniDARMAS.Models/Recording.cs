namespace MiniDARMAS.Models
{
    public class Recording
    {
        public int RecordingId { get; set; }
        public int AgendaId { get; set; }
        public string AudioFileName { get; set; } = string.Empty;
        public string AudioFilePath { get; set; } = string.Empty;
        public DateTime UploadedDate { get; set; }
    }
}

