namespace HotelManagement.Desktop
{
    partial class ReservationForm
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
            panel1 = new Panel();
            label6 = new Label();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            dtpCheckOut = new DateTimePicker();
            label5 = new Label();
            dtpCheckIn = new DateTimePicker();
            label4 = new Label();
            cmbHotelCode = new ComboBox();
            label3 = new Label();
            cmbRoomNo = new ComboBox();
            label2 = new Label();
            cmbRoomType = new ComboBox();
            label1 = new Label();
            cmbGuestName = new ComboBox();
            label7 = new Label();
            panel3 = new Panel();
            btnDisplay = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            label8 = new Label();
            dgvReservations = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 43, 82);
            panel1.Controls.Add(label6);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 88);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(255, 215, 0);
            label6.Location = new Point(25, 19);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(498, 48);
            label6.TabIndex = 0;
            label6.Text = "📅 BOOKING/RESERVATION";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label8);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 88);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 787);
            panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpCheckOut);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpCheckIn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbHotelCode);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbRoomNo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbRoomType);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbGuestName);
            groupBox1.Controls.Add(label7);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(31, 43, 82);
            groupBox1.Location = new Point(0, 100);
            groupBox1.Margin = new Padding(4, 4, 4, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 4, 4, 4);
            groupBox1.Size = new Size(500, 562);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "RESERVATION DETAILS";
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Font = new Font("Segoe UI", 10F);
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(188, 500);
            dtpCheckOut.Margin = new Padding(4, 4, 4, 4);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(274, 34);
            dtpCheckOut.TabIndex = 5;
            dtpCheckOut.Value = new DateTime(2025, 12, 18, 0, 0, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(38, 506);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(106, 28);
            label5.TabIndex = 10;
            label5.Text = "Check Out:";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Font = new Font("Segoe UI", 10F);
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(188, 450);
            dtpCheckIn.Margin = new Padding(4, 4, 4, 4);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(274, 34);
            dtpCheckIn.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(38, 456);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(89, 28);
            label4.TabIndex = 8;
            label4.Text = "Check In:";
            // 
            // cmbHotelCode
            // 
            cmbHotelCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHotelCode.Font = new Font("Segoe UI", 10F);
            cmbHotelCode.FormattingEnabled = true;
            cmbHotelCode.Location = new Point(188, 350);
            cmbHotelCode.Margin = new Padding(4, 4, 4, 4);
            cmbHotelCode.Name = "cmbHotelCode";
            cmbHotelCode.Size = new Size(274, 36);
            cmbHotelCode.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(38, 356);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 28);
            label3.TabIndex = 6;
            label3.Text = "Hotel Code:";
            // 
            // cmbRoomNo
            // 
            cmbRoomNo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomNo.Font = new Font("Segoe UI", 10F);
            cmbRoomNo.FormattingEnabled = true;
            cmbRoomNo.Location = new Point(188, 250);
            cmbRoomNo.Margin = new Padding(4, 4, 4, 4);
            cmbRoomNo.Name = "cmbRoomNo";
            cmbRoomNo.Size = new Size(274, 36);
            cmbRoomNo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(38, 256);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 28);
            label2.TabIndex = 4;
            label2.Text = "Room No:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 10F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(188, 150);
            cmbRoomType.Margin = new Padding(4, 4, 4, 4);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(274, 36);
            cmbRoomType.TabIndex = 1;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(38, 156);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 28);
            label1.TabIndex = 2;
            label1.Text = "Room Type:";
            // 
            // cmbGuestName
            // 
            cmbGuestName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuestName.Font = new Font("Segoe UI", 10F);
            cmbGuestName.FormattingEnabled = true;
            cmbGuestName.Location = new Point(188, 100);
            cmbGuestName.Margin = new Padding(4, 4, 4, 4);
            cmbGuestName.Name = "cmbGuestName";
            cmbGuestName.Size = new Size(274, 36);
            cmbGuestName.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(38, 106);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(123, 28);
            label7.TabIndex = 0;
            label7.Text = "Guest Name:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(240, 242, 245);
            panel3.Controls.Add(btnDisplay);
            panel3.Controls.Add(btnUpdate);
            panel3.Controls.Add(btnAdd);
            panel3.Controls.Add(btnSave);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 662);
            panel3.Margin = new Padding(4, 4, 4, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(500, 125);
            panel3.TabIndex = 1;
            // 
            // btnDisplay
            // 
            btnDisplay.BackColor = Color.FromArgb(155, 89, 182);
            btnDisplay.FlatAppearance.BorderSize = 0;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDisplay.ForeColor = Color.White;
            btnDisplay.Location = new Point(362, 25);
            btnDisplay.Margin = new Padding(4, 4, 4, 4);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(112, 50);
            btnDisplay.TabIndex = 3;
            btnDisplay.Text = "DISPLAY";
            btnDisplay.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(241, 196, 15);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(221, 25);
            btnUpdate.Margin = new Padding(4, 4, 4, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(133, 50);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(52, 152, 219);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(112, 25);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 50);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(4, 25);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 50);
            btnSave.TabIndex = 0;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(31, 43, 82);
            label8.Location = new Point(0, 0);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Padding = new Padding(12, 12, 12, 12);
            label8.Size = new Size(500, 100);
            label8.TabIndex = 2;
            label8.Text = "Room types available: Single, Double, Triple\r\nRooms no available: 101, 102, 201, 202, 301, 302";
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.White;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Dock = DockStyle.Fill;
            dgvReservations.Location = new Point(500, 88);
            dgvReservations.Margin = new Padding(4, 4, 4, 4);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(1000, 787);
            dgvReservations.TabIndex = 2;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1500, 875);
            Controls.Add(dgvReservations);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1517, 920);
            Name = "ReservationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Booking/Reservation";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private Panel panel2;
        private GroupBox groupBox1;
        private DateTimePicker dtpCheckOut;
        private Label label5;
        private DateTimePicker dtpCheckIn;
        private Label label4;
        private ComboBox cmbHotelCode;
        private Label label3;
        private ComboBox cmbRoomNo;
        private Label label2;
        private ComboBox cmbRoomType;
        private Label label1;
        private ComboBox cmbGuestName;
        private Label label7;
        private Panel panel3;
        private Button btnDisplay;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSave;
        private DataGridView dgvReservations;
        private Label label8;
    }
}