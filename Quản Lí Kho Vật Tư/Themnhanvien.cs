using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Themnhanvien : Form
    {
        public Themnhanvien()
        {
            InitializeComponent();
        }
        public bool isEdit = false;
        //tao ham để tự động đổ dữ liệu vào các ô nhập khi ơr chế độ sửa
        public void LoadDataToEdit(string Manv, string Hoten, string Gioitinh, string Ngaysinh, string Sdt, string Email, string Diachi, string Ngaybatdaulamviec, string Chucdanh, string Phongban, string Chinhanh, string Trangthai, string Mucluong, string Ghichu)
        {
            txtmanv.Text = Manv;
            txthoten.Text = Hoten;
            cbgioitinh.Text = Gioitinh;
            datengaysinh.Value = DateTime.Parse(Ngaysinh);
            txtsdt.Text = Sdt;
            txtemail.Text = Email;
            txtdiachi.Text = Diachi;
            datebatdau.Value = DateTime.Parse(Ngaybatdaulamviec);
            cbchucdanh.Text = Chucdanh;
            cbphongban.Text = Phongban;
            cbchinhanh.Text = Chinhanh;
            cbtrangthai.Text = Trangthai;
            txtluong.Text = Mucluong;
            tboxghichu.Text = Ghichu;
        }

        private void ibtnluu_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ các ô nhập liệu
            string Manv = txtmanv.Text;
            string Hoten = txthoten.Text;
            string Gioitinh = cbgioitinh.Text;
            string Ngaysinh = datengaysinh.Value.ToString("yyyy-MM-dd");
            string Sdt = txtsdt.Text;
            string Email = txtemail.Text;
            string Diachi = txtdiachi.Text;
            string Ngaybatdaulamviec = datebatdau.Value.ToString("yyyy-MM-dd");
            string Chucdanh = cbchucdanh.Text;
            string Phongban = cbphongban.Text;
            string Chinhanh = cbchinhanh.Text;
            string Trangthai = cbtrangthai.Text;
            string Mucluong = txtluong.Text;
            string Ghichu = tboxghichu.Text;

            string sql = "";
            //kiem tra điều kiện trống,trùng ràng buộv
            //Không để trống mã nhân viên và họ tên
            if(String.IsNullOrWhiteSpace(Manv) || String.IsNullOrWhiteSpace(Hoten))
            {
                MessageBox.Show("Mã nhân viên và Họ tên không được để trống!");
                return;
            }
            //Kiểm tra trùng mã nhân viên khi THÊM MỚI
            if (txtmanv.Enabled == true && Thuvien.checkTrung("Danhsachnhanvien", "Manv", Manv))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng sử dụng mã khác.");
                return;
            }
            //Kiem tra dinh dang sdt
            if(!string.IsNullOrEmpty(Sdt) && !Thuvien.checkDienThoai(Sdt))
            {
                MessageBox.Show("Số điện thoại không đúng định dạng.");
                return;
            }
            //Kiem tra dinh dang email
            if(!string.IsNullOrEmpty(Email) && !Thuvien.checkEmail(Email))
            {
                MessageBox.Show("Email không đúng định dạng.");
                return;
            }

            // 2. Kiểm tra nếu txtmanv đang bị khóa (Enabled = false) thì là đang SỬA
            if (txtmanv.Enabled == false)
            {
                // Câu lệnh UPDATE dựa trên Manv
                sql = string.Format(@"UPDATE Danhsachnhanvien 
              SET Hoten=N'{1}', Gioitinh=N'{2}', Ngaysinh='{3}', Sdt='{4}', Email='{5}', Diachi=N'{6}', 
                  Ngaybatdaulamviec='{7}', Chucdanh=N'{8}', Phongban=N'{9}', Chinhanh=N'{10}', 
                  Trangthai=N'{11}', Mucluong='{12}', Ghichu=N'{13}' 
              WHERE Manv='{0}'",
                      Manv, Hoten, Gioitinh, Ngaysinh, Sdt, Email, Diachi,
                      Ngaybatdaulamviec, Chucdanh, Phongban, Chinhanh, Trangthai, Mucluong, Ghichu);
            }
            else
            {
                // Câu lệnh INSERT mới hoàn toàn
                sql = string.Format(@"INSERT INTO Danhsachnhanvien 
              VALUES ('{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', N'{6}', '{7}', N'{8}', N'{9}', N'{10}', N'{11}', '{12}', N'{13}')",
                      Manv, Hoten, Gioitinh, Ngaysinh, Sdt, Email, Diachi,
                      Ngaybatdaulamviec, Chucdanh, Phongban, Chinhanh, Trangthai, Mucluong, Ghichu);
            }

            try
            {
                Thuvien.upd_del(sql);
                MessageBox.Show(txtmanv.Enabled ? "Thêm nhân viên thành công!" : "Cập nhật nhân viên thành công!");

                // Trả về kết quả OK để Form Danh sách biết mà Load lại bảng
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gbthemnv_Enter(object sender, EventArgs e)
        {

        }

        private void lbthemnv_Click(object sender, EventArgs e)
        {

        }

        private void Themnhanvien_Load(object sender, EventArgs e)
        {

        }

        private void panelfill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbngaybatdau_Click(object sender, EventArgs e)
        {

        }
    }
}
