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
    public partial class SuaKhachhang : Form
    {
        public string MaKH { get; private set; }
        public string TenKH { get; private set; }
        public string GioiTinh { get; private set; }
        public string SDT { get; private set; }
        public string Email { get; private set; }
        public string DiaChi { get; private set; }
        public string TrangThai { get; private set; }
        public string CCCD { get; private set; }
        public SuaKhachhang(string mkh,string ht,string gt,string sdt,string email,string tt, string diachi,string cccd)
        {
            InitializeComponent();
            txtMaKH.Text = mkh;
            txtTenKH.Text = ht;
            cboGioitinh.Text = gt;
            txtSDT.Text = sdt;
            txtEmail.Text = email;
            cboTrangthai.Text = tt;
            txtDiachi.Text = diachi;
            txtCCCD.Text = cccd;
            txtMaKH.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MaKH = txtMaKH.Text;
            TenKH = txtTenKH.Text;
            GioiTinh = cboGioitinh.Text;
            SDT = txtSDT.Text;
            Email = txtEmail.Text;
            TrangThai = cboTrangthai.Text;
            DiaChi = txtDiachi.Text;
            CCCD = txtCCCD.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
