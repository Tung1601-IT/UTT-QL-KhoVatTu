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
using System.Windows.Interop;
namespace Quản_Lí_Kho_Vật_Tư
{
    
    public partial class Doitac_NCC : Form
    {
        public Doitac_NCC()
        {
            InitializeComponent();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            // B1: Lấy dữ liệu trên các đk đưa vào biến
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string nhom = cboNhomdoitac.SelectedItem.ToString().Trim();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string ghichu=txtGhichu.Text.Trim();
            //Kiem tra trung ma
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
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");

        }

        private void Doitac_NCC_Load(object sender, EventArgs e)
        {
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMadoitac.Text = dgvNCC.Rows[i].Cells[0].Value.ToString();
            txtTendoitac.Text=dgvNCC.Rows[i].Cells[1].Value.ToString();
            cboNhomdoitac.Text= dgvNCC.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text= dgvNCC.Rows[i].Cells[3].Value.ToString();
            txtEmail.Text= dgvNCC.Rows[i].Cells[4].Value.ToString();
            txtDiachi.Text= dgvNCC.Rows[i].Cells[5].Value.ToString();
            txtGhichu.Text= dgvNCC.Rows[i].Cells[6].Value.ToString();
            txtMadoitac.Enabled=false;
            cboNhomdoitac.Enabled=false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string nhom = cboNhomdoitac.SelectedItem.ToString();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string ghichu = txtGhichu.Text.Trim();
            Thuvien.upd_del("Update Doitac_NCC set Tendoitac=N'"+ht+ "',Nhomdoitac=N'"+nhom+"',SDT='"+dt+"',Email='"+mail+"',Diachi=N'"+dc+"',Ghichu=N'"+ghichu+"' where Madoitac='"+mdt+"'");
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mdt= txtMadoitac.Text.Trim();
            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("Delete from Doitac_NCC where Madoitac='" + mdt + "'");
            MessageBox.Show("Xoa thanh cong");
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mdt=txtMadoitac_tk.Text.Trim();
            string ht=txtTendoitac_tk.Text.Trim();
            string sdt=txtSDT_tk.Text.Trim();
            string nhom=cboNhomdoitac_tk.Text.Trim();
            Thuvien.load_KH(dgvNCC,"Select * from Doitac_NCC where Madoitac like '%" + mdt + "%' and " +
                "Tendoitac like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Nhomdoitac like N'%" + nhom + "%'");
        }
    }
}
