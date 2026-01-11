using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class HoadonNhapkho : Form
    {
        public HoadonNhapkho()
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

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            string sql = "SELECT MaHD, Ngaytao, TongTien, NVtaophieu FROM Phieunhap WHERE Ngaytao >= @TuNgay AND Ngaytao<DATEADD(DAY, 1, @DenNgay) ORDER BY Ngaytao";

            using (SqlCommand cmd = new SqlCommand(sql, Thuvien.con))
            {
                if (dtpTuNgay.Checked)
                    cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = dtpTuNgay.Value.Date;
                else
                    cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = DBNull.Value;

                if (dtpDenNgay.Checked)
                    cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = dtpDenNgay.Value.Date;
                else
                    cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = DBNull.Value;

                cmd.Parameters.Add("@LoaiHD", SqlDbType.NVarChar, 20).Value = loaiHD;
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHoadon.DataSource = dt;
                }
            }
            dgvHoadon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvHoadon.Columns["SoTien"].DefaultCellStyle.Format = "N0";
        }
        private void HoadonNhapkho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ql_vattuDataSet.Phieunhap' table. You can move, or remove it, as needed.
            this.phieunhapTableAdapter.Fill(this.ql_vattuDataSet.Phieunhap);

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

        private void dgvHoadon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return;

            string maHD = dgvHoadon.Rows[i].Cells[0].Value.ToString();

            Chitiet_hoadon f = new Chitiet_hoadon(maHD);
            f.ShowDialog();
        }
    }
}
