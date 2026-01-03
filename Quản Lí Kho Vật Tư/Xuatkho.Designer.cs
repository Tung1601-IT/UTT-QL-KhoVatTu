namespace Quản_Lí_Kho_Vật_Tư
{
    partial class Xuatkho
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_xXoa = new System.Windows.Forms.Button();
            this.btn_xSua = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.xNhacc = new System.Windows.Forms.ComboBox();
            this.btnLuuxuat = new System.Windows.Forms.Button();
            this.xNhapthem = new System.Windows.Forms.Button();
            this.xTongtien = new System.Windows.Forms.TextBox();
            this.dgvXuatkho = new System.Windows.Forms.DataGridView();
            this.xThanhtien = new System.Windows.Forms.TextBox();
            this.xSoluong = new System.Windows.Forms.TextBox();
            this.xDonvt = new System.Windows.Forms.TextBox();
            this.xKhachhang = new System.Windows.Forms.ComboBox();
            this.xGiaban = new System.Windows.Forms.TextBox();
            this.xLoaivt = new System.Windows.Forms.TextBox();
            this.xTenvt = new System.Windows.Forms.ComboBox();
            this.xMavt = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatkho)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_xXoa);
            this.groupBox4.Controls.Add(this.btn_xSua);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.xNhacc);
            this.groupBox4.Controls.Add(this.btnLuuxuat);
            this.groupBox4.Controls.Add(this.xNhapthem);
            this.groupBox4.Controls.Add(this.xTongtien);
            this.groupBox4.Controls.Add(this.dgvXuatkho);
            this.groupBox4.Controls.Add(this.xThanhtien);
            this.groupBox4.Controls.Add(this.xSoluong);
            this.groupBox4.Controls.Add(this.xDonvt);
            this.groupBox4.Controls.Add(this.xKhachhang);
            this.groupBox4.Controls.Add(this.xGiaban);
            this.groupBox4.Controls.Add(this.xLoaivt);
            this.groupBox4.Controls.Add(this.xTenvt);
            this.groupBox4.Controls.Add(this.xMavt);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Location = new System.Drawing.Point(34, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(733, 422);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Xuất vật tư";
            // 
            // btn_xXoa
            // 
            this.btn_xXoa.Location = new System.Drawing.Point(585, 159);
            this.btn_xXoa.Name = "btn_xXoa";
            this.btn_xXoa.Size = new System.Drawing.Size(75, 23);
            this.btn_xXoa.TabIndex = 55;
            this.btn_xXoa.Text = "Xóa";
            this.btn_xXoa.UseVisualStyleBackColor = true;
            this.btn_xXoa.Click += new System.EventHandler(this.btn_xXoa_Click);
            // 
            // btn_xSua
            // 
            this.btn_xSua.Location = new System.Drawing.Point(585, 123);
            this.btn_xSua.Name = "btn_xSua";
            this.btn_xSua.Size = new System.Drawing.Size(75, 23);
            this.btn_xSua.TabIndex = 55;
            this.btn_xSua.Text = "Sửa";
            this.btn_xSua.UseVisualStyleBackColor = true;
            this.btn_xSua.Click += new System.EventHandler(this.btn_xSua_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Nhà cung cấp";
            // 
            // xNhacc
            // 
            this.xNhacc.FormattingEnabled = true;
            this.xNhacc.Location = new System.Drawing.Point(133, 158);
            this.xNhacc.Name = "xNhacc";
            this.xNhacc.Size = new System.Drawing.Size(121, 24);
            this.xNhacc.TabIndex = 53;
            this.xNhacc.SelectedIndexChanged += new System.EventHandler(this.xNhacc_SelectedIndexChanged);
            // 
            // btnLuuxuat
            // 
            this.btnLuuxuat.Location = new System.Drawing.Point(358, 344);
            this.btnLuuxuat.Name = "btnLuuxuat";
            this.btnLuuxuat.Size = new System.Drawing.Size(109, 23);
            this.btnLuuxuat.TabIndex = 53;
            this.btnLuuxuat.Text = "Xuất kho";
            this.btnLuuxuat.UseVisualStyleBackColor = true;
            this.btnLuuxuat.Click += new System.EventHandler(this.btnLuuxuat_Click);
            // 
            // xNhapthem
            // 
            this.xNhapthem.Location = new System.Drawing.Point(195, 344);
            this.xNhapthem.Name = "xNhapthem";
            this.xNhapthem.Size = new System.Drawing.Size(109, 23);
            this.xNhapthem.TabIndex = 53;
            this.xNhapthem.Text = "Nhập Thêm";
            this.xNhapthem.UseVisualStyleBackColor = true;
            this.xNhapthem.Click += new System.EventHandler(this.xNhapthem_Click);
            // 
            // xTongtien
            // 
            this.xTongtien.Location = new System.Drawing.Point(420, 160);
            this.xTongtien.Name = "xTongtien";
            this.xTongtien.Size = new System.Drawing.Size(121, 22);
            this.xTongtien.TabIndex = 53;
            // 
            // dgvXuatkho
            // 
            this.dgvXuatkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXuatkho.Location = new System.Drawing.Point(6, 188);
            this.dgvXuatkho.Name = "dgvXuatkho";
            this.dgvXuatkho.RowHeadersWidth = 51;
            this.dgvXuatkho.RowTemplate.Height = 24;
            this.dgvXuatkho.Size = new System.Drawing.Size(654, 150);
            this.dgvXuatkho.TabIndex = 53;
            this.dgvXuatkho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvXuatkho_CellClick);
            // 
            // xThanhtien
            // 
            this.xThanhtien.Location = new System.Drawing.Point(420, 123);
            this.xThanhtien.Name = "xThanhtien";
            this.xThanhtien.Size = new System.Drawing.Size(121, 22);
            this.xThanhtien.TabIndex = 53;
            // 
            // xSoluong
            // 
            this.xSoluong.Location = new System.Drawing.Point(420, 88);
            this.xSoluong.Name = "xSoluong";
            this.xSoluong.Size = new System.Drawing.Size(121, 22);
            this.xSoluong.TabIndex = 53;
            this.xSoluong.TextChanged += new System.EventHandler(this.txt_xSoluong_TextChanged);
            // 
            // xDonvt
            // 
            this.xDonvt.Location = new System.Drawing.Point(420, 52);
            this.xDonvt.Name = "xDonvt";
            this.xDonvt.Size = new System.Drawing.Size(121, 22);
            this.xDonvt.TabIndex = 53;
            // 
            // xKhachhang
            // 
            this.xKhachhang.FormattingEnabled = true;
            this.xKhachhang.Location = new System.Drawing.Point(420, 17);
            this.xKhachhang.Name = "xKhachhang";
            this.xKhachhang.Size = new System.Drawing.Size(121, 24);
            this.xKhachhang.TabIndex = 53;
            // 
            // xGiaban
            // 
            this.xGiaban.Location = new System.Drawing.Point(133, 123);
            this.xGiaban.Name = "xGiaban";
            this.xGiaban.Size = new System.Drawing.Size(121, 22);
            this.xGiaban.TabIndex = 53;
            // 
            // xLoaivt
            // 
            this.xLoaivt.Location = new System.Drawing.Point(133, 88);
            this.xLoaivt.Name = "xLoaivt";
            this.xLoaivt.Size = new System.Drawing.Size(121, 22);
            this.xLoaivt.TabIndex = 53;
            // 
            // xTenvt
            // 
            this.xTenvt.FormattingEnabled = true;
            this.xTenvt.Location = new System.Drawing.Point(133, 52);
            this.xTenvt.Name = "xTenvt";
            this.xTenvt.Size = new System.Drawing.Size(121, 24);
            this.xTenvt.TabIndex = 53;
            this.xTenvt.SelectedIndexChanged += new System.EventHandler(this.xTenvt_SelectedIndexChanged);
            // 
            // xMavt
            // 
            this.xMavt.Location = new System.Drawing.Point(133, 19);
            this.xMavt.Name = "xMavt";
            this.xMavt.Size = new System.Drawing.Size(121, 22);
            this.xMavt.TabIndex = 53;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(311, 163);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 16);
            this.label30.TabIndex = 53;
            this.label30.Text = "Tổng tiền";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(309, 129);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(69, 16);
            this.label29.TabIndex = 53;
            this.label29.Text = "Thành tiền";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(311, 94);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(60, 16);
            this.label28.TabIndex = 53;
            this.label28.Text = "Số lượng";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(311, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 16);
            this.label27.TabIndex = 53;
            this.label27.Text = "Đơn vị tính";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(311, 25);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 16);
            this.label26.TabIndex = 53;
            this.label26.Text = "Khách hàng";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(40, 129);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 16);
            this.label25.TabIndex = 53;
            this.label25.Text = "Giá bán";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(41, 94);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 16);
            this.label24.TabIndex = 53;
            this.label24.Text = "Loại vật tư";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(42, 60);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 16);
            this.label23.TabIndex = 53;
            this.label23.Text = "Tên vật tư";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(41, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 16);
            this.label22.TabIndex = 53;
            this.label22.Text = "Mã vật tư";
            // 
            // Xuatkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Name = "Xuatkho";
            this.Text = "Xuatkho";
            this.Load += new System.EventHandler(this.Xuatkho_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatkho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_xXoa;
        private System.Windows.Forms.Button btn_xSua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox xNhacc;
        private System.Windows.Forms.Button btnLuuxuat;
        private System.Windows.Forms.Button xNhapthem;
        private System.Windows.Forms.TextBox xTongtien;
        private System.Windows.Forms.DataGridView dgvXuatkho;
        private System.Windows.Forms.TextBox xThanhtien;
        private System.Windows.Forms.TextBox xSoluong;
        private System.Windows.Forms.TextBox xDonvt;
        private System.Windows.Forms.ComboBox xKhachhang;
        private System.Windows.Forms.TextBox xGiaban;
        private System.Windows.Forms.TextBox xLoaivt;
        private System.Windows.Forms.ComboBox xTenvt;
        private System.Windows.Forms.TextBox xMavt;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
    }
}