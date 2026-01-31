using System;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class TranscriberForm : Form
    {
        private AssignmentService _assignmentService;
        private TranscriptionService _transcriptionService;
        private Assignment? _selectedAssignment;

        public TranscriberForm()
        {
            InitializeComponent();
            _assignmentService = new AssignmentService();
            _transcriptionService = new TranscriptionService();
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            if (LoginForm.CurrentUser == null) return;

            var assignments = _assignmentService.GetAssignmentsByTranscriberId(LoginForm.CurrentUser.UserId);
            dgvAssignments.DataSource = assignments;
            dgvAssignments.Columns["AssignmentId"].Visible = false;
            dgvAssignments.Columns["RecordingId"].Visible = false;
            dgvAssignments.Columns["TranscriberId"].Visible = false;
            dgvAssignments.Columns["AssignedDate"].Visible = false;
            dgvAssignments.Columns["TranscriberName"].Visible = false;
        }

        private void dgvAssignments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAssignments.SelectedRows.Count > 0)
            {
                int assignmentId = Convert.ToInt32(dgvAssignments.SelectedRows[0].Cells["AssignmentId"].Value);
                var assignments = _assignmentService.GetAssignmentsByTranscriberId(LoginForm.CurrentUser?.UserId ?? 0);
                _selectedAssignment = assignments.FirstOrDefault(a => a.AssignmentId == assignmentId);

                if (_selectedAssignment != null)
                {
                    lblMeetingNo.Text = _selectedAssignment.MeetingNo ?? "";
                    lblAgendaTitle.Text = _selectedAssignment.AgendaTitle ?? "";
                    lblAudioFile.Text = _selectedAssignment.AudioFileName ?? "";
                    lblStatus.Text = _selectedAssignment.Status;

                    // Load existing transcription if any
                    var transcription = _transcriptionService.GetTranscriptionByAssignmentId(assignmentId);
                    if (transcription != null)
                    {
                        txtTranscription.Text = transcription.TranscriptionText;
                    }
                    else
                    {
                        txtTranscription.Clear();
                    }

                    btnSaveDraft.Enabled = true;
                    btnSubmit.Enabled = true;
                    btnPlayAudio.Enabled = !string.IsNullOrEmpty(_selectedAssignment.AudioFileName);
                }
            }
        }

        private void btnPlayAudio_Click(object sender, EventArgs e)
        {
            if (_selectedAssignment == null || string.IsNullOrEmpty(_selectedAssignment.AudioFileName))
            {
                MessageBox.Show("No audio file found for this assignment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string audioPath = _selectedAssignment.AudioFileName;
                string? foundPath = null;

                // Try multiple possible locations
                string[] possiblePaths = new[]
                {
                    audioPath, // Original path (might be absolute)
                    System.IO.Path.Combine(Application.StartupPath, audioPath), // Relative to bin folder
                    System.IO.Path.Combine(Application.StartupPath, "Recordings", audioPath), // Recordings subfolder
                    System.IO.Path.Combine(Application.StartupPath, "..", "..", "..", "Recordings", audioPath), // Project Recordings folder
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MiniDARMAS", "Recordings", audioPath)
                };

                // Check each possible path
                foreach (var path in possiblePaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        foundPath = path;
                        break;
                    }
                }

                if (foundPath != null)
                {
                    // File found, open it
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = foundPath,
                        UseShellExecute = true
                    };
                    System.Diagnostics.Process.Start(psi);
                }
                else
                {
                    // File not found, ask user to locate it
                    var result = MessageBox.Show(
                        $"Could not find audio file: {audioPath}\n\nWould you like to browse for the file?",
                        "File Not Found",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            openFileDialog.Title = "Locate Audio File";
                            openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.m4a;*.wma;*.aac;*.flac|All Files|*.*";
                            openFileDialog.FileName = System.IO.Path.GetFileName(audioPath);

                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = openFileDialog.FileName,
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(psi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open audio file: An error occurred trying to start process '{_selectedAssignment.AudioFileName}' with working directory '{System.IO.Directory.GetCurrentDirectory()}'. The system cannot find the file specified.", "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            if (_selectedAssignment == null)
            {
                MessageBox.Show("Please select an assignment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTranscription.Text))
            {
                MessageBox.Show("Please enter transcription text.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Transcription transcription = new Transcription
            {
                AssignmentId = _selectedAssignment.AssignmentId,
                TranscriptionText = txtTranscription.Text,
                Status = "Draft",
                SubmittedDate = DateTime.Now
            };

            if (_transcriptionService.SaveTranscription(transcription))
            {
                MessageBox.Show("Draft saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save draft.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_selectedAssignment == null)
            {
                MessageBox.Show("Please select an assignment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTranscription.Text))
            {
                MessageBox.Show("Please enter transcription text before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Transcription transcription = new Transcription
            {
                AssignmentId = _selectedAssignment.AssignmentId,
                TranscriptionText = txtTranscription.Text,
                Status = "Submitted",
                SubmittedDate = DateTime.Now
            };

            if (_transcriptionService.SaveTranscription(transcription))
            {
                // Update assignment status to Completed
                _assignmentService.UpdateAssignmentStatus(_selectedAssignment.AssignmentId, "Completed");
                MessageBox.Show("Transcription submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAssignments();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Failed to submit transcription.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            lblMeetingNo.Text = "";
            lblAgendaTitle.Text = "";
            lblAudioFile.Text = "";
            lblStatus.Text = "";
            txtTranscription.Clear();
            btnSaveDraft.Enabled = false;
            btnSubmit.Enabled = false;
            btnPlayAudio.Enabled = false;
            _selectedAssignment = null;
        }

        private void TranscriberForm_Load(object sender, EventArgs e)
        {

        }
    }
}

