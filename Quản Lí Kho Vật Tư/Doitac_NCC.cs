
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using ex_cel = Microsoft.Office.Interop.Excel;
namespace Quản_Lí_Kho_Vật_Tư
{
    
    public partial class Doitac_NCC : Form
    {
        public Doitac_NCC()
        {
            InitializeComponent();
            
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            // B1: Lấy dữ liệu trên các đk đưa vào biến
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string nhom;
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string ghichu=txtGhichu.Text.Trim();
            if (cboNhomdoitac.SelectedItem == null)
                nhom = "";
            else
                nhom = cboNhomdoitac.SelectedItem.ToString();
            if (Thuvien.checkTrong(mdt))
            {
                txtMadoitac.Focus();
                lbMadoitac.Text = "Mã đối tác không được để trống";
                lbMadoitac.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(ht))
            {
                txtTendoitac.Focus();
                lbTendoitac.Text = "Tên đối tác không được để trống";
                lbTendoitac.ForeColor = Color.Red;
                return;
            }
            if (Thuvien.checkTrong(nhom))
            {
                cboNhomdoitac.Focus();
                lbNhomdoitac.Text = "Nhóm đối tác không được để trống";
                lbNhomdoitac.ForeColor = Color.Red;
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
            if (Thuvien.checkTrong(dc))
            {
                txtDiachi.Focus();
                lbDiachi.Text = "Địa chỉ không được để trống";
                lbDiachi.ForeColor = Color.Red;
                return;
            }
            if (!Thuvien.checkDienThoai(dt))
            {
                txtSDT.Focus();
                MessageBox.Show("Số điện thoại không đúng...");
                return;
            }
            if (!Thuvien.checkEmail(mail))
            {
                txtEmail.Focus();
                MessageBox.Show("Email không đúng...");
                return;
            }

            //B2:Kết nối DB

            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();
            //B3: Tạo đối tượng command để thực thi câu lệnh sql
            string sql = "Insert Doitac_NCC values(@mdt,@ht,@nhom,@dt,@mail,@dc,@ghichu)";
            SqlCommand cmd = new SqlCommand(sql, Thuvien.con);
            cmd.Parameters.Add("@mdt", SqlDbType.NVarChar, 50).Value = mdt;
            cmd.Parameters.Add("@ht", SqlDbType.NVarChar, 50).Value = ht;
            cmd.Parameters.Add("@nhom", SqlDbType.NVarChar, 50).Value = nhom;
            cmd.Parameters.Add("@dt", SqlDbType.VarChar, 10).Value = dt;
            cmd.Parameters.Add("@mail", SqlDbType.NVarChar, 50).Value = mail;
            cmd.Parameters.Add("@dc", SqlDbType.NVarChar, 50).Value = dc;
            cmd.Parameters.Add("@ghichu", SqlDbType.NVarChar, 100).Value = ghichu;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Thuvien.con.Close();
            MessageBox.Show("Thêm mới thành công");
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");

        }

        private void Doitac_NCC_Load(object sender, EventArgs e)
        {
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMadoitac.Text = dgvNCC.Rows[i].Cells[0].Value.ToString();
            txtTendoitac.Text=dgvNCC.Rows[i].Cells[1].Value.ToString();
            cboNhomdoitac.Text= dgvNCC.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text= dgvNCC.Rows[i].Cells[3].Value.ToString();
            txtEmail.Text= dgvNCC.Rows[i].Cells[4].Value.ToString();
            txtDiachi.Text= dgvNCC.Rows[i].Cells[5].Value.ToString();
            txtGhichu.Text= dgvNCC.Rows[i].Cells[6].Value.ToString();
            txtMadoitac.Enabled=false;
            cboNhomdoitac.Enabled=false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string nhom = cboNhomdoitac.SelectedItem.ToString();
            string dt = txtSDT.Text.Trim();
            string mail = txtEmail.Text.Trim();
            string dc = txtDiachi.Text.Trim();
            string ghichu = txtGhichu.Text.Trim();
            Thuvien.upd_del("Update Doitac_NCC set Tendoitac=N'"+ht+ "',Nhomdoitac=N'"+nhom+"',SDT='"+dt+"',Email='"+mail+"',Diachi=N'"+dc+"',Ghichu=N'"+ghichu+"' where Madoitac='"+mdt+"'");
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mdt= txtMadoitac.Text.Trim();
            DialogResult kq = MessageBox.Show("Ban chac chan muon xoa?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                return;
            Thuvien.upd_del("Delete from Doitac_NCC where Madoitac='" + mdt + "'");
            MessageBox.Show("Xoa thanh cong");
            Thuvien.load_KH(dgvNCC, "Select* from Doitac_NCC");
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string mdt=txtMadoitac_tk.Text.Trim();
            string ht=txtTendoitac_tk.Text.Trim();
            string sdt=txtSDT_tk.Text.Trim();
            string nhom=cboNhomdoitac_tk.Text.Trim();
            Thuvien.load_KH(dgvNCC,"Select * from Doitac_NCC where Madoitac like '%" + mdt + "%' and " +
                "Tendoitac like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Nhomdoitac like N'%" + nhom + "%'");
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
    head.Value2 = "DANH SÁCH ĐỐI TÁC";
    head.Font.Bold = true;
    head.Font.Name = "Tahoma";
    head.Font.Size = "16";
    head.HorizontalAlignment = ex_cel.XlHAlign.xlHAlignCenter;
    // Tạo tiêu đề cột 
    ex_cel.Range cl1 = oSheet.get_Range("A3", "A3");
    cl1.Value2 = "STT";
    cl1.ColumnWidth = 7.5;

    ex_cel.Range cl2 = oSheet.get_Range("B3", "B3");
    cl2.Value2 = "MÃ ĐỐI TÁC";
    cl2.ColumnWidth = 25.0;

    ex_cel.Range cl3 = oSheet.get_Range("C3", "C3");
    cl3.Value2 = "TÊN ĐỐI TÁC";
    cl3.ColumnWidth = 40.0;

    ex_cel.Range cl4 = oSheet.get_Range("D3", "D3");
    cl4.Value2 = "NHÓM ĐỐI TÁC";
    cl4.ColumnWidth = 15.0;

    ex_cel.Range cl5 = oSheet.get_Range("E3", "E3");
    cl5.Value2 = "ĐIỆN THOẠI";
    cl5.ColumnWidth = 25.0;

    ex_cel.Range cl6 = oSheet.get_Range("F3", "F3");
    cl6.Value2 = "EMAIL";
    cl6.ColumnWidth = 40.0;

    ex_cel.Range cl7 = oSheet.get_Range("G3", "G3");
    cl7.Value2 = "ĐỊA CHỈ";
    cl7.ColumnWidth = 60.0;

    ex_cel.Range cl8 = oSheet.get_Range("H3", "H3");
    cl8.Value2 = "GHI CHÚ";
    cl8.ColumnWidth = 60.0;
            //ex_cel.Range cl6_1 = oSheet.get_Range("F4", "F1000");
            //cl6_1.Columns.NumberFormat = "dd/mm/yyyy";

    ex_cel.Range rowHead = oSheet.get_Range("A3", "H3");
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
    ex_cel.Range cl_ngs = oSheet.get_Range("D" + rowStart, "D" + rowEnd);
    cl_ngs.Columns.NumberFormat = "dd/mm/yyyy";

}
        private void btnXuat_Click(object sender, EventArgs e)
        {
            string mdt = txtMadoitac.Text.Trim();
            string ht = txtTendoitac.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string nhom = cboNhomdoitac.Text.Trim();
            if (Thuvien.con.State == ConnectionState.Closed)
                Thuvien.con.Open();

            string sql = " Select ROW_NUMBER() over(order by Madoitac) STT, * from Doitac_NCC where Madoitac like '%" + mdt + "%' and " +
                "Tendoitac like N'%" + ht + "%' and " +
                "SDT like N'%" + sdt + "%' and " +
                "Nhomdoitac like N'%" + nhom + "%'";
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

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            using (FileExcel f = new FileExcel())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    Thuvien.load_KH(dgvNCC,"Select * from DOitac_NCC"); 
                }
            }
        }

        private void txtMadoitac_TextChanged(object sender, EventArgs e)
        {
            string mdt = txtMadoitac.Text.Trim();
            if (Thuvien.checkTrung("Doitac_NCC", "Madoitac", mdt))
            {
                lbMadoitac.Text = "Mã đối tác đã tồn tại.";
                lbMadoitac.ForeColor = Color.Red;
            }
            else
            {
                lbMadoitac.Text = "";
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string dt=txtSDT.Text.Trim();
            if (Thuvien.checkTrung("Doitac_NCC", "SDT", dt))
            {
                lbSDT.Text = "Số điện thoại đã tồn tại.";
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
            if (Thuvien.checkTrung("Doitac_NCC", "Email", mail))
            {
                lbEmail.Text = "Email đã tồn tại.";
                lbEmail.ForeColor = Color.Red;
            }
            else
            {
                lbEmail.Text = "";
            }
        }

        private void Doitac_NCC_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
    }

