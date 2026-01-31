namespace MiniDARMAS
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meetingManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendaManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordingManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignmentManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transcriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myAssignmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reviewTranscriptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveMeetingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amharicToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.StatusStrip statusStrip1;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordingManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transcriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignmentManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myAssignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reviewTranscriptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveMeetingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amharicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.operatorToolStripMenuItem,
            this.transcriberToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.approverToolStripMenuItem,
            this.systemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.userManagementToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // operatorToolStripMenuItem
            // 
            this.operatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meetingManagementToolStripMenuItem,
            this.agendaManagementToolStripMenuItem,
            this.recordingManagementToolStripMenuItem,
            this.assignmentManagementToolStripMenuItem});
            this.operatorToolStripMenuItem.Name = "operatorToolStripMenuItem";
            this.operatorToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.operatorToolStripMenuItem.Text = "Operator";
            // 
            // meetingManagementToolStripMenuItem
            // 
            this.meetingManagementToolStripMenuItem.Name = "meetingManagementToolStripMenuItem";
            this.meetingManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.meetingManagementToolStripMenuItem.Text = "Meeting Management";
            this.meetingManagementToolStripMenuItem.Click += new System.EventHandler(this.meetingManagementToolStripMenuItem_Click);
            // 
            // agendaManagementToolStripMenuItem
            // 
            this.agendaManagementToolStripMenuItem.Name = "agendaManagementToolStripMenuItem";
            this.agendaManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.agendaManagementToolStripMenuItem.Text = "Agenda Management";
            this.agendaManagementToolStripMenuItem.Click += new System.EventHandler(this.agendaManagementToolStripMenuItem_Click);
            // 
            // recordingManagementToolStripMenuItem
            // 
            this.recordingManagementToolStripMenuItem.Name = "recordingManagementToolStripMenuItem";
            this.recordingManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.recordingManagementToolStripMenuItem.Text = "Recording Management";
            this.recordingManagementToolStripMenuItem.Click += new System.EventHandler(this.recordingManagementToolStripMenuItem_Click);
            // 
            // assignmentManagementToolStripMenuItem
            // 
            this.assignmentManagementToolStripMenuItem.Name = "assignmentManagementToolStripMenuItem";
            this.assignmentManagementToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.assignmentManagementToolStripMenuItem.Text = "Assignment Management";
            this.assignmentManagementToolStripMenuItem.Click += new System.EventHandler(this.assignmentManagementToolStripMenuItem_Click);
            // 
            // transcriberToolStripMenuItem
            // 
            this.transcriberToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myAssignmentsToolStripMenuItem});
            this.transcriberToolStripMenuItem.Name = "transcriberToolStripMenuItem";
            this.transcriberToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.transcriberToolStripMenuItem.Text = "Transcriber";
            // 
            // myAssignmentsToolStripMenuItem
            // 
            this.myAssignmentsToolStripMenuItem.Name = "myAssignmentsToolStripMenuItem";
            this.myAssignmentsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.myAssignmentsToolStripMenuItem.Text = "My Assignments";
            this.myAssignmentsToolStripMenuItem.Click += new System.EventHandler(this.myAssignmentsToolStripMenuItem_Click);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reviewTranscriptionsToolStripMenuItem});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // reviewTranscriptionsToolStripMenuItem
            // 
            this.reviewTranscriptionsToolStripMenuItem.Name = "reviewTranscriptionsToolStripMenuItem";
            this.reviewTranscriptionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reviewTranscriptionsToolStripMenuItem.Text = "Review Transcriptions";
            this.reviewTranscriptionsToolStripMenuItem.Click += new System.EventHandler(this.reviewTranscriptionsToolStripMenuItem_Click);
            // 
            // approverToolStripMenuItem
            // 
            this.approverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approveMeetingToolStripMenuItem});
            this.approverToolStripMenuItem.Name = "approverToolStripMenuItem";
            this.approverToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.approverToolStripMenuItem.Text = "Approver";
            // 
            // approveMeetingToolStripMenuItem
            // 
            this.approveMeetingToolStripMenuItem.Name = "approveMeetingToolStripMenuItem";
            this.approveMeetingToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.approveMeetingToolStripMenuItem.Text = "Approve Meeting";
            this.approveMeetingToolStripMenuItem.Click += new System.EventHandler(this.approveMeetingToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.systemToolStripMenuItem.Text = "File";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.amharicToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // amharicToolStripMenuItem
            // 
            this.amharicToolStripMenuItem.Name = "amharicToolStripMenuItem";
            this.amharicToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.amharicToolStripMenuItem.Text = "Amharic";
            this.amharicToolStripMenuItem.Click += new System.EventHandler(this.amharicToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(57, 17);
            this.lblWelcome.Text = "Welcome";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini-DARMAS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
