namespace MiniDARMAS.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string MeetingNo { get; set; } = string.Empty;
        public DateTime MeetingDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Chairperson { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsFinalApproved { get; set; }
    }
}

