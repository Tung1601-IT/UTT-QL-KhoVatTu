namespace Quản_Lí_Kho_Vật_Tư
{
    partial class Lichlamviec
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ngay = new System.Windows.Forms.DateTimePicker();
            this.ca = new System.Windows.Forms.ComboBox();
            this.nhanvien = new System.Windows.Forms.ComboBox();
            this.xoa = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.them = new System.Windows.Forms.Button();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ngaytk = new System.Windows.Forms.DateTimePicker();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.thongke = new System.Windows.Forms.Button();
            this.thoat = new System.Windows.Forms.Button();
            this.timkiem = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.xuat = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bÁNHÀNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đỐITÁCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sẢNPHẢMDỊCHVỤToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUẢNLÍKHOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUẢNLÍTHUCHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bÁOCÁOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nHÂNVIÊNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchLàmViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(49, 250);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(843, 328);
            this.dgv.TabIndex = 2;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ngay);
            this.groupBox1.Controls.Add(this.ca);
            this.groupBox1.Controls.Add(this.nhanvien);
            this.groupBox1.Controls.Add(this.xoa);
            this.groupBox1.Controls.Add(this.sua);
            this.groupBox1.Controls.Add(this.them);
            this.groupBox1.Controls.Add(this.ghichu);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(916, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 458);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // ngay
            // 
            this.ngay.Location = new System.Drawing.Point(161, 117);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(208, 27);
            this.ngay.TabIndex = 13;
            // 
            // ca
            // 
            this.ca.FormattingEnabled = true;
            this.ca.Items.AddRange(new object[] {
            "Ca sáng",
            "Ca chiều",
            "Ca tối"});
            this.ca.Location = new System.Drawing.Point(161, 185);
            this.ca.Name = "ca";
            this.ca.Size = new System.Drawing.Size(208, 28);
            this.ca.TabIndex = 12;
            this.ca.Text = " Chọn ca";
            // 
            // nhanvien
            // 
            this.nhanvien.FormattingEnabled = true;
            this.nhanvien.Location = new System.Drawing.Point(161, 48);
            this.nhanvien.Name = "nhanvien";
            this.nhanvien.Size = new System.Drawing.Size(208, 28);
            this.nhanvien.TabIndex = 11;
            this.nhanvien.Text = "Chọn nhân viên";
            // 
            // xoa
            // 
            this.xoa.AutoSize = true;
            this.xoa.BackColor = System.Drawing.Color.Gray;
            this.xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.ForeColor = System.Drawing.Color.Bisque;
            this.xoa.Location = new System.Drawing.Point(280, 343);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(89, 44);
            this.xoa.TabIndex = 10;
            this.xoa.Text = "Xóa";
            this.xoa.UseVisualStyleBackColor = false;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // sua
            // 
            this.sua.AutoSize = true;
            this.sua.BackColor = System.Drawing.Color.Gray;
            this.sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sua.ForeColor = System.Drawing.Color.Bisque;
            this.sua.Location = new System.Drawing.Point(161, 343);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(89, 44);
            this.sua.TabIndex = 9;
            this.sua.Text = "Sửa ";
            this.sua.UseVisualStyleBackColor = false;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // them
            // 
            this.them.AutoSize = true;
            this.them.BackColor = System.Drawing.Color.Gray;
            this.them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.them.ForeColor = System.Drawing.Color.Bisque;
            this.them.Location = new System.Drawing.Point(35, 343);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(89, 44);
            this.them.TabIndex = 8;
            this.them.Text = "Thêm";
            this.them.UseVisualStyleBackColor = false;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // ghichu
            // 
            this.ghichu.Location = new System.Drawing.Point(161, 261);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(208, 27);
            this.ghichu.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(9, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(9, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ca ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(9, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi chú";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhân viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ngaytk);
            this.groupBox2.Controls.Add(this.txttimkiem);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(49, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 104);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ngày";
            // 
            // ngaytk
            // 
            this.ngaytk.Location = new System.Drawing.Point(241, 70);
            this.ngaytk.Name = "ngaytk";
            this.ngaytk.ShowCheckBox = true;
            this.ngaytk.Size = new System.Drawing.Size(268, 27);
            this.ngaytk.TabIndex = 15;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(241, 25);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(268, 27);
            this.txttimkiem.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã nhân viên";
            // 
            // thongke
            // 
            this.thongke.AutoSize = true;
            this.thongke.BackColor = System.Drawing.Color.Gray;
            this.thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thongke.ForeColor = System.Drawing.Color.Bisque;
            this.thongke.Location = new System.Drawing.Point(951, 111);
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(89, 44);
            this.thongke.TabIndex = 13;
            this.thongke.Text = "Thống kê";
            this.thongke.UseVisualStyleBackColor = false;
            this.thongke.Click += new System.EventHandler(this.thongke_Click);
            // 
            // thoat
            // 
            this.thoat.AutoSize = true;
            this.thoat.BackColor = System.Drawing.Color.Gray;
            this.thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoat.ForeColor = System.Drawing.Color.Bisque;
            this.thoat.Location = new System.Drawing.Point(1197, 111);
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(89, 44);
            this.thoat.TabIndex = 14;
            this.thoat.Text = "Thoát";
            this.thoat.UseVisualStyleBackColor = false;
            this.thoat.Click += new System.EventHandler(this.thoat_Click);
            // 
            // timkiem
            // 
            this.timkiem.AutoSize = true;
            this.timkiem.BackColor = System.Drawing.Color.Gray;
            this.timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Bisque;
            this.timkiem.Location = new System.Drawing.Point(626, 128);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(122, 44);
            this.timkiem.TabIndex = 15;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.UseVisualStyleBackColor = false;
            this.timkiem.Click += new System.EventHandler(this.timkiem_Click);
            // 
            // button7
            // 
            this.button7.AutoSize = true;
            this.button7.BackColor = System.Drawing.Color.Gray;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Bisque;
            this.button7.Location = new System.Drawing.Point(626, 183);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(122, 44);
            this.button7.TabIndex = 16;
            this.button7.Text = "Hiển thị tất cả";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // xuat
            // 
            this.xuat.AutoSize = true;
            this.xuat.BackColor = System.Drawing.Color.Gray;
            this.xuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuat.ForeColor = System.Drawing.Color.Bisque;
            this.xuat.Location = new System.Drawing.Point(1077, 111);
            this.xuat.Name = "xuat";
            this.xuat.Size = new System.Drawing.Size(96, 44);
            this.xuat.TabIndex = 17;
            this.xuat.Text = "Xuất file";
            this.xuat.UseVisualStyleBackColor = false;
            this.xuat.Click += new System.EventHandler(this.xuat_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iMSToolStripMenuItem,
            this.bÁNHÀNGToolStripMenuItem,
            this.đỐITÁCToolStripMenuItem,
            this.sẢNPHẢMDỊCHVỤToolStripMenuItem,
            this.qUẢNLÍKHOToolStripMenuItem,
            this.qUẢNLÍTHUCHIToolStripMenuItem,
            this.bÁOCÁOToolStripMenuItem,
            this.nHÂNVIÊNToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1298, 54);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iMSToolStripMenuItem
            // 
            this.iMSToolStripMenuItem.AutoSize = false;
            this.iMSToolStripMenuItem.Name = "iMSToolStripMenuItem";
            this.iMSToolStripMenuItem.Size = new System.Drawing.Size(100, 50);
            this.iMSToolStripMenuItem.Text = "IMS";
            // 
            // bÁNHÀNGToolStripMenuItem
            // 
            this.bÁNHÀNGToolStripMenuItem.Name = "bÁNHÀNGToolStripMenuItem";
            this.bÁNHÀNGToolStripMenuItem.Size = new System.Drawing.Size(109, 50);
            this.bÁNHÀNGToolStripMenuItem.Text = "TỔNG QUAN";
            this.bÁNHÀNGToolStripMenuItem.Click += new System.EventHandler(this.bÁNHÀNGToolStripMenuItem_Click);
            // 
            // đỐITÁCToolStripMenuItem
            // 
            this.đỐITÁCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem,
            this.nhàCungToolStripMenuItem});
            this.đỐITÁCToolStripMenuItem.Name = "đỐITÁCToolStripMenuItem";
            this.đỐITÁCToolStripMenuItem.Size = new System.Drawing.Size(79, 50);
            this.đỐITÁCToolStripMenuItem.Text = "ĐỐI TÁC";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // nhàCungToolStripMenuItem
            // 
            this.nhàCungToolStripMenuItem.Name = "nhàCungToolStripMenuItem";
            this.nhàCungToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.nhàCungToolStripMenuItem.Text = "Nhà cung cấp-Đại lý";
            this.nhàCungToolStripMenuItem.Click += new System.EventHandler(this.nhàCungToolStripMenuItem_Click);
            // 
            // sẢNPHẢMDỊCHVỤToolStripMenuItem
            // 
            this.sẢNPHẢMDỊCHVỤToolStripMenuItem.Name = "sẢNPHẢMDỊCHVỤToolStripMenuItem";
            this.sẢNPHẢMDỊCHVỤToolStripMenuItem.Size = new System.Drawing.Size(162, 50);
            this.sẢNPHẢMDỊCHVỤToolStripMenuItem.Text = "SẢN PHẢM-DỊCH VỤ";
            this.sẢNPHẢMDỊCHVỤToolStripMenuItem.Click += new System.EventHandler(this.sẢNPHẢMDỊCHVỤToolStripMenuItem_Click);
            // 
            // qUẢNLÍKHOToolStripMenuItem
            // 
            this.qUẢNLÍKHOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tồnKhoToolStripMenuItem,
            this.nhậpKhoToolStripMenuItem,
            this.xuấtKhoToolStripMenuItem});
            this.qUẢNLÍKHOToolStripMenuItem.Name = "qUẢNLÍKHOToolStripMenuItem";
            this.qUẢNLÍKHOToolStripMenuItem.Size = new System.Drawing.Size(115, 50);
            this.qUẢNLÍKHOToolStripMenuItem.Text = "QUẢN LÍ KHO";
            // 
            // tồnKhoToolStripMenuItem
            // 
            this.tồnKhoToolStripMenuItem.Name = "tồnKhoToolStripMenuItem";
            this.tồnKhoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tồnKhoToolStripMenuItem.Text = "TỒN KHO";
            this.tồnKhoToolStripMenuItem.Click += new System.EventHandler(this.tồnKhoToolStripMenuItem_Click);
            // 
            // nhậpKhoToolStripMenuItem
            // 
            this.nhậpKhoToolStripMenuItem.Name = "nhậpKhoToolStripMenuItem";
            this.nhậpKhoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhậpKhoToolStripMenuItem.Text = "NHẬP KHO";
            this.nhậpKhoToolStripMenuItem.Click += new System.EventHandler(this.nhậpKhoToolStripMenuItem_Click);
            // 
            // xuấtKhoToolStripMenuItem
            // 
            this.xuấtKhoToolStripMenuItem.Name = "xuấtKhoToolStripMenuItem";
            this.xuấtKhoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xuấtKhoToolStripMenuItem.Text = "XUẤT KHO";
            this.xuấtKhoToolStripMenuItem.Click += new System.EventHandler(this.xuấtKhoToolStripMenuItem_Click);
            // 
            // qUẢNLÍTHUCHIToolStripMenuItem
            // 
            this.qUẢNLÍTHUCHIToolStripMenuItem.Name = "qUẢNLÍTHUCHIToolStripMenuItem";
            this.qUẢNLÍTHUCHIToolStripMenuItem.Size = new System.Drawing.Size(141, 50);
            this.qUẢNLÍTHUCHIToolStripMenuItem.Text = "QUẢN LÍ THU CHI";
            this.qUẢNLÍTHUCHIToolStripMenuItem.Click += new System.EventHandler(this.qUẢNLÍTHUCHIToolStripMenuItem_Click);
            // 
            // bÁOCÁOToolStripMenuItem
            // 
            this.bÁOCÁOToolStripMenuItem.Name = "bÁOCÁOToolStripMenuItem";
            this.bÁOCÁOToolStripMenuItem.Size = new System.Drawing.Size(87, 50);
            this.bÁOCÁOToolStripMenuItem.Text = "BÁO CÁO";
            // 
            // nHÂNVIÊNToolStripMenuItem
            // 
            this.nHÂNVIÊNToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchNhânViênToolStripMenuItem,
            this.lịchLàmViệcToolStripMenuItem});
            this.nHÂNVIÊNToolStripMenuItem.Name = "nHÂNVIÊNToolStripMenuItem";
            this.nHÂNVIÊNToolStripMenuItem.Size = new System.Drawing.Size(102, 50);
            this.nHÂNVIÊNToolStripMenuItem.Text = "NHÂN VIÊN";
            // 
            // danhSáchNhânViênToolStripMenuItem
            // 
            this.danhSáchNhânViênToolStripMenuItem.Name = "danhSáchNhânViênToolStripMenuItem";
            this.danhSáchNhânViênToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.danhSáchNhânViênToolStripMenuItem.Text = "Danh sách nhân viên";
            this.danhSáchNhânViênToolStripMenuItem.Click += new System.EventHandler(this.danhSáchNhânViênToolStripMenuItem_Click);
            // 
            // lịchLàmViệcToolStripMenuItem
            // 
            this.lịchLàmViệcToolStripMenuItem.Name = "lịchLàmViệcToolStripMenuItem";
            this.lịchLàmViệcToolStripMenuItem.Size = new System.Drawing.Size(227, 26);
            this.lịchLàmViệcToolStripMenuItem.Text = "Lịch làm việc";
            // 
            // Lichlamviec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 684);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.xuat);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.thoat);
            this.Controls.Add(this.thongke);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Name = "Lichlamviec";
            this.Text = "Lichlamviec";
            this.Load += new System.EventHandler(this.Lichlamviec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox nhanvien;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.TextBox ghichu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button thongke;
        private System.Windows.Forms.Button thoat;
        private System.Windows.Forms.ComboBox ca;
        private System.Windows.Forms.DateTimePicker ngay;
        private System.Windows.Forms.DateTimePicker ngaytk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button timkiem;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button xuat;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bÁNHÀNGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đỐITÁCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sẢNPHẢMDỊCHVỤToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUẢNLÍKHOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUẢNLÍTHUCHIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bÁOCÁOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nHÂNVIÊNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchLàmViệcToolStripMenuItem;
    }
}