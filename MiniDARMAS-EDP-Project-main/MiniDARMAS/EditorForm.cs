using System;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class EditorForm : Form
    {
        private TranscriptionService _transcriptionService;
        private Transcription? _selectedTranscription;

        public EditorForm()
        {
            InitializeComponent();
            _transcriptionService = new TranscriptionService();
            LoadTranscriptions();
        }

        private void LoadTranscriptions()
        {
            var transcriptions = _transcriptionService.GetTranscriptionsByStatus("Submitted");
            dgvTranscriptions.DataSource = transcriptions;
            dgvTranscriptions.Columns["TranscriptionId"].Visible = false;
            dgvTranscriptions.Columns["AssignmentId"].Visible = false;
            dgvTranscriptions.Columns["ReviewedBy"].Visible = false;
            dgvTranscriptions.Columns["ReviewedDate"].Visible = false;
            dgvTranscriptions.Columns["TranscriberName"].Visible = false;
        }

        private void dgvTranscriptions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTranscriptions.SelectedRows.Count > 0)
            {
                int transcriptionId = Convert.ToInt32(dgvTranscriptions.SelectedRows[0].Cells["TranscriptionId"].Value);
                var transcriptions = _transcriptionService.GetTranscriptionsByStatus("Submitted");
                _selectedTranscription = transcriptions.FirstOrDefault(t => t.TranscriptionId == transcriptionId);

                if (_selectedTranscription != null)
                {
                    lblMeetingNo.Text = _selectedTranscription.MeetingNo ?? "";
                    lblAgendaTitle.Text = _selectedTranscription.AgendaTitle ?? "";
                    lblTranscriber.Text = _selectedTranscription.TranscriberName ?? "";
                    txtTranscription.Text = _selectedTranscription.TranscriptionText;
                    txtComments.Text = _selectedTranscription.EditorComments ?? "";
                    btnApprove.Enabled = true;
                    btnReturn.Enabled = true;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_selectedTranscription == null)
            {
                MessageBox.Show("Please select a transcription to approve.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to approve this transcription?", "Confirm Approval", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (LoginForm.CurrentUser == null) return;

                // Update transcription text if edited
                _selectedTranscription.TranscriptionText = txtTranscription.Text;
                _transcriptionService.SaveTranscription(_selectedTranscription);

                // Update status
                if (_transcriptionService.UpdateTranscriptionStatus(_selectedTranscription.TranscriptionId, 
                    "Approved", txtComments.Text, LoginForm.CurrentUser.UserId))
                {
                    MessageBox.Show("Transcription approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTranscriptions();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to approve transcription.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (_selectedTranscription == null)
            {
                MessageBox.Show("Please select a transcription to return.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComments.Text))
            {
                MessageBox.Show("Please provide comments for returning the transcription.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to return this transcription for correction?", "Confirm Return", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (LoginForm.CurrentUser == null) return;

                // Update transcription text if edited
                _selectedTranscription.TranscriptionText = txtTranscription.Text;
                _transcriptionService.SaveTranscription(_selectedTranscription);

                // Update status
                if (_transcriptionService.UpdateTranscriptionStatus(_selectedTranscription.TranscriptionId, 
                    "Returned", txtComments.Text, LoginForm.CurrentUser.UserId))
                {
                    MessageBox.Show("Transcription returned for correction.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTranscriptions();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to return transcription.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            lblMeetingNo.Text = "";
            lblAgendaTitle.Text = "";
            lblTranscriber.Text = "";
            txtTranscription.Clear();
            txtComments.Clear();
            btnApprove.Enabled = false;
            btnReturn.Enabled = false;
            _selectedTranscription = null;
        }
    }
}

