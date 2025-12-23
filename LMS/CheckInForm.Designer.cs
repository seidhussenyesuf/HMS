namespace HotelManagement.Desktop
{
    partial class CheckInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            panelHeader = new Panel();
            labelTitle = new Label();
            splitContainer1 = new SplitContainer();
            panelReservations = new Panel();
            groupBoxReservations = new GroupBox();
            dgvReservations = new DataGridView();
            panelActions = new Panel();
            btnNewReservation = new Button();
            btnCheckOut = new Button();
            btnCheckIn = new Button();
            btnRefresh = new Button();
            panelAvailableRooms = new Panel();
            groupBoxAvailableRooms = new GroupBox();
            dgvAvailableRooms = new DataGridView();
            lblAvailableRooms = new Label();
            panelCheckInForm = new Panel();
            groupBoxCheckIn = new GroupBox();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            cmbRoomType = new ComboBox();
            cmbGuestName = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelReservations.SuspendLayout();
            groupBoxReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            panelActions.SuspendLayout();
            panelAvailableRooms.SuspendLayout();
            groupBoxAvailableRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableRooms).BeginInit();
            panelCheckInForm.SuspendLayout();
            groupBoxCheckIn.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(31, 43, 82);
            panelHeader.Controls.Add(labelTitle);
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
            labelTitle.Size = new Size(385, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "🏨 CHECK-IN / CHECK-OUT";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 80);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelReservations);
            splitContainer1.Panel1.Controls.Add(panelCheckInForm);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelAvailableRooms);
            splitContainer1.Size = new Size(1200, 620);
            splitContainer1.SplitterDistance = 800;
            splitContainer1.TabIndex = 1;
            // 
            // panelReservations
            // 
            panelReservations.Controls.Add(groupBoxReservations);
            panelReservations.Controls.Add(panelActions);
            panelReservations.Dock = DockStyle.Fill;
            panelReservations.Location = new Point(0, 0);
            panelReservations.Name = "panelReservations";
            panelReservations.Size = new Size(800, 400);
            panelReservations.TabIndex = 0;
            // 
            // groupBoxReservations
            // 
            groupBoxReservations.Controls.Add(dgvReservations);
            groupBoxReservations.Dock = DockStyle.Fill;
            groupBoxReservations.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxReservations.ForeColor = Color.FromArgb(31, 43, 82);
            groupBoxReservations.Location = new Point(0, 0);
            groupBoxReservations.Name = "groupBoxReservations";
            groupBoxReservations.Size = new Size(800, 340);
            groupBoxReservations.TabIndex = 0;
            groupBoxReservations.TabStop = false;
            groupBoxReservations.Text = "ACTIVE RESERVATIONS";
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.White;
            dgvReservations.BorderStyle = BorderStyle.None;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Dock = DockStyle.Fill;
            dgvReservations.Location = new Point(3, 26);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(794, 311);
            dgvReservations.TabIndex = 0;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(240, 242, 245);
            panelActions.Controls.Add(btnNewReservation);
            panelActions.Controls.Add(btnCheckOut);
            panelActions.Controls.Add(btnCheckIn);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(0, 340);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(800, 60);
            panelActions.TabIndex = 1;
            // 
            // btnNewReservation
            // 
            btnNewReservation.BackColor = Color.FromArgb(52, 152, 219);
            btnNewReservation.FlatAppearance.BorderSize = 0;
            btnNewReservation.FlatStyle = FlatStyle.Flat;
            btnNewReservation.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNewReservation.ForeColor = Color.White;
            btnNewReservation.Location = new Point(20, 10);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Size = new Size(160, 40);
            btnNewReservation.TabIndex = 3;
            btnNewReservation.Text = "➕ NEW CHECK-IN";
            btnNewReservation.UseVisualStyleBackColor = false;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BackColor = Color.FromArgb(231, 76, 60);
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(620, 10);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(160, 40);
            btnCheckOut.TabIndex = 2;
            btnCheckOut.Text = "🚪 CHECK-OUT";
            btnCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BackColor = Color.FromArgb(46, 204, 113);
            btnCheckIn.FlatAppearance.BorderSize = 0;
            btnCheckIn.FlatStyle = FlatStyle.Flat;
            btnCheckIn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.Location = new Point(440, 10);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(160, 40);
            btnCheckIn.TabIndex = 1;
            btnCheckIn.Text = "✅ CHECK-IN";
            btnCheckIn.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(241, 196, 15);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(260, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(160, 40);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "🔄 REFRESH";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // panelAvailableRooms
            // 
            panelAvailableRooms.Controls.Add(groupBoxAvailableRooms);
            panelAvailableRooms.Controls.Add(lblAvailableRooms);
            panelAvailableRooms.Dock = DockStyle.Fill;
            panelAvailableRooms.Location = new Point(0, 0);
            panelAvailableRooms.Name = "panelAvailableRooms";
            panelAvailableRooms.Size = new Size(396, 620);
            panelAvailableRooms.TabIndex = 0;
            // 
            // groupBoxAvailableRooms
            // 
            groupBoxAvailableRooms.Controls.Add(dgvAvailableRooms);
            groupBoxAvailableRooms.Dock = DockStyle.Fill;
            groupBoxAvailableRooms.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxAvailableRooms.ForeColor = Color.FromArgb(31, 43, 82);
            groupBoxAvailableRooms.Location = new Point(0, 40);
            groupBoxAvailableRooms.Name = "groupBoxAvailableRooms";
            groupBoxAvailableRooms.Size = new Size(396, 580);
            groupBoxAvailableRooms.TabIndex = 1;
            groupBoxAvailableRooms.TabStop = false;
            groupBoxAvailableRooms.Text = "AVAILABLE ROOMS";
            // 
            // dgvAvailableRooms
            // 
            dgvAvailableRooms.AllowUserToAddRows = false;
            dgvAvailableRooms.AllowUserToDeleteRows = false;
            dgvAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailableRooms.BackgroundColor = Color.White;
            dgvAvailableRooms.BorderStyle = BorderStyle.None;
            dgvAvailableRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailableRooms.Dock = DockStyle.Fill;
            dgvAvailableRooms.Location = new Point(3, 26);
            dgvAvailableRooms.Name = "dgvAvailableRooms";
            dgvAvailableRooms.ReadOnly = true;
            dgvAvailableRooms.RowHeadersVisible = false;
            dgvAvailableRooms.RowHeadersWidth = 51;
            dgvAvailableRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableRooms.Size = new Size(390, 551);
            dgvAvailableRooms.TabIndex = 0;
            // 
            // lblAvailableRooms
            // 
            lblAvailableRooms.BackColor = Color.FromArgb(52, 152, 219);
            lblAvailableRooms.Dock = DockStyle.Top;
            lblAvailableRooms.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvailableRooms.ForeColor = Color.White;
            lblAvailableRooms.Location = new Point(0, 0);
            lblAvailableRooms.Name = "lblAvailableRooms";
            lblAvailableRooms.Size = new Size(396, 40);
            lblAvailableRooms.TabIndex = 0;
            lblAvailableRooms.Text = "Available Rooms: 0";
            lblAvailableRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCheckInForm
            // 
            panelCheckInForm.Controls.Add(groupBoxCheckIn);
            panelCheckInForm.Dock = DockStyle.Bottom;
            panelCheckInForm.Location = new Point(0, 400);
            panelCheckInForm.Name = "panelCheckInForm";
            panelCheckInForm.Size = new Size(800, 220);
            panelCheckInForm.TabIndex = 1;
            // 
            // groupBoxCheckIn
            // 
            groupBoxCheckIn.Controls.Add(dtpCheckOut);
            groupBoxCheckIn.Controls.Add(dtpCheckIn);
            groupBoxCheckIn.Controls.Add(cmbRoomType);
            groupBoxCheckIn.Controls.Add(cmbGuestName);
            groupBoxCheckIn.Controls.Add(label4);
            groupBoxCheckIn.Controls.Add(label3);
            groupBoxCheckIn.Controls.Add(label2);
            groupBoxCheckIn.Controls.Add(label1);
            groupBoxCheckIn.Dock = DockStyle.Fill;
            groupBoxCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxCheckIn.ForeColor = Color.FromArgb(31, 43, 82);
            groupBoxCheckIn.Location = new Point(0, 0);
            groupBoxCheckIn.Name = "groupBoxCheckIn";
            groupBoxCheckIn.Size = new Size(800, 220);
            groupBoxCheckIn.TabIndex = 0;
            groupBoxCheckIn.TabStop = false;
            groupBoxCheckIn.Text = "QUICK CHECK-IN FORM";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Font = new Font("Segoe UI", 10F);
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(550, 120);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(200, 30);
            dtpCheckOut.TabIndex = 3;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI", 10F);
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(550, 70);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(200, 30);
            dtpCheckIn.TabIndex = 2;
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 10F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(200, 120);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(200, 31);
            cmbRoomType.TabIndex = 1;
            // 
            // cmbGuestName
            // 
            cmbGuestName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuestName.Font = new Font("Segoe UI", 10F);
            cmbGuestName.FormattingEnabled = true;
            cmbGuestName.Location = new Point(200, 70);
            cmbGuestName.Name = "cmbGuestName";
            cmbGuestName.Size = new Size(200, 31);
            cmbGuestName.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(450, 125);
            label4.Name = "label4";
            label4.Size = new Size(94, 23);
            label4.TabIndex = 3;
            label4.Text = "Check-Out:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(450, 75);
            label3.Name = "label3";
            label3.Size = new Size(79, 23);
            label3.TabIndex = 2;
            label3.Text = "Check-In:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(50, 125);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 1;
            label2.Text = "Room Type:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(50, 75);
            label1.Name = "label1";
            label1.Size = new Size(104, 23);
            label1.TabIndex = 0;
            label1.Text = "Guest Name:";
            // 
            // CheckInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(splitContainer1);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1218, 747);
            Name = "CheckInForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Check-In / Check-Out Management";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelReservations.ResumeLayout(false);
            groupBoxReservations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            panelActions.ResumeLayout(false);
            panelAvailableRooms.ResumeLayout(false);
            groupBoxAvailableRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAvailableRooms).EndInit();
            panelCheckInForm.ResumeLayout(false);
            groupBoxCheckIn.ResumeLayout(false);
            groupBoxCheckIn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private SplitContainer splitContainer1;
        private Panel panelReservations;
        private GroupBox groupBoxReservations;
        private DataGridView dgvReservations;
        private Panel panelActions;
        private Button btnRefresh;
        private Button btnCheckIn;
        private Button btnCheckOut;
        private Panel panelAvailableRooms;
        private GroupBox groupBoxAvailableRooms;
        private DataGridView dgvAvailableRooms;
        private Label lblAvailableRooms;
        private Panel panelCheckInForm;
        private GroupBox groupBoxCheckIn;
        private DateTimePicker dtpCheckOut;
        private DateTimePicker dtpCheckIn;
        private ComboBox cmbRoomType;
        private ComboBox cmbGuestName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnNewReservation;
    }
}