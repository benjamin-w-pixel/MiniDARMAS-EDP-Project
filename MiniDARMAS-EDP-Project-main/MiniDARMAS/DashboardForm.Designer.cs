namespace MiniDARMAS
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblTotalMeetings;
        private System.Windows.Forms.Label lblPendingAssignments;
        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.GroupBox grpLogs;
        private System.Windows.Forms.DataGridView dgvActivityLogs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblTotalMeetings = new System.Windows.Forms.Label();
            this.lblPendingAssignments = new System.Windows.Forms.Label();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.grpLogs = new System.Windows.Forms.GroupBox();
            this.dgvActivityLogs = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpStats.SuspendLayout();
            this.grpLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Users:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(87, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Meetings:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 30);
            this.label3.Name = "label3";
            this.label3.Size = new Size(122, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pending Assignments:";
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalUsers.Location = new System.Drawing.Point(20, 50);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new Size(19, 21);
            this.lblTotalUsers.TabIndex = 1;
            this.lblTotalUsers.Text = "0";
            // 
            // lblTotalMeetings
            // 
            this.lblTotalMeetings.AutoSize = true;
            this.lblTotalMeetings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalMeetings.Location = new System.Drawing.Point(180, 50);
            this.lblTotalMeetings.Name = "lblTotalMeetings";
            this.lblTotalMeetings.Size = new Size(19, 21);
            this.lblTotalMeetings.TabIndex = 3;
            this.lblTotalMeetings.Text = "0";
            // 
            // lblPendingAssignments
            // 
            this.lblPendingAssignments.AutoSize = true;
            this.lblPendingAssignments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPendingAssignments.Location = new System.Drawing.Point(360, 50);
            this.lblPendingAssignments.Name = "lblPendingAssignments";
            this.lblPendingAssignments.Size = new Size(19, 21);
            this.lblPendingAssignments.TabIndex = 5;
            this.lblPendingAssignments.Text = "0";
            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.label1);
            this.grpStats.Controls.Add(this.lblTotalUsers);
            this.grpStats.Controls.Add(this.label2);
            this.grpStats.Controls.Add(this.lblTotalMeetings);
            this.grpStats.Controls.Add(this.label3);
            this.grpStats.Controls.Add(this.lblPendingAssignments);
            this.grpStats.Location = new System.Drawing.Point(12, 12);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(550, 100);
            this.grpStats.TabIndex = 0;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "System Statistics";
            // 
            // grpLogs
            // 
            this.grpLogs.Controls.Add(this.dgvActivityLogs);
            this.grpLogs.Location = new System.Drawing.Point(12, 118);
            this.grpLogs.Name = "grpLogs";
            this.grpLogs.Size = new System.Drawing.Size(550, 250);
            this.grpLogs.TabIndex = 1;
            this.grpLogs.TabStop = false;
            this.grpLogs.Text = "Activity Logs (Last 50)";
            // 
            // dgvActivityLogs
            // 
            this.dgvActivityLogs.AllowUserToAddRows = false;
            this.dgvActivityLogs.AllowUserToDeleteRows = false;
            this.dgvActivityLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActivityLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvActivityLogs.Location = new System.Drawing.Point(3, 19);
            this.dgvActivityLogs.Name = "dgvActivityLogs";
            this.dgvActivityLogs.ReadOnly = true;
            this.dgvActivityLogs.Size = new System.Drawing.Size(544, 228);
            this.dgvActivityLogs.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(400, 375);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(485, 375);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 410);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpLogs);
            this.Controls.Add(this.grpStats);
            this.Name = "DashboardForm";
            this.Text = "Admin Dashboard";
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            this.grpLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActivityLogs)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
