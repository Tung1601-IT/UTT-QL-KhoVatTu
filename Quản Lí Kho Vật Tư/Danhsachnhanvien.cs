using FontAwesome.Sharp;
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
    public partial class Danhsachnhanvien : Form
    {
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
    }
}

