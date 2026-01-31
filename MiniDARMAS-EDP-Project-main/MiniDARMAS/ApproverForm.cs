using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class ApproverForm : Form
    {
        private MeetingService _meetingService;
        private TranscriptionService _transcriptionService;

        public ApproverForm()
        {
            InitializeComponent();
            _meetingService = new MeetingService();
            _transcriptionService = new TranscriptionService();
            LoadMeetings();
        }

        private void LoadMeetings()
        {
            try
            {
                var allMeetings = _meetingService.GetAllMeetings();
                if (allMeetings == null) allMeetings = new List<Meeting>();
                
                var meetings = allMeetings.Where(m => !m.IsFinalApproved).ToList();
                
                // Clear any existing binding to avoid event storms
                cmbMeeting.DataSource = null;
                cmbMeeting.DisplayMember = "MeetingNo";
                cmbMeeting.ValueMember = "MeetingId";
                cmbMeeting.DataSource = meetings;
                
                if (meetings.Count > 0)
                {
                    // Selecting index 0 will trigger SelectedIndexChanged -> LoadApprovedTranscriptions
                    cmbMeeting.SelectedIndex = 0;
                    // Force a load if event doesn't fire
                    LoadApprovedTranscriptions();
                }
                else
                {
                    rtxtFinalDocument.Text = "No pending meetings for approval found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading meetings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtxtFinalDocument.Text = "Failed to load meetings list.";
            }
        }

        private void LoadApprovedTranscriptions()
        {
            try
            {
                int meetingId = GetSelectedMeetingId();
                if (meetingId != -1)
                {
                    LoadTranscriptions(meetingId);
                }
                else
                {
                    rtxtFinalDocument.Text = "Please select a meeting.";
                    btnExport.Enabled = false;
                    btnFinalApprove.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                rtxtFinalDocument.Text = $"Error loading transcriptions: {ex.Message}";
                btnExport.Enabled = false;
                btnFinalApprove.Enabled = false;
            }
        }

        private int GetSelectedMeetingId()
        {
            if (cmbMeeting.SelectedValue == null) return -1;

            try
            {
                // Handle various types that SelectedValue might be
                if (cmbMeeting.SelectedValue is int intId) return intId;
                if (cmbMeeting.SelectedValue is Meeting meeting) return meeting.MeetingId;
                
                // Fallback to conversion for other numeric types or strings
                return Convert.ToInt32(cmbMeeting.SelectedValue);
            }
            catch
            {
                return -1;
            }
        }

        private void LoadTranscriptions(int meetingId)
        {
            var transcriptions = _transcriptionService.GetApprovedTranscriptionsByMeetingId(meetingId);
            
            if (transcriptions.Count > 0)
            {
                StringBuilder finalDocument = new StringBuilder();
                finalDocument.AppendLine("MEETING MINUTES");
                finalDocument.AppendLine("================");
                finalDocument.AppendLine();

                var meeting = _meetingService.GetMeetingById(meetingId);
                if (meeting != null)
                {
                    finalDocument.AppendLine($"Meeting No: {meeting.MeetingNo}");
                    finalDocument.AppendLine($"Date: {meeting.MeetingDate:yyyy-MM-dd}");
                    finalDocument.AppendLine($"Location: {meeting.Location}");
                    finalDocument.AppendLine($"Chairperson: {meeting.Chairperson}");
                    finalDocument.AppendLine();
                    finalDocument.AppendLine("AGENDA ITEMS");
                    finalDocument.AppendLine("============");
                    finalDocument.AppendLine();
                }

                foreach (var transcription in transcriptions)
                {
                    finalDocument.AppendLine($"Agenda: {transcription.AgendaTitle}");
                    finalDocument.AppendLine();
                    finalDocument.AppendLine(transcription.TranscriptionText);
                    
                    if (!string.IsNullOrWhiteSpace(transcription.EditorComments))
                    {
                        finalDocument.AppendLine();
                        finalDocument.AppendLine($"Editor Comments: {transcription.EditorComments}");
                    }
                    
                    finalDocument.AppendLine();
                    finalDocument.AppendLine("---");
                    finalDocument.AppendLine();
                }

                rtxtFinalDocument.Text = finalDocument.ToString();
                btnExport.Enabled = true;
                btnFinalApprove.Enabled = true;
            }
            else
            {
                rtxtFinalDocument.Text = "No approved transcriptions available for this meeting.";
                btnExport.Enabled = false;
                btnFinalApprove.Enabled = false;
            }
        }

        private void cmbMeeting_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadApprovedTranscriptions();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|RTF Files|*.rtf|All Files|*.*";
            saveFileDialog.Title = "Export Final Meeting Document";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                    if (extension == ".rtf")
                    {
                        rtxtFinalDocument.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        File.WriteAllText(saveFileDialog.FileName, rtxtFinalDocument.Text);
                    }
                    MessageBox.Show("Document exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to export document: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFinalApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int meetingId = GetSelectedMeetingId();

                if (meetingId == -1)
                {
                    MessageBox.Show("Please select a valid meeting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to mark this meeting as Final Approved?", "Confirm Final Approval",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_meetingService.MarkMeetingAsFinalApproved(meetingId))
                    {
                        MessageBox.Show("Meeting marked as Final Approved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMeetings();
                        rtxtFinalDocument.Clear();
                        btnExport.Enabled = false;
                        btnFinalApprove.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark meeting as Final Approved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during final approval: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

