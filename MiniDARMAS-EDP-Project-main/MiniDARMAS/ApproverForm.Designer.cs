namespace MiniDARMAS
{
    partial class ApproverForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMeeting;
        private System.Windows.Forms.ComboBox cmbMeeting;
        private System.Windows.Forms.RichTextBox rtxtFinalDocument;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnFinalApprove;
        private System.Windows.Forms.GroupBox groupBox1;

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
            this.cmbMeeting = new System.Windows.Forms.ComboBox();
            this.rtxtFinalDocument = new System.Windows.Forms.RichTextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFinalApprove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
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
            // cmbMeeting
            // 
            this.cmbMeeting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeeting.FormattingEnabled = true;
            this.cmbMeeting.Location = new System.Drawing.Point(90, 27);
            this.cmbMeeting.Name = "cmbMeeting";
            this.cmbMeeting.Size = new System.Drawing.Size(300, 23);
            this.cmbMeeting.TabIndex = 1;
            this.cmbMeeting.SelectedIndexChanged += new System.EventHandler(this.cmbMeeting_SelectedIndexChanged);
            // 
            // rtxtFinalDocument
            // 
            this.rtxtFinalDocument.Location = new System.Drawing.Point(20, 70);
            this.rtxtFinalDocument.Name = "rtxtFinalDocument";
            this.rtxtFinalDocument.ReadOnly = true;
            this.rtxtFinalDocument.Size = new System.Drawing.Size(800, 400);
            this.rtxtFinalDocument.TabIndex = 2;
            this.rtxtFinalDocument.Text = "";
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(20, 490);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 35);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export Document";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFinalApprove
            // 
            this.btnFinalApprove.Enabled = false;
            this.btnFinalApprove.Location = new System.Drawing.Point(180, 490);
            this.btnFinalApprove.Name = "btnFinalApprove";
            this.btnFinalApprove.Size = new System.Drawing.Size(150, 35);
            this.btnFinalApprove.TabIndex = 4;
            this.btnFinalApprove.Text = "Final Approve Meeting";
            this.btnFinalApprove.UseVisualStyleBackColor = true;
            this.btnFinalApprove.Click += new System.EventHandler(this.btnFinalApprove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMeeting);
            this.groupBox1.Controls.Add(this.cmbMeeting);
            this.groupBox1.Controls.Add(this.rtxtFinalDocument);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnFinalApprove);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 550);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Final Meeting Document";
            // 
            // ApproverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(874, 600);
            this.Controls.Add(this.groupBox1);
            this.Name = "ApproverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approver - Final Meeting Approval";
            this.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
        }
    }
}

