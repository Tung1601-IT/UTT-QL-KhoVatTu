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
    public partial class Xuatkho : Form
    {
        public Xuatkho()
        {
            InitializeComponent();
        }


        private string TaoMaHoaDon(string loai, SqlTransaction tran)
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");

            string sql = $"SELECT COUNT(*) FROM Phieuxuat WHERE MaHD LIKE '{loai}{ngay}%'";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con, tran);

            int stt = (int)cmd.ExecuteScalar() + 1;
            return $"{loai}{ngay}_{stt:D3}";
        }
        
        DataTable dtXuat;

        private void Init_xNhapTable()
        {
            dtXuat = new DataTable();
            dtXuat.Columns.Add("Mavt");
            dtXuat.Columns.Add("Tenvt");
            dtXuat.Columns.Add("Loaivt");
            dtXuat.Columns.Add("Khachhang");
            dtXuat.Columns.Add("Donvitinh");
            dtXuat.Columns.Add("Soluong", typeof(int));
            dtXuat.Columns.Add("Giaban", typeof(decimal));
            dtXuat.Columns.Add("Thanhtien", typeof(decimal));

            dgvXuatkho.DataSource = dtXuat;
        }

        int rowxDangChon = -1;

        private void dgvXuatkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            rowxDangChon = e.RowIndex;
            DataGridViewRow row = dgvXuatkho.Rows[e.RowIndex];

            xMavt.Text = row.Cells["Mavt"].Value.ToString();
            xTenvt.Text = row.Cells["Tenvt"].Value.ToString();
            xLoaivt.Text = row.Cells["Loaivt"].Value.ToString();
            xDonvt.Text = row.Cells["Donvitinh"].Value.ToString();
            xSoluong.Text = row.Cells["Soluong"].Value.ToString();
            xGiaban.Text = row.Cells["Giaban"].Value.ToString();
            xThanhtien.Text = row.Cells["Thanhtien"].Value.ToString();
            xKhachhang.Text = row.Cells["Khachhang"].Value.ToString();
        }


        private void btn_xSua_Click(object sender, EventArgs e)
        {
            if (rowxDangChon < 0)
            {
                MessageBox.Show("Chọn vật tư cần sửa");
                return;
            }

            DataRow r = dtXuat.Rows[rowxDangChon];

            int sl = int.Parse(xSoluong.Text);
            decimal gia = decimal.Parse(xGiaban.Text);
            decimal thanhtien = sl * gia;

            r["Soluong"] = sl;
            r["Giaban"] = gia;
            r["Thanhtien"] = thanhtien;

            xThanhtien.Text = thanhtien.ToString("N0");

            xTinhTongTienNhap();
        }


        private void btn_xXoa_Click(object sender, EventArgs e)
        {
            if (rowxDangChon < 0)
            {
                MessageBox.Show("Chọn dòng cần xóa");
                return;
            }

            if (MessageBox.Show("Xóa vật tư này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dtXuat.Rows.RemoveAt(rowxDangChon);
                rowxDangChon = -1;

                xResetNhap();
                xTinhTongTienNhap();
            }
        }

        void xResetNhap()
        {
            xMavt.Clear();
            xLoaivt.Clear();
            xDonvt.Clear();
            xSoluong.Clear();
            xGiaban.Clear();
            xThanhtien.Text = "0";
            xTenvt.SelectedIndex = -1;
            xNhacc.SelectedIndex = -1;
            xKhachhang.SelectedIndex = -1;
        }


        void xTinhTongTienNhap()
        {
            decimal tong = dtXuat.AsEnumerable()
                                 .Sum(r => r.Field<decimal>("Thanhtien"));
            xTongtien.Text = tong.ToString("N0");
        }






        private void Load_xTenVatTu()
        {
            try
            {
                if (Thuvien.con.State == ConnectionState.Open)
                    Thuvien.con.Close();

                Thuvien.con.Open();

                string sql = "SELECT DISTINCT Tenvattu FROM QL_Kho";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con))
                {
                    DataTable tb = new DataTable();
                    da.Fill(tb);

                    xTenvt.DataSource = tb;
                    xTenvt.DisplayMember = "Tenvattu";
                    xTenvt.SelectedIndex = -1;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Thuvien.con.Close();
            }
        }

        private void xTenvt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (xTenvt.SelectedIndex < 0) return;


            Load_xNhaCungCap_TheoVT(xTenvt.Text);
        }




        private void Load_xNhaCungCap_TheoVT(string tenVT)
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

            xNhacc.DataSource = tb;
            xNhacc.DisplayMember = "Tendoitac";
            xNhacc.ValueMember = "Madoitac";
            xNhacc.SelectedIndex = -1;

            Thuvien.con.Close();
        }

        private void xNhacc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;

            if (xNhacc.SelectedIndex < 0) return;

            Load_xThongTinVatTu(xTenvt.Text, xNhacc.SelectedValue.ToString());
        }

        private void Load_xThongTinVatTu(string tenVT, string maNCC)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = @"
        SELECT Mavattu, Loaivattu, Donvitinh, Giaban
        FROM QL_Kho
        WHERE Tenvattu = @tenvt AND Madoitac = @mancc";

            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.AddWithValue("@tenvt", tenVT);
            cmd.Parameters.AddWithValue("@mancc", maNCC);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                xMavt.Text = rd["Mavattu"].ToString();
                xLoaivt.Text = rd["Loaivattu"].ToString();
                xDonvt.Text = rd["Donvitinh"].ToString();
                xGiaban.Text = rd["Giaban"].ToString();
            }
            rd.Close();
            Thuvien.con.Close();
        }


        private int LaySoLuongTon(string mavt)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
            {
                Thuvien.con.Open();
            }
            string sql = "SELECT Soluong FROM QL_Kho WHERE Mavattu = @mavt";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.AddWithValue("@mavt", mavt);
            object kq = cmd.ExecuteScalar();
            return kq == null ? 0 : Convert.ToInt32(kq);
        }

        private void xNhapthem_Click(object sender, EventArgs e)
        {
            string mavt = xMavt.Text;
            string tenvt = xTenvt.Text;
            string loaivt = xLoaivt.Text;
            string khachhang = xKhachhang.Text;
            string dvt = xDonvt.Text;
            if (!int.TryParse(xSoluong.Text, out int sl)) return;
            if (!decimal.TryParse(xGiaban.Text, out decimal giaban)) return;

            int ton = LaySoLuongTon(mavt);
            if (sl > ton)
            {
                MessageBox.Show("Số lượng xuất vượt quá tồn kho");
                return;
            }




            decimal thanhtien = sl * giaban;

            // Nếu đã tồn tại → cộng số lượng
            foreach (DataRow r in dtXuat.Rows)
            {
                if (r["Mavt"].ToString() == mavt)
                {
                    r["Soluong"] = (int)r["Soluong"] + sl;
                    r["Thanhtien"] = (decimal)r["Thanhtien"] + thanhtien;
                    xTinhTongTien();
                    return;
                }
            }

            // Chưa có → thêm mới
            DataRow row = dtXuat.NewRow();
            row["Mavt"] = mavt;
            row["Tenvt"] = tenvt;
            row["Loaivt"] = loaivt;
            row["Khachhang"] = khachhang;
            row["Donvitinh"] = dvt;
            row["Soluong"] = sl;
            row["Giaban"] = giaban;
            row["Thanhtien"] = thanhtien;

            dtXuat.Rows.Add(row);
            xTinhTongTien();
            xResetNhap();
        }

        private void xTinhTongTien()
        {
            decimal tong = 0;

            foreach (DataRow r in dtXuat.Rows)
            {
                tong += Convert.ToDecimal(r["Thanhtien"]);
            }

            xTongtien.Text = tong.ToString("N0");
        }


        private void txt_xSoluong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(xSoluong.Text))
            {
                xThanhtien.Text = "0";
                return;
            }

            if (!int.TryParse(xSoluong.Text, out int soluong))
            {
                xThanhtien.Text = "0";
                return;
            }

            if (!decimal.TryParse(xGiaban.Text, out decimal giaban))
            {
                xThanhtien.Text = "0";
                return;
            }

            decimal thanhtien = soluong * giaban;
            xThanhtien.Text = thanhtien.ToString("N0"); // format tiền
        }

        private void xSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuuxuat_Click(object sender, EventArgs e)
        {
            if (dtXuat == null || dtXuat.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có vật tư xuất");
                return;
            }

            

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            SqlTransaction tran = Thuvien.con.BeginTransaction();

            try
            {
                string maHD = TaoMaHoaDon("PX", tran);
                decimal tongTien = dtXuat.AsEnumerable()
                                         .Sum(r => r.Field<decimal>("Thanhtien"));

                // =========================
                // 1️⃣ PHIẾU XUẤT
                // =========================
                string sqlPX = @"
                INSERT INTO Phieuxuat
                (MaHD, Ngaytao, TongTien, NVtaophieu)
                VALUES
                (@mahd, @ngay, @tong, @nv)";

                SqlCommand cmdPX = new SqlCommand(sqlPX, Thuvien.con, tran);
                cmdPX.Parameters.AddWithValue("@mahd", maHD);
                cmdPX.Parameters.AddWithValue("@ngay", xNgaytao.Value);
                cmdPX.Parameters.AddWithValue("@tong", tongTien);
                cmdPX.Parameters.AddWithValue("@nv", xNhanvien.Text);
                

                cmdPX.ExecuteNonQuery();

                // =========================
                // 2️⃣ CHI TIẾT + TRỪ KHO
                // =========================
                foreach (DataRow r in dtXuat.Rows)
                {
                    string sqlCT = @"
            INSERT INTO Phieuxuat_CT
            (MaHD, MaVT, SoLuong, Giaban, ThanhTien, Doitac)
            VALUES
            (@mahd, @mavt, @sl, @gia, @tt, @dt)";

                    SqlCommand cmdCT = new SqlCommand(sqlCT, Thuvien.con, tran);
                    cmdCT.Parameters.AddWithValue("@mahd", maHD);
                    cmdCT.Parameters.AddWithValue("@mavt", r["Mavt"]);
                    cmdCT.Parameters.AddWithValue("@sl", r["Soluong"]);
                    cmdCT.Parameters.AddWithValue("@gia", r["Giaban"]);
                    cmdCT.Parameters.AddWithValue("@tt", r["Thanhtien"]);
                    cmdCT.Parameters.AddWithValue("@dt", r["Khachhang"]);
                    
                    cmdCT.ExecuteNonQuery();

                    // Trừ tồn kho
                    string sqlKho = @"
            UPDATE QL_Kho
            SET Soluong = Soluong - @sl
            WHERE Mavattu = @mavt";

                    SqlCommand cmdKho = new SqlCommand(sqlKho, Thuvien.con, tran);
                    cmdKho.Parameters.AddWithValue("@sl", r["Soluong"]);
                    cmdKho.Parameters.AddWithValue("@mavt", r["Mavt"]);
                    cmdKho.ExecuteNonQuery();
                }

                tran.Commit();
                MessageBox.Show($"Xuất kho thành công!\nMã phiếu: {maHD}");

                dtXuat.Clear();
                xTongtien.Text = "0";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi xuất kho:\n" + ex.Message);
            }
            finally
            {
                Thuvien.con.Close();
            }
        }
        bool isLoading = true;

        private void Xuatkho_Load(object sender, EventArgs e)
        {
            isLoading = true;
            Init_xNhapTable();
            Load_xTenVatTu();
            LockInput();
            Load_KhachHang();

            xNgaytao.Value = DateTime.Now;
            xNgaytao.Enabled = false;

            xNhanvien.Text = Dangnhap.TenNhanVien; // hoặc TenDangNhap
            xNhanvien.ReadOnly = true;

            xSoluong.TextChanged += txt_xSoluong_TextChanged;
            isLoading = false;
        }

        private void LockInput()
        {
            

            xMavt.ReadOnly = true;
            xLoaivt.ReadOnly = true;
            xDonvt.ReadOnly = true;
            xGiaban.ReadOnly = true;
            xThanhtien.ReadOnly = true;
            xTongtien.ReadOnly = true;


        }

        private void Load_KhachHang()
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = "SELECT Makhachhang, Tenkhachhang FROM Khachhang";
            SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            xKhachhang.DataSource = tb;
            xKhachhang.DisplayMember = "Tenkhachhang";
            xKhachhang.ValueMember = "Makhachhang";
            xKhachhang.SelectedIndex = -1;

            Thuvien.con.Close();
        }



        // Gọi form
        private void bÁNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

           Tongquan f = new Tongquan();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Doitac_Khachhang f = new Doitac_Khachhang();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void nhàCungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Doitac_NCC f = new Doitac_NCC();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void sẢNPHẢMDỊCHVỤToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Sanphamdichvu f = new Sanphamdichvu();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Quanlikho f = new Quanlikho();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Nhapkho f = new Nhapkho();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void qUẢNLÍTHUCHIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Quanlithuchi f = new Quanlithuchi();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Danhsachnhanvien f = new Danhsachnhanvien();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }

        private void lịchLàmViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Lichlamviec f = new Lichlamviec();

            // Khi Form mới đóng → đóng Trang chủ
            f.FormClosed += (s, args) =>
            {
                this.Close();
            };

            f.Show();
        }
    }
}

    

