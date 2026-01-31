namespace MiniDARMAS
{
    partial class EditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTranscriptions;
        private System.Windows.Forms.Label lblMeetingNoLabel;
        private System.Windows.Forms.Label lblAgendaTitleLabel;
        private System.Windows.Forms.Label lblTranscriberLabel;
        private System.Windows.Forms.Label lblMeetingNo;
        private System.Windows.Forms.Label lblAgendaTitle;
        private System.Windows.Forms.Label lblTranscriber;
        private System.Windows.Forms.TextBox txtTranscription;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReturn;
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
            dgvTranscriptions = new DataGridView();
            lblMeetingNoLabel = new Label();
            lblAgendaTitleLabel = new Label();
            lblTranscriberLabel = new Label();
            lblMeetingNo = new Label();
            lblAgendaTitle = new Label();
            lblTranscriber = new Label();
            txtTranscription = new TextBox();
            txtComments = new TextBox();
            lblComments = new Label();
            btnApprove = new Button();
            btnReturn = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvTranscriptions).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTranscriptions
            // 
            dgvTranscriptions.AllowUserToAddRows = false;
            dgvTranscriptions.AllowUserToDeleteRows = false;
            dgvTranscriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTranscriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTranscriptions.Dock = DockStyle.Fill;
            dgvTranscriptions.Location = new Point(4, 29);
            dgvTranscriptions.Margin = new Padding(4, 5, 4, 5);
            dgvTranscriptions.MultiSelect = false;
            dgvTranscriptions.Name = "dgvTranscriptions";
            dgvTranscriptions.ReadOnly = true;
            dgvTranscriptions.RowHeadersWidth = 62;
            dgvTranscriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTranscriptions.Size = new Size(913, 189);
            dgvTranscriptions.TabIndex = 0;
            dgvTranscriptions.SelectionChanged += dgvTranscriptions_SelectionChanged;
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
            // lblTranscriberLabel
            // 
            lblTranscriberLabel.AutoSize = true;
            lblTranscriberLabel.Location = new Point(29, 150);
            lblTranscriberLabel.Margin = new Padding(4, 0, 4, 0);
            lblTranscriberLabel.Name = "lblTranscriberLabel";
            lblTranscriberLabel.Size = new Size(100, 25);
            lblTranscriberLabel.TabIndex = 3;
            lblTranscriberLabel.Text = "Transcriber:";
            // 
            // lblMeetingNo
            // 
            lblMeetingNo.AutoSize = true;
            lblMeetingNo.Location = new Point(157, 50);
            lblMeetingNo.Margin = new Padding(4, 0, 4, 0);
            lblMeetingNo.Name = "lblMeetingNo";
            lblMeetingNo.Size = new Size(0, 25);
            lblMeetingNo.TabIndex = 4;
            // 
            // lblAgendaTitle
            // 
            lblAgendaTitle.AutoSize = true;
            lblAgendaTitle.Location = new Point(157, 100);
            lblAgendaTitle.Margin = new Padding(4, 0, 4, 0);
            lblAgendaTitle.Name = "lblAgendaTitle";
            lblAgendaTitle.Size = new Size(0, 25);
            lblAgendaTitle.TabIndex = 5;
            // 
            // lblTranscriber
            // 
            lblTranscriber.AutoSize = true;
            lblTranscriber.Location = new Point(157, 150);
            lblTranscriber.Margin = new Padding(4, 0, 4, 0);
            lblTranscriber.Name = "lblTranscriber";
            lblTranscriber.Size = new Size(0, 25);
            lblTranscriber.TabIndex = 6;
            // 
            // txtTranscription
            // 
            txtTranscription.Location = new Point(259, 34);
            txtTranscription.Margin = new Padding(4, 5, 4, 5);
            txtTranscription.Multiline = true;
            txtTranscription.Name = "txtTranscription";
            txtTranscription.ScrollBars = ScrollBars.Vertical;
            txtTranscription.Size = new Size(662, 157);
            txtTranscription.TabIndex = 7;
            // 
            // txtComments
            // 
            txtComments.Location = new Point(223, 244);
            txtComments.Margin = new Padding(4, 5, 4, 5);
            txtComments.Multiline = true;
            txtComments.Name = "txtComments";
            txtComments.ScrollBars = ScrollBars.Vertical;
            txtComments.Size = new Size(702, 131);
            txtComments.TabIndex = 8;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Location = new Point(26, 294);
            lblComments.Margin = new Padding(4, 0, 4, 0);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(103, 25);
            lblComments.TabIndex = 9;
            lblComments.Text = "Comments:";
            // 
            // btnApprove
            // 
            btnApprove.Enabled = false;
            btnApprove.Location = new Point(223, 385);
            btnApprove.Margin = new Padding(4, 5, 4, 5);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(171, 50);
            btnApprove.TabIndex = 10;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReturn
            // 
            btnReturn.Enabled = false;
            btnReturn.Location = new Point(444, 385);
            btnReturn.Margin = new Padding(4, 5, 4, 5);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(295, 50);
            btnReturn.TabIndex = 11;
            btnReturn.Text = "Return for Correction";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblMeetingNoLabel);
            groupBox1.Controls.Add(lblAgendaTitleLabel);
            groupBox1.Controls.Add(lblTranscriberLabel);
            groupBox1.Controls.Add(lblMeetingNo);
            groupBox1.Controls.Add(lblAgendaTitle);
            groupBox1.Controls.Add(lblTranscriber);
            groupBox1.Controls.Add(txtTranscription);
            groupBox1.Controls.Add(txtComments);
            groupBox1.Controls.Add(lblComments);
            groupBox1.Controls.Add(btnApprove);
            groupBox1.Controls.Add(btnReturn);
            groupBox1.Location = new Point(13, 304);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(929, 817);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Review Transcription";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvTranscriptions);
            groupBox2.Location = new Point(13, 14);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(921, 223);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Submissions Awaiting Review";
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 1050);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "EditorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editor - Review Transcriptions";
            ((System.ComponentModel.ISupportInitialize)dgvTranscriptions).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

