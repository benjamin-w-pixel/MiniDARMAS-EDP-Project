using MiniDARMAS.Data;
using MiniDARMAS.Models;

namespace MiniDARMAS.Business
{
    public class TranscriptionService
    {
        private TranscriptionRepository _transcriptionRepository;

        public TranscriptionService()
        {
            _transcriptionRepository = new TranscriptionRepository();
        }

        public bool SaveTranscription(Transcription transcription)
        {
            if (string.IsNullOrWhiteSpace(transcription.TranscriptionText))
                return false;

            return _transcriptionRepository.CreateOrUpdateTranscription(transcription);
        }

        public Transcription? GetTranscriptionByAssignmentId(int assignmentId)
        {
            return _transcriptionRepository.GetTranscriptionByAssignmentId(assignmentId);
        }

        public List<Transcription> GetTranscriptionsByStatus(string status)
        {
            return _transcriptionRepository.GetTranscriptionsByStatus(status);
        }

        public bool UpdateTranscriptionStatus(int transcriptionId, string status, string? comments, int? reviewedBy)
        {
            return _transcriptionRepository.UpdateTranscriptionStatus(transcriptionId, status, comments, reviewedBy);
        }

        public List<Transcription> GetApprovedTranscriptionsByMeetingId(int meetingId)
        {
            return _transcriptionRepository.GetApprovedTranscriptionsByMeetingId(meetingId);
        }
    }
}

