namespace Quản_Lí_Kho_Vật_Tư
{
    partial class FileExcecl_KH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lbTenFile = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChonTep = new FontAwesome.Sharp.IconButton();
            this.btnDowload = new FontAwesome.Sharp.IconButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNhap);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.lbTenFile);
            this.groupBox1.Controls.Add(this.btnChonTep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDowload);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 350);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(491, 284);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(132, 48);
            this.btnNhap.TabIndex = 11;
            this.btnNhap.Text = "Nhập dữ liệu";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(366, 284);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(104, 48);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lbTenFile
            // 
            this.lbTenFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbTenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F);
            this.lbTenFile.Location = new System.Drawing.Point(320, 210);
            this.lbTenFile.Name = "lbTenFile";
            this.lbTenFile.Size = new System.Drawing.Size(202, 37);
            this.lbTenFile.TabIndex = 9;
            this.lbTenFile.Text = "Không có file nào được chọn";
            this.lbTenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Cursor = System.Windows.Forms.Cursors.No;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(231, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tải file lên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Location = new System.Drawing.Point(170, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(170, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Cursor = System.Windows.Forms.Cursors.No;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(231, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tải dữ liệu mẫu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChonTep
            // 
            this.btnChonTep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F);
            this.btnChonTep.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnChonTep.IconColor = System.Drawing.Color.Black;
            this.btnChonTep.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnChonTep.Location = new System.Drawing.Point(235, 210);
            this.btnChonTep.Name = "btnChonTep";
            this.btnChonTep.Size = new System.Drawing.Size(79, 37);
            this.btnChonTep.TabIndex = 8;
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
            this.btnDowload.Location = new System.Drawing.Point(235, 85);
            this.btnDowload.Name = "btnDowload";
            this.btnDowload.Size = new System.Drawing.Size(170, 51);
            this.btnDowload.TabIndex = 4;
            this.btnDowload.Text = "Tải xuống";
            this.btnDowload.UseVisualStyleBackColor = true;
            this.btnDowload.Click += new System.EventHandler(this.btnDowload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FileExcecl_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 369);
            this.Controls.Add(this.groupBox1);
            this.Name = "FileExcecl_KH";
            this.Text = "FileExcecl_KH";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lbTenFile;
        private FontAwesome.Sharp.IconButton btnChonTep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnDowload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}