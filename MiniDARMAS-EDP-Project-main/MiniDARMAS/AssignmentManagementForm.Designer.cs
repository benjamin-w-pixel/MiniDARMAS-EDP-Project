namespace MiniDARMAS
{
    partial class AssignmentManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.Label lblAgenda;
        private System.Windows.Forms.Label lblRecording;
        private System.Windows.Forms.Label lblTranscriber;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbMeeting;
        private System.Windows.Forms.ComboBox cmbAgenda;
        private System.Windows.Forms.ComboBox cmbRecording;
        private System.Windows.Forms.ComboBox cmbTranscriber;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnAssign;

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
            this.lblMeeting = new System.Windows.Forms.Label();
            this.lblAgenda = new System.Windows.Forms.Label();
            this.lblRecording = new System.Windows.Forms.Label();
            this.lblTranscriber = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbMeeting = new System.Windows.Forms.ComboBox();
            this.cmbAgenda = new System.Windows.Forms.ComboBox();
            this.cmbRecording = new System.Windows.Forms.ComboBox();
            this.cmbTranscriber = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMeeting
            // 
            this.lblMeeting.AutoSize = true;
            this.lblMeeting.Location = new System.Drawing.Point(30, 30);
            this.lblMeeting.Name = "lblMeeting";
            this.lblMeeting.Size = new System.Drawing.Size(55, 15);
            this.lblMeeting.TabIndex = 0;
            this.lblMeeting.Text = "Meeting:";
            // 
            // lblAgenda
            // 
            this.lblAgenda.AutoSize = true;
            this.lblAgenda.Location = new System.Drawing.Point(30, 60);
            this.lblAgenda.Name = "lblAgenda";
            this.lblAgenda.Size = new System.Drawing.Size(51, 15);
            this.lblAgenda.TabIndex = 1;
            this.lblAgenda.Text = "Agenda:";
            // 
            // lblRecording
            // 
            this.lblRecording.AutoSize = true;
            this.lblRecording.Location = new System.Drawing.Point(30, 90);
            this.lblRecording.Name = "lblRecording";
            this.lblRecording.Size = new System.Drawing.Size(64, 15);
            this.lblRecording.TabIndex = 2;
            this.lblRecording.Text = "Recording:";
            // 
            // lblTranscriber
            // 
            this.lblTranscriber.AutoSize = true;
            this.lblTranscriber.Location = new System.Drawing.Point(30, 120);
            this.lblTranscriber.Name = "lblTranscriber";
            this.lblTranscriber.Size = new System.Drawing.Size(70, 15);
            this.lblTranscriber.TabIndex = 3;
            this.lblTranscriber.Text = "Transcriber:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(30, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            // 
            // cmbMeeting
            // 
            this.cmbMeeting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeeting.FormattingEnabled = true;
            this.cmbMeeting.Location = new System.Drawing.Point(120, 27);
            this.cmbMeeting.Name = "cmbMeeting";
            this.cmbMeeting.Size = new System.Drawing.Size(300, 23);
            this.cmbMeeting.TabIndex = 5;
            this.cmbMeeting.SelectedIndexChanged += new System.EventHandler(this.cmbMeeting_SelectedIndexChanged);
            // 
            // cmbAgenda
            // 
            this.cmbAgenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgenda.FormattingEnabled = true;
            this.cmbAgenda.Location = new System.Drawing.Point(120, 57);
            this.cmbAgenda.Name = "cmbAgenda";
            this.cmbAgenda.Size = new System.Drawing.Size(300, 23);
            this.cmbAgenda.TabIndex = 6;
            this.cmbAgenda.SelectedIndexChanged += new System.EventHandler(this.cmbAgenda_SelectedIndexChanged);
            // 
            // cmbRecording
            // 
            this.cmbRecording.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecording.FormattingEnabled = true;
            this.cmbRecording.Location = new System.Drawing.Point(120, 87);
            this.cmbRecording.Name = "cmbRecording";
            this.cmbRecording.Size = new System.Drawing.Size(300, 23);
            this.cmbRecording.TabIndex = 7;
            // 
            // cmbTranscriber
            // 
            this.cmbTranscriber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranscriber.FormattingEnabled = true;
            this.cmbTranscriber.Location = new System.Drawing.Point(120, 117);
            this.cmbTranscriber.Name = "cmbTranscriber";
            this.cmbTranscriber.Size = new System.Drawing.Size(300, 23);
            this.cmbTranscriber.TabIndex = 8;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Assigned",
            "In Progress",
            "Completed"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 147);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 23);
            this.cmbStatus.TabIndex = 9;
            this.cmbStatus.SelectedIndex = 0;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(120, 190);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(150, 35);
            this.btnAssign.TabIndex = 10;
            this.btnAssign.Text = "Assign to Transcriber";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // AssignmentManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(450, 400);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbTranscriber);
            this.Controls.Add(this.cmbRecording);
            this.Controls.Add(this.cmbAgenda);
            this.Controls.Add(this.cmbMeeting);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTranscriber);
            this.Controls.Add(this.lblRecording);
            this.Controls.Add(this.lblAgenda);
            this.Controls.Add(this.lblMeeting);
            this.Name = "AssignmentManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment Management";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

