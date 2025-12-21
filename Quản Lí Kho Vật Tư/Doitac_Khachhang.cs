using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Doitac_Khachhang : Form
    {
        public Doitac_Khachhang()
        {
            InitializeComponent();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            // B1: Lấy dữ liệu trên các đk đưa vào biến
            string mkh = txtMaKH.Text.Trim();
            string ht = txtTenKH.Text.Trim();
            string gt = cboGioitinh.SelectedItem.ToString().Trim();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string tt=cboTrangthai.SelectedItem.ToString().Trim();
            string dc = txtDiachi.Text.Trim();
            string cccd = txtCCCD.Text.Trim();

            //Kiem tra trung ma
            //B2:Kết nối DB

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
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");

        }

        private void Doitac_Khachhang_Load(object sender, EventArgs e)
        {
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i=e.RowIndex;
            txtMaKH.Text = dgvKH.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[i].Cells[1].Value.ToString();
            cboGioitinh.Text = dgvKH.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvKH.Rows[i].Cells[3].Value.ToString();
            txtEmail.Text=  dgvKH.Rows[i].Cells[4].Value.ToString();
            cboTrangthai.Text = dgvKH.Rows[i].Cells[5].Value.ToString();
            txtDiachi.Text = dgvKH.Rows[i].Cells[6].Value.ToString();
            txtCCCD.Text = dgvKH.Rows[i].Cells[7].Value.ToString();
            txtMaKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH.Text.Trim();
            string ht = txtTenKH.Text.Trim();
            string gt = cboGioitinh.SelectedItem.ToString().Trim();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string tt = cboTrangthai.SelectedItem.ToString().Trim();
            string dc = txtDiachi.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            Thuvien.upd_del("Update Khachhang set Tenkhachhang=N'" + ht + "',Gioitinh=N'" + gt + "',SDT='" + dt + "',Email='" + mail + "',Trangthai=N'" + tt + "',Diachi=N'" + dc + "',CCCD=N'"+cccd+"' where Makhachhang='" + mkh + "'");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH.Text.Trim();
            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("Delete from Khachhang where Makhachhang='" + mkh + "'");
            MessageBox.Show("Xoa thanh cong");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH_tk.Text.Trim();
            string ht = txtTenKH_tk.Text.Trim();
            string sdt = txtSDT_tk.Text.Trim();
            string tt = cboTrangthai_tk.Text.Trim();
            Thuvien.load_KH(dgvKH, "Select * from Khachhang where Makhachhang like '%" + mkh + "%' and " +
                "Tenkhachhang like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Trangthai like N'%" + tt + "%'");
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string makh=txtMaKH.Text.Trim();
            if (!Thuvien.checkTrung("Khachhang", "Makhachhang", makh))
            {
                lbMaKH.Text = "Mã khách hàng đã tồn tại";
                lbMaKH.ForeColor=Color.Red;
            }
            else
            {
                lbMaKH.Text = "";
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (!Thuvien.checkTrung("Khachhang", "SDT", sdt))
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
            if (!Thuvien.checkTrung("Khachhang", "Email", mail))
            {
                lbEmail.Text = "Email đã tồn tại";
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.Text = "";
            }
        }
    }
    }

