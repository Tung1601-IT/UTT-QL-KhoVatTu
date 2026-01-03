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
    public partial class Nhapkho : Form
    {
        public Nhapkho()
        {
            InitializeComponent();
        }

        bool isLoading = true;
        DataTable dtNhap;

        private void InitNhapTable()
        {
            dtNhap = new DataTable();
            dtNhap.Columns.Add("Mavt");
            dtNhap.Columns.Add("Tenvt");
            dtNhap.Columns.Add("Loaivt");
            dtNhap.Columns.Add("Nhacc");
            dtNhap.Columns.Add("Donvitinh");
            dtNhap.Columns.Add("Soluong", typeof(int));
            dtNhap.Columns.Add("Gianhap", typeof(decimal));
            dtNhap.Columns.Add("Thanhtien", typeof(decimal));

            dgvNhapkho.DataSource = dtNhap;
        }

        int rowDangChon = -1;

        private void dgvNhapkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            rowDangChon = e.RowIndex;
            DataGridViewRow row = dgvNhapkho.Rows[e.RowIndex];

            nMavt.Text = row.Cells["Mavt"].Value.ToString();
            nTenvt.Text = row.Cells["Tenvt"].Value.ToString();
            nLoaivt.Text = row.Cells["Loaivt"].Value.ToString();
            nDonvt.Text = row.Cells["Donvitinh"].Value.ToString();
            nSoluong.Text = row.Cells["Soluong"].Value.ToString();
            nGianhap.Text = row.Cells["Gianhap"].Value.ToString();
            nThanhtien.Text = row.Cells["Thanhtien"].Value.ToString();
            nNhacc.Text = row.Cells["Nhacc"].Value.ToString();
        }

        private void btn_nSua_Click(object sender, EventArgs e)
        {
            if (rowDangChon < 0)
            {
                MessageBox.Show("Chọn vật tư cần sửa");
                return;
            }

            DataRow r = dtNhap.Rows[rowDangChon];

            int sl = int.Parse(nSoluong.Text);
            decimal gia = decimal.Parse(nGianhap.Text);
            decimal thanhtien = sl * gia;

            r["Soluong"] = sl;
            r["Gianhap"] = gia;
            r["Thanhtien"] = thanhtien;

            nThanhtien.Text = thanhtien.ToString("N0");

            TinhTongTienNhap();
        }

        private void btn_nXoa_Click(object sender, EventArgs e)
        {
            if (rowDangChon < 0)
            {
                MessageBox.Show("Chọn dòng cần xóa");
                return;
            }

            if (MessageBox.Show("Xóa vật tư này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dtNhap.Rows.RemoveAt(rowDangChon);
                rowDangChon = -1;

                ResetNhap();
                TinhTongTienNhap();
            }
        }

        void ResetNhap()
        {
            nMavt.Clear();
            nLoaivt.Clear();
            nDonvt.Clear();
            nSoluong.Clear();
            nGianhap.Clear();
            nThanhtien.Text = "0";
            nTenvt.SelectedIndex = -1;
            nNhacc.SelectedIndex = -1;
        }

        void TinhTongTienNhap()
        {
            decimal tong = dtNhap.AsEnumerable()
                                 .Sum(r => r.Field<decimal>("Thanhtien"));
            nTongtien.Text = tong.ToString("N0");
        }






        private void btnNhapthem_Click(object sender, EventArgs e)
        {
            string mavt = nMavt.Text;
            string tenvt = nTenvt.Text;
            string loaivt = nLoaivt.Text;
            string nhacc = nNhacc.Text;
            string dvt = nDonvt.Text;
            if (!int.TryParse(nSoluong.Text, out int sl)) return;
            if (!decimal.TryParse(nGianhap.Text, out decimal gianhap)) return;



            decimal thanhtien = sl * gianhap;

            // Nếu đã tồn tại → cộng số lượng
            foreach (DataRow r in dtNhap.Rows)
            {
                if (r["Mavt"].ToString() == mavt)
                {
                    r["Soluong"] = (int)r["Soluong"] + sl;
                    r["Thanhtien"] = (decimal)r["Thanhtien"] + thanhtien;
                    TinhTongTien();
                    return;
                }
            }

            // Chưa có → thêm mới
            DataRow row = dtNhap.NewRow();
            row["Mavt"] = mavt;
            row["Tenvt"] = tenvt;
            row["Loaivt"] = loaivt;
            row["Nhacc"] = nhacc;
            row["Donvitinh"] = dvt;
            row["Soluong"] = sl;
            row["Gianhap"] = gianhap;
            row["Thanhtien"] = thanhtien;

            dtNhap.Rows.Add(row);
            TinhTongTien();
            ResetNhap();
        }

        private void TinhTongTien()
        {
            decimal tong = 0;

            foreach (DataRow r in dtNhap.Rows)
            {
                tong += Convert.ToDecimal(r["Thanhtien"]);
            }

            nTongtien.Text = tong.ToString("N0");
        }


        private void btnLuunhap_Click(object sender, EventArgs e)
        {
            if (dtNhap == null || dtNhap.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có vật tư nào");
                return;
            }

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            SqlTransaction tran = Thuvien.con.BeginTransaction();

            try
            {
                string maHD = TaoMaHoaDon("HDN", tran);
                decimal tongTien = dtNhap.AsEnumerable()
                                         .Sum(r => r.Field<decimal>("Thanhtien"));

                // 1️⃣ Insert hóa đơn
                string sqlHD = @"
                    INSERT INTO Hoadon (MaHD, NgayTao, LoaiHD, TongTien)
                    VALUES (@mahd, GETDATE(), N'NHAP', @tongtien)";


                SqlCommand cmdHD = new SqlCommand(sqlHD, Thuvien.con, tran);
                cmdHD.Parameters.AddWithValue("@mahd", maHD);
                cmdHD.Parameters.AddWithValue("@tongtien", tongTien);
                cmdHD.ExecuteNonQuery();

                // 2️⃣ Chi tiết + update kho
                foreach (DataRow r in dtNhap.Rows)
                {
                    // Chi tiết hóa đơn
                    string sqlCT = @"
                    INSERT INTO Hoadon_CT (MaHD, MaVT, Soluong, Gianhap, Thanhtien,Doitac)
                    VALUES (@mahd, @mavt, @sl, @gia, @tt,@doitac)";

                    SqlCommand cmdCT = new SqlCommand(sqlCT, Thuvien.con, tran);
                    cmdCT.Parameters.AddWithValue("@mahd", maHD);
                    cmdCT.Parameters.AddWithValue("@mavt", r["Mavt"]);
                    cmdCT.Parameters.AddWithValue("@sl", r["Soluong"]);
                    cmdCT.Parameters.AddWithValue("@gia", r["Gianhap"]);
                    cmdCT.Parameters.AddWithValue("@tt", r["Thanhtien"]);
                    cmdCT.Parameters.AddWithValue("@doitac", r["Nhacc"]);

                    cmdCT.ExecuteNonQuery();

                    // Update kho
                    string sqlKho = @"
                UPDATE QL_Kho 
                SET Soluong = Soluong + @sl
                WHERE Mavattu = @mavt";

                    SqlCommand cmdKho = new SqlCommand(sqlKho, Thuvien.con, tran);
                    cmdKho.Parameters.AddWithValue("@sl", r["Soluong"]);
                    cmdKho.Parameters.AddWithValue("@mavt", r["Mavt"]);
                    cmdKho.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show($"Nhập kho thành công\nMã hóa đơn: {maHD}");

                dtNhap.Clear();
                nTongtien.Text = "0";
               
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi khi lưu hóa đơn\n" + ex.Message);
            }
            finally
            {
                Thuvien.con.Close();
            }
        }




        private void Load_TenVatTu()
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = "SELECT DISTINCT Tenvattu FROM QL_Kho";
            SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            nTenvt.DataSource = tb;
            nTenvt.DisplayMember = "Tenvattu";
            nTenvt.SelectedIndex = -1;

            Thuvien.con.Close();
        }

        private void nTenvt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (nTenvt.SelectedIndex < 0) return;


            Load_NhaCungCap_TheoVT(nTenvt.Text);
        }


        private void Load_NhaCungCap_TheoVT(string tenVT)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = @"
            SELECT DISTINCT n.Madoitac, n.Tendoitac
            FROM QL_Kho k
            JOIN Doitac_NCC n ON k.Madoitac = n.Madoitac
            WHERE k.Tenvattu = @tenvt";

            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.AddWithValue("@tenvt", tenVT);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            nNhacc.DataSource = tb;
            nNhacc.DisplayMember = "Tendoitac";
            nNhacc.ValueMember = "Madoitac";
            nNhacc.SelectedIndex = -1;

            Thuvien.con.Close();
        }

        private void nNhacc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (nNhacc.SelectedIndex < 0) return;

            Load_ThongTinVatTu(nTenvt.Text, nNhacc.SelectedValue.ToString());
        }


        private void Load_ThongTinVatTu(string tenVT, string maNCC)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = @"
        SELECT Mavattu, Loaivattu, Donvitinh, Gianhap
        FROM QL_Kho
        WHERE Tenvattu = @tenvt AND Madoitac = @mancc";

            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.AddWithValue("@tenvt", tenVT);
            cmd.Parameters.AddWithValue("@mancc", maNCC);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                nMavt.Text = rd["Mavattu"].ToString();
                nLoaivt.Text = rd["Loaivattu"].ToString();
                nDonvt.Text = rd["Donvitinh"].ToString();
                nGianhap.Text = rd["Gianhap"].ToString();
            }
            rd.Close();
            Thuvien.con.Close();
        }


        private void LockInput()
        {
            nMavt.ReadOnly = true;
            nLoaivt.ReadOnly = true;
            nDonvt.ReadOnly = true;
            nGianhap.ReadOnly = true;
            nThanhtien.ReadOnly = true;
            nTongtien.ReadOnly = true;



        }

        private void Nhapkho_Load(object sender, EventArgs e)
        {
            isLoading = true;
            InitNhapTable();
            Load_TenVatTu();
            LockInput();
            nSoluong.TextChanged += txtSoluong_TextChanged;
            isLoading = false;
        }
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nSoluong.Text))
            {
                nThanhtien.Text = "0";
                return;
            }

            if (!int.TryParse(nSoluong.Text, out int soluong))
            {
                nThanhtien.Text = "0";
                return;
            }

            if (!decimal.TryParse(nGianhap.Text, out decimal gianhap))
            {
                nThanhtien.Text = "0";
                return;
            }

            decimal thanhtien = soluong * gianhap;
            nThanhtien.Text = thanhtien.ToString("N0"); // format tiền
        }

        private void nSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }



        private string TaoMaHoaDon(string loai, SqlTransaction tran)
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");

            string sql = $"SELECT COUNT(*) FROM HoaDon WHERE MaHD LIKE '{loai}{ngay}%'";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con, tran);

            int stt = (int)cmd.ExecuteScalar() + 1;
            return $"{loai}{ngay}_{stt:D3}";
        }
    }
}
