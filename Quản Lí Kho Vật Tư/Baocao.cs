using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartSeries = System.Windows.Forms.DataVisualization.Charting.Series;

namespace Quản_Lí_Kho_Vật_Tư
{
    public partial class Baocao : Form
    {
        public Baocao()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private System.Data.DataTable Getthongkexuatnhapton(DateTime tuNgay,DateTime denNgay)
        {
            System.Data.DataTable dt=new System.Data.DataTable();
            string sql = @"Select 
            vt.Mavattu AS MAVT,
            vt.Tenvattu AS TenVT,
            ISNULL(SUM(pnct.Soluong),0) AS TONGNHAP,
            ISNULL(SUM(pxct.Soluong),0) AS TONGXUAT,
            ISNULL(SUM(pnct.Soluong),0)-ISNULL(SUM(pxct.Soluong),0) AS TONKHO
            FROM QL_Kho vt
            LEFT JOIN Phieunhap_CT pnct ON vt.Mavattu=pnct.MaVT
            LEFT JOIN Phieunhap pn ON pnct.MaHD=pn.MaHD
            LEFT JOIN Phieuxuat_CT pxct ON vt.Mavattu=pxct.MaVT
            LEFT JOIN Phieuxuat px ON pxct.MAHD=px.MAHD
            where 
            (pn.Ngaytao BETWEEN @TuNgay AND @DenNgay OR pn.Ngaytao IS NULL)
            AND 
            (px.Ngaytao BETWEEN @TuNgay AND @DenNgay OR px.Ngaytao IS NULL)
            GROUP BY vt.Mavattu,vt.Tenvattu";
            SqlConnection conn = new SqlConnection(
      ConfigurationManager.ConnectionStrings["QLKhoVatTu"].ConnectionString
  );

            SqlCommand cmd = new SqlCommand(sql, conn); 
            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
            cmd.Parameters.AddWithValue("@DenNgay", denNgay);
             SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        private void Loadchartnhapxuatton(System.Data.DataTable dt)
        {
          chart.Series.Clear();
            ChartSeries sNhap = new ChartSeries("Nhập");
            ChartSeries sXuat = new ChartSeries("Xuất");
            ChartSeries sTon = new ChartSeries("Tồn");

            sNhap.ChartType = SeriesChartType.Column;
            sXuat.ChartType = SeriesChartType.Column;
            sTon.ChartType = SeriesChartType.Line;

            foreach (DataRow row in dt.Rows)
            {
                string maVT = row["MAVT"].ToString();

                sNhap.Points.AddXY(maVT, Convert.ToInt32(row["TONGNHAP"]));
                sXuat.Points.AddXY(maVT, Convert.ToInt32(row["TONGXUAT"]));
                sTon.Points.AddXY(maVT, Convert.ToInt32(row["TONKHO"]));
            }

            chart.Series.Add(sNhap);
            chart.Series.Add(sXuat);
            chart.Series.Add(sTon);
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value;
            DateTime denNgay = dtpDenNgay.Value;
            System.Data.DataTable dt = Getthongkexuatnhapton(tuNgay, denNgay);

            //Đổ bảng
            dgvbaocao.DataSource = dt;
            //Đổ Chart 
            Loadchartnhapxuatton(dt);
        }
        }
    }
