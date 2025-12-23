namespace HotelManagement.Desktop
{
    partial class PaymentForm
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
            lblTitle = new Label();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvPayments = new DataGridView();
            panelMain = new Panel();
            panelDetails = new Panel();
            dtpPaymentDate = new DateTimePicker();
            label7 = new Label();
            cmbPaymentMethod = new ComboBox();
            txtAmount = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelButtons = new Panel();
            btnDisplay = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            panelMain.SuspendLayout();
            panelDetails.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(31, 43, 82);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnSearch);
            panelHeader.Controls.Add(txtSearch);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 4, 4, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1500, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(255, 215, 0);
            lblTitle.Location = new Point(25, 25);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(515, 48);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "💳 PAYMENT MANAGEMENT";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(255, 215, 0);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.FromArgb(31, 43, 82);
            btnSearch.Location = new Point(1188, 25);
            btnSearch.Margin = new Padding(4, 4, 4, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 50);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(875, 25);
            txtSearch.Margin = new Padding(4, 4, 4, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name or payment method...";
            txtSearch.Size = new Size(286, 37);
            txtSearch.TabIndex = 1;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(25, 25);
            dgvPayments.Margin = new Padding(4, 4, 4, 4);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(1450, 312);
            dgvPayments.TabIndex = 1;
            dgvPayments.CellClick += dgvPayments_CellClick;
            dgvPayments.SelectionChanged += dgvPayments_SelectionChanged;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(240, 242, 245);
            panelMain.Controls.Add(panelDetails);
            panelMain.Controls.Add(dgvPayments);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 100);
            panelMain.Margin = new Padding(4, 4, 4, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1500, 775);
            panelMain.TabIndex = 2;
            // 
            // panelDetails
            // 
            panelDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelDetails.BackColor = Color.White;
            panelDetails.BorderStyle = BorderStyle.FixedSingle;
            panelDetails.Controls.Add(dtpPaymentDate);
            panelDetails.Controls.Add(label7);
            panelDetails.Controls.Add(cmbPaymentMethod);
            panelDetails.Controls.Add(txtAmount);
            panelDetails.Controls.Add(txtLastName);
            panelDetails.Controls.Add(txtFirstName);
            panelDetails.Controls.Add(label6);
            panelDetails.Controls.Add(label5);
            panelDetails.Controls.Add(label4);
            panelDetails.Controls.Add(label3);
            panelDetails.Controls.Add(label2);
            panelDetails.Controls.Add(label1);
            panelDetails.Location = new Point(25, 362);
            panelDetails.Margin = new Padding(4, 4, 4, 4);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(1450, 250);
            panelDetails.TabIndex = 3;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Font = new Font("Segoe UI", 10F);
            dtpPaymentDate.Location = new Point(1062, 125);
            dtpPaymentDate.Margin = new Padding(4, 4, 4, 4);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(312, 34);
            dtpPaymentDate.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(31, 43, 82);
            label7.Location = new Point(874, 131);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(151, 28);
            label7.TabIndex = 10;
            label7.Text = "Payment Date:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Bank Transfer", "Mobile Payment" });
            cmbPaymentMethod.Location = new Point(1062, 75);
            cmbPaymentMethod.Margin = new Padding(4, 4, 4, 4);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(312, 36);
            cmbPaymentMethod.TabIndex = 3;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 10F);
            txtAmount.Location = new Point(250, 175);
            txtAmount.Margin = new Padding(4, 4, 4, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(249, 34);
            txtAmount.TabIndex = 2;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(250, 125);
            txtLastName.Margin = new Padding(4, 4, 4, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(249, 34);
            txtLastName.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(250, 75);
            txtFirstName.Margin = new Padding(4, 4, 4, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(249, 34);
            txtFirstName.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(31, 43, 82);
            label6.Location = new Point(874, 83);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(180, 28);
            label6.TabIndex = 5;
            label6.Text = "Payment Method:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(31, 43, 82);
            label5.Location = new Point(62, 181);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 28);
            label5.TabIndex = 4;
            label5.Text = "Amount:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(31, 43, 82);
            label4.Location = new Point(62, 131);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(117, 28);
            label4.TabIndex = 3;
            label4.Text = "Last Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(31, 43, 82);
            label3.Location = new Point(62, 81);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 28);
            label3.TabIndex = 2;
            label3.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(31, 43, 82);
            label2.Location = new Point(62, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(252, 28);
            label2.TabIndex = 1;
            label2.Text = "PAYMENT INFORMATION";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(31, 43, 82);
            label1.Location = new Point(24, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(264, 38);
            label1.TabIndex = 0;
            label1.Text = "PAYMENT DETAILS";
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.BackColor = Color.FromArgb(240, 242, 245);
            panelButtons.Controls.Add(btnDisplay);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(25, 625);
            panelButtons.Margin = new Padding(4, 4, 4, 4);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1450, 88);
            panelButtons.TabIndex = 2;
            // 
            // btnDisplay
            // 
            btnDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisplay.BackColor = Color.FromArgb(155, 89, 182);
            btnDisplay.FlatAppearance.BorderSize = 0;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDisplay.ForeColor = Color.White;
            btnDisplay.Location = new Point(1200, 19);
            btnDisplay.Margin = new Padding(4, 4, 4, 4);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(225, 50);
            btnDisplay.TabIndex = 5;
            btnDisplay.Text = "📄 DISPLAY";
            btnDisplay.UseVisualStyleBackColor = false;
            btnDisplay.Click += btnDisplay_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(230, 126, 34);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(950, 19);
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
            btnDelete.Location = new Point(700, 19);
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
            btnSave.Location = new Point(450, 19);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(225, 50);
            btnSave.TabIndex = 2;
            btnSave.Text = "💾 SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(25, 19);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(225, 50);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "➕ ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1500, 875);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1517, 920);
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment Management - Hotel Hyatt";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            panelMain.ResumeLayout(false);
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvPayments;
        private Panel panelMain;
        private Panel panelButtons;
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private Button btnAdd;
        private Panel panelDetails;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtAmount;
        private ComboBox cmbPaymentMethod;
        private DateTimePicker dtpPaymentDate;
        private Button btnDisplay;
    }
}