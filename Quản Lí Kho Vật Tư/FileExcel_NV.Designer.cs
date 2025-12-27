namespace Quản_Lí_Kho_Vật_Tư
{
    partial class FileExcel_NV
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTenFile = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnNhap = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChonTep = new FontAwesome.Sharp.IconButton();
            this.btnDowload = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb1.Location = new System.Drawing.Point(184, 94);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(23, 25);
            this.lb1.TabIndex = 1;
            this.lb1.Text = "1";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb2.Location = new System.Drawing.Point(184, 198);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(23, 25);
            this.lb2.TabIndex = 2;
            this.lb2.Text = "2";
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb3.Location = new System.Drawing.Point(251, 94);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(0, 25);
            this.lb3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Cursor = System.Windows.Forms.Cursors.No;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(234, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tải dữ liệu mẫu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(234, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 30);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tải file lên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTenFile
            // 
            this.lbTenFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F);
            this.lbTenFile.Location = new System.Drawing.Point(326, 243);
            this.lbTenFile.Name = "lbTenFile";
            this.lbTenFile.Size = new System.Drawing.Size(202, 37);
            this.lbTenFile.TabIndex = 10;
            this.lbTenFile.Text = "Không có file nào được chọn";
            this.lbTenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(437, 347);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 48);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(572, 347);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(132, 48);
            this.btnNhap.TabIndex = 13;
            this.btnNhap.Text = "Nhập dữ liệu";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChonTep
            // 
            this.btnChonTep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F);
            this.btnChonTep.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnChonTep.IconColor = System.Drawing.Color.Black;
            this.btnChonTep.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChonTep.Location = new System.Drawing.Point(241, 243);
            this.btnChonTep.Name = "btnChonTep";
            this.btnChonTep.Size = new System.Drawing.Size(79, 37);
            this.btnChonTep.TabIndex = 11;
            this.btnChonTep.Text = "Chọn tệp";
            this.btnChonTep.UseVisualStyleBackColor = true;
            this.btnChonTep.Click += new System.EventHandler(this.btnChonTep_Click);
            // 
            // btnDowload
            // 
            this.btnDowload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDowload.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDowload.IconColor = System.Drawing.Color.Black;
            this.btnDowload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDowload.IconSize = 30;
            this.btnDowload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDowload.Location = new System.Drawing.Point(256, 137);
            this.btnDowload.Name = "btnDowload";
            this.btnDowload.Size = new System.Drawing.Size(145, 36);
            this.btnDowload.TabIndex = 9;
            this.btnDowload.Text = "Tải xuống";
            this.btnDowload.UseVisualStyleBackColor = true;
            this.btnDowload.Click += new System.EventHandler(this.btnDowload_Click);
            // 
            // FileExcel_NV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnChonTep);
            this.Controls.Add(this.lbTenFile);
            this.Controls.Add(this.btnDowload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.label1);
            this.Name = "FileExcel_NV";
            this.Text = "FileExcel_NV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnDowload;
        private System.Windows.Forms.Label lbTenFile;
        private FontAwesome.Sharp.IconButton btnChonTep;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}