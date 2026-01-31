using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class RecordingManagementForm : Form
    {
        private RecordingService _recordingService;
        private AgendaService _agendaService;
        private MeetingService _meetingService;
        private Recording? _selectedRecording;

        public RecordingManagementForm()
        {
            InitializeComponent();
            _recordingService = new RecordingService();
            _agendaService = new AgendaService();
            _meetingService = new MeetingService();
            LoadMeetings();
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
            dgvRecordings.DataSource = recordings;
            dgvRecordings.Columns["RecordingId"].Visible = false;
            dgvRecordings.Columns["AgendaId"].Visible = false;
        }

        private void cmbMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAgendas();
            ClearForm();
        }

        private void cmbAgenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecordings();
            ClearForm();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.m4a;*.wma|All Files|*.*";
            openFileDialog.Title = "Select Audio File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtAudioFilePath.Text = openFileDialog.FileName;
                txtAudioFileName.Text = Path.GetFileName(openFileDialog.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (cmbAgenda.SelectedValue == null) return;

            Recording recording = new Recording
            {
                AgendaId = Convert.ToInt32(cmbAgenda.SelectedValue),
                AudioFileName = txtAudioFileName.Text.Trim(),
                AudioFilePath = txtAudioFilePath.Text.Trim()
            };

            if (_recordingService.CreateRecording(recording))
            {
                MessageBox.Show("Recording added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecordings();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to add recording.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRecording == null)
            {
                MessageBox.Show("Please select a recording to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete this recording?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_recordingService.DeleteRecording(_selectedRecording.RecordingId))
                {
                    MessageBox.Show("Recording deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecordings();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete recording.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRecordings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecordings.SelectedRows.Count > 0)
            {
                int recordingId = Convert.ToInt32(dgvRecordings.SelectedRows[0].Cells["RecordingId"].Value);
                int agendaId = Convert.ToInt32(cmbAgenda.SelectedValue);
                var recordings = _recordingService.GetRecordingsByAgendaId(agendaId);
                _selectedRecording = recordings.FirstOrDefault(r => r.RecordingId == recordingId);

                if (_selectedRecording != null)
                {
                    txtAudioFileName.Text = _selectedRecording.AudioFileName;
                    txtAudioFilePath.Text = _selectedRecording.AudioFilePath;
                }
            }
        }

        private bool ValidateInput()
        {
            if (cmbAgenda.SelectedValue == null)
            {
                MessageBox.Show("Please select an agenda.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAudioFileName.Text))
            {
                MessageBox.Show("Please select an audio file.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtAudioFileName.Clear();
            txtAudioFilePath.Clear();
            _selectedRecording = null;
        }
    }
}

