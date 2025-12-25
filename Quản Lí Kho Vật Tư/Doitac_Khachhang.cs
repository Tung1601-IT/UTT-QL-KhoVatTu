using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ex_cel = Microsoft.Office.Interop.Excel;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Doitac_Khachhang : Form
    {
        public Doitac_Khachhang()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiachi.Clear();
            txtCCCD.Clear();

            if (cboGioitinh.Items.Count > 0)
                cboGioitinh.SelectedIndex = 0;
            if (cboTrangthai.Items.Count > 0)
                cboTrangthai.SelectedIndex = 0;
            lbMaKH.Text = "";
            lbTenKH.Text = "";
            lbSDT.Text = "";
            lbEmail.Text = "";
            lbDiachi.Text = "";
            lbGioitinh.Text = "";
            lbCCCD.Text = "";
            lbTrangthai.Text = "";

            txtMaKH.Focus();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            // B1: Lấy dữ liệu trên các đk đưa vào biến
            string mkh = txtMaKH.Text.Trim();
            string ht = txtTenKH.Text.Trim();
            string gt = cboGioitinh.SelectedItem.ToString().Trim();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string tt=cboTrangthai.SelectedItem.ToString().Trim();
            string dc = txtDiachi.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            if (cboGioitinh.SelectedItem == null)
                gt = "";
            else
                gt= cboGioitinh.SelectedItem.ToString();

            if (cboTrangthai.SelectedItem == null)
                tt = "";
            else
                tt = cboTrangthai.SelectedItem.ToString();

            if (Thuvien.checkTrong(mkh))
            {
                txtMaKH.Focus();
                lbMaKH.Text = "Mã khách hàng không được để trống";
                lbMaKH.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(ht))
            {
                txtTenKH.Focus();
                lbTenKH.Text = "Tên khách hàng không được để trống";
                lbTenKH.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(gt))
            {
                cboGioitinh.Focus();
                lbGioitinh.Text = "Giới tính không được để trống";
                lbGioitinh.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dt))
            {
                txtSDT.Focus();
                lbSDT.Text = "Số điện thoại không được để trống";
                lbSDT.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(mail))
            {
                txtEmail.Focus();
                lbEmail.Text = "Email không được để trống";
                lbEmail.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(tt))
            {
                cboTrangthai.Focus();
                lbTrangthai.Text = "Trạng thái không được để trống";
                lbTrangthai.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(dc))
            {
                txtDiachi.Focus();
                lbDiachi.Text = "Địa chỉ không được để trống";
                lbDiachi.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(cccd))
            {
                txtCCCD.Focus();
                lbCCCD.Text = "CCCD không được để trống";
                lbCCCD.ForeColor = Color.Red;
                return;
            }

            //Kiem tra trung ma
            //B2:Kết nối DB

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            //B3: Tạo đối tượng command để thực thi câu lệnh sql
            string sql = "Insert Khachhang values(@mkh,@ht,@gt,@dt,@mail,@tt,@dc,@cccd)";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@mkh", SqlDbType.NVarChar, 50).Value = mkh;
            cmd.Parameters.Add("@ht", SqlDbType.NVarChar, 50).Value = ht;
            cmd.Parameters.Add("@gt", SqlDbType.NVarChar, 50).Value = gt;
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 10).Value = dt;
            cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = mail;
            cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 100).Value = tt;
            cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 50).Value = dc;
            cmd.Parameters.Add("@cccd", SqlDbType.NVarChar, 100).Value = cccd;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Thuvien.con.Close();
            MessageBox.Show("Thêm mới thành công");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
            ClearForm();
        }

        private void Doitac_Khachhang_Load(object sender, EventArgs e)
        {
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i=e.RowIndex;
            txtMaKH.Text = Convert.ToString(dgvKH.Rows[i].Cells["MaKH"].Value);
            txtTenKH.Text = Convert.ToString(dgvKH.Rows[i].Cells["Hoten"].Value);
            cboGioitinh.Text = Convert.ToString(dgvKH.Rows[i].Cells["Gioitinh"].Value);
            txtSDT.Text = Convert.ToString(dgvKH.Rows[i].Cells["SDT"].Value);
            txtEmail.Text= Convert.ToString(dgvKH.Rows[i].Cells["Email"].Value);
            cboTrangthai.Text = Convert.ToString(dgvKH.Rows[i].Cells["Trangthai"].Value);
            txtDiachi.Text = Convert.ToString(dgvKH.Rows[i].Cells["Diachinhanhang"].Value);
            txtCCCD.Text = Convert.ToString(dgvKH.Rows[i].Cells["CCCD"].Value);
            txtMaKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH.Text.Trim();
            string ht = txtTenKH.Text.Trim();
            string gt = cboGioitinh.SelectedItem.ToString().Trim();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string tt = cboTrangthai.SelectedItem.ToString().Trim();
            string dc = txtDiachi.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            Thuvien.upd_del("Update Khachhang set Tenkhachhang=N'" + ht + "',Gioitinh=N'" + gt + "',SDT='" + dt + "',Email='" + mail + "',Trangthai=N'" + tt + "',Diachi=N'" + dc + "',CCCD=N'"+cccd+"' where Makhachhang='" + mkh + "'");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH.Text.Trim();
            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("Delete from Khachhang where Makhachhang='" + mkh + "'");
            MessageBox.Show("Xoa thanh cong");
            Thuvien.load_KH(dgvKH, "Select* from Khachhang");
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH_tk.Text.Trim();
            string ht = txtTenKH_tk.Text.Trim();
            string sdt = txtSDT_tk.Text.Trim();
            string tt = cboTrangthai_tk.Text.Trim();
            Thuvien.load_KH(dgvKH, "Select * from Khachhang where Makhachhang like '%" + mkh + "%' and " +
                "Tenkhachhang like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Trangthai like N'%" + tt + "%'");
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string makh=txtMaKH.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "Makhachhang", makh))
            {
                lbMaKH.Text = "Mã khách hàng đã tồn tại";
                lbMaKH.ForeColor=Color.Red;
            }
            else
            {
                lbMaKH.Text = "";
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "SDT", sdt))
            {
                lbSDT.Text = "Số điện thoại đã tồn tại";
                lbSDT.ForeColor = Color.Red;
            }
            else
            {
                lbSDT.Text = "";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string mail = txtEmail.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "Email", mail))
            {
                lbEmail.Text = "Email đã tồn tại";
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.Text = "";
            }
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (Thuvien.checkTrung("Khachhang", "CCCD", cccd))
            {
                lbCCCD.Text = "CCCD đã tồn tại";
                lbCCCD.ForeColor = Color.Red;
            }
            else
            {
                lbCCCD.Text = "";
            }
        }
        private void btnXuatExcel_Click_1(object sender, EventArgs e)
        {
            using (FileExcecl_KH f = new FileExcecl_KH())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    Thuvien.load_KH(dgvKH, "Select * from Khachhang");
                }
            }
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
            ex_cel.Range head = oSheet.get_Range("A1", "H1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH KHÁCH HÀNG";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "16";
            head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "STT";
            cl1.ColumnWidth = 7.5;

            ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ KHÁCH HÀNG";
            cl2.ColumnWidth = 25.0;

            ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN KHÁCH HÀNG";
            cl3.ColumnWidth = 40.0;

            ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "GIỚI TÍNH";
            cl4.ColumnWidth = 15.0;

            ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "ĐIỆN THOẠI";
            cl5.ColumnWidth = 20.0;

            ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "EMAIL";
            cl6.ColumnWidth = 40.0;

            ex_cel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "TRẠNG THÁI";
            cl7.ColumnWidth = 20.0;

            ex_cel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "ĐỊA CHỈ";
            cl8.ColumnWidth = 50.0;

            ex_cel.Range cl9 = oSheet.get_Range("K3", "K3");
            cl9.Value2 = "CCCD";
            cl9.ColumnWidth = 20.0;

            //ex_cel.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";

            ex_cel.Range rowHead = oSheet.get_Range("A3", "K3");
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
                    if (c == 4||c==8)
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
            ex_cel.Range cl_ngs = oSheet.get_Range("D" + rowStart, "D" + rowEnd);
            cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";

        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            string mkh = txtMaKH_tk.Text.Trim();
            string ht = txtTenKH_tk.Text.Trim();
            string sdt = txtSDT_tk.Text.Trim();
            string tt = cboTrangthai_tk.Text.Trim();
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            string sql = "Select ROW_NUMBER() over(order by Makhachhang) STT,* from Khachhang where Makhachhang like '%" + mkh + "%' and " +
                "Tenkhachhang like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Trangthai like N'%" + tt + "%'";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            //B4: Tao doi tuong 
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //B5:Tao doi tuong datatable de lay du lieu tu da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            Thuvien.con.Close();
            ExportExcel(tb, "DSDoitac");
        }
    }
    }
    

