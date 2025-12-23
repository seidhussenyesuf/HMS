namespace HotelManagement.Desktop
{
    partial class MainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDashboard));
            panelHeader = new Panel();
            lblSystemTitle = new Label();
            lblWelcome = new Label();
            pictureBoxLogo = new PictureBox();
            lblHotelName = new Label();
            panelSidebar = new Panel();
            btnUserManagement = new Button();
            btnReports = new Button();
            btnLogout = new Button();
            btnBill = new Button();
            btnEmployee = new Button();
            btnPayment = new Button();
            btnGuest = new Button();
            btnRoom = new Button();
            btnBooking = new Button();
            btnDashboard = new Button();
            panelMainContent = new Panel();
            panelDashboard = new Panel();
            panelStats = new Panel();
            panelStatCard7 = new Panel();
            lblPopularRoom = new Label();
            label13 = new Label();
            pictureBox7 = new PictureBox();
            panelStatCard6 = new Panel();
            lblAvailableRooms = new Label();
            label11 = new Label();
            pictureBox6 = new PictureBox();
            panelStatCard5 = new Panel();
            lblOccupiedRooms = new Label();
            label9 = new Label();
            pictureBox5 = new PictureBox();
            panelStatCard4 = new Panel();
            lblTodayRevenue = new Label();
            label7 = new Label();
            pictureBox4 = new PictureBox();
            panelStatCard3 = new Panel();
            lblTotalBookings = new Label();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            panelStatCard2 = new Panel();
            lblTotalRooms = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            panelStatCard1 = new Panel();
            lblTotalGuests = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            btnRoomStatus = new Button();
            btnNewReservation = new Button();
            btnQuickCheckIn = new Button();
            label4 = new Label();
            panelStatusBar = new Panel();
            lblTime = new Label();
            lblDate = new Label();
            label6 = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelSidebar.SuspendLayout();
            panelMainContent.SuspendLayout();
            panelDashboard.SuspendLayout();
            panelStats.SuspendLayout();
            panelStatCard7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panelStatCard6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panelStatCard5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panelStatCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panelStatCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelStatCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelStatCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelStatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(31, 43, 82);
            panelHeader.Controls.Add(lblSystemTitle);
            panelHeader.Controls.Add(lblWelcome);
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(lblHotelName);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1300, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.AutoSize = true;
            lblSystemTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSystemTitle.ForeColor = Color.FromArgb(255, 215, 0);
            lblSystemTitle.Location = new Point(120, 25);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(365, 37);
            lblSystemTitle.TabIndex = 3;
            lblSystemTitle.Text = "HOTEL MANAGEMENT SYSTEM";
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(1000, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(288, 30);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome, User (Receptionist)";
            lblWelcome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(20, 15);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(50, 50);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 1;
            pictureBoxLogo.TabStop = false;
            // 
            // lblHotelName
            // 
            lblHotelName.AutoSize = true;
            lblHotelName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHotelName.ForeColor = Color.White;
            lblHotelName.Location = new Point(80, 25);
            lblHotelName.Name = "lblHotelName";
            lblHotelName.Size = new Size(144, 32);
            lblHotelName.TabIndex = 0;
            lblHotelName.Text = "HOTEL HYATT";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(41, 53, 92);
            panelSidebar.Controls.Add(btnUserManagement);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnBill);
            panelSidebar.Controls.Add(btnEmployee);
            panelSidebar.Controls.Add(btnPayment);
            panelSidebar.Controls.Add(btnGuest);
            panelSidebar.Controls.Add(btnRoom);
            panelSidebar.Controls.Add(btnBooking);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 80);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 620);
            panelSidebar.TabIndex = 1;
            // 
            // btnUserManagement
            // 
            btnUserManagement.BackColor = Color.FromArgb(41, 53, 92);
            btnUserManagement.FlatAppearance.BorderSize = 0;
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Segoe UI", 11F);
            btnUserManagement.ForeColor = Color.White;
            btnUserManagement.Image = (Image)resources.GetObject("btnUserManagement.Image");
            btnUserManagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.Location = new Point(0, 480);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Padding = new Padding(20, 0, 0, 0);
            btnUserManagement.Size = new Size(250, 60);
            btnUserManagement.TabIndex = 9;
            btnUserManagement.Text = "   USERS";
            btnUserManagement.TextAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;
            btnUserManagement.Visible = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(41, 53, 92);
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 11F);
            btnReports.ForeColor = Color.White;
            btnReports.Image = (Image)resources.GetObject("btnReports.Image");
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(0, 420);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(20, 0, 0, 0);
            btnReports.Size = new Size(250, 60);
            btnReports.TabIndex = 8;
            btnReports.Text = "   REPORTS";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            btnReports.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 560);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(250, 60);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "   LOGOUT";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnBill
            // 
            btnBill.BackColor = Color.FromArgb(41, 53, 92);
            btnBill.FlatAppearance.BorderSize = 0;
            btnBill.FlatStyle = FlatStyle.Flat;
            btnBill.Font = new Font("Segoe UI", 11F);
            btnBill.ForeColor = Color.White;
            btnBill.Image = (Image)resources.GetObject("btnBill.Image");
            btnBill.ImageAlign = ContentAlignment.MiddleLeft;
            btnBill.Location = new Point(0, 360);
            btnBill.Name = "btnBill";
            btnBill.Padding = new Padding(20, 0, 0, 0);
            btnBill.Size = new Size(250, 60);
            btnBill.TabIndex = 6;
            btnBill.Text = "   BILL";
            btnBill.TextAlign = ContentAlignment.MiddleLeft;
            btnBill.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBill.UseVisualStyleBackColor = false;
            btnBill.Click += btnBill_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.BackColor = Color.FromArgb(41, 53, 92);
            btnEmployee.FlatAppearance.BorderSize = 0;
            btnEmployee.FlatStyle = FlatStyle.Flat;
            btnEmployee.Font = new Font("Segoe UI", 11F);
            btnEmployee.ForeColor = Color.White;
            btnEmployee.Image = (Image)resources.GetObject("btnEmployee.Image");
            btnEmployee.ImageAlign = ContentAlignment.MiddleLeft;
            btnEmployee.Location = new Point(0, 300);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Padding = new Padding(20, 0, 0, 0);
            btnEmployee.Size = new Size(250, 60);
            btnEmployee.TabIndex = 5;
            btnEmployee.Text = "   EMPLOYEE";
            btnEmployee.TextAlign = ContentAlignment.MiddleLeft;
            btnEmployee.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployee.UseVisualStyleBackColor = false;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnPayment
            // 
            btnPayment.BackColor = Color.FromArgb(41, 53, 92);
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Segoe UI", 11F);
            btnPayment.ForeColor = Color.White;
            btnPayment.Image = (Image)resources.GetObject("btnPayment.Image");
            btnPayment.ImageAlign = ContentAlignment.MiddleLeft;
            btnPayment.Location = new Point(0, 240);
            btnPayment.Name = "btnPayment";
            btnPayment.Padding = new Padding(20, 0, 0, 0);
            btnPayment.Size = new Size(250, 60);
            btnPayment.TabIndex = 4;
            btnPayment.Text = "   PAYMENT";
            btnPayment.TextAlign = ContentAlignment.MiddleLeft;
            btnPayment.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPayment.UseVisualStyleBackColor = false;
            btnPayment.Click += btnPayment_Click;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.FromArgb(41, 53, 92);
            btnGuest.FlatAppearance.BorderSize = 0;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Font = new Font("Segoe UI", 11F);
            btnGuest.ForeColor = Color.White;
            btnGuest.Image = (Image)resources.GetObject("btnGuest.Image");
            btnGuest.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuest.Location = new Point(0, 180);
            btnGuest.Name = "btnGuest";
            btnGuest.Padding = new Padding(20, 0, 0, 0);
            btnGuest.Size = new Size(250, 60);
            btnGuest.TabIndex = 3;
            btnGuest.Text = "   GUEST";
            btnGuest.TextAlign = ContentAlignment.MiddleLeft;
            btnGuest.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += btnGuest_Click;
            // 
            // btnRoom
            // 
            btnRoom.BackColor = Color.FromArgb(41, 53, 92);
            btnRoom.FlatAppearance.BorderSize = 0;
            btnRoom.FlatStyle = FlatStyle.Flat;
            btnRoom.Font = new Font("Segoe UI", 11F);
            btnRoom.ForeColor = Color.White;
            btnRoom.Image = (Image)resources.GetObject("btnRoom.Image");
            btnRoom.ImageAlign = ContentAlignment.MiddleLeft;
            btnRoom.Location = new Point(0, 120);
            btnRoom.Name = "btnRoom";
            btnRoom.Padding = new Padding(20, 0, 0, 0);
            btnRoom.Size = new Size(250, 60);
            btnRoom.TabIndex = 2;
            btnRoom.Text = "   ROOM";
            btnRoom.TextAlign = ContentAlignment.MiddleLeft;
            btnRoom.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRoom.UseVisualStyleBackColor = false;
            btnRoom.Click += btnRoom_Click;
            // 
            // btnBooking
            // 
            btnBooking.BackColor = Color.FromArgb(41, 53, 92);
            btnBooking.FlatAppearance.BorderSize = 0;
            btnBooking.FlatStyle = FlatStyle.Flat;
            btnBooking.Font = new Font("Segoe UI", 11F);
            btnBooking.ForeColor = Color.White;
            btnBooking.Image = (Image)resources.GetObject("btnBooking.Image");
            btnBooking.ImageAlign = ContentAlignment.MiddleLeft;
            btnBooking.Location = new Point(0, 60);
            btnBooking.Name = "btnBooking";
            btnBooking.Padding = new Padding(20, 0, 0, 0);
            btnBooking.Size = new Size(250, 60);
            btnBooking.TabIndex = 1;
            btnBooking.Text = "   BOOKING";
            btnBooking.TextAlign = ContentAlignment.MiddleLeft;
            btnBooking.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBooking.UseVisualStyleBackColor = false;
            btnBooking.Click += btnBooking_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(255, 215, 0);
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.FromArgb(31, 43, 82);
            btnDashboard.Image = (Image)resources.GetObject("btnDashboard.Image");
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(250, 60);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "   DASHBOARD";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panelMainContent
            // 
            panelMainContent.Controls.Add(panelDashboard);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(250, 80);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1050, 620);
            panelMainContent.TabIndex = 2;
            // 
            // panelDashboard
            // 
            panelDashboard.AutoScroll = true;
            panelDashboard.BackColor = Color.FromArgb(240, 242, 245);
            panelDashboard.Controls.Add(panelStats);
            panelDashboard.Controls.Add(label2);
            panelDashboard.Controls.Add(btnRoomStatus);
            panelDashboard.Controls.Add(btnNewReservation);
            panelDashboard.Controls.Add(btnQuickCheckIn);
            panelDashboard.Controls.Add(label4);
            panelDashboard.Dock = DockStyle.Fill;
            panelDashboard.Location = new Point(0, 0);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Size = new Size(1050, 620);
            panelDashboard.TabIndex = 0;
            // 
            // panelStats
            // 
            panelStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelStats.Controls.Add(panelStatCard7);
            panelStats.Controls.Add(panelStatCard6);
            panelStats.Controls.Add(panelStatCard5);
            panelStats.Controls.Add(panelStatCard4);
            panelStats.Controls.Add(panelStatCard3);
            panelStats.Controls.Add(panelStatCard2);
            panelStats.Controls.Add(panelStatCard1);
            panelStats.Location = new Point(30, 80);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(990, 250);
            panelStats.TabIndex = 5;
            // 
            // panelStatCard7
            // 
            panelStatCard7.BackColor = Color.White;
            panelStatCard7.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard7.Controls.Add(lblPopularRoom);
            panelStatCard7.Controls.Add(label13);
            panelStatCard7.Controls.Add(pictureBox7);
            panelStatCard7.Location = new Point(850, 0);
            panelStatCard7.Name = "panelStatCard7";
            panelStatCard7.Size = new Size(130, 120);
            panelStatCard7.TabIndex = 6;
            // 
            // lblPopularRoom
            // 
            lblPopularRoom.Font = new Font("Segoe UI", 10F);
            lblPopularRoom.ForeColor = Color.FromArgb(52, 152, 219);
            lblPopularRoom.Location = new Point(5, 70);
            lblPopularRoom.Name = "lblPopularRoom";
            lblPopularRoom.Size = new Size(120, 40);
            lblPopularRoom.TabIndex = 2;
            lblPopularRoom.Text = "Single";
            lblPopularRoom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(64, 64, 64);
            label13.Location = new Point(5, 40);
            label13.Name = "label13";
            label13.Size = new Size(120, 25);
            label13.TabIndex = 1;
            label13.Text = "POPULAR";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(50, 5);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(30, 30);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 0;
            pictureBox7.TabStop = false;
            // 
            // panelStatCard6
            // 
            panelStatCard6.BackColor = Color.White;
            panelStatCard6.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard6.Controls.Add(lblAvailableRooms);
            panelStatCard6.Controls.Add(label11);
            panelStatCard6.Controls.Add(pictureBox6);
            panelStatCard6.Location = new Point(710, 0);
            panelStatCard6.Name = "panelStatCard6";
            panelStatCard6.Size = new Size(130, 120);
            panelStatCard6.TabIndex = 5;
            // 
            // lblAvailableRooms
            // 
            lblAvailableRooms.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAvailableRooms.ForeColor = Color.FromArgb(39, 174, 96);
            lblAvailableRooms.Location = new Point(5, 60);
            lblAvailableRooms.Name = "lblAvailableRooms";
            lblAvailableRooms.Size = new Size(120, 40);
            lblAvailableRooms.TabIndex = 2;
            lblAvailableRooms.Text = "18";
            lblAvailableRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(64, 64, 64);
            label11.Location = new Point(5, 30);
            label11.Name = "label11";
            label11.Size = new Size(120, 25);
            label11.TabIndex = 1;
            label11.Text = "AVAILABLE";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(50, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(30, 30);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 0;
            pictureBox6.TabStop = false;
            // 
            // panelStatCard5
            // 
            panelStatCard5.BackColor = Color.White;
            panelStatCard5.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard5.Controls.Add(lblOccupiedRooms);
            panelStatCard5.Controls.Add(label9);
            panelStatCard5.Controls.Add(pictureBox5);
            panelStatCard5.Location = new Point(570, 0);
            panelStatCard5.Name = "panelStatCard5";
            panelStatCard5.Size = new Size(130, 120);
            panelStatCard5.TabIndex = 4;
            // 
            // lblOccupiedRooms
            // 
            lblOccupiedRooms.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblOccupiedRooms.ForeColor = Color.FromArgb(231, 76, 60);
            lblOccupiedRooms.Location = new Point(5, 60);
            lblOccupiedRooms.Name = "lblOccupiedRooms";
            lblOccupiedRooms.Size = new Size(120, 40);
            lblOccupiedRooms.TabIndex = 2;
            lblOccupiedRooms.Text = "32";
            lblOccupiedRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(64, 64, 64);
            label9.Location = new Point(5, 30);
            label9.Name = "label9";
            label9.Size = new Size(120, 25);
            label9.TabIndex = 1;
            label9.Text = "OCCUPIED";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(50, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(30, 30);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // panelStatCard4
            // 
            panelStatCard4.BackColor = Color.White;
            panelStatCard4.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard4.Controls.Add(lblTodayRevenue);
            panelStatCard4.Controls.Add(label7);
            panelStatCard4.Controls.Add(pictureBox4);
            panelStatCard4.Location = new Point(430, 0);
            panelStatCard4.Name = "panelStatCard4";
            panelStatCard4.Size = new Size(130, 120);
            panelStatCard4.TabIndex = 3;
            // 
            // lblTodayRevenue
            // 
            lblTodayRevenue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTodayRevenue.ForeColor = Color.FromArgb(155, 89, 182);
            lblTodayRevenue.Location = new Point(5, 60);
            lblTodayRevenue.Name = "lblTodayRevenue";
            lblTodayRevenue.Size = new Size(120, 40);
            lblTodayRevenue.TabIndex = 2;
            lblTodayRevenue.Text = "$2,850";
            lblTodayRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(64, 64, 64);
            label7.Location = new Point(5, 30);
            label7.Name = "label7";
            label7.Size = new Size(120, 25);
            label7.TabIndex = 1;
            label7.Text = "TODAY'S REVENUE";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(50, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(30, 30);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // panelStatCard3
            // 
            panelStatCard3.BackColor = Color.White;
            panelStatCard3.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard3.Controls.Add(lblTotalBookings);
            panelStatCard3.Controls.Add(label5);
            panelStatCard3.Controls.Add(pictureBox3);
            panelStatCard3.Location = new Point(290, 0);
            panelStatCard3.Name = "panelStatCard3";
            panelStatCard3.Size = new Size(130, 120);
            panelStatCard3.TabIndex = 2;
            // 
            // lblTotalBookings
            // 
            lblTotalBookings.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalBookings.ForeColor = Color.FromArgb(142, 68, 173);
            lblTotalBookings.Location = new Point(5, 60);
            lblTotalBookings.Name = "lblTotalBookings";
            lblTotalBookings.Size = new Size(120, 40);
            lblTotalBookings.TabIndex = 2;
            lblTotalBookings.Text = "12";
            lblTotalBookings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(5, 30);
            label5.Name = "label5";
            label5.Size = new Size(120, 25);
            label5.TabIndex = 1;
            label5.Text = "TOTAL BOOKINGS";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(50, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // panelStatCard2
            // 
            panelStatCard2.BackColor = Color.White;
            panelStatCard2.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard2.Controls.Add(lblTotalRooms);
            panelStatCard2.Controls.Add(label3);
            panelStatCard2.Controls.Add(pictureBox2);
            panelStatCard2.Location = new Point(150, 0);
            panelStatCard2.Name = "panelStatCard2";
            panelStatCard2.Size = new Size(130, 120);
            panelStatCard2.TabIndex = 1;
            // 
            // lblTotalRooms
            // 
            lblTotalRooms.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalRooms.ForeColor = Color.FromArgb(39, 174, 96);
            lblTotalRooms.Location = new Point(5, 60);
            lblTotalRooms.Name = "lblTotalRooms";
            lblTotalRooms.Size = new Size(120, 40);
            lblTotalRooms.TabIndex = 2;
            lblTotalRooms.Text = "50";
            lblTotalRooms.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(5, 30);
            label3.Name = "label3";
            label3.Size = new Size(120, 25);
            label3.TabIndex = 1;
            label3.Text = "TOTAL ROOMS";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(50, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panelStatCard1
            // 
            panelStatCard1.BackColor = Color.White;
            panelStatCard1.BorderStyle = BorderStyle.FixedSingle;
            panelStatCard1.Controls.Add(lblTotalGuests);
            panelStatCard1.Controls.Add(label1);
            panelStatCard1.Controls.Add(pictureBox1);
            panelStatCard1.Location = new Point(10, 0);
            panelStatCard1.Name = "panelStatCard1";
            panelStatCard1.Size = new Size(130, 120);
            panelStatCard1.TabIndex = 0;
            // 
            // lblTotalGuests
            // 
            lblTotalGuests.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotalGuests.ForeColor = Color.FromArgb(41, 128, 185);
            lblTotalGuests.Location = new Point(5, 60);
            lblTotalGuests.Name = "lblTotalGuests";
            lblTotalGuests.Size = new Size(120, 40);
            lblTotalGuests.TabIndex = 2;
            lblTotalGuests.Text = "3";
            lblTotalGuests.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(5, 30);
            label1.Name = "label1";
            label1.Size = new Size(120, 25);
            label1.TabIndex = 1;
            label1.Text = "TOTAL GUESTS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(50, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(31, 43, 82);
            label2.Location = new Point(30, 20);
            label2.Name = "label2";
            label2.Size = new Size(378, 54);
            label2.TabIndex = 4;
            label2.Text = "HOTEL DASHBOARD";
            // 
            // btnRoomStatus
            // 
            btnRoomStatus.BackColor = Color.FromArgb(155, 89, 182);
            btnRoomStatus.FlatAppearance.BorderSize = 0;
            btnRoomStatus.FlatStyle = FlatStyle.Flat;
            btnRoomStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRoomStatus.ForeColor = Color.White;
            btnRoomStatus.Image = (Image)resources.GetObject("btnRoomStatus.Image");
            btnRoomStatus.ImageAlign = ContentAlignment.MiddleLeft;
            btnRoomStatus.Location = new Point(290, 400);
            btnRoomStatus.Name = "btnRoomStatus";
            btnRoomStatus.Padding = new Padding(20, 0, 0, 0);
            btnRoomStatus.Size = new Size(250, 60);
            btnRoomStatus.TabIndex = 3;
            btnRoomStatus.Text = "   ROOM STATUS";
            btnRoomStatus.TextAlign = ContentAlignment.MiddleLeft;
            btnRoomStatus.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRoomStatus.UseVisualStyleBackColor = false;
            btnRoomStatus.Click += btnRoomStatus_Click;
            // 
            // btnNewReservation
            // 
            btnNewReservation.BackColor = Color.FromArgb(46, 204, 113);
            btnNewReservation.FlatAppearance.BorderSize = 0;
            btnNewReservation.FlatStyle = FlatStyle.Flat;
            btnNewReservation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNewReservation.ForeColor = Color.White;
            btnNewReservation.Image = (Image)resources.GetObject("btnNewReservation.Image");
            btnNewReservation.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewReservation.Location = new Point(30, 400);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Padding = new Padding(20, 0, 0, 0);
            btnNewReservation.Size = new Size(250, 60);
            btnNewReservation.TabIndex = 2;
            btnNewReservation.Text = "   NEW RESERVATION";
            btnNewReservation.TextAlign = ContentAlignment.MiddleLeft;
            btnNewReservation.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewReservation.UseVisualStyleBackColor = false;
            btnNewReservation.Click += btnNewReservation_Click;
            // 
            // btnQuickCheckIn
            // 
            btnQuickCheckIn.BackColor = Color.FromArgb(52, 152, 219);
            btnQuickCheckIn.FlatAppearance.BorderSize = 0;
            btnQuickCheckIn.FlatStyle = FlatStyle.Flat;
            btnQuickCheckIn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuickCheckIn.ForeColor = Color.White;
            btnQuickCheckIn.Image = (Image)resources.GetObject("btnQuickCheckIn.Image");
            btnQuickCheckIn.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuickCheckIn.Location = new Point(550, 400);
            btnQuickCheckIn.Name = "btnQuickCheckIn";
            btnQuickCheckIn.Padding = new Padding(20, 0, 0, 0);
            btnQuickCheckIn.Size = new Size(250, 60);
            btnQuickCheckIn.TabIndex = 1;
            btnQuickCheckIn.Text = "   QUICK CHECK-IN";
            btnQuickCheckIn.TextAlign = ContentAlignment.MiddleLeft;
            btnQuickCheckIn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnQuickCheckIn.UseVisualStyleBackColor = false;
            btnQuickCheckIn.Click += btnQuickCheckIn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(31, 43, 82);
            label4.Location = new Point(30, 350);
            label4.Name = "label4";
            label4.Size = new Size(243, 41);
            label4.TabIndex = 0;
            label4.Text = "QUICK ACTIONS";
            // 
            // panelStatusBar
            // 
            panelStatusBar.BackColor = Color.FromArgb(31, 43, 82);
            panelStatusBar.Controls.Add(lblTime);
            panelStatusBar.Controls.Add(lblDate);
            panelStatusBar.Controls.Add(label6);
            panelStatusBar.Dock = DockStyle.Bottom;
            panelStatusBar.Location = new Point(250, 700);
            panelStatusBar.Name = "panelStatusBar";
            panelStatusBar.Size = new Size(1050, 30);
            panelStatusBar.TabIndex = 3;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(900, 5);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(140, 20);
            lblTime.TabIndex = 2;
            lblTime.Text = "12:00:00";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDate.ForeColor = Color.White;
            lblDate.Location = new Point(200, 5);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(300, 20);
            lblDate.TabIndex = 1;
            lblDate.Text = "Monday, December 15, 2025";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(255, 215, 0);
            label6.Location = new Point(10, 5);
            label6.Name = "label6";
            label6.Size = new Size(184, 20);
            label6.TabIndex = 0;
            label6.Text = "HOTEL HYATT SYSTEM";
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 730);
            Controls.Add(panelStatusBar);
            Controls.Add(panelMainContent);
            Controls.Add(panelSidebar);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1318, 777);
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Management System - Hotel Hyatt";
            Load += MainDashboard_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelSidebar.ResumeLayout(false);
            panelMainContent.ResumeLayout(false);
            panelDashboard.ResumeLayout(false);
            panelDashboard.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStatCard7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panelStatCard6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panelStatCard5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panelStatCard4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panelStatCard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelStatCard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelStatCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelStatusBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblHotelName;
        private PictureBox pictureBoxLogo;
        private Label lblSystemTitle;
        private Label lblWelcome;
        private Panel panelSidebar;
        private Button btnDashboard;
        private Button btnBooking;
        private Button btnRoom;
        private Button btnGuest;
        private Button btnPayment;
        private Button btnEmployee;
        private Button btnBill;
        private Button btnLogout;
        private Panel panelMainContent;
        private Panel panelDashboard;
        private Panel panelStats;
        private Panel panelStatCard1;
        private Label lblTotalGuests;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panelStatCard2;
        private Label lblTotalRooms;
        private Label label3;
        private PictureBox pictureBox2;
        private Panel panelStatCard3;
        private Label lblTotalBookings;
        private Label label5;
        private PictureBox pictureBox3;
        private Panel panelStatCard4;
        private Label lblTodayRevenue;
        private Label label7;
        private PictureBox pictureBox4;
        private Panel panelStatCard5;
        private Label lblOccupiedRooms;
        private Label label9;
        private PictureBox pictureBox5;
        private Panel panelStatCard6;
        private Label lblAvailableRooms;
        private Label label11;
        private PictureBox pictureBox6;
        private Panel panelStatCard7;
        private Label lblPopularRoom;
        private Label label13;
        private PictureBox pictureBox7;
        private Label label2;
        private Button btnRoomStatus;
        private Button btnNewReservation;
        private Button btnQuickCheckIn;
        private Label label4;
        private Panel panelStatusBar;
        private Label lblTime;
        private Label lblDate;
        private Label label6;
        private Button btnUserManagement;
        private Button btnReports;
    }
}