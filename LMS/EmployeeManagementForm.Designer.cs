namespace HotelManagement.Desktop
{
    partial class EmployeeManagementForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            labelTitle = new Label();
            btnSearchEmployee = new Button();
            txtSearchEmployee = new TextBox();
            dgvEmployees = new DataGridView();
            panelForm = new Panel();
            panelDetails = new Panel();
            dtpHireDate = new DateTimePicker();
            cmbStatus = new ComboBox();
            cmbPosition = new ComboBox();
            cmbDepartment = new ComboBox();
            txtEmergencyContact = new TextBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtSalary = new TextBox();
            txtAge = new TextBox();
            txtFullName = new TextBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelButtons = new Panel();
            btnGenerateReport = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnAddNew = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            panelForm.SuspendLayout();
            panelDetails.SuspendLayout();
            panelButtons.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(31, 43, 82);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(btnSearchEmployee);
            panelHeader.Controls.Add(txtSearchEmployee);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 4, 4, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1500, 100);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.FromArgb(255, 215, 0);
            labelTitle.Location = new Point(25, 25);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(527, 48);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "👨‍💼 EMPLOYEE MANAGEMENT";
            // 
            // btnSearchEmployee
            // 
            btnSearchEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchEmployee.BackColor = Color.FromArgb(255, 215, 0);
            btnSearchEmployee.FlatAppearance.BorderSize = 0;
            btnSearchEmployee.FlatStyle = FlatStyle.Flat;
            btnSearchEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearchEmployee.ForeColor = Color.FromArgb(31, 43, 82);
            btnSearchEmployee.Location = new Point(1188, 25);
            btnSearchEmployee.Margin = new Padding(4, 4, 4, 4);
            btnSearchEmployee.Name = "btnSearchEmployee";
            btnSearchEmployee.Size = new Size(150, 50);
            btnSearchEmployee.TabIndex = 2;
            btnSearchEmployee.Text = "🔍 SEARCH";
            btnSearchEmployee.UseVisualStyleBackColor = false;
            btnSearchEmployee.Click += btnSearchEmployee_Click;
            // 
            // txtSearchEmployee
            // 
            txtSearchEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchEmployee.Font = new Font("Segoe UI", 11F);
            txtSearchEmployee.Location = new Point(875, 25);
            txtSearchEmployee.Margin = new Padding(4, 4, 4, 4);
            txtSearchEmployee.Name = "txtSearchEmployee";
            txtSearchEmployee.PlaceholderText = "Search by name or department...";
            txtSearchEmployee.Size = new Size(286, 37);
            txtSearchEmployee.TabIndex = 1;
            txtSearchEmployee.KeyPress += txtSearchEmployee_KeyPress;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(25, 25);
            dgvEmployees.Margin = new Padding(4, 4, 4, 4);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1424, 312);
            dgvEmployees.TabIndex = 1;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
            // 
            // panelForm
            // 
            panelForm.AutoScroll = true;
            panelForm.BackColor = Color.FromArgb(240, 242, 245);
            panelForm.Controls.Add(panelDetails);
            panelForm.Controls.Add(dgvEmployees);
            panelForm.Controls.Add(panelButtons);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 100);
            panelForm.Margin = new Padding(4, 4, 4, 4);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1500, 805);
            panelForm.TabIndex = 2;
            // 
            // panelDetails
            // 
            panelDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelDetails.BackColor = Color.White;
            panelDetails.BorderStyle = BorderStyle.FixedSingle;
            panelDetails.Controls.Add(dtpHireDate);
            panelDetails.Controls.Add(cmbStatus);
            panelDetails.Controls.Add(cmbPosition);
            panelDetails.Controls.Add(cmbDepartment);
            panelDetails.Controls.Add(txtEmergencyContact);
            panelDetails.Controls.Add(txtAddress);
            panelDetails.Controls.Add(txtEmail);
            panelDetails.Controls.Add(txtPhone);
            panelDetails.Controls.Add(txtSalary);
            panelDetails.Controls.Add(txtAge);
            panelDetails.Controls.Add(txtFullName);
            panelDetails.Controls.Add(label14);
            panelDetails.Controls.Add(label13);
            panelDetails.Controls.Add(label12);
            panelDetails.Controls.Add(label11);
            panelDetails.Controls.Add(label10);
            panelDetails.Controls.Add(label9);
            panelDetails.Controls.Add(label8);
            panelDetails.Controls.Add(label7);
            panelDetails.Controls.Add(label6);
            panelDetails.Controls.Add(label5);
            panelDetails.Controls.Add(label4);
            panelDetails.Controls.Add(label3);
            panelDetails.Controls.Add(label2);
            panelDetails.Controls.Add(label1);
            panelDetails.Location = new Point(25, 362);
            panelDetails.Margin = new Padding(4, 4, 4, 4);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(1424, 350);
            panelDetails.TabIndex = 3;
            // 
            // dtpHireDate
            // 
            dtpHireDate.Font = new Font("Segoe UI", 10F);
            dtpHireDate.Format = DateTimePickerFormat.Short;
            dtpHireDate.Location = new Point(1062, 175);
            dtpHireDate.Margin = new Padding(4, 4, 4, 4);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(312, 34);
            dtpHireDate.TabIndex = 5;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(250, 225);
            cmbStatus.Margin = new Padding(4, 4, 4, 4);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(249, 36);
            cmbStatus.TabIndex = 4;
            // 
            // cmbPosition
            // 
            cmbPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPosition.Font = new Font("Segoe UI", 10F);
            cmbPosition.FormattingEnabled = true;
            cmbPosition.Location = new Point(250, 175);
            cmbPosition.Margin = new Padding(4, 4, 4, 4);
            cmbPosition.Name = "cmbPosition";
            cmbPosition.Size = new Size(249, 36);
            cmbPosition.TabIndex = 3;
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Font = new Font("Segoe UI", 10F);
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(250, 125);
            cmbDepartment.Margin = new Padding(4, 4, 4, 4);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(249, 36);
            cmbDepartment.TabIndex = 2;
            // 
            // txtEmergencyContact
            // 
            txtEmergencyContact.Font = new Font("Segoe UI", 10F);
            txtEmergencyContact.Location = new Point(1062, 225);
            txtEmergencyContact.Margin = new Padding(4, 4, 4, 4);
            txtEmergencyContact.Multiline = true;
            txtEmergencyContact.Name = "txtEmergencyContact";
            txtEmergencyContact.Size = new Size(312, 74);
            txtEmergencyContact.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(1062, 125);
            txtAddress.Margin = new Padding(4, 4, 4, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(312, 36);
            txtAddress.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(1062, 75);
            txtEmail.Margin = new Padding(4, 4, 4, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(312, 34);
            txtEmail.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(250, 275);
            txtPhone.Margin = new Padding(4, 4, 4, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(249, 34);
            txtPhone.TabIndex = 5;
            // 
            // txtSalary
            // 
            txtSalary.Font = new Font("Segoe UI", 10F);
            txtSalary.Location = new Point(655, 78);
            txtSalary.Margin = new Padding(4, 4, 4, 4);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(249, 34);
            txtSalary.TabIndex = 6;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 10F);
            txtAge.Location = new Point(655, 125);
            txtAge.Margin = new Padding(4, 4, 4, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(124, 34);
            txtAge.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(250, 75);
            txtFullName.Margin = new Padding(4, 4, 4, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(312, 34);
            txtFullName.TabIndex = 0;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(31, 43, 82);
            label14.Location = new Point(912, 131);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(92, 28);
            label14.TabIndex = 13;
            label14.Text = "Address:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(31, 43, 82);
            label13.Location = new Point(912, 81);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(69, 28);
            label13.TabIndex = 12;
            label13.Text = "Email:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(31, 43, 82);
            label12.Location = new Point(912, 181);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(108, 28);
            label12.TabIndex = 11;
            label12.Text = "Hire Date:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(31, 43, 82);
            label11.Location = new Point(912, 231);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(116, 56);
            label11.TabIndex = 10;
            label11.Text = "Emergency\r\nContact:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(31, 43, 82);
            label10.Location = new Point(62, 281);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(76, 28);
            label10.TabIndex = 9;
            label10.Text = "Phone:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(31, 43, 82);
            label9.Location = new Point(62, 231);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(76, 28);
            label9.TabIndex = 8;
            label9.Text = "Status:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(31, 43, 82);
            label8.Location = new Point(62, 181);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(93, 28);
            label8.TabIndex = 7;
            label8.Text = "Position:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(31, 43, 82);
            label7.Location = new Point(62, 131);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(132, 28);
            label7.TabIndex = 6;
            label7.Text = "Department:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(31, 43, 82);
            label6.Location = new Point(570, 131);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(54, 28);
            label6.TabIndex = 5;
            label6.Text = "Age:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(31, 43, 82);
            label5.Location = new Point(570, 84);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 28);
            label5.TabIndex = 4;
            label5.Text = "Salary:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(31, 43, 82);
            label4.Location = new Point(62, 81);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(113, 28);
            label4.TabIndex = 3;
            label4.Text = "Full Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(31, 43, 82);
            label3.Location = new Point(25, 19);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(273, 38);
            label3.TabIndex = 2;
            label3.Text = "EMPLOYEE DETAILS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 81);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.BackColor = Color.FromArgb(240, 242, 245);
            panelButtons.Controls.Add(btnGenerateReport);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnAddNew);
            panelButtons.Location = new Point(25, 725);
            panelButtons.Margin = new Padding(4, 4, 4, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1424, 88);
            panelButtons.TabIndex = 2;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGenerateReport.BackColor = Color.FromArgb(155, 89, 182);
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(1174, 19);
            btnGenerateReport.Margin = new Padding(4, 4, 4, 4);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(225, 50);
            btnGenerateReport.TabIndex = 5;
            btnGenerateReport.Text = "📊 GENERATE REPORT";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(230, 126, 34);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(924, 19);
            btnClear.Margin = new Padding(4, 4, 4, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(225, 50);
            btnClear.TabIndex = 4;
            btnClear.Text = "🔄 CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(674, 19);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(225, 50);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(424, 19);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(225, 50);
            btnSave.TabIndex = 2;
            btnSave.Text = "💾 SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.FromArgb(52, 152, 219);
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(25, 19);
            btnAddNew.Margin = new Padding(4, 4, 4, 4);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(225, 50);
            btnAddNew.TabIndex = 1;
            btnAddNew.Text = "➕ ADD NEW";
            btnAddNew.UseVisualStyleBackColor = false;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 873);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1500, 32);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(138, 25);
            toolStripStatusLabel.Text = "Ready to work...";
            // 
            // EmployeeManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1500, 905);
            Controls.Add(statusStrip1);
            Controls.Add(panelForm);
            Controls.Add(panelHeader);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1517, 950);
            Name = "EmployeeManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management - Hotel Hyatt";
            Load += EmployeeManagementForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            panelForm.ResumeLayout(false);
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            panelButtons.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Button btnSearchEmployee;
        private TextBox txtSearchEmployee;
        private DataGridView dgvEmployees;
        private Panel panelForm;
        private Panel panelButtons;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private Button btnAddNew;
        private Panel panelDetails;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtFullName;
        private TextBox txtAge;
        private TextBox txtSalary;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private TextBox txtEmergencyContact;
        private ComboBox cmbDepartment;
        private ComboBox cmbPosition;
        private ComboBox cmbStatus;
        private DateTimePicker dtpHireDate;
        private Button btnGenerateReport;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}