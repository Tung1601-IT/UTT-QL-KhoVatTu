using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Dangnhap : Form
    {

        public static string TenNhanVien = "";
        
        public Dangnhap()
        {
            InitializeComponent();
        }

        private void linkDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dk = new Dangky();
            dk.Show();
            this.Hide();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (Thuvien.checkTrong(txtTaikhoan.Text.Trim()))
            {
                txtTaikhoan.Focus();
                lbTaikhoan.Text = "Tài khoản không được để trống";
                lbTaikhoan.ForeColor = Color.Red;
                return;
            }

            if (Thuvien.checkTrong(txtMatkhau.Text.Trim()))
            {
                txtMatkhau.Focus();
                lbMatkhau.Text = "Mật khẩu không được để trống";
                lbMatkhau.ForeColor = Color.Red;
                return;
            }

            string tk = txtTaikhoan.Text.Trim();
            string mk = txtMatkhau.Text.Trim();
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = "Select * from Taikhoan where Taikhoan='" + tk + "' and Matkhau='" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            SqlDataReader kq = cmd.ExecuteReader();
            if (kq.Read())
            {

                TenNhanVien = kq["Hoten"].ToString(); // tên cột trong DB
                


                this.Hide();   

                    Tongquan f = new Tongquan();

                    // Khi Form mới đóng → đóng Trang chủ
                    f.FormClosed += (s, args) =>
                    {
                        this.Close();
                    };

                    f.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Thuvien.con.Close();
        }
        

        private void ckHienthimk_CheckedChanged(object sender, EventArgs e)
        {
            txtMatkhau.UseSystemPasswordChar = !ckHienthimk.Checked;
        }

        
    }
}
