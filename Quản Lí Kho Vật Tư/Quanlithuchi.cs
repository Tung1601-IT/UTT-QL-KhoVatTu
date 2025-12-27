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
    public partial class Quanlithuchi : Form
    {
        
        public Quanlithuchi()
        {
            InitializeComponent();
           
        }
        private void LoadHoaDon()
        {
            string loaiHD = "";
            string loai = cboLoaiHD.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(loai) || loai == "Tất cả")
                loaiHD = null;
            else
                loaiHD = loai;

                using (SqlCommand cmd = new SqlCommand("Thu_chi", Thuvien.con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (dtpTuNgay.Checked)
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = dtpTuNgay.Value.Date;
                    else
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = DBNull.Value;

                    if (dtpDenNgay.Checked)
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = dtpDenNgay.Value.Date;
                    else
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = DBNull.Value;

                    cmd.Parameters.Add("@LoaiHD", SqlDbType.NVarChar, 20).Value = loaiHD;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvHoadon.DataSource = dt;
                    }
                }
            dgvHoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoadon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvHoadon.Columns["SoTien"].DefaultCellStyle.Format = "N0";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Checked && dtpDenNgay.Checked &&
               dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!");
                return;
            }

            LoadHoaDon();
        }

        private void Quanlithuchi_Load(object sender, EventArgs e)
        {
            cboLoaiHD.SelectedIndex = 0; 
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            LoadHoaDon(); 
        }

        private void dgvHoadon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i<0) return;

            string maHD = dgvHoadon.Rows[i].Cells["MaHD"].Value.ToString();

            Chitiet_hoadon f = new Chitiet_hoadon(maHD);
            f.ShowDialog();
        }
    }
}
