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
    public partial class BaoCao_HDN : Form
    {
        public BaoCao_HDN()
        {
            InitializeComponent();
        }

        private void BaoCao_HDN_Load(object sender, EventArgs e)
        {
            ReportDocument cry = new ReportDocument();
            cry.Load(@"C:\DDDD\BaiTapHSK\BaiTapHSK\HDN.rpt");
            crystalReportViewer1.ReportSource = cry;
            crystalReportViewer1.Refresh();
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            ReportDocument crys = new ReportDocument();
            crys.Load(@"C:\DDDD\BaiTapHSK\BaiTapHSK\HDN.rpt");
            ParameterFieldDefinition pfds = crys.DataDefinition.ParameterFields["TenNV"];
            ParameterValues pvs = new ParameterValues();
            ParameterDiscreteValue pdvs = new ParameterDiscreteValue();
            pdvs.Value = txt_tenNV.Text;
            pvs.Add(pdvs);
            pfds.CurrentValues.Clear();
            pfds.ApplyCurrentValues(pvs);
            if (txt_tenNV.Text != "" && txt_MaHD.Text != "")
            {
                crys.RecordSelectionFormula = "{tblHoaDonNhap.iMaHD}={?MaHD} and {tblKhachHang.sHoTen}={?TenNV} ";
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
                    crys.RecordSelectionFormula = " {tblHoaDonNhap.iMaHD}={?MaHD} ";
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
                    crys.RecordSelectionFormula = " { tblNhanVien.sHoTen}={?TenNV}";
                }
            }
            crystalReportViewer1.ReportSource = crys;
            crystalReportViewer1.Refresh();
        }

        private void txt_MaHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
