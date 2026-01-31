using System;
using System.Windows.Forms;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ThemeHelper.ApplyTheme(this);
            LoadUserMenu();
            RedirectToDefaultForm();
        }

        private void LoadUserMenu()
        {
            if (LoginForm.CurrentUser == null)
            {
                this.Hide();
                new LoginForm().Show();
                return;
            }

            lblWelcome.Text = $"{MiniDARMAS.Business.LocalizationHelper.GetString("Welcome")}, {LoginForm.CurrentUser.FullName} ({LoginForm.CurrentUser.Role})";

            string role = LoginForm.CurrentUser.Role;
            adminToolStripMenuItem.Visible = (role == "Admin");
            operatorToolStripMenuItem.Visible = (role == "Operator");
            transcriberToolStripMenuItem.Visible = (role == "Transcriber");
            editorToolStripMenuItem.Visible = (role == "Editor");
            approverToolStripMenuItem.Visible = (role == "Approver");
        }

        private void RedirectToDefaultForm()
        {
            if (LoginForm.CurrentUser == null) return;

            string role = LoginForm.CurrentUser.Role;
            switch (role)
            {
                case "Admin":
                    dashboardToolStripMenuItem_Click(null, null);
                    break;
                case "Operator":
                    meetingManagementToolStripMenuItem_Click(null, null);
                    break;
                case "Transcriber":
                    myAssignmentsToolStripMenuItem_Click(null, null);
                    break;
                case "Editor":
                    reviewTranscriptionsToolStripMenuItem_Click(null, null);
                    break;
                case "Approver":
                    approveMeetingToolStripMenuItem_Click(null, null);
                    break;
            }
        }

        private void ShowForm(Form form)
        {
            // Close existing child forms of same type
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == form.GetType())
                {
                    child.Activate();
                    MiniDARMAS.Business.LocalizationHelper.ApplyLanguage(child); // Ensure it's translated
                    return;
                }
                child.Close();
            }

            form.MdiParent = this;
            ThemeHelper.ApplyTheme(form);
            MiniDARMAS.Business.LocalizationHelper.ApplyLanguage(form); // APPLY LANGUAGE HERE
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new DashboardForm());
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new UserManagementForm());
        }

        private void meetingManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new MeetingManagementForm());
        }

        private void agendaManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new AgendaManagementForm());
        }

        private void recordingManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new RecordingManagementForm());
        }

        private void assignmentManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new AssignmentManagementForm());
        }

        private void myAssignmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new TranscriberForm());
        }

        private void reviewTranscriptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new EditorForm());
        }

        private void approveMeetingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(new ApproverForm());
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm.CurrentUser = null;
            this.Hide();
            new LoginForm().Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MiniDARMAS.Business.LocalizationHelper.CurrentLanguage = MiniDARMAS.Business.LocalizationHelper.Language.English;
            UpdateLanguage();
            englishToolStripMenuItem.Checked = true;
            amharicToolStripMenuItem.Checked = false;
        }

        private void amharicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MiniDARMAS.Business.LocalizationHelper.CurrentLanguage = MiniDARMAS.Business.LocalizationHelper.Language.Amharic;
            UpdateLanguage();
            englishToolStripMenuItem.Checked = false;
            amharicToolStripMenuItem.Checked = true;
        }

        private void UpdateLanguage()
        {
            MiniDARMAS.Business.LocalizationHelper.ApplyLanguage(this);
            foreach (Form child in this.MdiChildren)
            {
                MiniDARMAS.Business.LocalizationHelper.ApplyLanguage(child);
            }
            LoadUserMenu(); // Refresh welcome label
        }
    }
}

