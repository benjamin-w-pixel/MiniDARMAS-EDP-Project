using System;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class MeetingManagementForm : Form
    {
        private MeetingService _meetingService;
        private Meeting? _selectedMeeting;

        public MeetingManagementForm()
        {
            InitializeComponent();
            _meetingService = new MeetingService();
            LoadMeetings();
        }

        private void LoadMeetings()
        {
            var meetings = _meetingService.GetAllMeetings();
            dgvMeetings.DataSource = meetings;
            dgvMeetings.Columns["MeetingId"].Visible = false;
            dgvMeetings.Columns["CreatedBy"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnSave.Text = "Add Meeting";
            _selectedMeeting = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            Meeting meeting = new Meeting
            {
                MeetingNo = txtMeetingNo.Text.Trim(),
                MeetingDate = dtpMeetingDate.Value,
                Location = txtLocation.Text.Trim(),
                Chairperson = txtChairperson.Text.Trim(),
                CreatedBy = LoginForm.CurrentUser?.UserId ?? 0
            };

            bool success = false;
            if (_selectedMeeting == null)
            {
                if (_meetingService.CreateMeeting(meeting))
                {
                    MessageBox.Show("Meeting created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show("Failed to create meeting. Meeting number may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                meeting.MeetingId = _selectedMeeting.MeetingId;
                meeting.CreatedBy = _selectedMeeting.CreatedBy;
                if (_meetingService.UpdateMeeting(meeting))
                {
                    MessageBox.Show("Meeting updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show("Failed to update meeting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                LoadMeetings();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMeeting == null)
            {
                MessageBox.Show("Please select a meeting to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete meeting '{_selectedMeeting.MeetingNo}'?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_meetingService.DeleteMeeting(_selectedMeeting.MeetingId))
                {
                    MessageBox.Show("Meeting deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMeetings();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete meeting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvMeetings_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMeetings.SelectedRows.Count > 0)
            {
                int meetingId = Convert.ToInt32(dgvMeetings.SelectedRows[0].Cells["MeetingId"].Value);
                var meetings = _meetingService.GetAllMeetings();
                _selectedMeeting = meetings.FirstOrDefault(m => m.MeetingId == meetingId);

                if (_selectedMeeting != null)
                {
                    txtMeetingNo.Text = _selectedMeeting.MeetingNo;
                    dtpMeetingDate.Value = _selectedMeeting.MeetingDate;
                    txtLocation.Text = _selectedMeeting.Location;
                    txtChairperson.Text = _selectedMeeting.Chairperson;
                    btnSave.Text = "Update Meeting";
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMeetingNo.Text))
            {
                MessageBox.Show("Please enter meeting number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter location.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtChairperson.Text))
            {
                MessageBox.Show("Please enter chairperson name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtMeetingNo.Clear();
            dtpMeetingDate.Value = DateTime.Now;
            txtLocation.Clear();
            txtChairperson.Clear();
            _selectedMeeting = null;
        }
    }
}

