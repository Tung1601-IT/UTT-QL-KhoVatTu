using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;

namespace Quản_Lí_Kho_Vật_Tư
{
    internal class Thuvien
    {
        //public static SqlConnection con = new SqlConnection("Data Source=ComputerTungha;Initial Catalog=QL_KhoVatTu;Integrated Security=True");
        public static SqlConnection con = new SqlConnection("Data Source=TRUONGDOAN\\TRUONGDOAN;Initial Catalog=QL_KhoVatTu;User ID=sa;Password=Truong2022005!;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        //public static SqlConnection con = new SqlConnection("Data Source=TRUONGDOAN\\TRUONGDOAN;Initial Catalog=QL_KhoVatTu;User ID=sa;Password=Truong2022005!;Encrypt=True;TrustServerCertificate=True");
        //public static SqlConnection con = new SqlConnection("Data Source=msi\\xuan;Initial Catalog=ql_vattu;Integrated Security=True");

        public static void load_KH(DataGridView dgv, string sql)
        {
            //B1:Kết nối DB
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //B2:tạo đối tượng command để thực hiện câu lệnh sql
            SqlCommand cmd = new SqlCommand(sql, con);
            //b3:tao đối tượng dataAdapter để lấy kq từ cmd
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //b4:Tạo đối tượng dataTable để lấy dl từ da
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();//Giai phong cmd
            con.Close();//ngat ket noi
                        //b5: Đổ dữ liệu từ dataTable vào dataGridView
            dgv.DataSource = tb;
            dgv.Refresh();
        }
        public static void upd_del(string sql)
        {
            //Ket noi DB
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Tao doi tuong command de thuc hien cau lenh sql
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public static void ThemmoiDoitac(string ma, string ten, string nhom,
                   string sdt, string email, string diachi, string ghichu)
        {
            string sql = @"INSERT INTO Doitac_NCC
                  (Madoitac, Tendoitac, Nhomdoitac, SDT, Email, Diachi, Ghichu)
                  VALUES (@Ma, @Ten, @Nhom, @SDT, @Email, @Diachi, @Ghichu)";

            SqlCommand cmd = new SqlCommand(sql, con);
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@Nhom", nhom);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                if (ghichu == null)
                {
                    cmd.Parameters.AddWithValue("@Ghichu", "");
                }
                else
                    cmd.Parameters.AddWithValue("@Ghichu", ghichu);
                if (checkTrung("Doitac_NCC", "Madoitac", ma) || checkTrung("Doitac_NCC", "SDT", sdt) || checkTrung("Doitac_NCC", "Email", email))
                {
                    MessageBox.Show("Có dữ liệu bị trùng lặp hoặc thông tin đã tồn tại.\n Vui lòng kiểm tra lại thông tin.");
                    return;
                }


                if (con.State == ConnectionState.Closed)
                    con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static bool checkTrung(string table, string column, string value)
        {
            string sql = $"SELECT COUNT(*) FROM {table} WHERE {column} = @value";

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@value", value);

            int kq = (int)cmd.ExecuteScalar();

            return kq > 0; // true = trùng
        }
        public static bool checkTrong(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return true;   // trống
            return false;      // không trống
        }
        public static bool checkDienThoai(string dt)
        {
            return dt.Length == 10 && dt.All(char.IsDigit);
        }
        public static bool checkEmail(string email)
        {
            return email.EndsWith("@gmail.com");
        }
        public static bool checkCCCD(string cccd)
        {
            return cccd.Length == 12 && cccd.All(char.IsDigit);
        }
        public static void ThemmoiKhachhang(string ma, string ten, string gt,
                   string sdt, string email, string tt, string diachi, string cccd)
        {
            string sql = @"INSERT INTO Khachhang
                  (Makhachhang, Tenkhachhang, Gioitinh, SDT, Email, Trangthai, Diachinhanhang,CCCD)
                  VALUES (@Ma, @Ten, @Gioitinh, @SDT, @Email, @Trangthai,@Diachi, @CCCD)";

            SqlCommand cmd = new SqlCommand(sql, con);
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@Gioitinh", gt);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Trangthai", tt);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@CCCD", cccd);
                if (checkTrung("Khachhang", "Makhachhang", ma) || checkTrung("Khachhang", "SDT", sdt) || checkTrung("Khachhang", "Email", email) || checkTrung("Khachhang", "CCCD", cccd))
                {
                    MessageBox.Show("Có dữ liệu bị trùng lặp hoặc thông tin đã tồn tại.\n Vui lòng kiểm tra lại thông tin.");
                    return;
                }
                if (con.State == ConnectionState.Closed)
                    con.Open();

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public static void ThemmoiNhanvien(string Manv, string Hoten, string Gioitinh, string Ngaysinh, string Sdt, string Email, string Diachi, string Ngaybatdaulamviec, string Chucdanh, string Phongban, string Chinhanh, string Trangthai, string Mucluong, string Ghichu)
        {
            // 1. Sửa tên bảng thành Nhanvien (viết hoa chữ cái đầu)
            string sql = @"INSERT INTO Nhanvien (Manv, Hoten, Gioitinh, Ngaysinh, Sdt, Email, Diachi, Ngaybatdaulamviec, Chucdanh, Phongban, Chinhanh, Trangthai, Mucluong, Ghichu) 
                   VALUES (@Manv, @Hoten, @Gioitinh, @Ngaysinh, @Sdt, @Email, @Diachi, @Ngaybatdaulamviec, @Chucdanh, @Phongban, @Chinhanh, @Trangthai, @Mucluong, @Ghichu)";

            SqlCommand cmd = new SqlCommand(sql, con); // 'con' là biến kết nối của bạn

            // 2. Nạp đầy đủ 14 tham số khớp với danh sách truyền vào
            cmd.Parameters.AddWithValue("@Manv", Manv);
            cmd.Parameters.AddWithValue("@Hoten", Hoten);
            cmd.Parameters.AddWithValue("@Gioitinh", Gioitinh);
            cmd.Parameters.AddWithValue("@Ngaysinh", Ngaysinh);
            cmd.Parameters.AddWithValue("@Sdt", Sdt);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Diachi", Diachi);
            cmd.Parameters.AddWithValue("@Ngaybatdaulamviec", Ngaybatdaulamviec);
            cmd.Parameters.AddWithValue("@Chucdanh", Chucdanh);
            cmd.Parameters.AddWithValue("@Phongban", Phongban);
            cmd.Parameters.AddWithValue("@Chinhanh", Chinhanh);
            cmd.Parameters.AddWithValue("@Trangthai", Trangthai);
            cmd.Parameters.AddWithValue("@Mucluong", Mucluong);
            cmd.Parameters.AddWithValue("@Ghichu", Ghichu);

            // 3. Mở kết nối và thực thi
            if (con.State == ConnectionState.Closed) con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void SuaNhanvien(string Manv, string Hoten, string Gioitinh, string Ngaysinh, string Sdt, string Email, string Diachi, string Ngaybatdaulamviec, string Chucdanh, string Phongban, string Chinhanh, string Trangthai, string Mucluong, string Ghichu)
        {
            // Sử dụng câu lệnh UPDATE dựa trên khóa chính Manv
            string sql = @"UPDATE Danhsachnhanvien 
                   SET Hoten=@Hoten, Gioitinh=@Gioitinh, Ngaysinh=@Ngaysinh, Sdt=@Sdt, Email=@Email, 
                       Diachi=@Diachi, Ngaybatdaulamviec=@Ngaylam, Chucdanh=@Chucdanh, 
                       Phongban=@Phongban, Chinhanh=@Chinhanh, Trangthai=@Trangthai, 
                       Mucluong=@Mucluong, Ghichu=@Ghichu 
                   WHERE Manv=@Manv";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Manv", Manv);
            cmd.Parameters.AddWithValue("@Hoten", Hoten);
            cmd.Parameters.AddWithValue("@Gioitinh", Gioitinh);
            cmd.Parameters.AddWithValue("@Ngaysinh", Ngaysinh);
            cmd.Parameters.AddWithValue("@Sdt", Sdt);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Diachi", Diachi);
            cmd.Parameters.AddWithValue("@Ngaylam", Ngaybatdaulamviec);
            cmd.Parameters.AddWithValue("@Chucdanh", Chucdanh);
            cmd.Parameters.AddWithValue("@Phongban", Phongban);
            cmd.Parameters.AddWithValue("@Chinhanh", Chinhanh);
            cmd.Parameters.AddWithValue("@Trangthai", Trangthai);
            cmd.Parameters.AddWithValue("@Mucluong", Mucluong);
            cmd.Parameters.AddWithValue("@Ghichu", Ghichu);

            if (con.State == ConnectionState.Closed) con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                da.Fill(dt);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thư viện: " + ex.Message);
            }
            return dt;
        }
    }
}






