using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using Excel = Microsoft.Office.Interop.Excel;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Lichlamviec : Form
    {
        
        public Lichlamviec()
        {
            InitializeComponent();
        }

        private void Lichlamviec_Load(object sender, EventArgs e)
        {
            string sql = @"select 
                   
                    L.Manv AS [Mã nhân viên], 
                    N.Hoten AS [Họ Tên], 
                    L.Ngay AS [Ngày Làm], 
                    L.Ca AS [Ca Làm], 
                    L.Ghichu AS [Ghi chú]
                   from LichLamViec L, Danhsachnhanvien N 
                   where L.Manv = N.Manv
                   ORDER BY L.Ngay DESC";
            Thuvien.load_KH(dgv, sql);
            Taicomboboxnhanvien();
        }
        private void Taicomboboxnhanvien()
        {
            // Viết câu lệnh SQL
            string sql = "SELECT Manv, Hoten FROM Danhsachnhanvien";


            DataTable dt = Thuvien.LayDuLieu(sql);
            DataRow dr = dt.NewRow();
            dr["Manv"] = "";
            dr["Hoten"] = "Chọn nhân viên";
            dt.Rows.InsertAt(dr, 0);
            // Gán vào ComboBox
            nhanvien.DataSource = dt;
            nhanvien.DisplayMember = "Hoten";
            nhanvien.ValueMember = "Manv";

        }


        private void them_Click(object sender, EventArgs e)
        {
            if (nhanvien.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên cụ thể!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ca.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Ca làm việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string manv = nhanvien.SelectedValue.ToString();
                string ngayy = ngay.Value.ToString("yyyy-MM-dd");
                string caa = ca.Text;
                string ghichuu = ghichu.Text;
                string sqlCheck = "SELECT * FROM LichLamViec WHERE Manv = '" + manv + "' AND Ngay = '" + ngayy + "' AND Ca = N'" + caa + "'";
                DataTable dtCheck = Thuvien.LayDuLieu(sqlCheck);

                if (dtCheck.Rows.Count > 0)
                {
                    MessageBox.Show("Nhân viên này đã có lịch vào ca này rồi!", "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sql = "INSERT INTO LichLamViec (Manv, Ngay, Ca, Ghichu) " +
                             "VALUES ('" + manv + "', '" + ngayy + "', N'" + caa + "', N'" + ghichuu + "')";
                Thuvien.upd_del(sql);
                MessageBox.Show("Thêm lịch thành công!");
                Lichlamviec_Load(sender, e);
                nhanvien.SelectedIndex = 0;   
                ngay.Value = DateTime.Now;  
                ca.SelectedIndex = -1;       
                ghichu.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void sua_Click(object sender, EventArgs e)
        {
            if (nhanvien.SelectedIndex == 0 || nhanvien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa trên bảng danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                string manvMoi = nhanvien.SelectedValue.ToString();
                string ngayMoi = ngay.Value.ToString("yyyy-MM-dd");
                string caMoi = ca.Text;
                string ghichuMoi = ghichu.Text;
                //lay du lieu cu
                string manvCu = dgv.CurrentRow.Cells["Mã nhân viên"].Value.ToString();
                string ngayCu = DateTime.Parse(dgv.CurrentRow.Cells["Ngày Làm"].Value.ToString()).ToString("yyyy-MM-dd");
                string caCu = dgv.CurrentRow.Cells["Ca Làm"].Value.ToString();

                string sql = "UPDATE LichLamViec " +
                             "SET Manv = '" + manvMoi + "', Ngay = '" + ngayMoi + "', Ca = N'" + caMoi + "', Ghichu = N'" + ghichuMoi + "' " +
                             "WHERE Manv = '" + manvCu + "' AND Ngay = '" + ngayCu + "' AND Ca = N'" + caCu + "'";


                Thuvien.upd_del(sql);

                MessageBox.Show("Đã sửa thông tin thành công!", "Thông báo");


                Lichlamviec_Load(sender, e);

                nhanvien.SelectedIndex = 0;
                ngay.Value = DateTime.Now;
                ca.SelectedIndex = -1;
                ghichu.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Không thể sửa được. Lỗi: " + ex.Message, "Lỗi SQL");
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dgv.Columns.Contains("Ca Làm") == false) return;
            DataGridViewRow row = dgv.Rows[e.RowIndex];
            nhanvien.SelectedValue = row.Cells["Mã nhân viên"].Value.ToString(); 
            try
            {
                ngay.Value = DateTime.Parse(row.Cells["Ngày Làm"].Value.ToString());
            }
            catch { }

            ca.Text = row.Cells["Ca Làm"].Value.ToString();
            ghichu.Text = row.Cells["Ghi chú"].Value.ToString();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (nhanvien.SelectedIndex == 0 || nhanvien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lịch làm việc cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch làm việc này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (traloi == DialogResult.No) return; 

            try
            {

                string maCanXoa = dgv.CurrentRow.Cells["Mã nhân viên"].Value.ToString();
                string ngayCanXoa = DateTime.Parse(dgv.CurrentRow.Cells["Ngày Làm"].Value.ToString()).ToString("yyyy-MM-dd");
                string caCanXoa = dgv.CurrentRow.Cells["Ca Làm"].Value.ToString();

                string sql = "DELETE FROM LichLamViec " +
                             "WHERE Manv = '" + maCanXoa + "' AND Ngay = '" + ngayCanXoa + "' AND Ca = N'" + caCanXoa + "'";
                Thuvien.upd_del(sql);

                MessageBox.Show("Xóa thành công!", "Thông báo");
                Lichlamviec_Load(sender, e);
                nhanvien.SelectedIndex = 0;
                ngay.Value = DateTime.Now;
                ca.SelectedIndex = -1;
                ghichu.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không xóa được. Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT 
                    L.Manv AS [Mã nhân viên], 
                    N.Hoten AS [Họ Tên], 
                    L.Ngay AS [Ngày Làm], 
                    L.Ca AS [Ca Làm], 
                    L.Ghichu AS [Ghi chú]
                   FROM LichLamViec L, Danhsachnhanvien N 
                   WHERE L.Manv = N.Manv ";

            string maCanTim = txttimkiem.Text.Trim();
            if (maCanTim != "")
            {
                sql += " AND L.Manv LIKE '%" + maCanTim + "%'";
            }

            if (ngaytk.Checked)
            {
                string ngayCanTim = ngaytk.Value.ToString("yyyy-MM-dd");
                sql += " AND L.Ngay = '" + ngayCanTim + "'";
            }
            Thuvien.load_KH(dgv, sql);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
            ngaytk.Checked = false;
            ngaytk.Value = DateTime.Now; 
            Lichlamviec_Load(sender, e);
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Close", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }

        private void thongke_Click(object sender, EventArgs e)
        {
            // Để người dùng biết đang thống kê cho tháng nào
            int thang = ngaytk.Value.Month;
            int nam = ngaytk.Value.Year;

            // 2. Viết câu lệnh SQL dùng GROUP BY để đếm số lượng
            // Logic: Đếm số dòng (COUNT) trong bảng Lịch làm việc, nhóm theo Mã và Tên nhân viên
            string sql = @"SELECT 
                    L.Manv AS [Mã nhân viên], 
                    N.Hoten AS [Họ Tên], 
                    COUNT(L.Ca) AS [Tổng số ca làm],
                    'Tháng " + thang + "/" + nam + @"' AS [Thời gian]
                   FROM LichLamViec L, Danhsachnhanvien N
                   WHERE L.Manv = N.Manv 
                   AND MONTH(L.Ngay) = " + thang + @" 
                   AND YEAR(L.Ngay) = " + nam + @"
                   GROUP BY L.Manv, N.Hoten";

            Thuvien.load_KH(dgv, sql);

            MessageBox.Show("Đang hiển thị thống kê số ca làm việc trong Tháng " + thang + " năm " + nam, "Thông báo");
        }

        private void xuat_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                Excel.Range ten = (Excel.Range)exSheet.Cells[1, 1];
                ten.Font.Size = 12;
                ten.Font.Bold = true;
                ten.Value = "Thống Kê Lịch Làm Việc Của Nhân Viên";

                Excel.Range header = (Excel.Range)exSheet.Cells[3, 1]; 
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    exSheet.Cells[3, i + 1] = dgv.Columns[i].HeaderText;
                }
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null)
                        {
                            exSheet.Cells[i + 4, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                exSheet.Columns.AutoFit();


                exApp.Visible = true;

                // (Hoặc dùng SaveFileDialog nếu muốn lưu file luôn thay vì chỉ mở lên)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi");
            }
        }

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

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();   // Ẩn Trang chủ

            Quanlikho f = new Quanlikho();

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
    }
    }



