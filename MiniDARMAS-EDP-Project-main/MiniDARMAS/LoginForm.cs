using System;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class LoginForm : Form
    {
        private UserService _userService;
        public static User? CurrentUser { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
            MiniDARMAS.Business.LocalizationHelper.ApplyLanguage(this);
            _userService = new UserService();
            cmbRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string selectedRole = cmbRole.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(MiniDARMAS.Business.LocalizationHelper.GetString("Please enter both username and password."),
                    MiniDARMAS.Business.LocalizationHelper.GetString("Validation Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CurrentUser = _userService.Authenticate(username, password);

            if (CurrentUser != null)
            {
                // Map the UI role name back to standard English role for validation
                string actualRoleInSystem = selectedRole;
                if (MiniDARMAS.Business.LocalizationHelper.CurrentLanguage == MiniDARMAS.Business.LocalizationHelper.Language.Amharic)
                {
                    if (selectedRole == "አስተዳዳሪ") actualRoleInSystem = "Admin";
                    else if (selectedRole == "ኦፕሬተር") actualRoleInSystem = "Operator";
                    else if (selectedRole == "ጽሑፍ አዘጋጅ") actualRoleInSystem = "Transcriber";
                    else if (selectedRole == "አርታኢ") actualRoleInSystem = "Editor";
                    else if (selectedRole == "አጽዳቂ") actualRoleInSystem = "Approver";
                }

                if (!string.Equals(CurrentUser.Role, actualRoleInSystem, StringComparison.OrdinalIgnoreCase))
                {
                    string msg = string.Format(MiniDARMAS.Business.LocalizationHelper.GetString("Access denied. The account '{0}' exists, but it is assigned the role '{1}', not '{2}'."),
                        username, CurrentUser.Role, actualRoleInSystem);

                    MessageBox.Show(msg, MiniDARMAS.Business.LocalizationHelper.GetString("Role Mismatch"),
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                new Logger().LogActivity(CurrentUser.UserId, "LOGIN", "User logged in successfully");

                this.Hide();
                new MainForm().Show();
            }
            else
            {
                string errorMsg = string.Format(MiniDARMAS.Business.LocalizationHelper.GetString("Login Failed. The username '{0}' or the password you entered is incorrect. Please check your credentials and try again."), username);

                MessageBox.Show(errorMsg, MiniDARMAS.Business.LocalizationHelper.GetString("Login Failed"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

