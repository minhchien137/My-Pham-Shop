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
    public partial class HoaDonBan : Form
    {
        public HoaDonBan()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        /*private void report()
        {
            ReportDocument cry = new ReportDocument();
            cry.Load(@"D:\LTHSK\BaiTapHSK\BaiTapHSK\CrystalReport2.rpt");
            crystalReportViewer1.ReportSource = cry;
            crystalReportViewer1.Refresh();
            
        }*/
        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection con = new SqlConnection(db))
            {


                using (SqlCommand cmd = new SqlCommand("select*from HD", con))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                        //listBox1.Items.Add("Sunday");

                        /*cb_MaHD.DataSource = dt;
                        cb_MaHD.DisplayMember = "HD";
                        cb_MaHD.ValueMember = "iMaHD";*/
                        cb_trangthai.Items.Add("Đã thanh toán");
                        cb_trangthai.Items.Add("Chưa thanh toán");
                    }
                    dataGridView1.Columns[0].HeaderText = "Mã hóa đơn";
                    dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
                    dataGridView1.Columns[2].HeaderText = "Mã khách hàng";
                    dataGridView1.Columns[3].HeaderText = "Tên nhân viên";
                    dataGridView1.Columns[4].HeaderText = "Mã nhân viên";
                    dataGridView1.Columns[5].HeaderText = "Ngày đặt hàng";
                    dataGridView1.Columns[6].HeaderText = "Ngày giao hàng";
                    dataGridView1.Columns[7].HeaderText = "Địa chỉ giao";
                    dataGridView1.Columns[8].HeaderText = "Trạng thái";
                }

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
                return;
            txtMaHD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMaKH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMaNV.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtNgayDat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtNgayGiao.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cb_trangthai.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            //txtMaHD.Text = dataGridView1.CurrentRow.Cells["iMaHD"].Value.ToString();
            //txtNgaydat.Text = dataGridView1.CurrentRow.Cells["dNgayDat"].Value.ToString();
            //txtNgayGiao.Text = dataGridView1.CurrentRow.Cells["dNgayGiao"].Value.ToString();
            //txtDiaChi.Text = dataGridView1.CurrentRow.Cells["sDiaChiGiao"].Value.ToString();
            //txtMaKH.Text = dataGridView1.CurrentRow.Cells["iMaKH"].Value.ToString();
            //txtMaNV.Text = dataGridView1.CurrentRow.Cells["iMaNV"].Value.ToString();
            //cb_trangthai.Text = dataGridView1.CurrentRow.Cells["sTrangThai"].Value.ToString();

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnn;
                    cmd.CommandText = "ThemHDB";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iMaHD", txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@NgayDat", dtNgayDat.Text);
                    cmd.Parameters.AddWithValue("@NgayGiao", dtNgayGiao.Text);
                    cmd.Parameters.AddWithValue("@DiaChiGiao", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", cb_trangthai.Text);

                    using (SqlCommand check = new SqlCommand("select *from HD", cnn))
                    {
                        bool KT = false;
                        cnn.Open();
                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(txtMaHD.Text) == reader.GetInt32(0))
                                {
                                    MessageBox.Show("Mã hóa đơn này đã tồn tại. Mời nhập mã khác");
                                    KT = true;
                                }

                            }
                            reader.Close();

                        }
                        if (KT == false)
                        {
                            cmd.ExecuteNonQuery();
                            HoaDonBan_Load(sender, e);

                        }

                    }


                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "SuaHDB";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@NgayDat", dtNgayDat.Text);
                    cmd.Parameters.AddWithValue("@NgayGiao", dtNgayGiao.Text);
                    cmd.Parameters.AddWithValue("@DiaChiGiao", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@TrangThai", cb_trangthai.Text);
                    cnn.Open();
                    using (SqlCommand check = new SqlCommand("select *from HD where sTrangThai like N'%Đã thanh toán%'", cnn))
                    {
                        bool KT = false;

                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(txtMaHD.Text) == reader.GetInt32(0))
                                {
                                    MessageBox.Show("Hóa đơn này đã được thanh toán, không thể sửa");
                                    KT = true;
                                }

                            }
                            reader.Close();

                        }
                        if (KT == false)
                        {
                            cmd.ExecuteNonQuery();
                            HoaDonBan_Load(sender, e);

                        }

                    }
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(db))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = "XoaHDB";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaHD", txtMaKH.Text);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        HoaDonBan_Load(sender, e);

                    }
                }
            }
        }



        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void HoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("do you want to exit?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

            txtMaHD.Text = ("");
            txtDiaChi.Text = ("");
            txtMaKH.Text = ("");
            txtMaNV.Text = ("");
            dtNgayDat.Text = ("");
            dtNgayGiao.Text = ("");
        }

        /* private void Loc_Click(object sender, EventArgs e)
         {
             ReportDocument crys = new ReportDocument();
             crys.Load(@"D:\LTHSK\BaiTapHSK\BaiTapHSK\CrystalReport2.rpt");
             ParameterFieldDefinition pfd = crys.DataDefinition.ParameterFields["TenKH"];
             crys.RecordSelectionFormula = "{tblKhachHang.sHoTen} = {?TenKH}";
             ParameterValues pv = new ParameterValues();
             ParameterDiscreteValue pdv = new ParameterDiscreteValue();
             pdv.Value = txtTenKH.Text;
             pv.Add(pdv);
             pfd.CurrentValues.Clear();
             pfd.ApplyCurrentValues(pv);
             crystalReportViewer1.ReportSource = crys;
             crystalReportViewer1.Refresh();

         }*/

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            /*if (txtMaHD.Text != "" && txtMaNV.Text != "" && txtMaKH.Text != "")
            {

                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' " +
                    "and CONVERT({2}, System.String)like '%{3}%'" +
                    "and CONVERT({4}, System.String) like '%{5}%'", "iMaHD"
                    , txtMaHD.Text.Trim(), "iMaNV", txtMaNV.Text.Trim(), "iMaKH", txtMaKH.Text.Trim());
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }

            else
            {
                if (txtMaHD.Text != "" && txtMaNV.Text != "")
                {

                    string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' " +
                        "and CONVERT({2}, System.String)like '%{3}%'"
                        , "iMaHD", txtMaHD.Text.Trim(), "iMaNV", txtMaNV.Text.Trim());
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                }
                else
                {
                    if (txtMaHD.Text != "" && txtMaKH.Text != "")
                    {

                        string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' and CONVERT({2}, System.String)like '%{3}%'"
                            , "iMaHD"
                            , txtMaHD.Text.Trim(), "iMaKH", txtMaKH.Text.Trim());
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                    }
                    else
                    {
                        if (txtMaHD.Text != "")
                        {
                            string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' ", "iMaHD"
                                    , txtMaHD.Text.Trim());
                            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                        }

                        else
                        {
                            if (txtMaKH.Text != "")
                            {

                                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                                  "iMaKH", txtMaKH.Text.Trim());
                                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                            }
                            
                            else
                            {
                                
                                if (txtNgaydat.Text != "" || txtNgayGiao.Text != "")
                                {

                                    string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' or CONVERT({2}, System.String) like '%{3}%'" ,
                                      "dNgayDat", txtNgaydat.Text.Trim(), "dNgayGiao", txtNgayGiao.Text.Trim());
                                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                                }
                                
                               
                            }
                        }
                    } 
                }
            }*/
            string Filter = "CONVERT(iMaHD, System.String) <> ''";
            if (!string.IsNullOrEmpty(txtMaHD.Text)) { 
                Filter += string.Format("AND  CONVERT({0}, System.String) like '%{1}%' ", "iMaHD" , txtMaHD.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtMaKH.Text)) {
                Filter += string.Format("AND  CONVERT({0}, System.String) like '%{1}%' ", "iMaKH", txtMaKH.Text.Trim());

            }
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                Filter += string.Format("AND  CONVERT({0}, System.String) like '%{1}%' ", "iMaNV", txtMaNV.Text.Trim());

            }
            /*if(!string.IsNullOrEmpty(txtNgaydat.Text))
             {
                 Filter += string.Format("AND  CONVERT({0}, System.String) like '%{1}%' ", "dNgayDat", txtNgaydat.Text.Trim());

             }
            if (!string.IsNullOrEmpty(txtNgayGiao.Text))
            {
                Filter += string.Format("AND  CONVERT({0}, System.String) like '%{1}%' ", "dNgayGiao", txtNgayGiao.Text.Trim());

            }*/

            if (!string.IsNullOrEmpty(cb_trangthai.Text))
            {
                Filter += string.Format("AND  CONVERT({0}, System.String) like '%{1}%' ", "sTrangThai", cb_trangthai.Text.Trim());

            }
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = Filter;



        }

        private void btnInHDB_Click(object sender, EventArgs e)
        {
            BaoCao_HDB hoaDonBan = new BaoCao_HDB();
            
            hoaDonBan.Show();
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            string RowFilter = string.Format("{0} > '{1}' and {2}  < '{3}'" , "dNgayDat" , A1.Text.Trim(), "dNgayDat", A2.Text.Trim());
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            //cb_MaHD.Items.Add(cb_MaHD.Text);
        }*/
    }
}
