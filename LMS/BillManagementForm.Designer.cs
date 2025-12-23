namespace HotelManagement.Desktop
{
    partial class BillManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillManagementForm));
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            txtDescription = new TextBox();
            label11 = new Label();
            txtTotalAmount = new TextBox();
            label10 = new Label();
            txtDiscount = new TextBox();
            label9 = new Label();
            txtTax = new TextBox();
            label8 = new Label();
            txtAdditionalCharges = new TextBox();
            label7 = new Label();
            txtRoomCharges = new TextBox();
            label6 = new Label();
            txtRoomPrice = new TextBox();
            label5 = new Label();
            txtNights = new TextBox();
            label4 = new Label();
            cmbRoomType = new ComboBox();
            label3 = new Label();
            cmbGuest = new ComboBox();
            label2 = new Label();
            panel3 = new Panel();
            btnDisplay = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            dgvBills = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 43, 82);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1200, 70);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 215, 0);
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(317, 41);
            label1.TabIndex = 0;
            label1.Text = "💰 BILL MANAGEMENT";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 630);
            panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtTotalAmount);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtDiscount);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtTax);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtAdditionalCharges);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtRoomCharges);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtRoomPrice);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtNights);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbRoomType);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbGuest);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(31, 43, 82);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 530);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "BILL DETAILS";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.Location = new Point(150, 450);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(220, 60);
            txtDescription.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(30, 455);
            label11.Name = "label11";
            label11.Size = new Size(96, 23);
            label11.TabIndex = 17;
            label11.Text = "Description:";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.BackColor = Color.FromArgb(255, 255, 192);
            txtTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotalAmount.ForeColor = Color.Green;
            txtTotalAmount.Location = new Point(150, 400);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(220, 34);
            txtTotalAmount.TabIndex = 7;
            txtTotalAmount.Text = "$0.00";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(30, 405);
            label10.Name = "label10";
            label10.Size = new Size(115, 28);
            label10.TabIndex = 15;
            label10.Text = "Total Bill:";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 10F);
            txtDiscount.Location = new Point(150, 360);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(220, 30);
            txtDiscount.TabIndex = 6;
            txtDiscount.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(30, 365);
            label9.Name = "label9";
            label9.Size = new Size(77, 23);
            label9.TabIndex = 13;
            label9.Text = "Discount:";
            // 
            // txtTax
            // 
            txtTax.Font = new Font("Segoe UI", 10F);
            txtTax.Location = new Point(150, 320);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(220, 30);
            txtTax.TabIndex = 5;
            txtTax.Text = "$0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(30, 325);
            label8.Name = "label8";
            label8.Size = new Size(36, 23);
            label8.TabIndex = 11;
            label8.Text = "Tax:";
            // 
            // txtAdditionalCharges
            // 
            txtAdditionalCharges.Font = new Font("Segoe UI", 10F);
            txtAdditionalCharges.Location = new Point(150, 280);
            txtAdditionalCharges.Name = "txtAdditionalCharges";
            txtAdditionalCharges.Size = new Size(220, 30);
            txtAdditionalCharges.TabIndex = 4;
            txtAdditionalCharges.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(30, 285);
            label7.Name = "label7";
            label7.Size = new Size(118, 23);
            label7.TabIndex = 9;
            label7.Text = "Additional ($):";
            // 
            // txtRoomCharges
            // 
            txtRoomCharges.Font = new Font("Segoe UI", 10F);
            txtRoomCharges.Location = new Point(150, 240);
            txtRoomCharges.Name = "txtRoomCharges";
            txtRoomCharges.ReadOnly = true;
            txtRoomCharges.Size = new Size(220, 30);
            txtRoomCharges.TabIndex = 3;
            txtRoomCharges.Text = "$0.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(30, 245);
            label6.Name = "label6";
            label6.Size = new Size(119, 23);
            label6.TabIndex = 7;
            label6.Text = "Room Charges:";
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.Font = new Font("Segoe UI", 10F);
            txtRoomPrice.Location = new Point(150, 200);
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.Size = new Size(220, 30);
            txtRoomPrice.TabIndex = 2;
            txtRoomPrice.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(30, 205);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 5;
            label5.Text = "Room Price:";
            // 
            // txtNights
            // 
            txtNights.Font = new Font("Segoe UI", 10F);
            txtNights.Location = new Point(150, 160);
            txtNights.Name = "txtNights";
            txtNights.Size = new Size(220, 30);
            txtNights.TabIndex = 1;
            txtNights.Text = "1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(30, 165);
            label4.Name = "label4";
            label4.Size = new Size(61, 23);
            label4.TabIndex = 3;
            label4.Text = "Nights:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 10F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(150, 120);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(220, 31);
            cmbRoomType.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(30, 125);
            label3.Name = "label3";
            label3.Size = new Size(97, 23);
            label3.TabIndex = 1;
            label3.Text = "Room Type:";
            // 
            // cmbGuest
            // 
            cmbGuest.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGuest.Font = new Font("Segoe UI", 10F);
            cmbGuest.FormattingEnabled = true;
            cmbGuest.Location = new Point(150, 80);
            cmbGuest.Name = "cmbGuest";
            cmbGuest.Size = new Size(220, 31);
            cmbGuest.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(30, 85);
            label2.Name = "label2";
            label2.Size = new Size(99, 23);
            label2.TabIndex = 0;
            label2.Text = "Guest Name:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(240, 242, 245);
            panel3.Controls.Add(btnDisplay);
            panel3.Controls.Add(btnUpdate);
            panel3.Controls.Add(btnAdd);
            panel3.Controls.Add(btnSave);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 530);
            panel3.Name = "panel3";
            panel3.Size = new Size(400, 100);
            panel3.TabIndex = 1;
            // 
            // btnDisplay
            // 
            btnDisplay.BackColor = Color.FromArgb(155, 89, 182);
            btnDisplay.FlatAppearance.BorderSize = 0;
            btnDisplay.FlatStyle = FlatStyle.Flat;
            btnDisplay.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDisplay.ForeColor = Color.White;
            btnDisplay.Location = new Point(290, 20);
            btnDisplay.Name = "btnDisplay";
            btnDisplay.Size = new Size(90, 40);
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
            btnUpdate.Location = new Point(200, 20);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 40);
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
            btnAdd.Location = new Point(110, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 40);
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
            btnSave.Location = new Point(20, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.BackgroundColor = Color.White;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.Location = new Point(400, 70);
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowHeadersWidth = 51;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(800, 630);
            dgvBills.TabIndex = 2;
            // 
            // BillManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(dgvBills);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1218, 747);
            Name = "BillManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill Management";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private GroupBox groupBox1;
        private TextBox txtDescription;
        private Label label11;
        private TextBox txtTotalAmount;
        private Label label10;
        private TextBox txtDiscount;
        private Label label9;
        private TextBox txtTax;
        private Label label8;
        private TextBox txtAdditionalCharges;
        private Label label7;
        private TextBox txtRoomCharges;
        private Label label6;
        private TextBox txtRoomPrice;
        private Label label5;
        private TextBox txtNights;
        private Label label4;
        private ComboBox cmbRoomType;
        private Label label3;
        private ComboBox cmbGuest;
        private Label label2;
        private Panel panel3;
        private Button btnDisplay;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnSave;
        private DataGridView dgvBills;
    }
}