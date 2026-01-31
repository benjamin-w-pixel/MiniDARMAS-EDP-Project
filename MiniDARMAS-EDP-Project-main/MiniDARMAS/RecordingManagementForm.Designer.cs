namespace MiniDARMAS
{
    partial class RecordingManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.Label lblAgenda;
        private System.Windows.Forms.Label lblAudioFile;
        private System.Windows.Forms.ComboBox cmbMeeting;
        private System.Windows.Forms.ComboBox cmbAgenda;
        private System.Windows.Forms.TextBox txtAudioFileName;
        private System.Windows.Forms.TextBox txtAudioFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvRecordings;
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
            this.lblMeeting = new System.Windows.Forms.Label();
            this.lblAgenda = new System.Windows.Forms.Label();
            this.lblAudioFile = new System.Windows.Forms.Label();
            this.cmbMeeting = new System.Windows.Forms.ComboBox();
            this.cmbAgenda = new System.Windows.Forms.ComboBox();
            this.txtAudioFileName = new System.Windows.Forms.TextBox();
            this.txtAudioFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvRecordings = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordings)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMeeting
            // 
            this.lblMeeting.AutoSize = true;
            this.lblMeeting.Location = new System.Drawing.Point(20, 30);
            this.lblMeeting.Name = "lblMeeting";
            this.lblMeeting.Size = new System.Drawing.Size(55, 15);
            this.lblMeeting.TabIndex = 0;
            this.lblMeeting.Text = "Meeting:";
            // 
            // lblAgenda
            // 
            this.lblAgenda.AutoSize = true;
            this.lblAgenda.Location = new System.Drawing.Point(20, 60);
            this.lblAgenda.Name = "lblAgenda";
            this.lblAgenda.Size = new System.Drawing.Size(51, 15);
            this.lblAgenda.TabIndex = 1;
            this.lblAgenda.Text = "Agenda:";
            // 
            // lblAudioFile
            // 
            this.lblAudioFile.AutoSize = true;
            this.lblAudioFile.Location = new System.Drawing.Point(20, 90);
            this.lblAudioFile.Name = "lblAudioFile";
            this.lblAudioFile.Size = new System.Drawing.Size(66, 15);
            this.lblAudioFile.TabIndex = 2;
            this.lblAudioFile.Text = "Audio File:";
            // 
            // cmbMeeting
            // 
            this.cmbMeeting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeeting.FormattingEnabled = true;
            this.cmbMeeting.Location = new System.Drawing.Point(100, 27);
            this.cmbMeeting.Name = "cmbMeeting";
            this.cmbMeeting.Size = new System.Drawing.Size(300, 23);
            this.cmbMeeting.TabIndex = 3;
            this.cmbMeeting.SelectedIndexChanged += new System.EventHandler(this.cmbMeeting_SelectedIndexChanged);
            // 
            // cmbAgenda
            // 
            this.cmbAgenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgenda.FormattingEnabled = true;
            this.cmbAgenda.Location = new System.Drawing.Point(100, 57);
            this.cmbAgenda.Name = "cmbAgenda";
            this.cmbAgenda.Size = new System.Drawing.Size(300, 23);
            this.cmbAgenda.TabIndex = 4;
            this.cmbAgenda.SelectedIndexChanged += new System.EventHandler(this.cmbAgenda_SelectedIndexChanged);
            // 
            // txtAudioFileName
            // 
            this.txtAudioFileName.Location = new System.Drawing.Point(100, 87);
            this.txtAudioFileName.Name = "txtAudioFileName";
            this.txtAudioFileName.ReadOnly = true;
            this.txtAudioFileName.Size = new System.Drawing.Size(200, 23);
            this.txtAudioFileName.TabIndex = 5;
            // 
            // txtAudioFilePath
            // 
            this.txtAudioFilePath.Location = new System.Drawing.Point(100, 117);
            this.txtAudioFilePath.Name = "txtAudioFilePath";
            this.txtAudioFilePath.ReadOnly = true;
            this.txtAudioFilePath.Size = new System.Drawing.Size(300, 23);
            this.txtAudioFilePath.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(310, 87);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 160);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Add Recording";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(210, 160);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvRecordings
            // 
            this.dgvRecordings.AllowUserToAddRows = false;
            this.dgvRecordings.AllowUserToDeleteRows = false;
            this.dgvRecordings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecordings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecordings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecordings.Location = new System.Drawing.Point(3, 19);
            this.dgvRecordings.MultiSelect = false;
            this.dgvRecordings.Name = "dgvRecordings";
            this.dgvRecordings.ReadOnly = true;
            this.dgvRecordings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecordings.Size = new System.Drawing.Size(644, 300);
            this.dgvRecordings.TabIndex = 10;
            this.dgvRecordings.SelectionChanged += new System.EventHandler(this.dgvRecordings_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMeeting);
            this.groupBox1.Controls.Add(this.lblAgenda);
            this.groupBox1.Controls.Add(this.lblAudioFile);
            this.groupBox1.Controls.Add(this.cmbMeeting);
            this.groupBox1.Controls.Add(this.cmbAgenda);
            this.groupBox1.Controls.Add(this.txtAudioFileName);
            this.groupBox1.Controls.Add(this.txtAudioFilePath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 210);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recording Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRecordings);
            this.groupBox2.Location = new System.Drawing.Point(450, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 322);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recordings List";
            // 
            // RecordingManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1112, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecordingManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recording Management";
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecordings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
        }
    }
}

