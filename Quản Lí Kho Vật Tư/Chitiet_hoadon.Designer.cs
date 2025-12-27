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
            this.dgvCThoadon = new System.Windows.Forms.DataGridView();
            this.btnDong = new FontAwesome.Sharp.IconButton();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblLoaiHD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCThoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCThoadon
            // 
            this.dgvCThoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCThoadon.Location = new System.Drawing.Point(123, 102);
            this.dgvCThoadon.Name = "dgvCThoadon";
            this.dgvCThoadon.RowHeadersWidth = 51;
            this.dgvCThoadon.RowTemplate.Height = 24;
            this.dgvCThoadon.Size = new System.Drawing.Size(779, 309);
            this.dgvCThoadon.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDong.IconColor = System.Drawing.Color.Black;
            this.btnDong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDong.Location = new System.Drawing.Point(798, 426);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(104, 48);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // lblMaHD
            // 
            this.lblMaHD.Location = new System.Drawing.Point(165, 20);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(228, 31);
            this.lblMaHD.TabIndex = 2;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.Location = new System.Drawing.Point(447, 20);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(228, 31);
            this.lblNgayTao.TabIndex = 3;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(447, 68);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(228, 31);
            this.lblTongTien.TabIndex = 4;
            // 
            // lblLoaiHD
            // 
            this.lblLoaiHD.Location = new System.Drawing.Point(165, 68);
            this.lblLoaiHD.Name = "lblLoaiHD";
            this.lblLoaiHD.Size = new System.Drawing.Size(228, 31);
            this.lblLoaiHD.TabIndex = 5;
            // 
            // Chitiet_hoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 513);
            this.Controls.Add(this.lblLoaiHD);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblNgayTao);
            this.Controls.Add(this.lblMaHD);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvCThoadon);
            this.Name = "Chitiet_hoadon";
            this.Text = "Chitiet_hoadon";
            this.Load += new System.EventHandler(this.Chitiet_hoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCThoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCThoadon;
        private FontAwesome.Sharp.IconButton btnDong;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblLoaiHD;
    }
}