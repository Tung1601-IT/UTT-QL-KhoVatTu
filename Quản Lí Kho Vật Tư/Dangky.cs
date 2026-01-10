using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Dangky : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=ANHTU\\ANHTU;Initial Catalog=QL_KhoVatTu;User ID=sa;Password=Truong2022005!;Encrypt=True;TrustServerCertificate=True");
        public Dangky()
        {
            InitializeComponent();
        }
        public string txtGioitinh;
        private void ckGioitinh_CheckedChanged(object sender, EventArgs e)
        {
            if (ckGioitinh.Checked)
                txtGioitinh = "Nam";
            else
                txtGioitinh = "Nữ";
        }
        public bool checktrungtk(string taikhoan)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = "select count(*) from Taikhoan where Taikhoan=@tk";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.AddWithValue("@tk", taikhoan);
            int kq = (int)cmd.ExecuteScalar();
            if (kq > 0)
                return true;
            else
            {
                return false;
            }
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            if(checktrungtk(txtTaikhoan.Text.Trim()))
            {
                MessageBox.Show("Taì khoản đã tồn tại!");
                return;
            }
            if(string.IsNullOrWhiteSpace(txtTaikhoan.Text.Trim()))
            {
                MessageBox.Show("Không để trống tài khoản!");
                return;
            }    
            string sql = "insert into Taikhoan values (@ht,@tk,@mk,@ns,@gt,@dt,@email,@dc)";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@ht", SqlDbType.NVarChar, 50).Value = txtHoten.Text.Trim();
            cmd.Parameters.Add("@tk", SqlDbType.VarChar, 50).Value = txtTaikhoan.Text.Trim();
            cmd.Parameters.Add("@mk", SqlDbType.VarChar, 50).Value = txtMatkhau.Text.Trim();
            cmd.Parameters.Add("@ns", SqlDbType.Date).Value = txtNgaysinh.Value;
            cmd.Parameters.Add("@gt", SqlDbType.NVarChar, 50).Value = txtGioitinh.Trim();
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 15).Value = txtDienthoai.Text.Trim();
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 255).Value = txtEmail.Text.Trim();
            cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 255).Value = txtDiachi.Text.Trim();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đăng kí thành công");
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            Dangnhap frm=new Dangnhap();
            frm.Show();
            this.Close();
        }
    }
}
