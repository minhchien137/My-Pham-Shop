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

namespace BaiTapHSK
{
    public partial class Nhacungcap : Form
    {
        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand smd = new SqlCommand("select * from tblNhaCC", cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter adt = new SqlDataAdapter(smd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dg_NCC.DataSource = dt;
                    }
                    dg_NCC.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
                    dg_NCC.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
                    dg_NCC.Columns[2].HeaderText = "Địa Chỉ";
                    dg_NCC.Columns[3].HeaderText = "Số Điện Thoại";


                }

            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(db))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandText = "XoaNhaCC";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNCC", txtmancc.Text);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        Nhacungcap_Load(sender, e);

                    }
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnn;
                    cmd.CommandText = "ThemNhaCC";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNCC", txtmancc.Text);
                    cmd.Parameters.AddWithValue("@tenNCC", txttennhacc.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtsdt.Text);


                    using (SqlCommand check = new SqlCommand("select *from tblNhaCC", cnn))
                    {
                        bool KT = false;
                        cnn.Open();
                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(txtmancc.Text) == reader.GetInt32(0))
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
                            Nhacungcap_Load(sender, e);

                        }

                    }
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnn;
                    cmd.CommandText = "SuaNHaCC";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maNCC", txtmancc.Text);
                    cmd.Parameters.AddWithValue("@tenNCC", txttennhacc.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtsdt.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    Nhacungcap_Load(sender, e);
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtmancc.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
              "iMaNCC", txtmancc.Text.Trim());
                (dg_NCC.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            else
            {
                MessageBox.Show("ma nha cung cap dang trong");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn thoát không?",
              "Error", MessageBoxButtons.YesNoCancel);
            Application.Exit();
        }
    }
}
