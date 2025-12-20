using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using xls = Microsoft.Office.Interop.Excel;
namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class FileExcel : Form
    {
        public FileExcel()
        {
            InitializeComponent();
        }

        private void btnDowload_Click(object sender, EventArgs e)
        {
        
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file (*.xlsx)|*.xlsx";
            sfd.FileName = "FileNhap.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Lấy dữ liệu trực tiếp từ bộ nhớ chương trình (Resources)
                    // 'FileNhap' phải khớp với tên trong bảng Resources của bạn
                    byte[] fileData = Properties.Resources.FileNhap;

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

            // Mở hộp thoại chọn file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 1. Lấy đường dẫn đầy đủ của file
                duongdan = openFileDialog1.FileName;

                // 2. Tách riêng tên file để hiển thị (ví dụ: FileNhap.xlsx)
                string tenfile = System.IO.Path.GetFileName(duongdan);

                // 3. Cập nhật tên file lên Label lbFileName
                lbTenFile.Text = tenfile;

                lbTenFile.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            //kiểm tra xem filename đã có dữ liệu chưa
            if (duongdan == null)
            {
                MessageBox.Show("Chưa chọn file");
            }
            else
            {
                xls.Application Excel = new xls.Application();// tạp một app làm việc mới
                                                              // mở dữ liệu từ file
                Excel.Workbooks.Open(duongdan);
                //đọc dữ liệu từng sheet của excel
                foreach (xls.Worksheet wsheet in Excel.Worksheets)
                {
                    int i = 2;  //để đọc từng dòng của sheet bắt đầu từ dòng số 2
                    do
                    {
                        if (wsheet.Cells[i, 1].Value == null && wsheet.Cells[i, 2].Value == null && wsheet.Cells[i, 3].Value == null)
                        {
                            break;
                        }
                        else
                        {
                            //Đổ dòng dữ liệu vào DB
                            Thuvien.ThemmoiDoitac(wsheet.Cells[i, 1].Value, wsheet.Cells[i, 2].Value, wsheet.Cells[i, 3].Value, wsheet.Cells[i, 4].Value, wsheet.Cells[i, 5].Value, wsheet.Cells[i, 6].Value, wsheet.Cells[i, 7].Value);
                            i++;
                        }
                    }
                    while (true);
                }
            }
        }
    }

    }


