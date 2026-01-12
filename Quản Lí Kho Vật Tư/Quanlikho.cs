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

        

        

        private void Quanlikho_Load(object sender, EventArgs e)
        { 
            Load_Kho();
            Load_TKNhacungcap();
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



        //Gọi form
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

        private void xuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

           Xuatkho f = new Xuatkho();

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
