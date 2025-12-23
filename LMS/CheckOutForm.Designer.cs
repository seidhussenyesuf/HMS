namespace HotelManagement.Desktop
{
    partial class CheckOutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOutForm));
            panelHeader = new Panel();
            labelTitle = new Label();
            splitContainer1 = new SplitContainer();
            panelLeft = new Panel();
            groupBoxReservations = new GroupBox();
            dgvReservations = new DataGridView();
            panelButtonsLeft = new Panel();
            btnLoadReservations = new Button();
            panelRight = new Panel();
            tabControl1 = new TabControl();
            tabPageCheckout = new TabPage();
            groupBoxPayment = new GroupBox();
            lblTotalPayment = new Label();
            label13 = new Label();
            lblCardAmount = new Label();
            label11 = new Label();
            lblCashAmount = new Label();
            label9 = new Label();
            lblTotalAmount = new Label();
            label7 = new Label();
            lblTaxAmount = new Label();
            label6 = new Label();
            lblRoomCharges = new Label();
            label5 = new Label();
            txtLateCheckoutFee = new TextBox();
            label4 = new Label();
            txtDiscount = new TextBox();
            label3 = new Label();
            txtAdditionalCharges = new TextBox();
            label2 = new Label();
            cmbPaymentMethod = new ComboBox();
            label1 = new Label();
            txtRoomNumber = new TextBox();
            txtGuestName = new TextBox();
            labelGuest = new Label();
            labelRoom = new Label();
            tabPageReceipt = new TabPage();
            richTextBoxReceipt = new RichTextBox();
            panelButtonsRight = new Panel();
            btnPrintReceipt = new Button();
            btnProcessCheckOut = new Button();
            btnCalculate = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelLeft.SuspendLayout();
            groupBoxReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            panelButtonsLeft.SuspendLayout();
            panelRight.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageCheckout.SuspendLayout();
            groupBoxPayment.SuspendLayout();
            tabPageReceipt.SuspendLayout();
            panelButtonsRight.SuspendLayout();
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
            labelTitle.Size = new Size(376, 41);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "🚪 CHECK-OUT MANAGEMENT";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 80);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panelLeft);
            splitContainer1.Panel1.Controls.Add(panelButtonsLeft);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelRight);
            splitContainer1.Panel2.Controls.Add(panelButtonsRight);
            splitContainer1.Size = new Size(1200, 620);
            splitContainer1.SplitterDistance = 600;
            splitContainer1.TabIndex = 1;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(groupBoxReservations);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(600, 540);
            panelLeft.TabIndex = 1;
            // 
            // groupBoxReservations
            // 
            groupBoxReservations.Controls.Add(dgvReservations);
            groupBoxReservations.Dock = DockStyle.Fill;
            groupBoxReservations.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxReservations.ForeColor = Color.FromArgb(31, 43, 82);
            groupBoxReservations.Location = new Point(0, 0);
            groupBoxReservations.Name = "groupBoxReservations";
            groupBoxReservations.Size = new Size(600, 540);
            groupBoxReservations.TabIndex = 0;
            groupBoxReservations.TabStop = false;
            groupBoxReservations.Text = "CHECKED-IN RESERVATIONS";
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
            dgvReservations.Size = new Size(594, 511);
            dgvReservations.TabIndex = 0;
            // 
            // panelButtonsLeft
            // 
            panelButtonsLeft.BackColor = Color.FromArgb(240, 242, 245);
            panelButtonsLeft.Controls.Add(btnLoadReservations);
            panelButtonsLeft.Dock = DockStyle.Bottom;
            panelButtonsLeft.Location = new Point(0, 540);
            panelButtonsLeft.Name = "panelButtonsLeft";
            panelButtonsLeft.Size = new Size(600, 80);
            panelButtonsLeft.TabIndex = 0;
            // 
            // btnLoadReservations
            // 
            btnLoadReservations.BackColor = Color.FromArgb(52, 152, 219);
            btnLoadReservations.FlatAppearance.BorderSize = 0;
            btnLoadReservations.FlatStyle = FlatStyle.Flat;
            btnLoadReservations.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLoadReservations.ForeColor = Color.White;
            btnLoadReservations.Location = new Point(20, 20);
            btnLoadReservations.Name = "btnLoadReservations";
            btnLoadReservations.Size = new Size(200, 40);
            btnLoadReservations.TabIndex = 0;
            btnLoadReservations.Text = "🔄 LOAD RESERVATIONS";
            btnLoadReservations.UseVisualStyleBackColor = false;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(tabControl1);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(596, 540);
            panelRight.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageCheckout);
            tabControl1.Controls.Add(tabPageReceipt);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(596, 540);
            tabControl1.TabIndex = 0;
            // 
            // tabPageCheckout
            // 
            tabPageCheckout.BackColor = Color.White;
            tabPageCheckout.Controls.Add(groupBoxPayment);
            tabPageCheckout.Controls.Add(txtLateCheckoutFee);
            tabPageCheckout.Controls.Add(label4);
            tabPageCheckout.Controls.Add(txtDiscount);
            tabPageCheckout.Controls.Add(label3);
            tabPageCheckout.Controls.Add(txtAdditionalCharges);
            tabPageCheckout.Controls.Add(label2);
            tabPageCheckout.Controls.Add(cmbPaymentMethod);
            tabPageCheckout.Controls.Add(label1);
            tabPageCheckout.Controls.Add(txtRoomNumber);
            tabPageCheckout.Controls.Add(txtGuestName);
            tabPageCheckout.Controls.Add(labelGuest);
            tabPageCheckout.Controls.Add(labelRoom);
            tabPageCheckout.Location = new Point(4, 29);
            tabPageCheckout.Name = "tabPageCheckout";
            tabPageCheckout.Padding = new Padding(3);
            tabPageCheckout.Size = new Size(588, 507);
            tabPageCheckout.TabIndex = 0;
            tabPageCheckout.Text = "Check-Out Details";
            // 
            // groupBoxPayment
            // 
            groupBoxPayment.Controls.Add(lblTotalPayment);
            groupBoxPayment.Controls.Add(label13);
            groupBoxPayment.Controls.Add(lblCardAmount);
            groupBoxPayment.Controls.Add(label11);
            groupBoxPayment.Controls.Add(lblCashAmount);
            groupBoxPayment.Controls.Add(label9);
            groupBoxPayment.Controls.Add(lblTotalAmount);
            groupBoxPayment.Controls.Add(label7);
            groupBoxPayment.Controls.Add(lblTaxAmount);
            groupBoxPayment.Controls.Add(label6);
            groupBoxPayment.Controls.Add(lblRoomCharges);
            groupBoxPayment.Controls.Add(label5);
            groupBoxPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxPayment.ForeColor = Color.FromArgb(31, 43, 82);
            groupBoxPayment.Location = new Point(30, 280);
            groupBoxPayment.Name = "groupBoxPayment";
            groupBoxPayment.Size = new Size(520, 200);
            groupBoxPayment.TabIndex = 12;
            groupBoxPayment.TabStop = false;
            groupBoxPayment.Text = "PAYMENT BREAKDOWN";
            // 
            // lblTotalPayment
            // 
            lblTotalPayment.AutoSize = true;
            lblTotalPayment.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPayment.ForeColor = Color.Green;
            lblTotalPayment.Location = new Point(350, 140);
            lblTotalPayment.Name = "lblTotalPayment";
            lblTotalPayment.Size = new Size(74, 28);
            lblTotalPayment.TabIndex = 11;
            lblTotalPayment.Text = "$0.00";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label13.Location = new Point(200, 140);
            label13.Name = "label13";
            label13.Size = new Size(144, 28);
            label13.TabIndex = 10;
            label13.Text = "Total Payment:";
            // 
            // lblCardAmount
            // 
            lblCardAmount.AutoSize = true;
            lblCardAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCardAmount.Location = new Point(350, 105);
            lblCardAmount.Name = "lblCardAmount";
            lblCardAmount.Size = new Size(59, 23);
            lblCardAmount.TabIndex = 9;
            lblCardAmount.Text = "$0.00";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(200, 105);
            label11.Name = "label11";
            label11.Size = new Size(113, 23);
            label11.TabIndex = 8;
            label11.Text = "Card Amount:";
            // 
            // lblCashAmount
            // 
            lblCashAmount.AutoSize = true;
            lblCashAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCashAmount.Location = new Point(350, 70);
            lblCashAmount.Name = "lblCashAmount";
            lblCashAmount.Size = new Size(59, 23);
            lblCashAmount.TabIndex = 7;
            lblCashAmount.Text = "$0.00";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(200, 70);
            label9.Name = "label9";
            label9.Size = new Size(118, 23);
            label9.TabIndex = 6;
            label9.Text = "Cash Amount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.Green;
            lblTotalAmount.Location = new Point(380, 30);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(79, 32);
            lblTotalAmount.TabIndex = 5;
            lblTotalAmount.Text = "$0.00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(220, 30);
            label7.Name = "label7";
            label7.Size = new Size(154, 32);
            label7.TabIndex = 4;
            label7.Text = "Total Bill:";
            // 
            // lblTaxAmount
            // 
            lblTaxAmount.AutoSize = true;
            lblTaxAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTaxAmount.Location = new Point(130, 105);
            lblTaxAmount.Name = "lblTaxAmount";
            lblTaxAmount.Size = new Size(59, 23);
            lblTaxAmount.TabIndex = 3;
            lblTaxAmount.Text = "$0.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(30, 105);
            label6.Name = "label6";
            label6.Size = new Size(106, 23);
            label6.TabIndex = 2;
            label6.Text = "Tax Amount:";
            // 
            // lblRoomCharges
            // 
            lblRoomCharges.AutoSize = true;
            lblRoomCharges.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoomCharges.Location = new Point(130, 70);
            lblRoomCharges.Name = "lblRoomCharges";
            lblRoomCharges.Size = new Size(59, 23);
            lblRoomCharges.TabIndex = 1;
            lblRoomCharges.Text = "$0.00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(30, 70);
            label5.Name = "label5";
            label5.Size = new Size(94, 23);
            label5.TabIndex = 0;
            label5.Text = "Room Bill:";
            // 
            // txtLateCheckoutFee
            // 
            txtLateCheckoutFee.Font = new Font("Segoe UI", 10F);
            txtLateCheckoutFee.Location = new Point(380, 220);
            txtLateCheckoutFee.Name = "txtLateCheckoutFee";
            txtLateCheckoutFee.Size = new Size(170, 30);
            txtLateCheckoutFee.TabIndex = 11;
            txtLateCheckoutFee.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(200, 225);
            label4.Name = "label4";
            label4.Size = new Size(174, 23);
            label4.TabIndex = 10;
            label4.Text = "Late Checkout Fee:";
            // 
            // txtDiscount
            // 
            txtDiscount.Font = new Font("Segoe UI", 10F);
            txtDiscount.Location = new Point(130, 220);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(170, 30);
            txtDiscount.TabIndex = 9;
            txtDiscount.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(30, 225);
            label3.Name = "label3";
            label3.Size = new Size(84, 23);
            label3.TabIndex = 8;
            label3.Text = "Discount:";
            // 
            // txtAdditionalCharges
            // 
            txtAdditionalCharges.Font = new Font("Segoe UI", 10F);
            txtAdditionalCharges.Location = new Point(380, 170);
            txtAdditionalCharges.Name = "txtAdditionalCharges";
            txtAdditionalCharges.Size = new Size(170, 30);
            txtAdditionalCharges.TabIndex = 7;
            txtAdditionalCharges.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(200, 175);
            label2.Name = "label2";
            label2.Size = new Size(164, 23);
            label2.TabIndex = 6;
            label2.Text = "Additional Charges:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Bank Transfer" });
            cmbPaymentMethod.Location = new Point(130, 170);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(170, 31);
            cmbPaymentMethod.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(30, 175);
            label1.Name = "label1";
            label1.Size = new Size(94, 23);
            label1.TabIndex = 4;
            label1.Text = "Payment:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Segoe UI", 10F);
            txtRoomNumber.Location = new Point(380, 120);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(170, 30);
            txtRoomNumber.TabIndex = 3;
            // 
            // txtGuestName
            // 
            txtGuestName.Font = new Font("Segoe UI", 10F);
            txtGuestName.Location = new Point(130, 120);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.ReadOnly = true;
            txtGuestName.Size = new Size(170, 30);
            txtGuestName.TabIndex = 2;
            // 
            // labelGuest
            // 
            labelGuest.AutoSize = true;
            labelGuest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelGuest.Location = new Point(30, 125);
            labelGuest.Name = "labelGuest";
            labelGuest.Size = new Size(104, 23);
            labelGuest.TabIndex = 1;
            labelGuest.Text = "Guest Name:";
            // 
            // labelRoom
            // 
            labelRoom.AutoSize = true;
            labelRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelRoom.Location = new Point(200, 125);
            labelRoom.Name = "labelRoom";
            labelRoom.Size = new Size(125, 23);
            labelRoom.TabIndex = 0;
            labelRoom.Text = "Room Number:";
            // 
            // tabPageReceipt
            // 
            tabPageReceipt.BackColor = Color.White;
            tabPageReceipt.Controls.Add(richTextBoxReceipt);
            tabPageReceipt.Location = new Point(4, 29);
            tabPageReceipt.Name = "tabPageReceipt";
            tabPageReceipt.Padding = new Padding(3);
            tabPageReceipt.Size = new Size(588, 507);
            tabPageReceipt.TabIndex = 1;
            tabPageReceipt.Text = "Receipt Preview";
            // 
            // richTextBoxReceipt
            // 
            richTextBoxReceipt.Dock = DockStyle.Fill;
            richTextBoxReceipt.Font = new Font("Courier New", 10F);
            richTextBoxReceipt.Location = new Point(3, 3);
            richTextBoxReceipt.Name = "richTextBoxReceipt";
            richTextBoxReceipt.ReadOnly = true;
            richTextBoxReceipt.Size = new Size(582, 501);
            richTextBoxReceipt.TabIndex = 0;
            richTextBoxReceipt.Text = "";
            // 
            // panelButtonsRight
            // 
            panelButtonsRight.BackColor = Color.FromArgb(240, 242, 245);
            panelButtonsRight.Controls.Add(btnPrintReceipt);
            panelButtonsRight.Controls.Add(btnProcessCheckOut);
            panelButtonsRight.Controls.Add(btnCalculate);
            panelButtonsRight.Dock = DockStyle.Bottom;
            panelButtonsRight.Location = new Point(0, 540);
            panelButtonsRight.Name = "panelButtonsRight";
            panelButtonsRight.Size = new Size(596, 80);
            panelButtonsRight.TabIndex = 1;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.BackColor = Color.FromArgb(155, 89, 182);
            btnPrintReceipt.FlatAppearance.BorderSize = 0;
            btnPrintReceipt.FlatStyle = FlatStyle.Flat;
            btnPrintReceipt.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrintReceipt.ForeColor = Color.White;
            btnPrintReceipt.Location = new Point(400, 20);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(170, 40);
            btnPrintReceipt.TabIndex = 2;
            btnPrintReceipt.Text = "🖨️ PRINT RECEIPT";
            btnPrintReceipt.UseVisualStyleBackColor = false;
            // 
            // btnProcessCheckOut
            // 
            btnProcessCheckOut.BackColor = Color.FromArgb(46, 204, 113);
            btnProcessCheckOut.FlatAppearance.BorderSize = 0;
            btnProcessCheckOut.FlatStyle = FlatStyle.Flat;
            btnProcessCheckOut.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProcessCheckOut.ForeColor = Color.White;
            btnProcessCheckOut.Location = new Point(210, 20);
            btnProcessCheckOut.Name = "btnProcessCheckOut";
            btnProcessCheckOut.Size = new Size(170, 40);
            btnProcessCheckOut.TabIndex = 1;
            btnProcessCheckOut.Text = "✅ PROCESS CHECKOUT";
            btnProcessCheckOut.UseVisualStyleBackColor = false;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.FromArgb(241, 196, 15);
            btnCalculate.FlatAppearance.BorderSize = 0;
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(20, 20);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(170, 40);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "🧮 CALCULATE BILL";
            btnCalculate.UseVisualStyleBackColor = false;
            // 
            // CheckOutForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(splitContainer1);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1218, 747);
            Name = "CheckOutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Check-Out Management";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            groupBoxReservations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            panelButtonsLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageCheckout.ResumeLayout(false);
            tabPageCheckout.PerformLayout();
            groupBoxPayment.ResumeLayout(false);
            groupBoxPayment.PerformLayout();
            tabPageReceipt.ResumeLayout(false);
            panelButtonsRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private SplitContainer splitContainer1;
        private Panel panelLeft;
        private GroupBox groupBoxReservations;
        private DataGridView dgvReservations;
        private Panel panelButtonsLeft;
        private Button btnLoadReservations;
        private Panel panelRight;
        private TabControl tabControl1;
        private TabPage tabPageCheckout;
        private GroupBox groupBoxPayment;
        private Label lblTotalPayment;
        private Label label13;
        private Label lblCardAmount;
        private Label label11;
        private Label lblCashAmount;
        private Label label9;
        private Label lblTotalAmount;
        private Label label7;
        private Label lblTaxAmount;
        private Label label6;
        private Label lblRoomCharges;
        private Label label5;
        private TextBox txtLateCheckoutFee;
        private Label label4;
        private TextBox txtDiscount;
        private Label label3;
        private TextBox txtAdditionalCharges;
        private Label label2;
        private ComboBox cmbPaymentMethod;
        private Label label1;
        private TextBox txtRoomNumber;
        private TextBox txtGuestName;
        private Label labelGuest;
        private Label labelRoom;
        private TabPage tabPageReceipt;
        private RichTextBox richTextBoxReceipt;
        private Panel panelButtonsRight;
        private Button btnPrintReceipt;
        private Button btnProcessCheckOut;
        private Button btnCalculate;
    }
}