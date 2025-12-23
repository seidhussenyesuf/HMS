using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Desktop
{
    public partial class UserManagementForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<User> _users = new BindingList<User>();
        private int _currentUserId = 0;
        private string _token;
        private bool _isSaving = false;
        private bool _eventsWired = false;

        public UserManagementForm(string token = "")
        {
            InitializeComponent();
            _token = token;

            SetupHttpClient();
            SetupDataGridView();
            SetupForm();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            if (_eventsWired) return;

            btnSearchUser.Click += btnSearchUser_Click;
            btnAddNewUser.Click += btnAddNewUser_Click;
            btnSaveUser.Click += btnSaveUser_Click;
            btnDeleteUser.Click += btnDeleteUser_Click;
            btnClear.Click += btnClear_Click;
            btnResetPassword.Click += btnResetPassword_Click;
            btnToggleActive.Click += btnToggleActive_Click;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.CellClick += dgvUsers_CellClick;
            txtSearchUser.KeyPress += txtSearchUser_KeyPress;

            _eventsWired = true;
        }

        private void SetupHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            }
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            colId.Width = 50;
            dgvUsers.Columns.Add(colId);

            DataGridViewTextBoxColumn colUserName = new DataGridViewTextBoxColumn();
            colUserName.Name = "colUserName";
            colUserName.HeaderText = "Username";
            colUserName.DataPropertyName = "UserName";
            colUserName.Width = 120;
            dgvUsers.Columns.Add(colUserName);

            DataGridViewTextBoxColumn colFullName = new DataGridViewTextBoxColumn();
            colFullName.Name = "colFullName";
            colFullName.HeaderText = "Full Name";
            colFullName.DataPropertyName = "FullName";
            colFullName.Width = 150;
            dgvUsers.Columns.Add(colFullName);

            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.Name = "colPhone";
            colPhone.HeaderText = "Phone";
            colPhone.DataPropertyName = "Phone";
            colPhone.Width = 100;
            dgvUsers.Columns.Add(colPhone);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "colEmail";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Width = 150;
            dgvUsers.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.Name = "colRole";
            colRole.HeaderText = "Role";
            colRole.DataPropertyName = "Role";
            colRole.Width = 100;
            dgvUsers.Columns.Add(colRole);

            DataGridViewCheckBoxColumn colIsActive = new DataGridViewCheckBoxColumn();
            colIsActive.Name = "colIsActive";
            colIsActive.HeaderText = "Active";
            colIsActive.DataPropertyName = "IsActive";
            colIsActive.Width = 70;
            dgvUsers.Columns.Add(colIsActive);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 80;
            dgvUsers.Columns.Add(colActions);
        }

        private void SetupForm()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] {
                "Admin",
                "Receptionist",
                "Manager",
                "Housekeeping",
                "Kitchen",
                "Security"
            });
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;

            LoadUsersAsync();
        }

        private async void LoadUsersAsync()
        {
            try
            {
                ShowStatus("Loading users...");
                var response = await _httpClient.GetAsync("users");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Users API Response: {json}");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var userList = JsonSerializer.Deserialize<List<User>>(json, options) ?? new List<User>();
                    _users = new BindingList<User>(userList);

                    dgvUsers.DataSource = null;
                    dgvUsers.DataSource = _users;
                    dgvUsers.ClearSelection();

                    ShowStatus($"Loaded {_users.Count} users");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error loading users: {error}");
                    ShowStatus($"Failed to load users: {response.StatusCode}");

                    UseDummyUsers();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception loading users: {ex.Message}");
                ShowStatus($"Error loading users: {ex.Message}");
                UseDummyUsers();
            }
        }

        private void UseDummyUsers()
        {
            _users = new BindingList<User>
            {
                new User {
                    Id = 1,
                    UserName = "admin",
                    FullName = "System Administrator",
                    Phone = "123-456-7890",
                    Email = "admin@hotelhyatt.com",
                    Role = "Admin",
                    IsActive = true
                },
                new User {
                    Id = 2,
                    UserName = "john.reception",
                    FullName = "John Smith",
                    Phone = "987-654-3210",
                    Email = "john@hotelhyatt.com",
                    Role = "Receptionist",
                    IsActive = true
                },
                new User {
                    Id = 3,
                    UserName = "maria.manager",
                    FullName = "Maria Garcia",
                    Phone = "555-123-4567",
                    Email = "maria@hotelhyatt.com",
                    Role = "Manager",
                    IsActive = true
                }
            };

            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
            dgvUsers.ClearSelection();

            ShowStatus("Using sample data - Check API connection");
        }

        private async void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchUser.Text))
            {
                LoadUsersAsync();
                return;
            }

            try
            {
                ShowStatus("Searching users...");
                var searchQuery = txtSearchUser.Text.Trim();
                var response = await _httpClient.GetAsync($"users/search?query={Uri.EscapeDataString(searchQuery)}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var userList = JsonSerializer.Deserialize<List<User>>(json, options) ?? new List<User>();
                    _users = new BindingList<User>(userList);

                    dgvUsers.DataSource = null;
                    dgvUsers.DataSource = _users;

                    ShowStatus($"Found {_users.Count} users matching '{searchQuery}'");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Search failed: {response.StatusCode}\n{error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentUserId = 0;
            txtUserName.Focus();
            ShowStatus("Ready to add new user...");
        }

        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (_isSaving) return;
            _isSaving = true;
            btnSaveUser.Enabled = false;

            try
            {
                if (!ValidateUserForm())
                    return;

                HttpResponseMessage response;
                string endpoint;
                object userData;

                if (_currentUserId == 0)
                {
                    // CREATE NEW USER
                    userData = new
                    {
                        userName = txtUserName.Text.Trim(),
                        password = txtPassword.Text.Trim(),
                        fullName = $"{txtFirstName.Text.Trim()} {txtLastName.Text.Trim()}".Trim(),
                        phone = txtPhone.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                        role = cmbRole.SelectedItem?.ToString() ?? "Receptionist"
                    };
                    endpoint = "auth/register";
                    ShowStatus("Registering new user...");
                }
                else
                {
                    // UPDATE EXISTING USER
                    userData = new
                    {
                        fullName = $"{txtFirstName.Text.Trim()} {txtLastName.Text.Trim()}".Trim(),
                        phone = txtPhone.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                        role = cmbRole.SelectedItem?.ToString() ?? "Receptionist"
                    };
                    endpoint = $"users/{_currentUserId}";
                    ShowStatus($"Updating user {_currentUserId}...");
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var json = JsonSerializer.Serialize(userData, options);
                Console.WriteLine($"Sending to {endpoint}: {json}");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                if (_currentUserId == 0)
                    response = await _httpClient.PostAsync(endpoint, content);
                else
                    response = await _httpClient.PutAsync(endpoint, content);

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response from {endpoint}: {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await Task.Delay(1000); // Wait 1 second
                    LoadUsersAsync(); // Refresh the list
                    ClearForm();
                    _currentUserId = 0;
                }
                else
                {
                    var errorMessage = ParseErrorMessage(responseContent);
                    MessageBox.Show($"Failed to save user: {errorMessage}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSaving = false;
                btnSaveUser.Enabled = true;
            }
        }

        private string ParseErrorMessage(string errorJson)
        {
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var errorObj = JsonSerializer.Deserialize<Dictionary<string, object>>(errorJson, options);

                if (errorObj != null)
                {
                    if (errorObj.ContainsKey("message"))
                        return errorObj["message"].ToString();
                    if (errorObj.ContainsKey("error"))
                        return errorObj["error"].ToString();
                    if (errorObj.ContainsKey("errors"))
                        return errorObj["errors"].ToString();
                }

                // Try to find common patterns
                if (errorJson.Contains("InternalServerError"))
                    return "Server error occurred. Please try again.";
                if (errorJson.Contains("duplicate"))
                    return "Username or email already exists.";
                if (errorJson.Contains("validation"))
                    return "Validation error. Please check your input.";

                return errorJson.Length > 100 ? errorJson.Substring(0, 100) + "..." : errorJson;
            }
            catch
            {
                return errorJson.Length > 100 ? errorJson.Substring(0, 100) + "..." : errorJson;
            }
        }

        private bool ValidateUserForm()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("Please enter username", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                return false;
            }

            if (_currentUserId == 0)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter password", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var userId = selectedRow.Cells["colID"].Value?.ToString();
            var userName = selectedRow.Cells["colUserName"].Value?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Invalid user selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userName == "admin")
            {
                MessageBox.Show("Cannot delete the main administrator account", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Delete user '{userName}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Deleting user {userName}...");
                    var response = await _httpClient.DeleteAsync($"users/{userId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("User deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Convert.ToInt32(userId) == _currentUserId)
                        {
                            _currentUserId = 0;
                            ClearForm();
                        }

                        LoadUsersAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete user: {response.StatusCode}\n{error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentUserId = 0;
            dgvUsers.ClearSelection();
            ShowStatus("Form cleared. Ready to add new user...");
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to reset password", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var userId = selectedRow.Cells["colID"].Value?.ToString();
            var userName = selectedRow.Cells["colUserName"].Value?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Invalid user selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var resetForm = new Form())
            {
                resetForm.Text = $"Reset Password for {userName}";
                resetForm.Size = new Size(400, 250);
                resetForm.StartPosition = FormStartPosition.CenterParent;
                resetForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                resetForm.MaximizeBox = false;
                resetForm.MinimizeBox = false;

                Label lblNew = new Label
                {
                    Text = "New Password:",
                    Location = new Point(20, 30),
                    Size = new Size(120, 25),
                    Font = new Font("Segoe UI", 10F)
                };

                TextBox txtNew = new TextBox
                {
                    Location = new Point(150, 30),
                    Size = new Size(200, 30),
                    Font = new Font("Segoe UI", 10F),
                    PasswordChar = '*'
                };

                Label lblConfirm = new Label
                {
                    Text = "Confirm Password:",
                    Location = new Point(20, 80),
                    Size = new Size(120, 25),
                    Font = new Font("Segoe UI", 10F)
                };

                TextBox txtConfirm = new TextBox
                {
                    Location = new Point(150, 80),
                    Size = new Size(200, 30),
                    Font = new Font("Segoe UI", 10F),
                    PasswordChar = '*'
                };

                Button btnSubmit = new Button
                {
                    Text = "Reset Password",
                    Location = new Point(100, 140),
                    Size = new Size(120, 35),
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    BackColor = Color.FromArgb(52, 152, 219),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                Button btnCancel = new Button
                {
                    Text = "Cancel",
                    Location = new Point(230, 140),
                    Size = new Size(120, 35),
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.FromArgb(231, 76, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                btnSubmit.Click += async (s, args) =>
                {
                    if (string.IsNullOrWhiteSpace(txtNew.Text))
                    {
                        MessageBox.Show("Please enter new password!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtNew.Text.Length < 6)
                    {
                        MessageBox.Show("Password must be at least 6 characters!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (txtNew.Text != txtConfirm.Text)
                    {
                        MessageBox.Show("Passwords don't match!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        var passwordData = new
                        {
                            userId = Convert.ToInt32(userId),
                            newPassword = txtNew.Text
                        };

                        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                        var json = JsonSerializer.Serialize(passwordData, options);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await _httpClient.PostAsync("auth/reset-password", content);
                        var responseContent = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Password reset successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetForm.DialogResult = DialogResult.OK;
                            resetForm.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to reset password: {responseContent}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                btnCancel.Click += (s, args) =>
                {
                    resetForm.DialogResult = DialogResult.Cancel;
                    resetForm.Close();
                };

                resetForm.Controls.AddRange(new Control[] { lblNew, txtNew, lblConfirm, txtConfirm, btnSubmit, btnCancel });

                if (resetForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsersAsync();
                }
            }
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            if (cmbRole.Items.Count > 0) cmbRole.SelectedIndex = 0;
        }

        private void ShowStatus(string message)
        {
            this.Text = $"User Management - {message}";
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                _currentUserId = 0;
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var userId = selectedRow.Cells["colID"].Value;

            if (userId != null)
            {
                _currentUserId = Convert.ToInt32(userId);

                if (selectedRow.DataBoundItem is User user)
                {
                    var nameParts = user.FullName.Split(' ', 2);
                    txtFirstName.Text = nameParts.Length > 0 ? nameParts[0] : "";
                    txtLastName.Text = nameParts.Length > 1 ? nameParts[1] : "";

                    txtUserName.Text = user.UserName;
                    txtPhone.Text = user.Phone;
                    txtEmail.Text = user.Email;

                    txtPassword.Clear();
                    txtConfirmPassword.Clear();

                    if (cmbRole.Items.Contains(user.Role))
                        cmbRole.SelectedItem = user.Role;
                    else
                        cmbRole.Text = user.Role;

                    ShowStatus($"Editing user: {user.UserName}");
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvUsers.Columns["colActions"].Index)
            {
                var userId = dgvUsers.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                var userName = dgvUsers.Rows[e.RowIndex].Cells["colUserName"].Value?.ToString();

                if (!string.IsNullOrEmpty(userId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvUsers.ClearSelection();
                        dgvUsers.Rows[e.RowIndex].Selected = true;
                        dgvUsers_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        if (userName == "admin")
                        {
                            MessageBox.Show("Cannot delete the main administrator account", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var result = MessageBox.Show($"Delete user '{userName}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting user {userName}...");
                                var response = await _httpClient.DeleteAsync($"users/{userId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("User deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadUsersAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete user: {error}", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void txtSearchUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchUser_Click(sender, e);
                e.Handled = true;
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private async void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvUsers.SelectedRows[0];
            var userId = selectedRow.Cells["colID"].Value?.ToString();
            var userName = selectedRow.Cells["colUserName"].Value?.ToString();
            var isActive = Convert.ToBoolean(selectedRow.Cells["colIsActive"].Value);

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Invalid user selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userName == "admin")
            {
                MessageBox.Show("Cannot deactivate the main administrator account", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newStatus = !isActive;
            var action = newStatus ? "activate" : "deactivate";

            var result = MessageBox.Show($"{action} user '{userName}'?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var statusData = new { isActive = newStatus };
                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(statusData, options);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PatchAsync($"users/{userId}/status", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"User {userName} {action}d successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsersAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to {action} user: {error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string UserName { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Role { get; set; } = "Receptionist";
            public bool IsActive { get; set; } = true;
        }
    }
}