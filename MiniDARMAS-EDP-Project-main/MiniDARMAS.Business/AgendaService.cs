using MiniDARMAS.Data;
using MiniDARMAS.Models;

namespace MiniDARMAS.Business
{
    public class AgendaService
    {
        private AgendaRepository _agendaRepository;

        public AgendaService()
        {
            _agendaRepository = new AgendaRepository();
        }

        public List<Agenda> GetAgendasByMeetingId(int meetingId)
        {
            return _agendaRepository.GetAgendasByMeetingId(meetingId);
        }

        public Agenda? GetAgendaById(int agendaId)
        {
            return _agendaRepository.GetAgendaById(agendaId);
        }

        public bool CreateAgenda(Agenda agenda)
        {
            if (string.IsNullOrWhiteSpace(agenda.AgendaTitle) || 
                string.IsNullOrWhiteSpace(agenda.Office))
                return false;

            return _agendaRepository.CreateAgenda(agenda);
        }

        public bool UpdateAgenda(Agenda agenda)
        {
            if (string.IsNullOrWhiteSpace(agenda.AgendaTitle) || 
                string.IsNullOrWhiteSpace(agenda.Office))
                return false;

            return _agendaRepository.UpdateAgenda(agenda);
        }

        public bool DeleteAgenda(int agendaId)
        {
            return _agendaRepository.DeleteAgenda(agendaId);
        }
    }
}

