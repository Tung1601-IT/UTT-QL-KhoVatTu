using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xls = Microsoft.Office.Interop.Excel;
namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class FileExcel_KH : Form
    {
        public FileExcel_KH()
        {
            InitializeComponent();
        }

        private void btnDowload_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file (*.xlsx)|*.xlsx";
            sfd.FileName = "FileMauKH.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] fileData = Properties.Resources.FileMauKH;

                    // Ghi dữ liệu ra file tại vị trí người dùng chọn
                    System.IO.File.WriteAllBytes(sfd.FileName, fileData);

                    MessageBox.Show("Tải file Excel mẫu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
        string duongdan = "";

        private void btnChonTep_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog1.Title = "Chọn file Excel để tải lên";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                duongdan = openFileDialog1.FileName;

                string tenfile = System.IO.Path.GetFileName(duongdan);

                lbTenFile.Text = tenfile;

                lbTenFile.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (duongdan == "")
            {
                MessageBox.Show("Vui lòng chọn file! ");
                return;
            }

            xls.Application Excel = new xls.Application();
            Excel.Workbooks.Open(duongdan);

            foreach (xls.Worksheet wsheet in Excel.Worksheets)
            {
                int i = 2;
                while (true)
                {
                    if (wsheet.Cells[i, 1].Value == null || wsheet.Cells[i, 2].Value == null ||
                        wsheet.Cells[i, 3].Value == null || wsheet.Cells[i, 4].Value == null ||
                        wsheet.Cells[i, 5].Value == null || wsheet.Cells[i, 6].Value == null)
                    {
                        break;
                    }

                    string ma = wsheet.Cells[i, 1].Value.ToString();
                    string ten = wsheet.Cells[i, 2].Value.ToString();
                    string gt = wsheet.Cells[i, 3].Value.ToString();
                    string sdt = wsheet.Cells[i, 4].Value.ToString();
                    string email = wsheet.Cells[i, 5].Value.ToString();
                    string tt = wsheet.Cells[i, 6].Value.ToString();
                    string diachi = wsheet.Cells[i, 7].Value.ToString();
                    string cccd = wsheet.Cells[i, 8].Value.ToString();

                    if (Thuvien.checkTrung("Khachhang", "Makhachhang", ma) ||
                        Thuvien.checkTrung("Khachhang", "SDT", sdt) ||
                        Thuvien.checkTrung("Khachhang", "Email", email)||
                        Thuvien.checkTrung("Khachhang", "CCCD", cccd))
                    {
                        MessageBox.Show($"Dòng {i} bị trùng dữ liệu hoặc dữ liệu đã tồn tại.\n Vui lòng kiểm tra lại thông tin.");
                        return;
                    }

                    Thuvien.ThemmoiDoitac(ma, ten,gt, sdt, email,tt,diachi, cccd);
                    i++;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
