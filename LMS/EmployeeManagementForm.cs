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
    public partial class EmployeeManagementForm : Form
    {
        private HttpClient _httpClient;
        private string _apiBaseUrl = "https://localhost:7018/api/";
        private BindingList<Employee> _employees = new BindingList<Employee>();
        private int _currentEmployeeId = 0;
        private string _token;

        public EmployeeManagementForm(string token = "")
        {
            InitializeComponent();
            _token = token;

            // Setup HTTP client
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            }

            SetupDataGridView();
            SetupForm();
        }

        private void SetupDataGridView()
        {
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.Columns.Clear();

            // Create columns
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "Id";
            colId.Width = 50;
            dgvEmployees.Columns.Add(colId);

            DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
            colName.Name = "colName";
            colName.HeaderText = "Full Name";
            colName.DataPropertyName = "Name";
            colName.Width = 150;
            dgvEmployees.Columns.Add(colName);

            DataGridViewTextBoxColumn colAge = new DataGridViewTextBoxColumn();
            colAge.Name = "colAge";
            colAge.HeaderText = "Age";
            colAge.DataPropertyName = "Age";
            colAge.Width = 60;
            dgvEmployees.Columns.Add(colAge);

            DataGridViewTextBoxColumn colDepartment = new DataGridViewTextBoxColumn();
            colDepartment.Name = "colDepartment";
            colDepartment.HeaderText = "Department";
            colDepartment.DataPropertyName = "Department";
            colDepartment.Width = 120;
            dgvEmployees.Columns.Add(colDepartment);

            DataGridViewTextBoxColumn colPosition = new DataGridViewTextBoxColumn();
            colPosition.Name = "colPosition";
            colPosition.HeaderText = "Position";
            colPosition.DataPropertyName = "Position";
            colPosition.Width = 120;
            dgvEmployees.Columns.Add(colPosition);

            DataGridViewTextBoxColumn colSalary = new DataGridViewTextBoxColumn();
            colSalary.Name = "colSalary";
            colSalary.HeaderText = "Salary";
            colSalary.DataPropertyName = "Salary";
            colSalary.Width = 100;
            colSalary.DefaultCellStyle.Format = "C2";
            dgvEmployees.Columns.Add(colSalary);

            DataGridViewTextBoxColumn colJoinDate = new DataGridViewTextBoxColumn();
            colJoinDate.Name = "colJoinDate";
            colJoinDate.HeaderText = "Join Date";
            colJoinDate.DataPropertyName = "JoinDate";
            colJoinDate.Width = 100;
            colJoinDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvEmployees.Columns.Add(colJoinDate);

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "colStatus";
            colStatus.HeaderText = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.Width = 80;
            dgvEmployees.Columns.Add(colStatus);

            DataGridViewButtonColumn colActions = new DataGridViewButtonColumn();
            colActions.Name = "colActions";
            colActions.HeaderText = "Actions";
            colActions.Text = "Actions";
            colActions.UseColumnTextForButtonValue = true;
            colActions.Width = 80;
            dgvEmployees.Columns.Add(colActions);
        }

        private void SetupForm()
        {
            // Setup Department combo box
            SetupDepartmentComboBox();
            SetupPositionComboBox();
            SetupStatusComboBox();

            // Set default hire date to today
            dtpHireDate.Value = DateTime.Today;

            LoadEmployeesAsync();
        }

        private void SetupDepartmentComboBox()
        {
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.AddRange(new string[] {
                "Reception",
                "Housekeeping",
                "Kitchen",
                "Maintenance",
                "Security",
                "Management",
                "Human Resources",
                "Accounting",
                "Sales & Marketing",
                "Food & Beverage",
                "Other"
            });
            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0;
        }

        private void SetupPositionComboBox()
        {
            cmbPosition.Items.Clear();
            cmbPosition.Items.AddRange(new string[] {
                "Receptionist",
                "Front Desk Clerk",
                "Housekeeping Supervisor",
                "Room Attendant",
                "Chef",
                "Sous Chef",
                "Line Cook",
                "Maintenance Technician",
                "Security Guard",
                "Manager",
                "Assistant Manager",
                "HR Manager",
                "Accountant",
                "Sales Executive",
                "Other"
            });
            if (cmbPosition.Items.Count > 0)
                cmbPosition.SelectedIndex = 0;
        }

        private void SetupStatusComboBox()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] {
                "Active",
                "Inactive"
            });
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;
        }

        private async void LoadEmployeesAsync()
        {
            try
            {
                ShowStatus("Loading employees...");
                Console.WriteLine($"Calling API: {_apiBaseUrl}employees");

                var response = await _httpClient.GetAsync("employees");

                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Response JSON: {json}");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var apiEmployeeList = JsonSerializer.Deserialize<List<ApiEmployee>>(json, options) ?? new List<ApiEmployee>();

                    // Convert API employees to form employees
                    var formEmployeeList = new List<Employee>();
                    foreach (var apiEmp in apiEmployeeList)
                    {
                        formEmployeeList.Add(new Employee
                        {
                            Id = apiEmp.Id,
                            Name = apiEmp.Name,
                            Age = apiEmp.Age,
                            Department = apiEmp.Department,
                            Position = apiEmp.Position,
                            Salary = apiEmp.Salary,
                            Phone = apiEmp.Phone,
                            Email = apiEmp.Email,
                            Address = apiEmp.Address,
                            JoinDate = apiEmp.JoinDate,
                            IsActive = apiEmp.IsActive
                        });
                    }

                    _employees = new BindingList<Employee>(formEmployeeList);

                    dgvEmployees.DataSource = null;
                    dgvEmployees.DataSource = _employees;
                    dgvEmployees.ClearSelection();

                    ShowStatus($"Loaded {_employees.Count} employees");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error: {error}");
                    ShowStatus($"Failed to load employees: {response.StatusCode}");
                    UseDummyEmployees();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in LoadEmployeesAsync: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                ShowStatus($"Error loading employees: {ex.Message}");
                UseDummyEmployees();
            }
        }

        private void UseDummyEmployees()
        {
            _employees = new BindingList<Employee>
            {
                new Employee {
                    Id = 1,
                    Name = "John Smith",
                    Age = 30,
                    Department = "Reception",
                    Position = "Receptionist",
                    Salary = 2500,
                    Phone = "123-456-7890",
                    Email = "john.smith@hotelhyatt.com",
                    Address = "123 Hotel Street, City",
                    JoinDate = DateTime.Now.AddYears(-2),
                    IsActive = true
                },
                new Employee {
                    Id = 2,
                    Name = "Maria Garcia",
                    Age = 28,
                    Department = "Housekeeping",
                    Position = "Supervisor",
                    Salary = 2800,
                    Phone = "987-654-3210",
                    Email = "maria.garcia@hotelhyatt.com",
                    Address = "456 Clean Avenue, City",
                    JoinDate = DateTime.Now.AddYears(-1),
                    IsActive = true
                },
                new Employee {
                    Id = 3,
                    Name = "David Chen",
                    Age = 35,
                    Department = "Kitchen",
                    Position = "Head Chef",
                    Salary = 3500,
                    Phone = "555-123-4567",
                    Email = "david.chen@hotelhyatt.com",
                    Address = "789 Food Boulevard, City",
                    JoinDate = DateTime.Now.AddYears(-3),
                    IsActive = true
                },
                new Employee {
                    Id = 4,
                    Name = "Sarah Johnson",
                    Age = 32,
                    Department = "Management",
                    Position = "Hotel Manager",
                    Salary = 4500,
                    Phone = "333-444-5555",
                    Email = "sarah.johnson@hotelhyatt.com",
                    Address = "101 Manager Road, City",
                    JoinDate = DateTime.Now.AddYears(-5),
                    IsActive = true
                }
            };

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _employees;
            dgvEmployees.ClearSelection();

            ShowStatus("Using sample data - Check API connection");
        }

        private async void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchEmployee.Text))
            {
                LoadEmployeesAsync();
                return;
            }

            try
            {
                ShowStatus("Searching employees...");
                var searchQuery = txtSearchEmployee.Text.Trim();
                var response = await _httpClient.GetAsync($"employees/search?query={Uri.EscapeDataString(searchQuery)}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var apiEmployeeList = JsonSerializer.Deserialize<List<ApiEmployee>>(json, options) ?? new List<ApiEmployee>();

                    // Convert API employees to form employees
                    var formEmployeeList = new List<Employee>();
                    foreach (var apiEmp in apiEmployeeList)
                    {
                        formEmployeeList.Add(new Employee
                        {
                            Id = apiEmp.Id,
                            Name = apiEmp.Name,
                            Age = apiEmp.Age,
                            Department = apiEmp.Department,
                            Position = apiEmp.Position,
                            Salary = apiEmp.Salary,
                            Phone = apiEmp.Phone,
                            Email = apiEmp.Email,
                            Address = apiEmp.Address,
                            JoinDate = apiEmp.JoinDate,
                            IsActive = apiEmp.IsActive
                        });
                    }

                    _employees = new BindingList<Employee>(formEmployeeList);

                    dgvEmployees.DataSource = null;
                    dgvEmployees.DataSource = _employees;

                    ShowStatus($"Found {_employees.Count} employees matching '{searchQuery}'");
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            _currentEmployeeId = 0;
            txtFullName.Focus();
            ShowStatus("Ready to add new employee...");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validate all fields with specific messages
            string validationError = ValidateEmployeeForm();
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate email
            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email))
            {
                bool emailExists = _employees.Any(emp =>
                    emp.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                    emp.Id != _currentEmployeeId);

                if (emailExists)
                {
                    MessageBox.Show($"Email '{email}' is already registered to another employee.",
                        "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
            }

            try
            {
                // Create employee data matching API model
                var employeeData = new
                {
                    Name = txtFullName.Text.Trim(),
                    Age = int.Parse(txtAge.Text),
                    Department = cmbDepartment.Text,
                    Position = cmbPosition.Text,
                    Salary = decimal.Parse(txtSalary.Text),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                var json = JsonSerializer.Serialize(employeeData);
                Console.WriteLine($"Sending JSON: {json}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                if (_currentEmployeeId == 0)
                {
                    // Add new employee
                    ShowStatus("Adding new employee...");
                    response = await _httpClient.PostAsync("employees", content);
                }
                else
                {
                    // Update existing employee
                    ShowStatus($"Updating employee {_currentEmployeeId}...");
                    response = await _httpClient.PutAsync($"employees/{_currentEmployeeId}", content);
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {response.StatusCode} - {responseContent}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Employee saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadEmployeesAsync();
                    ClearForm();
                    _currentEmployeeId = 0;
                }
                else
                {
                    MessageBox.Show($"Failed to save employee: {response.StatusCode}\n{responseContent}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nDetails: {ex.InnerException?.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateEmployeeForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
                return "Please enter employee name";

            if (string.IsNullOrWhiteSpace(txtAge.Text) || !int.TryParse(txtAge.Text, out int age))
                return "Please enter a valid age (must be a number)";

            if (age < 18 || age > 70)
                return "Age must be between 18 and 70";

            if (string.IsNullOrWhiteSpace(txtSalary.Text) || !decimal.TryParse(txtSalary.Text, out decimal salary))
                return "Please enter a valid salary (must be a number)";

            if (salary <= 0)
                return "Salary must be greater than 0";

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                return "Please enter email address";

            if (!IsValidEmail(txtEmail.Text))
                return "Please enter a valid email address (example: name@domain.com)";

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
                return "Please enter phone number";

            return string.Empty;
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvEmployees.SelectedRows[0];
            var employeeId = selectedRow.Cells["colID"].Value?.ToString();
            var employeeName = selectedRow.Cells["colName"].Value?.ToString();

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Invalid employee selected", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Delete employee '{employeeName}'?\n\nThis action cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ShowStatus($"Deleting employee {employeeName}...");
                    var response = await _httpClient.DeleteAsync($"employees/{employeeId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Convert.ToInt32(employeeId) == _currentEmployeeId)
                        {
                            _currentEmployeeId = 0;
                            ClearForm();
                        }

                        LoadEmployeesAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to delete employee: {response.StatusCode}\n{error}", "Error",
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
            _currentEmployeeId = 0;
            dgvEmployees.ClearSelection();
            ShowStatus("Form cleared. Ready to add new employee...");
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtAge.Clear();
            txtSalary.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0;
            if (cmbPosition.Items.Count > 0)
                cmbPosition.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0)
                cmbStatus.SelectedIndex = 0;

            dtpHireDate.Value = DateTime.Today;
        }

        private void ShowStatus(string message)
        {
            this.Text = $"👨‍💼 Employee Management - {message}";
            toolStripStatusLabel.Text = message;
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                _currentEmployeeId = 0;
                return;
            }

            var selectedRow = dgvEmployees.SelectedRows[0];
            var employeeId = selectedRow.Cells["colID"].Value;

            if (employeeId != null)
            {
                _currentEmployeeId = Convert.ToInt32(employeeId);

                if (selectedRow.DataBoundItem is Employee employee)
                {
                    txtFullName.Text = employee.Name;
                    txtAge.Text = employee.Age.ToString();
                    txtSalary.Text = employee.Salary.ToString("F2");
                    txtPhone.Text = employee.Phone;
                    txtEmail.Text = employee.Email;
                    txtAddress.Text = employee.Address;

                    // Set combo boxes
                    if (cmbDepartment.Items.Contains(employee.Department))
                        cmbDepartment.SelectedItem = employee.Department;
                    else
                        cmbDepartment.Text = employee.Department;

                    if (cmbPosition.Items.Contains(employee.Position))
                        cmbPosition.SelectedItem = employee.Position;
                    else
                        cmbPosition.Text = employee.Position;

                    // Set status based on IsActive
                    cmbStatus.SelectedItem = employee.IsActive ? "Active" : "Inactive";

                    // Set hire date
                    dtpHireDate.Value = employee.JoinDate;

                    ShowStatus($"Editing employee: {employee.Name}");
                }
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvEmployees.Columns["colActions"].Index)
            {
                var employeeId = dgvEmployees.Rows[e.RowIndex].Cells["colID"].Value?.ToString();
                var employeeName = dgvEmployees.Rows[e.RowIndex].Cells["colName"].Value?.ToString();

                if (!string.IsNullOrEmpty(employeeId))
                {
                    var contextMenu = new ContextMenuStrip();

                    var editItem = contextMenu.Items.Add("✏️ Edit");
                    editItem.Click += (s, args) =>
                    {
                        dgvEmployees.ClearSelection();
                        dgvEmployees.Rows[e.RowIndex].Selected = true;
                        dgvEmployees_SelectionChanged(sender, e);
                    };

                    var deleteItem = contextMenu.Items.Add("🗑️ Delete");
                    deleteItem.Click += async (s, args) =>
                    {
                        var result = MessageBox.Show($"Delete employee '{employeeName}'?", "Confirm Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                ShowStatus($"Deleting employee {employeeName}...");
                                var response = await _httpClient.DeleteAsync($"employees/{employeeId}");
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Employee deleted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadEmployeesAsync();
                                }
                                else
                                {
                                    var error = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Failed to delete employee: {error}", "Error",
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

        private void txtSearchEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearchEmployee_Click(sender, e);
                e.Handled = true;
            }
        }

        private void EmployeeManagementForm_Load(object sender, EventArgs e)
        {
            // Center the form
            this.CenterToScreen();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee report generation would be implemented here.\n\nThis would generate:\n- Employee Directory\n- Salary Report\n- Department-wise Report\n- Attendance Report",
                "Generate Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Form Employee model class
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Department { get; set; } = string.Empty;
            public string Position { get; set; } = string.Empty;
            public decimal Salary { get; set; }
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public DateTime JoinDate { get; set; } = DateTime.Now;
            public bool IsActive { get; set; } = true;

            // Helper property for display
            public string Status => IsActive ? "Active" : "Inactive";
        }

        // API Employee model class (for deserialization)
        private class ApiEmployee
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int Age { get; set; }
            public string Department { get; set; } = string.Empty;
            public string Position { get; set; } = string.Empty;
            public decimal Salary { get; set; }
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public DateTime JoinDate { get; set; } = DateTime.Now;
            public bool IsActive { get; set; } = true;
        }
    }
}