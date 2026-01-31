using System;
using System.Linq;
using System.Windows.Forms;
using MiniDARMAS.Business;
using MiniDARMAS.Models;

namespace MiniDARMAS
{
    public partial class UserManagementForm : Form
    {
        private UserService _userService;
        private User? _selectedUser;

        public UserManagementForm()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userService.GetAllUsers();
            dgvUsers.DataSource = users;
            dgvUsers.Columns["UserId"].Visible = false;
            dgvUsers.Columns["Password"].Visible = false;
            dgvUsers.Columns["CreatedDate"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            btnSave.Text = "Add User";
            _selectedUser = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            User user = new User
            {
                FullName = txtFullName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Role = cmbRole.SelectedItem?.ToString() ?? "",
                IsActive = chkIsActive.Checked
            };

            bool success = false;
            if (_selectedUser == null)
            {
                if (_userService.CreateUser(user))
                {
                    MessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show("Failed to create user. Username may already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                user.UserId = _selectedUser.UserId;
                if (_userService.UpdateUser(user))
                {
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    success = true;
                }
                else
                {
                    MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (success)
            {
                LoadUsers();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null)
            {
                MessageBox.Show("Please select a user to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete user '{_selectedUser.FullName}'?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_userService.DeleteUser(_selectedUser.UserId))
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserId"].Value);
                var users = _userService.GetAllUsers();
                _selectedUser = users.FirstOrDefault(u => u.UserId == userId);

                if (_selectedUser != null)
                {
                    txtFullName.Text = _selectedUser.FullName;
                    txtUsername.Text = _selectedUser.Username;
                    txtPassword.Text = _selectedUser.Password;
                    cmbRole.SelectedItem = _selectedUser.Role;
                    chkIsActive.Checked = _selectedUser.IsActive;
                    btnSave.Text = "Update User";
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            var users = _userService.GetAllUsers();
            var filtered = users.Where(u => 
                u.FullName.ToLower().Contains(searchText) ||
                u.Username.ToLower().Contains(searchText) ||
                u.Role.ToLower().Contains(searchText)).ToList();
            dgvUsers.DataSource = filtered;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            chkIsActive.Checked = true;
            _selectedUser = null;
        }
    }
}

