namespace MiniDARMAS
{
    partial class AgendaManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.Label lblAgendaTitle;
        private System.Windows.Forms.Label lblOffice;
        private System.Windows.Forms.Label lblSupportingDocument;
        private System.Windows.Forms.ComboBox cmbMeeting;
        private System.Windows.Forms.TextBox txtAgendaTitle;
        private System.Windows.Forms.TextBox txtOffice;
        private System.Windows.Forms.TextBox txtSupportingDocument;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvAgendas;
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
            this.lblAgendaTitle = new System.Windows.Forms.Label();
            this.lblOffice = new System.Windows.Forms.Label();
            this.lblSupportingDocument = new System.Windows.Forms.Label();
            this.cmbMeeting = new System.Windows.Forms.ComboBox();
            this.txtAgendaTitle = new System.Windows.Forms.TextBox();
            this.txtOffice = new System.Windows.Forms.TextBox();
            this.txtSupportingDocument = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvAgendas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendas)).BeginInit();
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
            // lblAgendaTitle
            // 
            this.lblAgendaTitle.AutoSize = true;
            this.lblAgendaTitle.Location = new System.Drawing.Point(20, 60);
            this.lblAgendaTitle.Name = "lblAgendaTitle";
            this.lblAgendaTitle.Size = new System.Drawing.Size(78, 15);
            this.lblAgendaTitle.TabIndex = 1;
            this.lblAgendaTitle.Text = "Agenda Title:";
            // 
            // lblOffice
            // 
            this.lblOffice.AutoSize = true;
            this.lblOffice.Location = new System.Drawing.Point(20, 90);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(42, 15);
            this.lblOffice.TabIndex = 2;
            this.lblOffice.Text = "Office:";
            // 
            // lblSupportingDocument
            // 
            this.lblSupportingDocument.AutoSize = true;
            this.lblSupportingDocument.Location = new System.Drawing.Point(20, 120);
            this.lblSupportingDocument.Name = "lblSupportingDocument";
            this.lblSupportingDocument.Size = new System.Drawing.Size(130, 15);
            this.lblSupportingDocument.TabIndex = 3;
            this.lblSupportingDocument.Text = "Supporting Document:";
            // 
            // cmbMeeting
            // 
            this.cmbMeeting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeeting.FormattingEnabled = true;
            this.cmbMeeting.Location = new System.Drawing.Point(160, 27);
            this.cmbMeeting.Name = "cmbMeeting";
            this.cmbMeeting.Size = new System.Drawing.Size(250, 23);
            this.cmbMeeting.TabIndex = 4;
            this.cmbMeeting.SelectedIndexChanged += new System.EventHandler(this.cmbMeeting_SelectedIndexChanged);
            // 
            // txtAgendaTitle
            // 
            this.txtAgendaTitle.Location = new System.Drawing.Point(160, 57);
            this.txtAgendaTitle.Name = "txtAgendaTitle";
            this.txtAgendaTitle.Size = new System.Drawing.Size(250, 23);
            this.txtAgendaTitle.TabIndex = 5;
            // 
            // txtOffice
            // 
            this.txtOffice.Location = new System.Drawing.Point(160, 87);
            this.txtOffice.Name = "txtOffice";
            this.txtOffice.Size = new System.Drawing.Size(250, 23);
            this.txtOffice.TabIndex = 6;
            // 
            // txtSupportingDocument
            // 
            this.txtSupportingDocument.Location = new System.Drawing.Point(160, 117);
            this.txtSupportingDocument.Name = "txtSupportingDocument";
            this.txtSupportingDocument.Size = new System.Drawing.Size(250, 23);
            this.txtSupportingDocument.TabIndex = 7;
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
            // dgvAgendas
            // 
            this.dgvAgendas.AllowUserToAddRows = false;
            this.dgvAgendas.AllowUserToDeleteRows = false;
            this.dgvAgendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAgendas.Location = new System.Drawing.Point(3, 19);
            this.dgvAgendas.MultiSelect = false;
            this.dgvAgendas.Name = "dgvAgendas";
            this.dgvAgendas.ReadOnly = true;
            this.dgvAgendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgendas.Size = new System.Drawing.Size(644, 300);
            this.dgvAgendas.TabIndex = 11;
            this.dgvAgendas.SelectionChanged += new System.EventHandler(this.dgvAgendas_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMeeting);
            this.groupBox1.Controls.Add(this.lblAgendaTitle);
            this.groupBox1.Controls.Add(this.lblOffice);
            this.groupBox1.Controls.Add(this.lblSupportingDocument);
            this.groupBox1.Controls.Add(this.cmbMeeting);
            this.groupBox1.Controls.Add(this.txtAgendaTitle);
            this.groupBox1.Controls.Add(this.txtOffice);
            this.groupBox1.Controls.Add(this.txtSupportingDocument);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 210);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agenda Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAgendas);
            this.groupBox2.Location = new System.Drawing.Point(450, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 322);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agendas List";
            // 
            // AgendaManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1112, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AgendaManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agenda Management";
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
        }
    }
}

