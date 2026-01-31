using System;
using System.Data;
using System.Windows.Forms;
using MiniDARMAS.Data;

namespace MiniDARMAS
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            LoadStatistics();
            LoadActivityLogs();
        }

        private void LoadStatistics()
        {
            try
            {
                object userCount = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Users");
                lblTotalUsers.Text = userCount != null ? userCount.ToString() : "0";

                object meetingCount = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Meetings");
                lblTotalMeetings.Text = meetingCount != null ? meetingCount.ToString() : "0";

                object pendingCount = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Assignments WHERE Status = 'Assigned' OR Status = 'In Progress'");
                lblPendingAssignments.Text = pendingCount != null ? pendingCount.ToString() : "0";
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error loading statistics: {ex.Message}");
            }
        }

        private void LoadActivityLogs()
        {
            try
            {
                string query = @"
                    SELECT TOP 50 
                        al.LogDate, 
                        u.Username, 
                        al.ActivityType, 
                        al.Description
                    FROM ActivityLogs al(NOLOCK)
                    LEFT JOIN Users u(NOLOCK) ON al.UserId = u.UserId
                    ORDER BY al.LogDate DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvActivityLogs.DataSource = dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error loading logs: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadActivityLogs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
