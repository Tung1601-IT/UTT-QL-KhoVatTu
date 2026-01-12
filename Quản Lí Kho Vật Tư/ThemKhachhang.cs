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
    public partial class ThemKhachhang : Form
    {
        public ThemKhachhang()
        {
            InitializeComponent();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH.Text.Trim();
            string ht = txtTenKH.Text.Trim();
            string gt;
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string tt;
            string dc = txtDiachi.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            if (cboGioitinh.SelectedItem == null)
                gt = "";
            else
                gt = cboGioitinh.SelectedItem.ToString();

            if (cboTrangthai.SelectedItem == null)
                tt = "";
            else
                tt = cboTrangthai.SelectedItem.ToString();

            if (Thuvien.checkTrong(mkh))
            {
                txtMaKH.Focus();
                lbMaKH.Text = "Mã khách hàng không được để trống";
                lbMaKH.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(ht))
            {
                txtTenKH.Focus();
                lbTenKH.Text = "Tên khách hàng không được để trống";
                lbTenKH.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(gt))
            {
                cboGioitinh.Focus();
                lbGioitinh.Text = "Giới tính không được để trống";
                lbGioitinh.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dt))
            {
                txtSDT.Focus();
                lbSDT.Text = "Số điện thoại không được để trống";
                lbSDT.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(mail))
            {
                txtEmail.Focus();
                lbEmail.Text = "Email không được để trống";
                lbEmail.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(tt))
            {
                cboTrangthai.Focus();
                lbTrangthai.Text = "Trạng thái không được để trống";
                lbTrangthai.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dc))
            {
                txtDiachi.Focus();
                lbDiachi.Text = "Địa chỉ không được để trống";
                lbDiachi.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(cccd))
            {
                txtCCCD.Focus();
                lbCCCD.Text = "CCCD không được để trống";
                lbCCCD.ForeColor = Color.Red;
                return;
            }

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            //B3: Tạo đối tượng command để thực thi câu lệnh sql
            string sql = "Insert Khachhang values(@mkh,@ht,@gt,@dt,@mail,@tt,@dc,@cccd)";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@mkh", SqlDbType.NVarChar, 50).Value = mkh;
            cmd.Parameters.Add("@ht", SqlDbType.NVarChar, 50).Value = ht;
            cmd.Parameters.Add("@gt", SqlDbType.NVarChar, 50).Value = gt;
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 10).Value = dt;
            cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = mail;
            cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 100).Value = tt;
            cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 50).Value = dc;
            cmd.Parameters.Add("@cccd", SqlDbType.NVarChar, 100).Value = cccd;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Thuvien.con.Close();
            MessageBox.Show("Thêm mới thành công");
            var f = Application.OpenForms["Doitac_Khachhang"] as Doitac_Khachhang;
            if (f != null)
                Thuvien.load_KH(f.DgvKH, "Select * from Khachhang");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "Makhachhang", makh))
            {
                lbMaKH.Text = "Mã khách hàng đã tồn tại";
                lbMaKH.ForeColor = Color.Red;
            }
            else
            {
                lbMaKH.Text = "";
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "SDT", sdt))
            {
                lbSDT.Text = "Số điện thoại đã tồn tại";
                lbSDT.ForeColor = Color.Red;
            }
            else
            {
                lbSDT.Text = "";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string mail = txtEmail.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "Email", mail))
            {
                lbEmail.Text = "Email đã tồn tại";
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.Text = "";
            }
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "CCCD", cccd))
            {
                lbCCCD.Text = "CCCD đã tồn tại";
                lbCCCD.ForeColor = Color.Red;
            }
            else
            {
                lbCCCD.Text = "";
            }
        }
    }
}
