namespace HotelManagement.Desktop
{
    partial class ReportsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnExport = new Button();
            btnGenerateReport = new Button();
            dgvRevenue = new DataGridView();
            lblTotalRevenue = new Label();
            label6 = new Label();
            dtpTo = new DateTimePicker();
            label5 = new Label();
            dtpFrom = new DateTimePicker();
            label4 = new Label();
            cmbReportType = new ComboBox();
            label3 = new Label();
            btnRefresh = new Button();
            tabPage2 = new TabPage();
            dgvTopGuests = new DataGridView();
            tabPage3 = new TabPage();
            chartOccupancy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1 = new GroupBox();
            lblOccupancyRate = new Label();
            lblAvailableRooms = new Label();
            lblOccupiedRooms = new Label();
            lblTotalRooms = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            tabPage4 = new TabPage();
            chartDailyBookings = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelHeader = new Panel();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopGuests).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartOccupancy).BeginInit();
            groupBox1.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDailyBookings).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 80);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1200, 620);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(240, 242, 245);
            tabPage1.Controls.Add(chartRevenue);
            tabPage1.Controls.Add(btnExport);
            tabPage1.Controls.Add(btnGenerateReport);
            tabPage1.Controls.Add(dgvRevenue);
            tabPage1.Controls.Add(lblTotalRevenue);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(dtpTo);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(dtpFrom);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(cmbReportType);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(btnRefresh);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1192, 582);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "💰 Revenue Report";
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartRevenue.Legends.Add(legend1);
            chartRevenue.Location = new Point(30, 250);
            chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Revenue";
            chartRevenue.Series.Add(series1);
            chartRevenue.Size = new Size(550, 300);
            chartRevenue.TabIndex = 12;
            chartRevenue.Text = "chart1";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.SteelBlue;
            btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(950, 80);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(150, 40);
            btnExport.TabIndex = 11;
            btnExport.Text = "📤 EXPORT REPORT";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.Green;
            btnGenerateReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(950, 30);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 40);
            btnGenerateReport.TabIndex = 10;
            btnGenerateReport.Text = "📊 GENERATE";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += new System.EventHandler(this.BtnGenerateReport_Click);
            // 
            // dgvRevenue
            // 
            dgvRevenue.AllowUserToAddRows = false;
            dgvRevenue.AllowUserToDeleteRows = false;
            dgvRevenue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenue.BackgroundColor = Color.White;
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.Location = new Point(600, 250);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.ReadOnly = true;
            dgvRevenue.RowHeadersWidth = 51;
            dgvRevenue.Size = new Size(550, 300);
            dgvRevenue.TabIndex = 9;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalRevenue.ForeColor = Color.Green;
            lblTotalRevenue.Location = new Point(700, 200);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(82, 32);
            lblTotalRevenue.TabIndex = 8;
            lblTotalRevenue.Text = "$0.00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(500, 203);
            label6.Name = "label6";
            label6.Size = new Size(194, 28);
            label6.TabIndex = 7;
            label6.Text = "Total Revenue:";
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(450, 80);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(250, 27);
            dtpTo.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(420, 85);
            label5.Name = "label5";
            label5.Size = new Size(28, 23);
            label5.TabIndex = 5;
            label5.Text = "To:";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(150, 80);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(250, 27);
            dtpFrom.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(100, 85);
            label4.Name = "label4";
            label4.Size = new Size(53, 23);
            label4.TabIndex = 3;
            label4.Text = "From:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Font = new Font("Segoe UI", 10F);
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(150, 30);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(200, 31);
            cmbReportType.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(30, 35);
            label3.Name = "label3";
            label3.Size = new Size(114, 23);
            label3.TabIndex = 1;
            label3.Text = "Report Type:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(950, 130);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 40);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "🔄 REFRESH";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(240, 242, 245);
            tabPage2.Controls.Add(dgvTopGuests);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1192, 582);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "👑 Top Guests";
            // 
            // dgvTopGuests
            // 
            dgvTopGuests.AllowUserToAddRows = false;
            dgvTopGuests.AllowUserToDeleteRows = false;
            dgvTopGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopGuests.BackgroundColor = Color.White;
            dgvTopGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopGuests.Dock = DockStyle.Fill;
            dgvTopGuests.Location = new Point(3, 3);
            dgvTopGuests.Name = "dgvTopGuests";
            dgvTopGuests.ReadOnly = true;
            dgvTopGuests.RowHeadersWidth = 51;
            dgvTopGuests.Size = new Size(1186, 576);
            dgvTopGuests.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = Color.FromArgb(240, 242, 245);
            tabPage3.Controls.Add(chartOccupancy);
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1192, 582);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "📊 Occupancy";
            // 
            // chartOccupancy
            // 
            chartArea2.Name = "ChartArea1";
            chartOccupancy.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartOccupancy.Legends.Add(legend2);
            chartOccupancy.Location = new Point(600, 50);
            chartOccupancy.Name = "chartOccupancy";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Occupancy";
            chartOccupancy.Series.Add(series2);
            chartOccupancy.Size = new Size(550, 500);
            chartOccupancy.TabIndex = 1;
            chartOccupancy.Text = "chart2";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.LightCyan;
            groupBox1.Controls.Add(lblOccupancyRate);
            groupBox1.Controls.Add(lblAvailableRooms);
            groupBox1.Controls.Add(lblOccupiedRooms);
            groupBox1.Controls.Add(lblTotalRooms);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(50, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 500);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current Occupancy Status";
            // 
            // lblOccupancyRate
            // 
            lblOccupancyRate.AutoSize = true;
            lblOccupancyRate.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOccupancyRate.ForeColor = Color.Blue;
            lblOccupancyRate.Location = new Point(250, 400);
            lblOccupancyRate.Name = "lblOccupancyRate";
            lblOccupancyRate.Size = new Size(94, 41);
            lblOccupancyRate.TabIndex = 7;
            lblOccupancyRate.Text = "0.0%";
            // 
            // lblAvailableRooms
            // 
            lblAvailableRooms.AutoSize = true;
            lblAvailableRooms.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvailableRooms.ForeColor = Color.Green;
            lblAvailableRooms.Location = new Point(250, 300);
            lblAvailableRooms.Name = "lblAvailableRooms";
            lblAvailableRooms.Size = new Size(35, 41);
            lblAvailableRooms.TabIndex = 6;
            lblAvailableRooms.Text = "0";
            // 
            // lblOccupiedRooms
            // 
            lblOccupiedRooms.AutoSize = true;
            lblOccupiedRooms.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOccupiedRooms.ForeColor = Color.OrangeRed;
            lblOccupiedRooms.Location = new Point(250, 200);
            lblOccupiedRooms.Name = "lblOccupiedRooms";
            lblOccupiedRooms.Size = new Size(35, 41);
            lblOccupiedRooms.TabIndex = 5;
            lblOccupiedRooms.Text = "0";
            // 
            // lblTotalRooms
            // 
            lblTotalRooms.AutoSize = true;
            lblTotalRooms.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRooms.ForeColor = Color.Black;
            lblTotalRooms.Location = new Point(250, 100);
            lblTotalRooms.Name = "lblTotalRooms";
            lblTotalRooms.Size = new Size(35, 41);
            lblTotalRooms.TabIndex = 4;
            lblTotalRooms.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F);
            label10.Location = new Point(50, 405);
            label10.Name = "label10";
            label10.Size = new Size(189, 32);
            label10.TabIndex = 3;
            label10.Text = "Occupancy Rate:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14F);
            label9.Location = new Point(50, 305);
            label9.Name = "label9";
            label9.Size = new Size(200, 32);
            label9.TabIndex = 2;
            label9.Text = "Available Rooms:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(50, 205);
            label8.Name = "label8";
            label8.Size = new Size(204, 32);
            label8.TabIndex = 1;
            label8.Text = "Occupied Rooms:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F);
            label7.Location = new Point(50, 105);
            label7.Name = "label7";
            label7.Size = new Size(166, 32);
            label7.TabIndex = 0;
            label7.Text = "Total Rooms:";
            // 
            // tabPage4
            // 
            tabPage4.BackColor = Color.FromArgb(240, 242, 245);
            tabPage4.Controls.Add(chartDailyBookings);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1192, 582);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "📈 Daily Bookings";
            // 
            // chartDailyBookings
            // 
            chartArea3.Name = "ChartArea1";
            chartDailyBookings.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartDailyBookings.Legends.Add(legend3);
            chartDailyBookings.Location = new Point(50, 50);
            chartDailyBookings.Name = "chartDailyBookings";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Bookings";
            chartDailyBookings.Series.Add(series3);
            chartDailyBookings.Size = new Size(1100, 500);
            chartDailyBookings.TabIndex = 0;
            chartDailyBookings.Text = "chart3";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(31, 43, 82);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 80);
            panelHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 215, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(340, 41);
            label1.TabIndex = 2;
            label1.Text = "📊 REPORTS DASHBOARD";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1218, 747);
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Reports Dashboard";
            Load += new System.EventHandler(this.ReportsForm_Load);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTopGuests).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartOccupancy).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDailyBookings).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private Button btnExport;
        private Button btnGenerateReport;
        private DataGridView dgvRevenue;
        private Label lblTotalRevenue;
        private Label label6;
        private DateTimePicker dtpTo;
        private Label label5;
        private DateTimePicker dtpFrom;
        private Label label4;
        private ComboBox cmbReportType;
        private Label label3;
        private Button btnRefresh;
        private TabPage tabPage2;
        private DataGridView dgvTopGuests;
        private TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOccupancy;
        private GroupBox groupBox1;
        private Label lblOccupancyRate;
        private Label lblAvailableRooms;
        private Label lblOccupiedRooms;
        private Label lblTotalRooms;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyBookings;
        private Panel panelHeader;
        private Label label1;
    }
}