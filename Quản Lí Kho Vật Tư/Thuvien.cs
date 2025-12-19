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
        public static SqlConnection con = new SqlConnection("Data Source=ComputerTungha;Initial Catalog=QL_KhoVatTu;Integrated Security=True");
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


    }
}
