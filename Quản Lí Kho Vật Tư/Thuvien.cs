using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí_Kho_Vật_Tư
{
    internal class Thuvien
    {
        public static SqlConnection con = new SqlConnection("Data Source = MSI\\xuan;Initial Catalog = QL_KhoVatTu; Integrated Security = True");
        public static void load_KH(DataGridView dgv,string sql)
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

            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Ma", ma);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@Nhom", nhom);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@Ghichu", ghichu);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
            public  static bool checkTrung(string table, string column, string value)
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

    }


}

