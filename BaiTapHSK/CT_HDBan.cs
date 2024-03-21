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
    public partial class CT_HDBan : Form
    {
        public CT_HDBan()
        {
            InitializeComponent();
        }
        private string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
        private void CT_HDBan_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(db))
            {


                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.tblCT_HDBan", con))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvhdb.DataSource = dt;

                    }
                    dgvhdb.Columns[0].HeaderText = "Mã hóa đơn";
                    dgvhdb.Columns[1].HeaderText = "Mã sản phẩm";
                    dgvhdb.Columns[2].HeaderText = "Giá bán";
                    dgvhdb.Columns[3].HeaderText = "Số lượng";
                }

            }
        }

        private void dgvhdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvhdb.Rows[e.RowIndex];
            txt_Mahd.Text = row.Cells["iMaHD"].Value.ToString();
            txt_Masp.Text = row.Cells["sMaSP"].Value.ToString();
            txt_Giaban.Text = row.Cells["fGiaBan"].Value.ToString();
            txt_Soluong.Text = row.Cells["iSoluong"].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themCTHDB";
                    cmd.Parameters.AddWithValue("@iMaHD", txt_Mahd.Text);
                    cmd.Parameters.AddWithValue("@sMaSP", txt_Masp.Text);
                    cmd.Parameters.AddWithValue("@fGiaBan", txt_Giaban.Text);
                    cmd.Parameters.AddWithValue("@iSoluong", txt_Soluong.Text);
                    cnn.Open();

                    using (SqlCommand check = new SqlCommand("select * from tblCT_HDBan where sTrangThai like N'%Đã thanh toán%'", cnn))
                    {
                        bool KT = false;

                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(txt_Mahd.Text) == reader.GetInt32(0))
                                {
                                    MessageBox.Show("Hóa đơn này đã được thanh toán, không thể thêm sản phẩm");
                                    KT = true;
                                }

                            }
                            reader.Close();

                        }
                        if (KT == false)
                        {
                            cmd.ExecuteNonQuery();
                            CT_HDBan_Load(sender, e);

                        }

                    }
                }
            }
            btnthem.Enabled = true;
        }
        /*Câu 3*/
        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Xoa_CTHDBan";
                    cmd.Parameters.AddWithValue("@iMaHD", txt_Mahd.Text);
                    cmd.Parameters.AddWithValue("@sMaSP", txt_Masp.Text);

                    cnn.Open();
                    using (SqlCommand check = new SqlCommand("select *from tblCT_HDBan where sTrangThai like N'%Đã thanh toán%'", cnn))
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
                                reader.Close();

                            }
                            if (KT == false)
                            {
                                cmd.ExecuteNonQuery();
                                CT_HDBan_Load(sender, e);

                            }
                        }

                    }
                }
            }
        }
    }
}
