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
using ex_cel = Microsoft.Office.Interop.Excel;
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
            string sql = @"SELECT MaHD, Ngaytao, TongTien, NVtaophieu
          FROM Phieunhap
          WHERE MaHD = @MaHD";
            using (SqlCommand cmd = new SqlCommand(sql, Thuvien.con))
            {
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 50).Value = _maHD;

                if (Thuvien.con.State != ConnectionState.Open)
                    Thuvien.con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        lblMaHD.Text = rd["MaHD"].ToString();
                        lblNgayTao.Text = Convert.ToDateTime(rd["NgayTao"]).ToString("dd/MM/yyyy HH:mm");
                        lblNhanvien.Text = rd["NVtaophieu"].ToString();
                        lblTongTien.Text = string.Format("{0:N0}", rd["TongTien"]);
                    }
                }
                Thuvien.con.Close();
            }


        }
        private void LoadDetail()
        {
            string sql = @"
                        SELECT 
                            ct.MaVT,
                            k.Tenvattu,
                            ct.Doitac,
                            ct.SoLuong,
                            ct.GiaNhap,
                            ct.ThanhTien
                        FROM Phieunhap_CT ct
                        INNER JOIN QL_Kho k 
                            ON ct.MaVT = k.Mavattu
                        WHERE ct.MaHD = @MaHD";
            using (SqlCommand cmd = new SqlCommand(sql, Thuvien.con))
            {
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 50).Value = _maHD;
                if (Thuvien.con.State != ConnectionState.Open)
                    Thuvien.con.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCThoadon.DataSource = dt;
                }
            }
            dgvCThoadon.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvCThoadon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
        private DataRow GetPhieuNhapHeader(string maHD)
        {
            string sql = @"SELECT ct.MaHD, pn.Ngaytao, pn.NVtaophieu, pn.TongTien,ct.Doitac
                   FROM Phieunhap pn 
                    INNER JOIN Phieunhap_CT ct
                    ON pn.MaHD=ct.MaHD
                    WHERE ct.MaHD=@MaHD";

            using (SqlCommand cmd = new SqlCommand(sql, Thuvien.con))
            {
                cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 50).Value = maHD;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
            }
        }
        public void ExportExcel(DataTable tb, string maHD)
        {
            var header = GetPhieuNhapHeader(maHD);
            if (header == null)
            {
                MessageBox.Show("Không tìm thấy phiếu!");
                return;
            }
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
            // Tạo phần đầu nếu muốn
            ex_cel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = "HÓA ĐƠN CHI TIẾT";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            string ma = header["MaHD"].ToString();
            DateTime ngay = Convert.ToDateTime(header["Ngaytao"]);
            string nv = header["NVtaophieu"].ToString();
            string dt = header["Doitac"].ToString();
            decimal tong = header["TongTien"] == DBNull.Value ? 0 : Convert.ToDecimal(header["TongTien"]);

            oSheet.Range["B3"].Value = "Mã HĐ:";
            oSheet.Range["B3"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignRight;
            oSheet.Range["C3"].Value = ma;
            oSheet.Range["C3"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;

            oSheet.Range["E3"].Value = "Ngày tạo:";
            oSheet.Range["E3"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignRight;
            oSheet.Range["F3"].Value = ngay.ToString("dd-MM-yyyy HH:mm");
            oSheet.Range["F3"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;

            oSheet.Range["B4"].Value = "Nhân viên:";
            oSheet.Range["B4"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignRight;
            oSheet.Range["C4"].Value = nv;
            oSheet.Range["C4"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;

            oSheet.Range["E4"].Value = "Đối tác:";
            oSheet.Range["E4"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignRight;
            oSheet.Range["F4"].Value = dt;
            oSheet.Range["F4"].HorizontalAlignment = ex_cel.XlHAlign.xlHAlignLeft;
            //oSheet.Range["E4"].NumberFormat = "#,##0 [$₫-vi-VN]";

            oSheet.Range["B3:B4"].Font.Bold = true;
            oSheet.Range["E3:E4"].Font.Bold = true;
            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A6", "A6");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B6", "B6");
            cl2.Value2 = "MÃ VẬT TƯ";
            cl2.ColumnWidth = 10;

            ex_cel.Range cl3 = oSheet.get_Range("C6", "C6");
            cl3.Value2 = "TÊN VẬT TƯ";
            cl3.ColumnWidth = 18;

            ex_cel.Range cl4 = oSheet.get_Range("D6", "D6");
            cl4.Value2 = "SL";
            cl4.ColumnWidth = 6;

            ex_cel.Range cl5 = oSheet.get_Range("E6", "E6");
            cl5.Value2 = "ĐƠN GIÁ";
            cl5.ColumnWidth = 20;

            ex_cel.Range cl6 = oSheet.get_Range("F6", "F6");
            cl6.Value2 = "THÀNH TIỀN";
            cl6.ColumnWidth = 25;

            ex_cel.Range cl5_1 = oSheet.get_Range("E7", "E1000");
            cl5_1.Columns.NumberFormat = "#,##0";
            ex_cel.Range cl6_1 = oSheet.get_Range("F7", "F1000");
            cl6_1.Columns.NumberFormat = "#,##0";

            ex_cel.Range rowHead = oSheet.get_Range("A6", "F6");
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
                        arr[r, c] = dr[c];
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 7;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            int rowTongtien = rowEnd + 1;
            oSheet.Range["A" + rowTongtien + ":B" + rowTongtien].Merge();
            oSheet.Range["A" + rowTongtien].Value = "Tổng tiền:";
            oSheet.Range["A" + rowTongtien].Font.Bold = true;
            oSheet.Range["A" + rowTongtien].Font.Size = 13;
            oSheet.Range["F" + rowTongtien].Value = tong;
            oSheet.Range["F" + rowTongtien].Font.Bold = true;
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
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string ma = _maHD;
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = @"Select ROW_NUMBER() over(order by ct.MaHD) STT,
                    ct.MaVT, k.Tenvattu, ct.SoLuong, ct.GiaNhap, ct.ThanhTien
                    FROM Phieunhap_CT ct
                    JOIN QL_Kho k ON k.Mavattu = ct.MaVT
                    WHERE ct.MaHD = @MaHD";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@MaHD", SqlDbType.VarChar, 50).Value = ma;
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            Thuvien.con.Close();
            ExportExcel(tb, ma);
        }
    }
}
