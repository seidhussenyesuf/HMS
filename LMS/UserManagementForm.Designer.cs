namespace HotelManagement.Desktop
{
    partial class UserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            panel1 = new Panel();
            btnSearchUser = new Button();
            txtSearchUser = new TextBox();
            label1 = new Label();
            dgvUsers = new DataGridView();
            groupBox1 = new GroupBox();
            cmbRole = new ComboBox();
            label15 = new Label();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            btnToggleActive = new Button();
            btnResetPassword = new Button();
            btnClear = new Button();
            btnDeleteUser = new Button();
            btnSaveUser = new Button();
            btnAddNewUser = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 43, 82);
            panel1.Controls.Add(btnSearchUser);
            panel1.Controls.Add(txtSearchUser);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 70);
            panel1.TabIndex = 0;
            // 
            // btnSearchUser
            // 
            btnSearchUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearchUser.BackColor = Color.FromArgb(255, 215, 0);
            btnSearchUser.FlatAppearance.BorderSize = 0;
            btnSearchUser.FlatStyle = FlatStyle.Flat;
            btnSearchUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearchUser.ForeColor = Color.FromArgb(31, 43, 82);
            btnSearchUser.Location = new Point(950, 20);
            btnSearchUser.Name = "btnSearchUser";
            btnSearchUser.Size = new Size(120, 30);
            btnSearchUser.TabIndex = 2;
            btnSearchUser.Text = "🔍 SEARCH";
            btnSearchUser.UseVisualStyleBackColor = false;
            btnSearchUser.Click += btnSearchUser_Click;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchUser.Font = new Font("Segoe UI", 10F);
            txtSearchUser.Location = new Point(700, 20);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.PlaceholderText = "Search by name or username...";
            txtSearchUser.Size = new Size(230, 30);
            txtSearchUser.TabIndex = 1;
            txtSearchUser.KeyPress += txtSearchUser_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 215, 0);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(314, 41);
            label1.TabIndex = 0;
            label1.Text = "👤 USER MANAGEMENT";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(20, 20);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1160, 250);
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(cmbRole);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtConfirmPassword);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(31, 43, 82);
            groupBox1.Location = new Point(20, 290);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1160, 280);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "USER DETAILS";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(850, 140);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(250, 31);
            cmbRole.TabIndex = 7;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label15.Location = new Point(730, 145);
            label15.Name = "label15";
            label15.Size = new Size(48, 23);
            label15.TabIndex = 16;
            label15.Text = "Role:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(850, 180);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(250, 30);
            txtConfirmPassword.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(850, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(250, 30);
            txtPassword.TabIndex = 6;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Segoe UI", 10F);
            txtUserName.Location = new Point(850, 60);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(250, 30);
            txtUserName.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(250, 180);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 30);
            txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(250, 140);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 30);
            txtPhone.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(250, 100);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(250, 30);
            txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(250, 60);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(250, 30);
            txtFirstName.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label14.Location = new Point(730, 185);
            label14.Name = "label14";
            label14.Size = new Size(148, 23);
            label14.TabIndex = 7;
            label14.Text = "Confirm Password:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label13.Location = new Point(730, 105);
            label13.Name = "label13";
            label13.Size = new Size(87, 23);
            label13.TabIndex = 6;
            label13.Text = "Password:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label12.Location = new Point(730, 65);
            label12.Name = "label12";
            label12.Size = new Size(96, 23);
            label12.TabIndex = 5;
            label12.Text = "Username:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(100, 185);
            label11.Name = "label11";
            label11.Size = new Size(55, 23);
            label11.TabIndex = 4;
            label11.Text = "Email:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(100, 145);
            label10.Name = "label10";
            label10.Size = new Size(61, 23);
            label10.TabIndex = 3;
            label10.Text = "Phone:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(100, 105);
            label9.Name = "label9";
            label9.Size = new Size(92, 23);
            label9.TabIndex = 2;
            label9.Text = "Last Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(100, 65);
            label8.Name = "label8";
            label8.Size = new Size(95, 23);
            label8.TabIndex = 1;
            label8.Text = "First Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(100, 65);
            label7.Name = "label7";
            label7.Size = new Size(0, 23);
            label7.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 65);
            label2.Name = "label2";
            label2.Size = new Size(0, 23);
            label2.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(240, 242, 245);
            panel2.Controls.Add(btnToggleActive);
            panel2.Controls.Add(btnResetPassword);
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(btnDeleteUser);
            panel2.Controls.Add(btnSaveUser);
            panel2.Controls.Add(btnAddNewUser);
            panel2.Location = new Point(20, 580);
            panel2.Name = "panel2";
            panel2.Size = new Size(1160, 70);
            panel2.TabIndex = 3;
            // 
            // btnToggleActive
            // 
            btnToggleActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToggleActive.BackColor = Color.FromArgb(241, 196, 15);
            btnToggleActive.FlatAppearance.BorderSize = 0;
            btnToggleActive.FlatStyle = FlatStyle.Flat;
            btnToggleActive.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnToggleActive.ForeColor = Color.White;
            btnToggleActive.Location = new Point(960, 15);
            btnToggleActive.Name = "btnToggleActive";
            btnToggleActive.Size = new Size(180, 40);
            btnToggleActive.TabIndex = 5;
            btnToggleActive.Text = "🔄 TOGGLE ACTIVE";
            btnToggleActive.UseVisualStyleBackColor = false;
            btnToggleActive.Click += btnToggleActive_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResetPassword.BackColor = Color.FromArgb(155, 89, 182);
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(760, 15);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(180, 40);
            btnResetPassword.TabIndex = 4;
            btnResetPassword.Text = "🔄 RESET PASSWORD";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(230, 126, 34);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(560, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(180, 40);
            btnClear.TabIndex = 3;
            btnClear.Text = "🗑️ CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(360, 15);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(180, 40);
            btnDeleteUser.TabIndex = 2;
            btnDeleteUser.Text = "🗑️ DELETE";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnSaveUser
            // 
            btnSaveUser.BackColor = Color.FromArgb(46, 204, 113);
            btnSaveUser.FlatAppearance.BorderSize = 0;
            btnSaveUser.FlatStyle = FlatStyle.Flat;
            btnSaveUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveUser.ForeColor = Color.White;
            btnSaveUser.Location = new Point(160, 15);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(180, 40);
            btnSaveUser.TabIndex = 1;
            btnSaveUser.Text = "💾 SAVE";
            btnSaveUser.UseVisualStyleBackColor = false;
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.BackColor = Color.FromArgb(52, 152, 219);
            btnAddNewUser.FlatAppearance.BorderSize = 0;
            btnAddNewUser.FlatStyle = FlatStyle.Flat;
            btnAddNewUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddNewUser.ForeColor = Color.White;
            btnAddNewUser.Location = new Point(0, 15);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.Size = new Size(180, 40);
            btnAddNewUser.TabIndex = 0;
            btnAddNewUser.Text = "➕ ADD NEW";
            btnAddNewUser.UseVisualStyleBackColor = false;
            btnAddNewUser.Click += btnAddNewUser_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 698);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1200, 26);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(117, 20);
            toolStripStatusLabel.Text = "Ready to work...";
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 724);
            Controls.Add(statusStrip1);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Controls.Add(dgvUsers);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1218, 771);
            Name = "UserManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Management (Admin Only)";
            Load += UserManagementForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnSearchUser;
        private TextBox txtSearchUser;
        private Label label1;
        private DataGridView dgvUsers;
        private GroupBox groupBox1;
        private ComboBox cmbRole;
        private Label label15;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label2;
        private Panel panel2;
        private Button btnResetPassword;
        private Button btnClear;
        private Button btnDeleteUser;
        private Button btnSaveUser;
        private Button btnAddNewUser;
        private Button btnToggleActive;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}