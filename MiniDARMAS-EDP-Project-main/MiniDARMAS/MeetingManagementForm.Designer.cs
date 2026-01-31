namespace MiniDARMAS
{
    partial class MeetingManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMeetingNo;
        private System.Windows.Forms.Label lblMeetingDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblChairperson;
        private System.Windows.Forms.TextBox txtMeetingNo;
        private System.Windows.Forms.DateTimePicker dtpMeetingDate;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtChairperson;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvMeetings;
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
            this.lblMeetingNo = new System.Windows.Forms.Label();
            this.lblMeetingDate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblChairperson = new System.Windows.Forms.Label();
            this.txtMeetingNo = new System.Windows.Forms.TextBox();
            this.dtpMeetingDate = new System.Windows.Forms.DateTimePicker();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtChairperson = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvMeetings = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMeetingNo
            // 
            this.lblMeetingNo.AutoSize = true;
            this.lblMeetingNo.Location = new System.Drawing.Point(20, 30);
            this.lblMeetingNo.Name = "lblMeetingNo";
            this.lblMeetingNo.Size = new System.Drawing.Size(75, 15);
            this.lblMeetingNo.TabIndex = 0;
            this.lblMeetingNo.Text = "Meeting No:";
            // 
            // lblMeetingDate
            // 
            this.lblMeetingDate.AutoSize = true;
            this.lblMeetingDate.Location = new System.Drawing.Point(20, 60);
            this.lblMeetingDate.Name = "lblMeetingDate";
            this.lblMeetingDate.Size = new System.Drawing.Size(81, 15);
            this.lblMeetingDate.TabIndex = 1;
            this.lblMeetingDate.Text = "Meeting Date:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(20, 90);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(56, 15);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "Location:";
            // 
            // lblChairperson
            // 
            this.lblChairperson.AutoSize = true;
            this.lblChairperson.Location = new System.Drawing.Point(20, 120);
            this.lblChairperson.Name = "lblChairperson";
            this.lblChairperson.Size = new System.Drawing.Size(75, 15);
            this.lblChairperson.TabIndex = 3;
            this.lblChairperson.Text = "Chairperson:";
            // 
            // txtMeetingNo
            // 
            this.txtMeetingNo.Location = new System.Drawing.Point(110, 27);
            this.txtMeetingNo.Name = "txtMeetingNo";
            this.txtMeetingNo.Size = new System.Drawing.Size(250, 23);
            this.txtMeetingNo.TabIndex = 4;
            // 
            // dtpMeetingDate
            // 
            this.dtpMeetingDate.Location = new System.Drawing.Point(110, 57);
            this.dtpMeetingDate.Name = "dtpMeetingDate";
            this.dtpMeetingDate.Size = new System.Drawing.Size(250, 23);
            this.dtpMeetingDate.TabIndex = 5;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(110, 87);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(250, 23);
            this.txtLocation.TabIndex = 6;
            // 
            // txtChairperson
            // 
            this.txtChairperson.Location = new System.Drawing.Point(110, 117);
            this.txtChairperson.Name = "txtChairperson";
            this.txtChairperson.Size = new System.Drawing.Size(250, 23);
            this.txtChairperson.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(240, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvMeetings
            // 
            this.dgvMeetings.AllowUserToAddRows = false;
            this.dgvMeetings.AllowUserToDeleteRows = false;
            this.dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMeetings.Location = new System.Drawing.Point(3, 19);
            this.dgvMeetings.MultiSelect = false;
            this.dgvMeetings.Name = "dgvMeetings";
            this.dgvMeetings.ReadOnly = true;
            this.dgvMeetings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetings.Size = new System.Drawing.Size(644, 300);
            this.dgvMeetings.TabIndex = 11;
            this.dgvMeetings.SelectionChanged += new System.EventHandler(this.dgvMeetings_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMeetingNo);
            this.groupBox1.Controls.Add(this.lblMeetingDate);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.lblChairperson);
            this.groupBox1.Controls.Add(this.txtMeetingNo);
            this.groupBox1.Controls.Add(this.dtpMeetingDate);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.txtChairperson);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 210);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meeting Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMeetings);
            this.groupBox2.Location = new System.Drawing.Point(400, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 322);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meetings List";
            // 
            // MeetingManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1062, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MeetingManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meeting Management";
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
        }
    }
}

