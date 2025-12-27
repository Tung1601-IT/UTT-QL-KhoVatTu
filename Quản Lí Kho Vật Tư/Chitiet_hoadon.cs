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
    public partial class Chitiet_hoadon : Form
    {
        private readonly string _maHD;
        public Chitiet_hoadon(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
        }

        private void Chitiet_hoadon_Load(object sender, EventArgs e)
        {
            LoadHeader();
            LoadDetail();
        }
        private void LoadHeader()
        {
            using (SqlCommand cmd = new SqlCommand("Hoadon_header", Thuvien.con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 50).Value = _maHD;

                if (Thuvien.con.State != ConnectionState.Open)
                    Thuvien.con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        lblMaHD.Text = rd["MaHD"].ToString();
                        lblNgayTao.Text = Convert.ToDateTime(rd["NgayTao"]).ToString("dd/MM/yyyy HH:mm");
                        lblLoaiHD.Text = rd["LoaiHD"].ToString();
                        lblTongTien.Text = string.Format("{0:N0}", rd["TongTien"]);
                    }
                }
                Thuvien.con.Close();
            }


        }
        private void LoadDetail()
        {
            using (SqlCommand cmd = new SqlCommand("CT_hoadon", Thuvien.con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 50).Value = _maHD;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCThoadon.DataSource = dt;
                }
            }

            dgvCThoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCThoadon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvCThoadon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }
    }
}
