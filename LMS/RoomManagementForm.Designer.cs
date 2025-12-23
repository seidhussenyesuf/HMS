namespace HotelManagement.Desktop
{
    partial class RoomManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomManagementForm));
            panelHeader = new Panel();
            labelTitle = new Label();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panelMain = new Panel();
            panelFilter = new Panel();
            cmbFilterStatus = new ComboBox();
            label6 = new Label();
            btnFilter = new Button();
            lblRoomCount = new Label();
            panelButtons = new Panel();
            btnFilter = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            panelForm = new Panel();
            cmbFloor = new ComboBox();
            label5 = new Label();
            cmbStatus = new ComboBox();
            label4 = new Label();
            txtPrice = new TextBox();
            label3 = new Label();
            cmbRoomType = new ComboBox();
            label2 = new Label();
            txtRoomNumber = new TextBox();
            label1 = new Label();
            dgvRooms = new DataGridView();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelFilter.SuspendLayout();
            panelButtons.SuspendLayout();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(31, 43, 82);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(btnSearch);
            panelHeader.Controls.Add(txtSearch);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 80);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.FromArgb(255, 215, 0);
            labelTitle.Location = new Point(20, 20);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(296, 41);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "🛏️ ROOM MANAGEMENT";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(255, 215, 0);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.FromArgb(31, 43, 82);
            btnSearch.Location = new Point(950, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 40);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍 SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(700, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by room number or type...";
            txtSearch.Size = new Size(230, 32);
            txtSearch.TabIndex = 1;
            // 
            // panelMain
            // 
            panelMain.AutoScroll = true;
            panelMain.BackColor = Color.FromArgb(240, 242, 245);
            panelMain.Controls.Add(panelFilter);
            panelMain.Controls.Add(panelButtons);
            panelMain.Controls.Add(panelForm);
            panelMain.Controls.Add(dgvRooms);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 80);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1200, 620);
            panelMain.TabIndex = 1;
            // 
            // panelFilter
            // 
            panelFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFilter.BackColor = Color.White;
            panelFilter.BorderStyle = BorderStyle.FixedSingle;
            panelFilter.Controls.Add(lblRoomCount);
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Controls.Add(label6);
            panelFilter.Controls.Add(cmbFilterStatus);
            panelFilter.Location = new Point(20, 280);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1160, 70);
            panelFilter.TabIndex = 3;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Font = new Font("Segoe UI", 10F);
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Location = new Point(170, 20);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(200, 31);
            cmbFilterStatus.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(31, 43, 82);
            label6.Location = new Point(30, 22);
            label6.Name = "label6";
            label6.Size = new Size(134, 25);
            label6.TabIndex = 1;
            label6.Text = "Filter by Status:";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(155, 89, 182);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(400, 17);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(120, 35);
            btnFilter.TabIndex = 2;
            btnFilter.Text = "FILTER";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // lblRoomCount
            // 
            lblRoomCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRoomCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoomCount.ForeColor = Color.FromArgb(31, 43, 82);
            lblRoomCount.Location = new Point(600, 20);
            lblRoomCount.Name = "lblRoomCount";
            lblRoomCount.Size = new Size(540, 25);
            lblRoomCount.TabIndex = 3;
            lblRoomCount.Text = "Total: 0 | Available: 0 | Occupied: 0";
            lblRoomCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelButtons
            // 
            panelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelButtons.BackColor = Color.FromArgb(240, 242, 245);
            panelButtons.Controls.Add(btnFilter);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Location = new Point(20, 500);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1160, 70);
            panelButtons.TabIndex = 2;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(155, 89, 182);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(820, 15);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(180, 40);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "🔍 FILTER";
            btnFilter.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(230, 126, 34);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(620, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(180, 40);
            btnClear.TabIndex = 4;
            btnClear.Text = "🔄 CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(420, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(241, 196, 15);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(220, 15);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(180, 40);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "✏️ UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(180, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ ADD NEW";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // panelForm
            // 
            panelForm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelForm.BackColor = Color.White;
            panelForm.BorderStyle = BorderStyle.FixedSingle;
            panelForm.Controls.Add(cmbFloor);
            panelForm.Controls.Add(label5);
            panelForm.Controls.Add(cmbStatus);
            panelForm.Controls.Add(label4);
            panelForm.Controls.Add(txtPrice);
            panelForm.Controls.Add(label3);
            panelForm.Controls.Add(cmbRoomType);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(txtRoomNumber);
            panelForm.Controls.Add(label1);
            panelForm.Location = new Point(20, 370);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1160, 120);
            panelForm.TabIndex = 1;
            // 
            // cmbFloor
            // 
            cmbFloor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFloor.Font = new Font("Segoe UI", 10F);
            cmbFloor.FormattingEnabled = true;
            cmbFloor.Location = new Point(850, 25);
            cmbFloor.Name = "cmbFloor";
            cmbFloor.Size = new Size(100, 31);
            cmbFloor.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(31, 43, 82);
            label5.Location = new Point(780, 28);
            label5.Name = "label5";
            label5.Size = new Size(61, 25);
            label5.TabIndex = 8;
            label5.Text = "Floor:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(650, 65);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 31);
            cmbStatus.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(31, 43, 82);
            label4.Location = new Point(550, 68);
            label4.Name = "label4";
            label4.Size = new Size(95, 25);
            label4.TabIndex = 6;
            label4.Text = "Status:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 10F);
            txtPrice.Location = new Point(650, 25);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 30);
            txtPrice.TabIndex = 2;
            txtPrice.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(31, 43, 82);
            label3.Location = new Point(550, 28);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 4;
            label3.Text = "Price ($):";
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 10F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(170, 65);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(200, 31);
            cmbRoomType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(31, 43, 82);
            label2.Location = new Point(30, 68);
            label2.Name = "label2";
            label2.Size = new Size(113, 25);
            label2.TabIndex = 2;
            label2.Text = "Room Type:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 10F);
            txtRoomNumber.Location = new Point(170, 25);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(150, 30);
            txtRoomNumber.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(31, 43, 82);
            label1.Location = new Point(30, 28);
            label1.Name = "label1";
            label1.Size = new Size(143, 25);
            label1.TabIndex = 0;
            label1.Text = "Room Number:";
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(20, 20);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1160, 250);
            dgvRooms.TabIndex = 0;
            // 
            // RoomManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1218, 747);
            Name = "RoomManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Room Management - Hotel Hyatt";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Button btnSearch;
        private TextBox txtSearch;
        private Panel panelMain;
        private DataGridView dgvRooms;
        private Panel panelForm;
        private TextBox txtRoomNumber;
        private Label label1;
        private ComboBox cmbRoomType;
        private Label label2;
        private TextBox txtPrice;
        private Label label3;
        private ComboBox cmbStatus;
        private Label label4;
        private ComboBox cmbFloor;
        private Label label5;
        private Panel panelButtons;
        private Button btnAdd;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnFilter;
        private Panel panelFilter;
        private Label label6;
        private ComboBox cmbFilterStatus;
        private Label lblRoomCount;
    }
}