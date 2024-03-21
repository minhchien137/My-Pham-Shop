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
    public partial class CT_Hoadonnhapcs : Form
    {
        public CT_Hoadonnhapcs()
        {
            InitializeComponent();
        }
       private string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
        private void CT_Hoadonnhapcs_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(db))
            {


                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblCT_HDNhap", con))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvhdn.DataSource = dt;
                        
                    }
                    dgvhdn.Columns[0].HeaderText = "Mã hóa đơn";
                    dgvhdn.Columns[1].HeaderText = "Mã sản phẩm";
                    dgvhdn.Columns[2].HeaderText = "Giá nhập";
                    dgvhdn.Columns[3].HeaderText = "Số lượng";
                }

            }
        }

        private void dgvhdn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvhdn.Rows[e.RowIndex];
            txt_Mahd.Text = row.Cells["iMaHD"].Value.ToString();
            txt_Masp.Text = row.Cells["sMaSP"].Value.ToString();
            txt_Gianhap.Text = row.Cells["fGiaNhap"].Value.ToString();
           txt_Soluong.Text = row.Cells["iSoluong"].Value.ToString();
  
        }
        
        private void btnthem_Click(object sender, EventArgs e)
        {

            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themCTHDN";
                    cmd.Parameters.AddWithValue("@iMaHD", txt_Mahd.Text);
                    cmd.Parameters.AddWithValue("@sMaSP", txt_Masp.Text);
                    cmd.Parameters.AddWithValue("@fGiaNhap", txt_Gianhap.Text);
                    cmd.Parameters.AddWithValue("@iSoluong", txt_Soluong.Text);
                    cnn.Open();
                    using (SqlCommand check = new SqlCommand("select *from HoaDonNhap where sTrangThai like N'%Đã thanh toán%'", cnn))
                    {
                        bool KT = false;

                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(txt_Mahd.Text) == reader.GetInt32(0))
                                {
                                    MessageBox.Show("Hóa đơn này đã được thanh toán, không thêm sản phẩm");
                                    KT = true;
                                }

                            }
                            reader.Close();

                        }
                        if (KT == false)
                        {
                            cmd.ExecuteNonQuery();
                            CT_Hoadonnhapcs_Load(sender, e);

                        }

                    }
                }
            }
            btnthem.Enabled = true;

        
    }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Bạn có muốn xóa hóa đơn {txt_Mahd.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(db))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "xoaCT_HDN";
                        cmd.Parameters.AddWithValue("@iMaHD", txt_Mahd.Text);
                        cmd.Parameters.AddWithValue("@iMaSP", txt_Masp.Text);
                        con.Open();
                        using (SqlCommand check = new SqlCommand("select *from HoaDonNhap where sTrangThai like N'%Đã thanh toán%'", con))
                        {
                            bool KT = false;

                            using (SqlDataReader reader = check.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    if (int.Parse(txt_Mahd.Text) == reader.GetInt32(0))
                                    {
                                        MessageBox.Show("Hóa đơn này đã được thanh toán, không thể xóa sản phẩm");
                                        KT = true;
                                    }

                                }
                                reader.Close();

                            }
                            if (KT == false)
                            {
                                cmd.ExecuteNonQuery();
                                CT_Hoadonnhapcs_Load(sender, e);

                            }

                        }
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txt_Mahd.Text = "";
            txt_Masp.Text = "";
            txt_Soluong.Text = "";
            txt_Gianhap.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CT_Hoadonnhapcs_Load(sender,e);
        }
    }
}
