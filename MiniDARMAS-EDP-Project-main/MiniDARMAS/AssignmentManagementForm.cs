using System;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class AssignmentManagementForm : Form
    {
        private AssignmentService _assignmentService;
        private RecordingService _recordingService;
        private UserService _userService;
        private MeetingService _meetingService;
        private AgendaService _agendaService;

        public AssignmentManagementForm()
        {
            InitializeComponent();
            _assignmentService = new AssignmentService();
            _recordingService = new RecordingService();
            _userService = new UserService();
            _meetingService = new MeetingService();
            _agendaService = new AgendaService();
            LoadMeetings();
            LoadTranscribers();
        }

        private void LoadMeetings()
        {
            var meetings = _meetingService.GetAllMeetings();
            cmbMeeting.DisplayMember = "MeetingNo";
            cmbMeeting.ValueMember = "MeetingId";
            cmbMeeting.DataSource = meetings;
            
            if (meetings.Count > 0)
            {
                cmbMeeting.SelectedIndex = 0;
                LoadAgendas();
            }
        }

        private void LoadAgendas()
        {
            int meetingId = -1;
            if (cmbMeeting.SelectedValue is int id)
            {
                meetingId = id;
            }
            else if (cmbMeeting.SelectedValue is Meeting meeting)
            {
                meetingId = meeting.MeetingId;
            }

            if (meetingId == -1) return;

            var agendas = _agendaService.GetAgendasByMeetingId(meetingId);
            cmbAgenda.DisplayMember = "AgendaTitle";
            cmbAgenda.ValueMember = "AgendaId";
            cmbAgenda.DataSource = agendas;
            
            if (agendas.Count > 0)
            {
                cmbAgenda.SelectedIndex = 0;
                LoadRecordings();
            }
        }

        private void LoadRecordings()
        {
            int agendaId = -1;
            if (cmbAgenda.SelectedValue is int id)
            {
                agendaId = id;
            }
            else if (cmbAgenda.SelectedValue is Agenda agenda)
            {
                agendaId = agenda.AgendaId;
            }

            if (agendaId == -1) return;

            var recordings = _recordingService.GetRecordingsByAgendaId(agendaId);
            cmbRecording.DisplayMember = "AudioFileName";
            cmbRecording.ValueMember = "RecordingId";
            cmbRecording.DataSource = recordings;
        }

        private void LoadTranscribers()
        {
            var users = _userService.GetAllUsers();
            var transcribers = users.Where(u => u.Role == "Transcriber" && u.IsActive).ToList();
            cmbTranscriber.DisplayMember = "FullName";
            cmbTranscriber.ValueMember = "UserId";
            cmbTranscriber.DataSource = transcribers;
        }

        private void cmbMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAgendas();
        }

        private void cmbAgenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecordings();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cmbRecording.SelectedValue == null || cmbTranscriber.SelectedValue == null)
            {
                MessageBox.Show("Please select both recording and transcriber.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Assignment assignment = new Assignment
            {
                RecordingId = Convert.ToInt32(cmbRecording.SelectedValue),
                TranscriberId = Convert.ToInt32(cmbTranscriber.SelectedValue),
                Status = cmbStatus.SelectedItem?.ToString() ?? "Assigned"
            };

            if (_assignmentService.CreateAssignment(assignment))
            {
                MessageBox.Show("Assignment created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecordings();
            }
            else
            {
                MessageBox.Show("Failed to create assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

