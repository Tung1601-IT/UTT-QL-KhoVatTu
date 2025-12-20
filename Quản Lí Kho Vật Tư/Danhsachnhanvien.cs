using FontAwesome.Sharp;
using Microsoft.Office.Interop.Excel;
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
    public partial class Danhsachnhanvien : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ComputerTungha;Initial Catalog=QL_KhoVatTu;Integrated Security=True");
        public void LoadData()
        {
            string sql = "select * from Danhsachnhanvien";
            Thuvien.load_KH(dgnhanvien, sql);
        }
        public Danhsachnhanvien()
        {
            InitializeComponent();
        }

        private void Danhsachnhanvien_Load(object sender, EventArgs e)
        {
            //Goi ham load_Kh tu lop thu vien
            //dgnhanvien la ten dat o DataGridView
            //nhanvien la ten bang dat trong sql
            string sql = "select * from Danhsachnhanvien";
            Thuvien.load_KH(dgnhanvien, sql);
        }
      
        private void ibtnnhanvien_Click(object sender, EventArgs e)
        {
            Themnhanvien tnv = new Themnhanvien();
            tnv.ShowDialog();//Hien thi form nhap lieu duoi dang hop thoai
                             //Sau khi dong form nhap lieu,load lai bang de thay nhan vien moi duoc them
            string sql = "select * from Danhsachnhanvien";
            Thuvien.load_KH(dgnhanvien, sql);
        }

        private void ibtntimkiemnhanvien_Click(object sender, EventArgs e)
        {
            //1.Kiem tra nguoi dung ch nhap gi thi load toan bo bang
            if (string.IsNullOrEmpty(txtmanv.Text))
            {
                string sqlFull = "SELECT *FROM Danhsachnhanvien";
                Thuvien.load_KH(dgnhanvien, sqlFull);
                return;
            }
            string Manv = txtmanv.Text;
            string Sdt = txtsdt.Text;
            //2.Tao cau lenh sql tim kiem theo ma nhan vien (dung like de tim kiem gtan dung)
            string sqlSearch = "SELECT *FROM Danhsachnhanvien WHERE Manv LIKE '%" + txtmanv.Text + "%' AND Sdt LIKE '%" + txtsdt.Text + "%' ";
            try
            {
                //3.Goi ham load_kh de hien thi ket qua loc len dgv
                Thuvien.load_KH(dgnhanvien, sqlSearch);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi:" + ex.Message);
            }
        }
        public void ExportExcel(System.Data.DataTable tb,string sheetname)
        {
            //1.Tao cac doi tuong Excel 
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
            //2.Tao tieu de lon cho bang 
            ex_cel.Range head = oSheet.get_Range("A1", "H1");//Den cot thu H vi co 8 cot
            head.MergeCells = true;
            head.Value2 = "DANH SACH NHAN VIEN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            //3.Tao tieu de cho cot
            ex_cel.Range cl1=oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2=oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Ma Nhan Vien";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Ho va ten";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3","D3");
            cl4.Value2 = "Gioi tinh";
            cl4.ColumnWidth = 10.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Ngay sinh";
            cl5.ColumnWidth = 25.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "SDT";
            cl6.ColumnWidth = 35.0;

            ex_cel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Email";
            cl7.ColumnWidth = 45.0;

            ex_cel.Range cl8 = oSheet.get_Range("H3"," H3");
            cl8.Value2 = "Dia chi";
            cl8.ColumnWidth = 55.0;

            //Dinh dang hang tieu de
            ex_cel.Range rowHead = oSheet.get_Range("A3", "H3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count+1];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                arr[r, 0] = r + 1;//STT
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    if (c == 4)
                        arr[r, c+1] = "'" + dr[c];
                    else
                        arr[r, c+1] = dr[c];

                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count+1;
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
            ex_cel.Range cl_ngs = oSheet.get_Range("E4","E" + (tb.Rows.Count + 3).ToString());
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";
            oExcel.Visible = true;

        }
        private void ibtnxuatfile_Click(object sender, EventArgs e)
        {
            //Lay du lieu tren dgv dua vao datatable
            System.Data.DataTable dt= (System.Data.DataTable)dgnhanvien.DataSource;
            if(dt!=null && dt.Rows.Count>0)
            {
                ExportExcel(dt, "Danh sach nhan vien");
            }
            else
            {
                MessageBox.Show("Khong co du lieu de xuat ra file Excel","Thong bao",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        public void ImportExcel(string filePath)
        {
            // 1. Khởi tạo đối tượng Excel để đọc
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks = oExcel.Workbooks;
            ex_cel.Workbook oBook = oBooks.Open(filePath);
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.Worksheets.get_Item(1);

            // 2. Xác định dòng cuối cùng có dữ liệu
            int lastRow = oSheet.Cells.SpecialCells(ex_cel.XlCellType.xlCellTypeLastCell).Row;

            // 3. Vòng lặp đọc dữ liệu (Bắt đầu từ dòng 4)
            for (int i = 4; i <= lastRow; i++)
            {
                // Cột 1 (A) là STT -> Chúng ta bỏ qua, không lưu vào DB
                // Cột 2 (B) là Mã nhân viên
                string Manv = ((ex_cel.Range)oSheet.Cells[i, 2]).Text.ToString();
                // Cột 3 (C) là Họ tên
                string Hoten = ((ex_cel.Range)oSheet.Cells[i, 3]).Text.ToString();
                string Gioitnh = ((ex_cel.Range)oSheet.Cells[i, 4]).Text.ToString();
                string Ngaysinh = ((ex_cel.Range)oSheet.Cells[i, 5]).Text.ToString();
                DateTime time = DateTime.ParseExact(Ngaysinh, "dd/MM/yyyy", null);
                string NgaysinhSQL= time.ToString("yyyy-MM-dd");
                string Sdt = ((ex_cel.Range)oSheet.Cells[i, 6]).Text.ToString();
                string Email = ((ex_cel.Range)oSheet.Cells[i, 7]).Text.ToString();
                string Diachi = ((ex_cel.Range)oSheet.Cells[i, 8]).Text.ToString();

                if (!string.IsNullOrEmpty(Manv))
                {
                    // 4. Lệnh SQL INSERT
                    string sql = "INSERT INTO  Danhsachnhanvien (Manv, Hoten, Gioitinh, Ngaysinh, Sdt, Email, Diachi) " +
                                 "VALUES ('" + Manv + "', N'" + Hoten + "', N'" + Gioitnh + "', '" + NgaysinhSQL + "', '" + Sdt + "', '" + Email + "', N'" + Diachi + "')";

                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            // 5. Giải phóng bộ nhớ
            oBook.Close(false);
            oExcel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
        }

        private void icnhapfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImportExcel(openFileDialog.FileName);
                    MessageBox.Show("Nhập dữ liệu thành công!", "Thông báo");

                    // Tải lại bảng để thấy dữ liệu mới
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nhập file: " + ex.Message);
                }
            }
        }
    }
}

