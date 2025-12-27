namespace Quản_Lí_Kho_Vật_Tư
{
    partial class Themnhanvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbthemnv = new System.Windows.Forms.Label();
            this.gbthemnv = new System.Windows.Forms.GroupBox();
            this.txtdiachi = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtsdt = new System.Windows.Forms.TextBox();
            this.datengaysinh = new System.Windows.Forms.DateTimePicker();
            this.cbgioitinh = new System.Windows.Forms.ComboBox();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.lbdiachi = new System.Windows.Forms.Label();
            this.lbemail = new System.Windows.Forms.Label();
            this.lbsdt = new System.Windows.Forms.Label();
            this.lbngaysinh = new System.Windows.Forms.Label();
            this.lbgioitinh = new System.Windows.Forms.Label();
            this.lbhoten = new System.Windows.Forms.Label();
            this.lbmanv = new System.Windows.Forms.Label();
            this.btnboqua = new System.Windows.Forms.Button();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.panelfill = new System.Windows.Forms.Panel();
            this.gbcongviec = new System.Windows.Forms.GroupBox();
            this.txtluong = new System.Windows.Forms.TextBox();
            this.cbtrangthai = new System.Windows.Forms.ComboBox();
            this.lbluong = new System.Windows.Forms.Label();
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.lbghichu = new System.Windows.Forms.Label();
            this.tboxghichu = new System.Windows.Forms.RichTextBox();
            this.cbchinhanh = new System.Windows.Forms.ComboBox();
            this.cbphongban = new System.Windows.Forms.ComboBox();
            this.cbchucdanh = new System.Windows.Forms.ComboBox();
            this.datebatdau = new System.Windows.Forms.DateTimePicker();
            this.lbchucdanh = new System.Windows.Forms.Label();
            this.lbchinhanh = new System.Windows.Forms.Label();
            this.lbphongban = new System.Windows.Forms.Label();
            this.lbngaybatdau = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ibtnluu = new FontAwesome.Sharp.IconButton();
            this.iconSplitButton1 = new FontAwesome.Sharp.IconSplitButton();
            this.gbthemnv.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.panelfill.SuspendLayout();
            this.gbcongviec.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbthemnv
            // 
            this.lbthemnv.AutoSize = true;
            this.lbthemnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbthemnv.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbthemnv.Location = new System.Drawing.Point(3, 0);
            this.lbthemnv.Name = "lbthemnv";
            this.lbthemnv.Size = new System.Drawing.Size(262, 29);
            this.lbthemnv.TabIndex = 0;
            this.lbthemnv.Text = "Thêm mới nhân viên";
            this.lbthemnv.Click += new System.EventHandler(this.lbthemnv_Click);
            // 
            // gbthemnv
            // 
            this.gbthemnv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbthemnv.Controls.Add(this.txtdiachi);
            this.gbthemnv.Controls.Add(this.txtemail);
            this.gbthemnv.Controls.Add(this.txtsdt);
            this.gbthemnv.Controls.Add(this.datengaysinh);
            this.gbthemnv.Controls.Add(this.cbgioitinh);
            this.gbthemnv.Controls.Add(this.txthoten);
            this.gbthemnv.Controls.Add(this.txtmanv);
            this.gbthemnv.Controls.Add(this.lbdiachi);
            this.gbthemnv.Controls.Add(this.lbemail);
            this.gbthemnv.Controls.Add(this.lbsdt);
            this.gbthemnv.Controls.Add(this.lbngaysinh);
            this.gbthemnv.Controls.Add(this.lbgioitinh);
            this.gbthemnv.Controls.Add(this.lbhoten);
            this.gbthemnv.Controls.Add(this.lbmanv);
            this.gbthemnv.Location = new System.Drawing.Point(12, 48);
            this.gbthemnv.Name = "gbthemnv";
            this.gbthemnv.Size = new System.Drawing.Size(773, 248);
            this.gbthemnv.TabIndex = 1;
            this.gbthemnv.TabStop = false;
            this.gbthemnv.Text = "Thông tin khởi tạo";
            this.gbthemnv.Enter += new System.EventHandler(this.gbthemnv_Enter);
            // 
            // txtdiachi
            // 
            this.txtdiachi.Location = new System.Drawing.Point(191, 209);
            this.txtdiachi.Name = "txtdiachi";
            this.txtdiachi.Size = new System.Drawing.Size(412, 22);
            this.txtdiachi.TabIndex = 13;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(478, 149);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(200, 22);
            this.txtemail.TabIndex = 12;
            // 
            // txtsdt
            // 
            this.txtsdt.Location = new System.Drawing.Point(478, 96);
            this.txtsdt.Name = "txtsdt";
            this.txtsdt.Size = new System.Drawing.Size(200, 22);
            this.txtsdt.TabIndex = 11;
            // 
            // datengaysinh
            // 
            this.datengaysinh.Location = new System.Drawing.Point(478, 42);
            this.datengaysinh.Name = "datengaysinh";
            this.datengaysinh.Size = new System.Drawing.Size(200, 22);
            this.datengaysinh.TabIndex = 10;
            // 
            // cbgioitinh
            // 
            this.cbgioitinh.FormattingEnabled = true;
            this.cbgioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ ",
            "Khác"});
            this.cbgioitinh.Location = new System.Drawing.Point(178, 149);
            this.cbgioitinh.Name = "cbgioitinh";
            this.cbgioitinh.Size = new System.Drawing.Size(190, 24);
            this.cbgioitinh.TabIndex = 9;
            // 
            // txthoten
            // 
            this.txthoten.Location = new System.Drawing.Point(178, 93);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(190, 22);
            this.txthoten.TabIndex = 8;
            // 
            // txtmanv
            // 
            this.txtmanv.Location = new System.Drawing.Point(178, 39);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.Size = new System.Drawing.Size(190, 22);
            this.txtmanv.TabIndex = 7;
            // 
            // lbdiachi
            // 
            this.lbdiachi.AutoSize = true;
            this.lbdiachi.Location = new System.Drawing.Point(114, 212);
            this.lbdiachi.Name = "lbdiachi";
            this.lbdiachi.Size = new System.Drawing.Size(47, 16);
            this.lbdiachi.TabIndex = 6;
            this.lbdiachi.Text = "Địa chỉ";
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Location = new System.Drawing.Point(377, 152);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(41, 16);
            this.lbemail.TabIndex = 5;
            this.lbemail.Text = "Email";
            // 
            // lbsdt
            // 
            this.lbsdt.AutoSize = true;
            this.lbsdt.Location = new System.Drawing.Point(374, 96);
            this.lbsdt.Name = "lbsdt";
            this.lbsdt.Size = new System.Drawing.Size(35, 16);
            this.lbsdt.TabIndex = 4;
            this.lbsdt.Text = "SDT";
            // 
            // lbngaysinh
            // 
            this.lbngaysinh.AutoSize = true;
            this.lbngaysinh.Location = new System.Drawing.Point(374, 45);
            this.lbngaysinh.Name = "lbngaysinh";
            this.lbngaysinh.Size = new System.Drawing.Size(67, 16);
            this.lbngaysinh.TabIndex = 3;
            this.lbngaysinh.Text = "Ngày sinh";
            // 
            // lbgioitinh
            // 
            this.lbgioitinh.AutoSize = true;
            this.lbgioitinh.Location = new System.Drawing.Point(54, 152);
            this.lbgioitinh.Name = "lbgioitinh";
            this.lbgioitinh.Size = new System.Drawing.Size(54, 16);
            this.lbgioitinh.TabIndex = 2;
            this.lbgioitinh.Text = "Giới tính";
            // 
            // lbhoten
            // 
            this.lbhoten.AutoSize = true;
            this.lbhoten.Location = new System.Drawing.Point(54, 96);
            this.lbhoten.Name = "lbhoten";
            this.lbhoten.Size = new System.Drawing.Size(64, 16);
            this.lbhoten.TabIndex = 1;
            this.lbhoten.Text = "Họ và tên";
            // 
            // lbmanv
            // 
            this.lbmanv.AutoSize = true;
            this.lbmanv.Location = new System.Drawing.Point(54, 45);
            this.lbmanv.Name = "lbmanv";
            this.lbmanv.Size = new System.Drawing.Size(86, 16);
            this.lbmanv.TabIndex = 0;
            this.lbmanv.Text = "Mã nhân viên";
            // 
            // btnboqua
            // 
            this.btnboqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnboqua.Location = new System.Drawing.Point(224, 21);
            this.btnboqua.Name = "btnboqua";
            this.btnboqua.Size = new System.Drawing.Size(113, 52);
            this.btnboqua.TabIndex = 2;
            this.btnboqua.Text = "Bỏ qua";
            this.btnboqua.UseVisualStyleBackColor = true;
            this.btnboqua.Click += new System.EventHandler(this.btnboqua_Click);
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.btnboqua);
            this.panelbottom.Controls.Add(this.ibtnluu);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.Location = new System.Drawing.Point(0, 590);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(800, 100);
            this.panelbottom.TabIndex = 5;
            // 
            // panelfill
            // 
            this.panelfill.Controls.Add(this.gbcongviec);
            this.panelfill.Controls.Add(this.flowLayoutPanel1);
            this.panelfill.Controls.Add(this.gbthemnv);
            this.panelfill.Controls.Add(this.label3);
            this.panelfill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelfill.Location = new System.Drawing.Point(0, 0);
            this.panelfill.Name = "panelfill";
            this.panelfill.Size = new System.Drawing.Size(800, 590);
            this.panelfill.TabIndex = 6;
            this.panelfill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelfill_Paint);
            // 
            // gbcongviec
            // 
            this.gbcongviec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbcongviec.Controls.Add(this.txtluong);
            this.gbcongviec.Controls.Add(this.cbtrangthai);
            this.gbcongviec.Controls.Add(this.lbluong);
            this.gbcongviec.Controls.Add(this.lbtrangthai);
            this.gbcongviec.Controls.Add(this.lbghichu);
            this.gbcongviec.Controls.Add(this.tboxghichu);
            this.gbcongviec.Controls.Add(this.cbchinhanh);
            this.gbcongviec.Controls.Add(this.cbphongban);
            this.gbcongviec.Controls.Add(this.cbchucdanh);
            this.gbcongviec.Controls.Add(this.datebatdau);
            this.gbcongviec.Controls.Add(this.lbchucdanh);
            this.gbcongviec.Controls.Add(this.lbchinhanh);
            this.gbcongviec.Controls.Add(this.lbphongban);
            this.gbcongviec.Controls.Add(this.lbngaybatdau);
            this.gbcongviec.Location = new System.Drawing.Point(13, 315);
            this.gbcongviec.Name = "gbcongviec";
            this.gbcongviec.Size = new System.Drawing.Size(772, 269);
            this.gbcongviec.TabIndex = 3;
            this.gbcongviec.TabStop = false;
            this.gbcongviec.Text = "Thông tin công việc";
            // 
            // txtluong
            // 
            this.txtluong.Location = new System.Drawing.Point(542, 139);
            this.txtluong.Name = "txtluong";
            this.txtluong.Size = new System.Drawing.Size(200, 22);
            this.txtluong.TabIndex = 15;
            // 
            // cbtrangthai
            // 
            this.cbtrangthai.FormattingEnabled = true;
            this.cbtrangthai.Items.AddRange(new object[] {
            "Đang làm việc",
            "Tạm nghỉ/Nghỉ phép",
            "Đã nghỉ việc"});
            this.cbtrangthai.Location = new System.Drawing.Point(217, 139);
            this.cbtrangthai.Name = "cbtrangthai";
            this.cbtrangthai.Size = new System.Drawing.Size(200, 24);
            this.cbtrangthai.TabIndex = 14;
            // 
            // lbluong
            // 
            this.lbluong.AutoSize = true;
            this.lbluong.Location = new System.Drawing.Point(438, 142);
            this.lbluong.Name = "lbluong";
            this.lbluong.Size = new System.Drawing.Size(68, 16);
            this.lbluong.TabIndex = 13;
            this.lbluong.Text = "Mức lương";
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Location = new System.Drawing.Point(19, 142);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(67, 16);
            this.lbtrangthai.TabIndex = 12;
            this.lbtrangthai.Text = "Trạng thái";
            // 
            // lbghichu
            // 
            this.lbghichu.AutoSize = true;
            this.lbghichu.Location = new System.Drawing.Point(53, 202);
            this.lbghichu.Name = "lbghichu";
            this.lbghichu.Size = new System.Drawing.Size(51, 16);
            this.lbghichu.TabIndex = 11;
            this.lbghichu.Text = "Ghi chú";
            // 
            // tboxghichu
            // 
            this.tboxghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxghichu.Location = new System.Drawing.Point(142, 185);
            this.tboxghichu.Name = "tboxghichu";
            this.tboxghichu.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tboxghichu.Size = new System.Drawing.Size(578, 48);
            this.tboxghichu.TabIndex = 10;
            this.tboxghichu.Text = "";
            // 
            // cbchinhanh
            // 
            this.cbchinhanh.FormattingEnabled = true;
            this.cbchinhanh.Items.AddRange(new object[] {
            "Miền Bắc",
            "Miền Trung",
            "Miền Nam"});
            this.cbchinhanh.Location = new System.Drawing.Point(542, 90);
            this.cbchinhanh.Name = "cbchinhanh";
            this.cbchinhanh.Size = new System.Drawing.Size(200, 24);
            this.cbchinhanh.TabIndex = 9;
            // 
            // cbphongban
            // 
            this.cbphongban.FormattingEnabled = true;
            this.cbphongban.Items.AddRange(new object[] {
            "Ban giám đốc",
            "Phòng cung ứng",
            "Phòng kho vận",
            "Phòng kế toán",
            "Phòng kỹ thuật",
            "Phòng hành chính"});
            this.cbphongban.Location = new System.Drawing.Point(542, 40);
            this.cbphongban.Name = "cbphongban";
            this.cbphongban.Size = new System.Drawing.Size(200, 24);
            this.cbphongban.TabIndex = 8;
            // 
            // cbchucdanh
            // 
            this.cbchucdanh.FormattingEnabled = true;
            this.cbchucdanh.Items.AddRange(new object[] {
            "Quản lý",
            "Nhân viên nghiệp vụ",
            "Thủ kho",
            "Nhân viên kĩ thuật",
            "Nhân viên hỗ trợ"});
            this.cbchucdanh.Location = new System.Drawing.Point(217, 90);
            this.cbchucdanh.Name = "cbchucdanh";
            this.cbchucdanh.Size = new System.Drawing.Size(200, 24);
            this.cbchucdanh.TabIndex = 7;
            // 
            // datebatdau
            // 
            this.datebatdau.Location = new System.Drawing.Point(217, 42);
            this.datebatdau.Name = "datebatdau";
            this.datebatdau.Size = new System.Drawing.Size(200, 22);
            this.datebatdau.TabIndex = 6;
            // 
            // lbchucdanh
            // 
            this.lbchucdanh.AutoSize = true;
            this.lbchucdanh.Location = new System.Drawing.Point(19, 93);
            this.lbchucdanh.Name = "lbchucdanh";
            this.lbchucdanh.Size = new System.Drawing.Size(70, 16);
            this.lbchucdanh.TabIndex = 4;
            this.lbchucdanh.Text = "Chức danh";
            // 
            // lbchinhanh
            // 
            this.lbchinhanh.AutoSize = true;
            this.lbchinhanh.Location = new System.Drawing.Point(434, 93);
            this.lbchinhanh.Name = "lbchinhanh";
            this.lbchinhanh.Size = new System.Drawing.Size(65, 16);
            this.lbchinhanh.TabIndex = 3;
            this.lbchinhanh.Text = "Chi nhánh";
            // 
            // lbphongban
            // 
            this.lbphongban.AutoSize = true;
            this.lbphongban.Location = new System.Drawing.Point(434, 45);
            this.lbphongban.Name = "lbphongban";
            this.lbphongban.Size = new System.Drawing.Size(72, 16);
            this.lbphongban.TabIndex = 1;
            this.lbphongban.Text = "Phòng ban";
            // 
            // lbngaybatdau
            // 
            this.lbngaybatdau.AutoSize = true;
            this.lbngaybatdau.Location = new System.Drawing.Point(19, 45);
            this.lbngaybatdau.Name = "lbngaybatdau";
            this.lbngaybatdau.Size = new System.Drawing.Size(141, 16);
            this.lbngaybatdau.TabIndex = 0;
            this.lbngaybatdau.Text = "Ngày bắt đầu làm việc";
            this.lbngaybatdau.Click += new System.EventHandler(this.lbngaybatdau_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, -61);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 55);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 532);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // paneltop
            // 
            this.paneltop.Controls.Add(this.lbthemnv);
            this.paneltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltop.Location = new System.Drawing.Point(0, 0);
            this.paneltop.Name = "paneltop";
            this.paneltop.Size = new System.Drawing.Size(800, 42);
            this.paneltop.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ibtnluu
            // 
            this.ibtnluu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ibtnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ibtnluu.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtnluu.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.ibtnluu.IconColor = System.Drawing.Color.White;
            this.ibtnluu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnluu.IconSize = 40;
            this.ibtnluu.Location = new System.Drawing.Point(364, 21);
            this.ibtnluu.Name = "ibtnluu";
            this.ibtnluu.Size = new System.Drawing.Size(129, 52);
            this.ibtnluu.TabIndex = 3;
            this.ibtnluu.Text = "Lưu";
            this.ibtnluu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtnluu.UseVisualStyleBackColor = false;
            this.ibtnluu.Click += new System.EventHandler(this.ibtnluu_Click);
            // 
            // iconSplitButton1
            // 
            this.iconSplitButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconSplitButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconSplitButton1.IconColor = System.Drawing.Color.Black;
            this.iconSplitButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSplitButton1.IconSize = 48;
            this.iconSplitButton1.Name = "iconSplitButton1";
            this.iconSplitButton1.Rotation = 0D;
            this.iconSplitButton1.Size = new System.Drawing.Size(23, 23);
            this.iconSplitButton1.Text = "iconSplitButton1";
            // 
            // Themnhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 690);
            this.Controls.Add(this.paneltop);
            this.Controls.Add(this.panelfill);
            this.Controls.Add(this.panelbottom);
            this.Name = "Themnhanvien";
            this.Text = "Themnhanvien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Themnhanvien_Load);
            this.gbthemnv.ResumeLayout(false);
            this.gbthemnv.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.panelfill.ResumeLayout(false);
            this.panelfill.PerformLayout();
            this.gbcongviec.ResumeLayout(false);
            this.gbcongviec.PerformLayout();
            this.paneltop.ResumeLayout(false);
            this.paneltop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbthemnv;
        private System.Windows.Forms.Label lbngaysinh;
        private System.Windows.Forms.Label lbgioitinh;
        private System.Windows.Forms.Label lbhoten;
        private System.Windows.Forms.Label lbmanv;
        private System.Windows.Forms.Label lbdiachi;
        private System.Windows.Forms.Label lbemail;
        private System.Windows.Forms.Label lbsdt;
        private System.Windows.Forms.Panel panelfill;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel paneltop;
        private System.Windows.Forms.Label lbchucdanh;
        private System.Windows.Forms.Label lbchinhanh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbphongban;
        private System.Windows.Forms.Label lbngaybatdau;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbghichu;
        private System.Windows.Forms.Label lbluong;
        private System.Windows.Forms.Label lbtrangthai;
        public System.Windows.Forms.TextBox txtemail;
        public System.Windows.Forms.TextBox txtsdt;
        public System.Windows.Forms.DateTimePicker datengaysinh;
        public System.Windows.Forms.ComboBox cbgioitinh;
        public System.Windows.Forms.TextBox txthoten;
        public System.Windows.Forms.TextBox txtmanv;
        public System.Windows.Forms.TextBox txtdiachi;
        public System.Windows.Forms.DateTimePicker datebatdau;
        public System.Windows.Forms.ComboBox cbchucdanh;
        public System.Windows.Forms.ComboBox cbchinhanh;
        public System.Windows.Forms.ComboBox cbphongban;
        public System.Windows.Forms.RichTextBox tboxghichu;
        public System.Windows.Forms.TextBox txtluong;
        public System.Windows.Forms.ComboBox cbtrangthai;
        public System.Windows.Forms.GroupBox gbthemnv;
        public System.Windows.Forms.Button btnboqua;
        public FontAwesome.Sharp.IconButton ibtnluu;
        public System.Windows.Forms.Panel panelbottom;
        public System.Windows.Forms.GroupBox gbcongviec;
    }
}