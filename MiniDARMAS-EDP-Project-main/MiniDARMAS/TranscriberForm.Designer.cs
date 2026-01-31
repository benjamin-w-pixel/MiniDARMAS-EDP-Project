using System.Windows.Forms;
using System.Drawing;

namespace MiniDARMAS
{
    partial class TranscriberForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.Label lblMeetingNoLabel;
        private System.Windows.Forms.Label lblAgendaTitleLabel;
        private System.Windows.Forms.Label lblAudioFileLabel;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblMeetingNo;
        private System.Windows.Forms.Label lblAgendaTitle;
        private System.Windows.Forms.Label lblAudioFile;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtTranscription;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnPlayAudio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvAssignments = new DataGridView();
            lblMeetingNoLabel = new Label();
            lblAgendaTitleLabel = new Label();
            lblAudioFileLabel = new Label();
            lblStatusLabel = new Label();
            lblMeetingNo = new Label();
            lblAgendaTitle = new Label();
            lblAudioFile = new Label();
            lblStatus = new Label();
            txtTranscription = new TextBox();
            btnSaveDraft = new Button();
            btnSubmit = new Button();
            btnPlayAudio = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAssignments
            // 
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.AllowUserToDeleteRows = false;
            dgvAssignments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssignments.Dock = DockStyle.Fill;
            dgvAssignments.Location = new Point(4, 29);
            dgvAssignments.Margin = new Padding(4, 5, 4, 5);
            dgvAssignments.MultiSelect = false;
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.ReadOnly = true;
            dgvAssignments.RowHeadersWidth = 62;
            dgvAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssignments.Size = new Size(913, 272);
            dgvAssignments.TabIndex = 0;
            dgvAssignments.SelectionChanged += dgvAssignments_SelectionChanged;
            // 
            // lblMeetingNoLabel
            // 
            lblMeetingNoLabel.AutoSize = true;
            lblMeetingNoLabel.Location = new Point(29, 50);
            lblMeetingNoLabel.Margin = new Padding(4, 0, 4, 0);
            lblMeetingNoLabel.Name = "lblMeetingNoLabel";
            lblMeetingNoLabel.Size = new Size(110, 25);
            lblMeetingNoLabel.TabIndex = 1;
            lblMeetingNoLabel.Text = "Meeting No:";
            // 
            // lblAgendaTitleLabel
            // 
            lblAgendaTitleLabel.AutoSize = true;
            lblAgendaTitleLabel.Location = new Point(29, 100);
            lblAgendaTitleLabel.Margin = new Padding(4, 0, 4, 0);
            lblAgendaTitleLabel.Name = "lblAgendaTitleLabel";
            lblAgendaTitleLabel.Size = new Size(115, 25);
            lblAgendaTitleLabel.TabIndex = 2;
            lblAgendaTitleLabel.Text = "Agenda Title:";
            // 
            // lblAudioFileLabel
            // 
            lblAudioFileLabel.AutoSize = true;
            lblAudioFileLabel.Location = new Point(29, 150);
            lblAudioFileLabel.Margin = new Padding(4, 0, 4, 0);
            lblAudioFileLabel.Name = "lblAudioFileLabel";
            lblAudioFileLabel.Size = new Size(95, 25);
            lblAudioFileLabel.TabIndex = 3;
            lblAudioFileLabel.Text = "Audio File:";
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.AutoSize = true;
            lblStatusLabel.Location = new Point(29, 200);
            lblStatusLabel.Margin = new Padding(4, 0, 4, 0);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(64, 25);
            lblStatusLabel.TabIndex = 4;
            lblStatusLabel.Text = "Status:";
            // 
            // lblMeetingNo
            // 
            lblMeetingNo.AutoSize = true;
            lblMeetingNo.Location = new Point(157, 50);
            lblMeetingNo.Margin = new Padding(4, 0, 4, 0);
            lblMeetingNo.Name = "lblMeetingNo";
            lblMeetingNo.Size = new Size(0, 25);
            lblMeetingNo.TabIndex = 5;
            // 
            // lblAgendaTitle
            // 
            lblAgendaTitle.AutoSize = true;
            lblAgendaTitle.Location = new Point(157, 100);
            lblAgendaTitle.Margin = new Padding(4, 0, 4, 0);
            lblAgendaTitle.Name = "lblAgendaTitle";
            lblAgendaTitle.Size = new Size(0, 25);
            lblAgendaTitle.TabIndex = 6;
            // 
            // lblAudioFile
            // 
            lblAudioFile.AutoSize = true;
            lblAudioFile.Location = new Point(157, 150);
            lblAudioFile.Margin = new Padding(4, 0, 4, 0);
            lblAudioFile.Name = "lblAudioFile";
            lblAudioFile.Size = new Size(0, 25);
            lblAudioFile.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(157, 200);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 25);
            lblStatus.TabIndex = 8;
            // 
            // txtTranscription
            // 
            txtTranscription.Location = new Point(29, 250);
            txtTranscription.Margin = new Padding(4, 5, 4, 5);
            txtTranscription.Multiline = true;
            txtTranscription.Name = "txtTranscription";
            txtTranscription.ScrollBars = ScrollBars.Vertical;
            txtTranscription.Size = new Size(855, 206);
            txtTranscription.TabIndex = 9;
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.Enabled = false;
            btnSaveDraft.Location = new Point(41, 496);
            btnSaveDraft.Margin = new Padding(4, 5, 4, 5);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(171, 50);
            btnSaveDraft.TabIndex = 10;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = true;
            btnSaveDraft.Click += btnSaveDraft_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Enabled = false;
            btnSubmit.Location = new Point(248, 496);
            btnSubmit.Margin = new Padding(4, 5, 4, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(209, 50);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "Submit to Editor";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnPlayAudio
            // 
            btnPlayAudio.Enabled = false;
            btnPlayAudio.Location = new Point(550, 496);
            btnPlayAudio.Margin = new Padding(4, 5, 4, 5);
            btnPlayAudio.Name = "btnPlayAudio";
            btnPlayAudio.Size = new Size(171, 50);
            btnPlayAudio.TabIndex = 12;
            btnPlayAudio.Text = "Play Audio";
            btnPlayAudio.UseVisualStyleBackColor = true;
            btnPlayAudio.Click += btnPlayAudio_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMeetingNoLabel);
            groupBox1.Controls.Add(lblAgendaTitleLabel);
            groupBox1.Controls.Add(lblAudioFileLabel);
            groupBox1.Controls.Add(lblStatusLabel);
            groupBox1.Controls.Add(lblMeetingNo);
            groupBox1.Controls.Add(lblAgendaTitle);
            groupBox1.Controls.Add(lblAudioFile);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(txtTranscription);
            groupBox1.Controls.Add(btnSaveDraft);
            groupBox1.Controls.Add(btnSubmit);
            groupBox1.Controls.Add(btnPlayAudio);
            groupBox1.Location = new Point(17, 348);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(929, 700);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Transcription";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvAssignments);
            groupBox2.Location = new Point(25, 20);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(921, 306);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "My Assignments";
            // 
            // TranscriberForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(980, 720);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "TranscriberForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transcriber - My Assignments";
            Load += TranscriberForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

