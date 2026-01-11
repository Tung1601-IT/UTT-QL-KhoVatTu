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
    public partial class ThemDoitac : Form
    {
        public ThemDoitac()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string nhom;
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string ghichu = txtGhichu.Text.Trim();
            if (cboNhomdoitac.SelectedItem == null)
                nhom = "";
            else
                nhom = cboNhomdoitac.SelectedItem.ToString();
            if (Thuvien.checkTrong(mdt))
            {
                txtMadoitac.Focus();
                lbMadoitac.Text = "Mã đối tác không được để trống";
                lbMadoitac.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(ht))
            {
                txtTendoitac.Focus();
                lbTendoitac.Text = "Tên đối tác không được để trống";
                lbTendoitac.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(nhom))
            {
                cboNhomdoitac.Focus();
                lbNhomdoitac.Text = "Nhóm đối tác không được để trống";
                lbNhomdoitac.ForeColor = Color.Red;
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
            if (Thuvien.checkTrong(dc))
            {
                txtDiachi.Focus();
                lbDiachi.Text = "Địa chỉ không được để trống";
                lbDiachi.ForeColor = Color.Red;
                return;
            }
            if (!Thuvien.checkDienThoai(dt))
            {
                txtSDT.Focus();
                MessageBox.Show("Số điện thoại không đúng...");
                return;
            }
            if (!Thuvien.checkEmail(mail))
            {
                txtEmail.Focus();
                MessageBox.Show("Email không đúng...");
                return;
            }

            //B2:Kết nối DB

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            //B3: Tạo đối tượng command để thực thi câu lệnh sql
            string sql = "Insert Doitac_NCC values(@mdt,@ht,@nhom,@dt,@mail,@dc,@ghichu)";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@mdt", SqlDbType.NVarChar, 50).Value = mdt;
            cmd.Parameters.Add("@ht", SqlDbType.NVarChar, 50).Value = ht;
            cmd.Parameters.Add("@nhom", SqlDbType.NVarChar, 50).Value = nhom;
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 10).Value = dt;
            cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = mail;
            cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 50).Value = dc;
            cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 100).Value = ghichu;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Thuvien.con.Close();
            MessageBox.Show("Thêm mới thành công");
            var f = Application.OpenForms["Doitac_NCC"] as Doitac_NCC;
            if (f != null)
                Thuvien.load_KH(f.DgvNCC, "Select * from Doitac_NCC");
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMadoitac_TextChanged(object sender, EventArgs e)
        {
            string mdt = txtMadoitac.Text.Trim();
            if (Thuvien.checkTrung("Doitac_NCC", "Madoitac", mdt))
            {
                lbMadoitac.Text = "Mã đối tác đã tồn tại.";
                lbMadoitac.ForeColor = Color.Red;
            }
            else
            {
                lbMadoitac.Text = "";
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string dt = txtSDT.Text.Trim();
            if (Thuvien.checkTrung("Doitac_NCC", "SDT", dt))
            {
                lbSDT.Text = "Số điện thoại đã tồn tại.";
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
            if (Thuvien.checkTrung("Doitac_NCC", "Email", mail))
            {
                lbEmail.Text = "Email đã tồn tại.";
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.Text = "";
            }
        }
    }
}
