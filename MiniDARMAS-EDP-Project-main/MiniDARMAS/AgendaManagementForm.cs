using System;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class AgendaManagementForm : Form
    {
        private AgendaService _agendaService;
        private MeetingService _meetingService;
        private Agenda? _selectedAgenda;

        public AgendaManagementForm()
        {
            InitializeComponent();
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
            dgvAgendas.DataSource = agendas;
            dgvAgendas.Columns["AgendaId"].Visible = false;
            dgvAgendas.Columns["MeetingId"].Visible = false;
        }

        private void cmbMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAgendas();
            ClearForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnSave.Text = "Add Agenda";
            _selectedAgenda = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            if (cmbMeeting.SelectedValue == null) return;

            Agenda agenda = new Agenda
            {
                MeetingId = Convert.ToInt32(cmbMeeting.SelectedValue),
                AgendaTitle = txtAgendaTitle.Text.Trim(),
                Office = txtOffice.Text.Trim(),
                SupportingDocument = txtSupportingDocument.Text.Trim()
            };

            bool success = false;
            if (_selectedAgenda == null)
            {
                if (_agendaService.CreateAgenda(agenda))
                {
                    MessageBox.Show("Agenda created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show("Failed to create agenda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                agenda.AgendaId = _selectedAgenda.AgendaId;
                agenda.MeetingId = _selectedAgenda.MeetingId;
                if (_agendaService.UpdateAgenda(agenda))
                {
                    MessageBox.Show("Agenda updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show("Failed to update agenda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                LoadAgendas();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedAgenda == null)
            {
                MessageBox.Show("Please select an agenda to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete this agenda?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_agendaService.DeleteAgenda(_selectedAgenda.AgendaId))
                {
                    MessageBox.Show("Agenda deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAgendas();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete agenda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvAgendas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgendas.SelectedRows.Count > 0)
            {
                int agendaId = Convert.ToInt32(dgvAgendas.SelectedRows[0].Cells["AgendaId"].Value);
                int meetingId = Convert.ToInt32(cmbMeeting.SelectedValue);
                var agendas = _agendaService.GetAgendasByMeetingId(meetingId);
                _selectedAgenda = agendas.FirstOrDefault(a => a.AgendaId == agendaId);

                if (_selectedAgenda != null)
                {
                    txtAgendaTitle.Text = _selectedAgenda.AgendaTitle;
                    txtOffice.Text = _selectedAgenda.Office;
                    txtSupportingDocument.Text = _selectedAgenda.SupportingDocument ?? "";
                    btnSave.Text = "Update Agenda";
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtAgendaTitle.Text))
            {
                MessageBox.Show("Please enter agenda title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtOffice.Text))
            {
                MessageBox.Show("Please enter office name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtAgendaTitle.Clear();
            txtOffice.Clear();
            txtSupportingDocument.Clear();
            _selectedAgenda = null;
        }
    }
}

