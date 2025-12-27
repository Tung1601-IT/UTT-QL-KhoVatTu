using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;
using xls = Microsoft.Office.Interop.Excel;


namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Quanlikho : Form
    {
        public Quanlikho()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mavt = tkMavt.Text.Trim();
            string tenvt = tkTenvt.Text.Trim();
            string loaivt = tkLoaivt.Text.Trim();
            string mancc = tkNhacungcap.SelectedValue.ToString();
            Thuvien.load_KH(dgvQL_Kho, "SELECT * FROM QL_Kho WHERE Mavattu LIKE '%" + mavt + "%' AND Tenvattu LIKE N'%" + tenvt + "%' AND Loaivattu LIKE N'%" + loaivt + "%' AND Madoitac LIKE N'%" + mancc + "%'");
            /*string sql = "SELECT * FROM QL_Kho WHERE Mavattu LIKE @mavt AND Tenvattu LIKE @tenvt AND Loaivattu LIKE @loaivt AND Madoitac LIKE @mancc";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.AddWithValue("@mavt", mavt );
            cmd.Parameters.AddWithValue("@tenvt", tenvt );
            cmd.Parameters.AddWithValue("@loaivt",loaivt );
            cmd.Parameters.AddWithValue("@mancc", mancc );
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b4:Tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();//Giai phong cmd
            Thuvien.con.Close();//ngat ket noi
                        //b5: Đổ dữ liệu từ dataTable vào dataGridView
            dgvQL_Kho.DataSource = tb;
            dgvQL_Kho.Refresh();
            */
        }

        

        bool isLoading = true;

        private void Quanlikho_Load(object sender, EventArgs e)
        {
            isLoading = true;
            Load_Kho();
            
            Load_TKNhacungcap();

            InitNhapTable();
            Init_xNhapTable();
            Load_TenVatTu();
            Load_xTenVatTu();
            LockInput();
            Load_KhachHang();

            nSoluong.TextChanged += txtSoluong_TextChanged;
            xSoluong.TextChanged += txt_xSoluong_TextChanged;
            isLoading = false;
        }
        private void Load_Kho()
        {
            string sql =
           "SELECT k.Mavattu, k.Tenvattu, k.Loaivattu, n.Tendoitac, k.Donvitinh, k.Soluong, k.Gianhap,k.Giaban, k.Ghichu FROM QL_Kho k JOIN Doitac_NCC n ON k.Madoitac = n.Madoitac";

            Thuvien.load_KH(dgvQL_Kho, sql);
        }
        
        private void Load_TKNhacungcap()
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = "SELECT Madoitac, Tendoitac FROM Doitac_NCC";
            SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            // Thêm dòng mặc định
            DataRow r = tb.NewRow();
            r["Madoitac"] = "";
            r["Tendoitac"] = "-- Chọn nhà cung cấp --";
            tb.Rows.InsertAt(r, 0);

            

            tkNhacungcap.DataSource = tb;
            tkNhacungcap.DisplayMember = "Tendoitac";
            tkNhacungcap.ValueMember = "Madoitac";
            tkNhacungcap.SelectedIndex = 0;

            Thuvien.con.Close();
        }

        

        public void ExportExcel(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks;
            ex_cel.Sheets oSheets;
            ex_cel.Workbook oBook;
            ex_cel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (ex_cel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (ex_cel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;
            // Tạo phần đầu nếu muốn
            ex_cel.Range head = oSheet.get_Range("A1", "I1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH VẬT TƯ";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ VẬT TƯ";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN VẬT TƯ";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "LOẠI VẬT TƯ";
            cl4.ColumnWidth = 15.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "NHÀ CUNG CẤP";
            cl5.ColumnWidth = 25.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "ĐƠN VỊ TÍNH";
            cl6.ColumnWidth = 40.0;

            ex_cel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "SỐ LƯỢNG";
            cl7.ColumnWidth = 60.0;

            ex_cel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "GIÁ NHẬP";
            cl8.ColumnWidth = 60.0;

            ex_cel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "GHI CHÚ";
            cl9.ColumnWidth = 60.0;
            //ex_cel.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";

            ex_cel.Range rowHead = oSheet.get_Range("A3", "I3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    if (c == 4)
                        arr[r, c] = "'" + dr[c];
                    else
                        arr[r, c] = dr[c];

                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            ex_cel.Range c1 = (ex_cel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            ex_cel.Range c2 = (ex_cel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            ex_cel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            // Kẻ viền
            range.Borders.LineStyle = ex_cel.Constants.xlSolid;
            // Căn giữa cột STT
            ex_cel.Range c3 = (ex_cel.Range)oSheet.Cells[rowEnd, columnStart];
            ex_cel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            //Định dạng ngày sinh
            

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string mavt = tkMavt.Text.Trim();
            string tenvt = tkTenvt.Text.Trim();
            string loaivt = tkLoaivt.Text.Trim();
            string mancc = tkNhacungcap.SelectedValue.ToString();
            
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = " Select ROW_NUMBER() over(order by Mavattu) STT, * from QL_Kho where Mavattu like '%" + mavt + "%' and " +
                "Tenvattu like N'%" + tenvt + "%' and " +
                "Loaivattu like N'%" + loaivt + "%' and " +
                "Madoitac like N'%" + mancc + "%'";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            //B4: Tao doi tuong 
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //B5:Tao doi tuong datatable de lay du lieu tu da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            Thuvien.con.Close();
            ExportExcel(tb, "DSVatTu");
        }
        



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
                string maHD = TaoMaHoaDon("HDN",tran);
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
                Load_Kho();
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

            xMavt.ReadOnly = true;
            xLoaivt.ReadOnly = true;
            xDonvt.ReadOnly = true;
            xGiaban.ReadOnly = true;
            xThanhtien.ReadOnly = true;
            xTongtien.ReadOnly = true;


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
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = "SELECT DISTINCT Tenvattu FROM QL_Kho";
            SqlDataAdapter da = new SqlDataAdapter(sql, Thuvien.con);
            DataTable tb = new DataTable();
            da.Fill(tb);

            xTenvt.DataSource = tb;
            xTenvt.DisplayMember = "Tenvattu";
            xTenvt.SelectedIndex = -1;

            Thuvien.con.Close();
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
            if (Thuvien.con.State==ConnectionState.Closed)
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
                string maHD = TaoMaHoaDon("HDX", tran);
                decimal tongTien = dtXuat.AsEnumerable()
                                         .Sum(r => r.Field<decimal>("Thanhtien"));

                // 1️⃣ Hóa đơn
                string sqlHD = @"
            INSERT INTO Hoadon (MaHD, NgayTao, LoaiHD, TongTien)
            VALUES (@mahd, GETDATE(), N'XUAT', @tong)";

                SqlCommand cmdHD = new SqlCommand(sqlHD, Thuvien.con, tran);
                cmdHD.Parameters.AddWithValue("@mahd", maHD);
                cmdHD.Parameters.AddWithValue("@tong", tongTien);
                cmdHD.ExecuteNonQuery();

                // 2️⃣ Chi tiết + trừ kho
                foreach (DataRow r in dtXuat.Rows)
                {
                    string sqlCT = @"
                INSERT INTO Hoadon_CT 
                (MaHD, MaVT, Soluong, Giaban, Thanhtien, Doitac)
                VALUES 
                (@mahd, @mavt, @sl, @gia, @tt, @doitac)
                ";

                    SqlCommand cmdCT = new SqlCommand(sqlCT, Thuvien.con, tran);
                    cmdCT.Parameters.AddWithValue("@mahd", maHD);
                    cmdCT.Parameters.AddWithValue("@mavt", r["Mavt"]);
                    cmdCT.Parameters.AddWithValue("@sl", r["Soluong"]);
                    cmdCT.Parameters.AddWithValue("@gia", r["Giaban"]);
                    cmdCT.Parameters.AddWithValue("@tt", r["Thanhtien"]);
                    cmdCT.Parameters.AddWithValue("@doitac", r["Khachhang"]);

                    cmdCT.ExecuteNonQuery();

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
                MessageBox.Show($"Xuất kho thành công\nMã hóa đơn: {maHD}");

                dtXuat.Clear();
                xTongtien.Text = "0";
                Load_Kho();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Lỗi xuất kho\n" + ex.Message);
            }
            finally
            {
                Thuvien.con.Close();
            }
        }

    }
}
