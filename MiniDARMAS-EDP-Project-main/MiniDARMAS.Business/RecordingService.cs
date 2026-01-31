using MiniDARMAS.Data;
using MiniDARMAS.Models;

namespace MiniDARMAS.Business
{
    public class RecordingService
    {
        private RecordingRepository _recordingRepository;

        public RecordingService()
        {
            _recordingRepository = new RecordingRepository();
        }

        public List<Recording> GetRecordingsByAgendaId(int agendaId)
        {
            return _recordingRepository.GetRecordingsByAgendaId(agendaId);
        }

        public Recording? GetRecordingById(int recordingId)
        {
            return _recordingRepository.GetRecordingById(recordingId);
        }

        public bool CreateRecording(Recording recording)
        {
            if (string.IsNullOrWhiteSpace(recording.AudioFileName) || 
                string.IsNullOrWhiteSpace(recording.AudioFilePath))
                return false;

            return _recordingRepository.CreateRecording(recording);
        }

        public bool DeleteRecording(int recordingId)
        {
            return _recordingRepository.DeleteRecording(recordingId);
        }
    }
}

