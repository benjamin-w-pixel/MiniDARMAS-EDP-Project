using MiniDARMAS.Data;
using MiniDARMAS.Models;

namespace MiniDARMAS.Business
{
    public class MeetingService
    {
        private MeetingRepository _meetingRepository;

        public MeetingService()
        {
            _meetingRepository = new MeetingRepository();
        }

        public List<Meeting> GetAllMeetings()
        {
            return _meetingRepository.GetAllMeetings();
        }

        public Meeting? GetMeetingById(int meetingId)
        {
            return _meetingRepository.GetMeetingById(meetingId);
        }

        public bool CreateMeeting(Meeting meeting)
        {
            if (string.IsNullOrWhiteSpace(meeting.MeetingNo) || 
                string.IsNullOrWhiteSpace(meeting.Location) || 
                string.IsNullOrWhiteSpace(meeting.Chairperson))
                return false;

            if (_meetingRepository.IsMeetingNoExists(meeting.MeetingNo))
                return false;

            return _meetingRepository.CreateMeeting(meeting);
        }

        public bool UpdateMeeting(Meeting meeting)
        {
            if (string.IsNullOrWhiteSpace(meeting.MeetingNo) || 
                string.IsNullOrWhiteSpace(meeting.Location) || 
                string.IsNullOrWhiteSpace(meeting.Chairperson))
                return false;

            if (_meetingRepository.IsMeetingNoExists(meeting.MeetingNo, meeting.MeetingId))
                return false;

            return _meetingRepository.UpdateMeeting(meeting);
        }

        public bool DeleteMeeting(int meetingId)
        {
            return _meetingRepository.DeleteMeeting(meetingId);
        }

        public bool MarkMeetingAsFinalApproved(int meetingId)
        {
            return _meetingRepository.MarkMeetingAsFinalApproved(meetingId);
        }
    }
}

