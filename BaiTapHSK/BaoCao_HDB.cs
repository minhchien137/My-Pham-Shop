using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace BaiTapHSK
{
    public partial class BaoCao_HDB : Form
    {
        private void report()
        {
            ReportDocument cry = new ReportDocument();
            cry.Load(@"C:\DDDD\BaiTapHSK\BaiTapHSK\HDB.rpt");
            crystalReportViewer1.ReportSource = cry;
            crystalReportViewer1.Refresh();

        }
        public BaoCao_HDB()
        {
            InitializeComponent();
        }

        private void BaoCao_HDB_Load(object sender, EventArgs e)
        {
            report();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*
        private void btn_Xem_Click(object sender, EventArgs e)
        {
            ReportDocument crys = new ReportDocument();
            crys.Load(@"C:\DDDD\BaiTapHSK\BaiTapHSK\HDB.rpt");
            crys.RecordSelectionFormula = "{tblNhanVien.sHoTen}={?TenNV} or{tblKhachHang.sHoTen}={?TenKH} ";
            ParameterFieldDefinition pfd = crys.DataDefinition.ParameterFields["TenKH"];
            ParameterValues pv = new ParameterValues();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pdv.Value = txt_TenKh.Text;
            pv.Add(pdv);
            pfd.CurrentValues.Clear();
            pfd.ApplyCurrentValues(pv);
        
            ParameterFieldDefinition pfds = crys.DataDefinition.ParameterFields["TenNV"];
            ParameterValues pvs = new ParameterValues();
            ParameterDiscreteValue pdvs = new ParameterDiscreteValue();
            pdvs.Value =txt_tenNV.Text;
            pvs.Add(pdvs);
            pfds.CurrentValues.Clear();
            pfds.ApplyCurrentValues(pvs);

            
            if(txt_MaHD.Text !="" && txt_TenKh.Text != "" && txt_tenNV.Text != "")
            {
                crys.RecordSelectionFormula = "{tblNhanVien.sHoTen}={?TenNV} and {tblKhachHang.sHoTen}={?TenKH} and {tblHoaDonBan.iMaHD}={?MaHD}";
                ParameterFieldDefinition pfd2 = crys.DataDefinition.ParameterFields["MaHD"];
                ParameterValues pv2 = new ParameterValues();
                ParameterDiscreteValue pdv2 = new ParameterDiscreteValue();
                pdv2.Value = txt_MaHD.Text;
                pv2.Add(pdv2);
                pfd2.CurrentValues.Clear();
                pfd2.ApplyCurrentValues(pv2);
            }
            else
            {
                if (txt_TenKh.Text != "" && txt_tenNV.Text != "")
                {
                    crys.RecordSelectionFormula = "{tblNhanVien.sHoTen}={?TenNV} and {tblKhachHang.sHoTen}={?TenKH} ";
                }
                else
                {
                    if (txt_TenKh.Text != "" && txt_MaHD.Text != "")
                    {
                        crys.RecordSelectionFormula = "{tblHoaDonBan.iMaHD}={?MaHD} and {tblKhachHang.sHoTen}={?TenKH} ";
                        ParameterFieldDefinition pfd2 = crys.DataDefinition.ParameterFields["MaHD"];
                        ParameterValues pv2 = new ParameterValues();
                        ParameterDiscreteValue pdv2 = new ParameterDiscreteValue();
                        pdv2.Value = txt_MaHD.Text;
                        pv2.Add(pdv2);
                        pfd2.CurrentValues.Clear();
                        pfd2.ApplyCurrentValues(pv2);
                    }
                    else
                    {
                        if (txt_tenNV.Text != "" && txt_MaHD.Text != "")
                        {
                            crys.RecordSelectionFormula = "{tblNhanVien.sHoTen}={?TenNV} and {tblHoaDonBan.iMaHD}={?MaHD} ";
                            ParameterFieldDefinition pfd2 = crys.DataDefinition.ParameterFields["MaHD"];
                            ParameterValues pv2 = new ParameterValues();
                            ParameterDiscreteValue pdv2 = new ParameterDiscreteValue();
                            pdv2.Value = txt_MaHD.Text;
                            pv2.Add(pdv2);
                            pfd2.CurrentValues.Clear();
                            pfd2.ApplyCurrentValues(pv2);
                        }
                        else
                        {
                            if (txt_MaHD.Text != "")
                            {
                                crys.RecordSelectionFormula = " {tblHoaDonBan.iMaHD}={?MaHD} ";
                                ParameterFieldDefinition pfd2 = crys.DataDefinition.ParameterFields["MaHD"];
                                ParameterValues pv2 = new ParameterValues();
                                ParameterDiscreteValue pdv2 = new ParameterDiscreteValue();
                                pdv2.Value = txt_MaHD.Text;
                                pv2.Add(pdv2);
                                pfd2.CurrentValues.Clear();
                                pfd2.ApplyCurrentValues(pv2);
                            }
                            else
                            {
                                crys.RecordSelectionFormula =" { tblNhanVien.sHoTen}={?TenNV} or { tblKhachHang.sHoTen}={?TenKH}";
                            }
                        }
                    }
                    
                }
            }
            
            crystalReportViewer1.ReportSource = crys;
            crystalReportViewer1.Refresh();
            
           

        }
        */

        /*

        private void btn_maxTien_Click(object sender, EventArgs e)
        {
            string conn = "Data Source=MSI\\MINHCHIEN;Initial Catalog=QLBanMyPham;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "BaoCaoMaxTT";

            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            dt.Clear();
            sqlDataAdapter.Fill(dt);
            HDB cpt = new HDB();
            cpt.SetDataSource(dt);
            //FrmBaoCaoKhachHangTuoi baoCaoKhachHangTuoi = new FrmBaoCaoKhachHangTuoi();
            crystalReportViewer1.ReportSource = cpt;
            //FrmBaoCaoHDB_Load(sender, e);
        }

        private void btn_TatCaHoaDon_Click(object sender, EventArgs e)
        {
            report();
        }

        

        private void btnKhoangTT_Click(object sender, EventArgs e)
        {
            string conn = "Data Source=MSI\\MINHCHIEN;Initial Catalog=QLBanMyPham;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "rptSEARCH_X_Y_HDB";
            sqlCommand.Parameters.AddWithValue("@x", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@y", textBox2.Text);
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            dt.Clear();
            sqlDataAdapter.Fill(dt);
            HDB cpt = new HDB();
            cpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cpt;
        }

        private void btnHDNgayGiao_Click(object sender, EventArgs e)
        {
            string conn = "Data Source=MSI\\MINHCHIEN;Initial Catalog=QLBanMyPham;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "BaoCaoHDBTheoNgayGiao";
            sqlCommand.Parameters.AddWithValue("@ngayGiao", dtNgayGiao.Text);
           
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dt = new DataTable();
            dt.Clear();
            sqlDataAdapter.Fill(dt);
            HDB cpt = new HDB();
            cpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cpt;
        }
        */
    }
}
