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
using ex_cel = Microsoft.Office.Interop.Excel;
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
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            string sql = @"
                        SELECT p.MaHD, p.Ngaytao, p.TongTien, p.NVtaophieu
                        FROM Phieunhap p
                        WHERE
                            (@TuNgay IS NULL OR p.Ngaytao >= @TuNgay)
                            AND (@DenNgay IS NULL OR p.Ngaytao < DATEADD(DAY, 1, @DenNgay))
                        ORDER BY p.Ngaytao;";

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

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHoadon.DataSource = dt;
                }
            }
        }
        private void HoadonNhapkho_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ql_vattuDataSet2.Doitac_NCC' table. You can move, or remove it, as needed.
            this.doitac_NCCTableAdapter.Fill(this.ql_vattuDataSet2.Doitac_NCC);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Nhapkho f = new Nhapkho();
            f.ShowDialog();
        }
        public void ExportExcel(DataTable tb, string sheetname)
        {

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
            ex_cel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH HÓA ĐƠN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ HÓA ĐƠN";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "NGÀY TẠO";
            cl3.ColumnWidth = 25.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "NHÂN VIÊN NHẬP";
            cl4.ColumnWidth = 17.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "TỔNG TIỀN";
            cl5.ColumnWidth = 22.0;

         
            ex_cel.Range cl3_1 = oSheet.get_Range("C3", "C1000");
            cl3_1.Columns.NumberFormat = "dd/mm/yyyy";

            ex_cel.Range cl5_1 = oSheet.get_Range("E3", "E1000");
            cl5_1.NumberFormat = "#,##0";

            ex_cel.Range rowHead = oSheet.get_Range("A3", "E3");
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
            ex_cel.Range cl_ngs = oSheet.get_Range("D" + rowStart, "D" + rowEnd);
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";

        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = @" Select ROW_NUMBER() over(order by MaHD) STT,
                    MaHD, Ngaytao, NVtaophieu,TongTien
                    FROM Phieunhap
                    WHERE
                        (@TuNgay IS NULL OR Ngaytao >= @TuNgay)
                        AND (@DenNgay IS NULL OR Ngaytao < DATEADD(DAY, 1, @DenNgay))
        ORDER BY Ngaytao;";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            if (dtpTuNgay.Checked)
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = dtpTuNgay.Value.Date;
            else
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = DBNull.Value;

            if (dtpDenNgay.Checked)
                cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = dtpDenNgay.Value.Date;
            else
                cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = DBNull.Value;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            Thuvien.con.Close();
            ExportExcel(tb, "DSHoadon");
        }
    }
}
