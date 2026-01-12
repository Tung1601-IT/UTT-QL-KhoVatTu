namespace Quản_Lí_Kho_Vật_Tư
{
    partial class Chitiet_hoadon
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
            this.dgvCThoadon = new System.Windows.Forms.DataGridView();
            this.btnDong = new FontAwesome.Sharp.IconButton();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblNhanvien = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ql_vattuDataSet1 = new Quản_Lí_Kho_Vật_Tư.ql_vattuDataSet1();
            this.phieunhapCTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phieunhap_CTTableAdapter = new Quản_Lí_Kho_Vật_Tư.ql_vattuDataSet1TableAdapters.Phieunhap_CTTableAdapter();
            this.MaVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenvattu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doitac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuat = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCThoadon)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_vattuDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieunhapCTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCThoadon
            // 
            this.dgvCThoadon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCThoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCThoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVT,
            this.Tenvattu,
            this.Doitac,
            this.SoLuong,
            this.GiaNhap,
            this.ThanhTien});
            this.dgvCThoadon.Location = new System.Drawing.Point(9, 124);
            this.dgvCThoadon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCThoadon.Name = "dgvCThoadon";
            this.dgvCThoadon.RowHeadersWidth = 51;
            this.dgvCThoadon.RowTemplate.Height = 24;
            this.dgvCThoadon.Size = new System.Drawing.Size(791, 251);
            this.dgvCThoadon.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDong.IconColor = System.Drawing.Color.Black;
            this.btnDong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDong.Location = new System.Drawing.Point(432, 398);
            this.btnDong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(96, 39);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lblMaHD
            // 
            this.lblMaHD.Location = new System.Drawing.Point(104, 33);
            this.lblMaHD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(171, 13);
            this.lblMaHD.TabIndex = 2;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.Location = new System.Drawing.Point(348, 33);
            this.lblNgayTao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(171, 13);
            this.lblNgayTao.TabIndex = 3;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(348, 73);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(171, 12);
            this.lblTongTien.TabIndex = 4;
            // 
            // lblNhanvien
            // 
            this.lblNhanvien.Location = new System.Drawing.Point(104, 73);
            this.lblNhanvien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNhanvien.Name = "lblNhanvien";
            this.lblNhanvien.Size = new System.Drawing.Size(171, 13);
            this.lblNhanvien.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblTongTien);
            this.groupBox1.Controls.Add(this.lblNhanvien);
            this.groupBox1.Controls.Add(this.lblNgayTao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblMaHD);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(791, 109);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày tạo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn: ";
            // 
            // ql_vattuDataSet1
            // 
            this.ql_vattuDataSet1.DataSetName = "ql_vattuDataSet1";
            this.ql_vattuDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phieunhapCTBindingSource
            // 
            this.phieunhapCTBindingSource.DataMember = "Phieunhap_CT";
            this.phieunhapCTBindingSource.DataSource = this.ql_vattuDataSet1;
            // 
            // phieunhap_CTTableAdapter
            // 
            this.phieunhap_CTTableAdapter.ClearBeforeFill = true;
            // 
            // MaVT
            // 
            this.MaVT.DataPropertyName = "MaVT";
            this.MaVT.HeaderText = "Mã vật tư";
            this.MaVT.Name = "MaVT";
            // 
            // Tenvattu
            // 
            this.Tenvattu.DataPropertyName = "Tenvattu";
            this.Tenvattu.HeaderText = "Tên vật tư";
            this.Tenvattu.Name = "Tenvattu";
            // 
            // Doitac
            // 
            this.Doitac.DataPropertyName = "Doitac";
            this.Doitac.HeaderText = "Đối tác";
            this.Doitac.Name = "Doitac";
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            // 
            // GiaNhap
            // 
            this.GiaNhap.DataPropertyName = "GiaNhap";
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.Name = "GiaNhap";
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            // 
            // btnXuat
            // 
            this.btnXuat.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnXuat.IconColor = System.Drawing.Color.Black;
            this.btnXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuat.Location = new System.Drawing.Point(295, 396);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(118, 41);
            this.btnXuat.TabIndex = 15;
            this.btnXuat.Text = "Xuất excel";
            this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // Chitiet_hoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 447);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvCThoadon);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Chitiet_hoadon";
            this.Text = "Chitiet_hoadon";
            this.Load += new System.EventHandler(this.Chitiet_hoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCThoadon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ql_vattuDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieunhapCTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCThoadon;
        private FontAwesome.Sharp.IconButton btnDong;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblNhanvien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ql_vattuDataSet1 ql_vattuDataSet1;
        private System.Windows.Forms.BindingSource phieunhapCTBindingSource;
        private ql_vattuDataSet1TableAdapters.Phieunhap_CTTableAdapter phieunhap_CTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenvattu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doitac;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private FontAwesome.Sharp.IconButton btnXuat;
    }
}