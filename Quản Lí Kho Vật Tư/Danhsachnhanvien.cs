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
        //SqlConnection con = new SqlConnection("Data Source=ComputerTungha;Initial Catalog=QL_KhoVatTu;Integrated Security=True");
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
        public void ExportExcel(System.Data.DataTable tb, string sheetname)
        {
            //1.Tao cac doi tuong Excel 
            // 1. Tạo các đối tượng Excel
            ex_cel.Application oExcel = new ex_cel.Application();
            ex_cel.Workbooks oBooks = oExcel.Workbooks;
            // Sửa dòng dưới: Gán trực tiếp khi Add và ép kiểu tường minh
            ex_cel.Workbook oBook = (ex_cel.Workbook)oBooks.Add(Type.Missing);
            ex_cel.Sheets oSheets = oBook.Worksheets;
            // Sửa dòng dưới: Ép kiểu tường minh để tránh lỗi CS0266
            ex_cel.Worksheet oSheet = (ex_cel.Worksheet)oBook.ActiveSheet;

            oSheet.Name = sheetname;
            //Tạo mới một Excel WorkBook 
            oSheet.get_Range("A3", "O3").EntireColumn.AutoFit();
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
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Ma Nhan Vien";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Ho va ten";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
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

            ex_cel.Range cl8 = oSheet.get_Range("H3", " H3");
            cl8.Value2 = "Dia chi";
            cl8.ColumnWidth = 55.0;

            // 9.Ngày bắt đầu làm việc
            ex_cel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Ngày bắt đầu";
            cl9.ColumnWidth = 20.0;

            // 10. Chức danh
            ex_cel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Chức danh";
            cl10.ColumnWidth = 20.0;

            // 11. Phòng ban
            ex_cel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "Phòng ban";
            cl11.ColumnWidth = 20.0;

            // 12. Chi nhánh
            ex_cel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "Chi nhánh";
            cl12.ColumnWidth = 20.0;

            // 13. Trạng thái
            ex_cel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "Trạng thái";
            cl13.ColumnWidth = 15.0;

            // 14. Mức lương
            ex_cel.Range cl14 = oSheet.get_Range("N3", "N3");
            cl14.Value2 = "Mức lương";
            cl14.ColumnWidth = 15.0;

            // 15. Ghi chú
            ex_cel.Range cl15 = oSheet.get_Range("O3", "O3");
            cl15.Value2 = "Ghi chú";
            cl15.ColumnWidth = 30.0;


            //Dinh dang hang tieu de
            ex_cel.Range rowHead = oSheet.get_Range("A3", "O3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = ex_cel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, 15];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                arr[r, 0] = r + 1;//STT
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    if (c == 4)
                        arr[r, c + 1] = "'" + dr[c];
                    else
                        arr[r, c + 1] = dr[c];

                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count + 1;
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
            ex_cel.Range cl_ngs = oSheet.get_Range("E4", "E" + (tb.Rows.Count + 3).ToString());
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";
            oExcel.Visible = true;
            //Định dạng ngày bắt đầu
            ex_cel.Range cl_ngbd = oSheet.get_Range("I4", "I" + (tb.Rows.Count + 3).ToString());
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";
            oExcel.Visible = true;
            // Định dạng cột N (Mức lương)
            ex_cel.Range cl_luong = oSheet.get_Range("N4", "N" + (tb.Rows.Count + 3).ToString());
            cl_luong.Columns.NumberFormat = "#,##0";
        }
        private void ibtnxuatfile_Click(object sender, EventArgs e)
        {
            //Lay du lieu tren dgv dua vao datatable
            System.Data.DataTable dt = (System.Data.DataTable)dgnhanvien.DataSource;
            if (dt != null && dt.Rows.Count > 0)
            {
                ExportExcel(dt, "Danh sach nhan vien");
            }
            else
            {
                MessageBox.Show("Khong co du lieu de xuat ra file Excel", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void icnhapfile_Click(object sender, EventArgs e)
        {
            FileExcel_NV frm = new FileExcel_NV();

            // Khi Form Excel đóng lại với kết quả OK
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Tự động làm mới bảng nhân viên
            }
        }

        private void ibtnxoa_Click(object sender, EventArgs e)
        {
            string Manv = txtmanv.Text.Trim(); // .Trim() để loại bỏ khoảng trắng thừa
            if (string.IsNullOrEmpty(Manv))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                // Sửa câu lệnh chỉ dùng Manv để xóa
                string sql = "DELETE FROM Danhsachnhanvien WHERE Manv = '" + Manv + "'";

                Thuvien.upd_del(sql);
                MessageBox.Show("Xóa nhân viên thành công");

                // Gọi lại hàm LoadData để cập nhật DataGridView
                LoadData();
            }
        }

        private void dgnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgnhanvien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Themnhanvien tnv = new Themnhanvien();
                DataGridViewRow row = dgnhanvien.Rows[e.RowIndex];

                // --- NHÓM THÔNG TIN CÁ NHÂN ---
                tnv.txtmanv.Text = row.Cells["fgmanv"].Value.ToString();
                tnv.txthoten.Text = row.Cells["gdhoten"].Value.ToString();
                tnv.cbgioitinh.Text = row.Cells["dggioitinh"].Value.ToString();
                tnv.datengaysinh.Value = Convert.ToDateTime(row.Cells["dgngaysinh"].Value);
                tnv.txtsdt.Text = row.Cells["dgsdt"].Value.ToString();
                tnv.txtemail.Text = row.Cells["dgemail"].Value.ToString();
                tnv.txtdiachi.Text = row.Cells["dgdiachi"].Value.ToString();

                // --- NHÓM THÔNG TIN CÔNG VIỆC  ---
                // 1. Ngày bắt đầu làm việc
                if (row.Cells["dgngaybatdaulamviec"].Value != DBNull.Value)
                    tnv.datebatdau.Value = Convert.ToDateTime(row.Cells["dgngaybatdaulamviec"].Value);

                // 2. Chức danh
                tnv.cbchucdanh.Text = row.Cells["dgchucdanh"].Value.ToString();

                // 3. Phòng ban
                tnv.cbphongban.Text = row.Cells["dgphongban"].Value.ToString();

                // 4. Chi nhánh
                tnv.cbchinhanh.Text = row.Cells["dgchinhanh"].Value.ToString();

                // 5. Trạng thái
                tnv.cbtrangthai.Text = row.Cells["dgtrangthai"].Value.ToString();

                // 6. Mức lương
                tnv.txtluong.Text = row.Cells["dgmucluong"].Value.ToString();

                // 7. Ghi chú
                tnv.tboxghichu.Text = row.Cells["dgghichu"].Value.ToString();

                // --- CẤU HÌNH FORM ---
                tnv.txtmanv.Enabled = false; // Khóa mã nhân viên vì là khóa chính (Primary Key)

                // Hiển thị Form và chờ phản hồi
                if (tnv.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Tự động làm mới bảng sau khi người dùng nhấn Lưu
                }
            }
        }
    }
}

