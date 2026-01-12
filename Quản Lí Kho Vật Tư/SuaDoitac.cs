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
    public partial class SuaDoitac : Form
    {
        public string Madoitac { get; private set; }
        public string Tendoitac { get; private set; }
        public string Nhomdoitac { get; private set; }
        public string SDT { get; private set; }
        public string Email { get; private set; }
        public string Diachi { get; private set; }
        public string Ghichu { get; private set; }
        public SuaDoitac(string mdt, string ht, string nhom, string sdt, string email,string diachi, string ghichu)
        {
            InitializeComponent();
            txtMadoitac.Text = mdt;
            txtTendoitac.Text = ht;
            cboNhomdoitac.Text = nhom;
            txtSDT.Text = sdt;
            txtEmail.Text = email;
            txtDiachi.Text = diachi;
            txtGhichu.Text = ghichu;
            txtMadoitac.ReadOnly = true;
            cboNhomdoitac.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Madoitac= txtMadoitac.Text;
            Tendoitac = txtTendoitac.Text;
            Nhomdoitac = cboNhomdoitac.Text;
            SDT = txtSDT.Text;
            Email = txtEmail.Text;
            Diachi = txtDiachi.Text;
            Ghichu = txtGhichu.Text;

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
