using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace BaiTapHSK
{
    public partial class HDNhap : Form
    {
        public HDNhap()
        {
            InitializeComponent();
        }

        private void HDNhap_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDonNhap", conn))
                {
                    conn.Open();
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dgvhoadonnhap.DataSource = dt;
                    }
                    dgvhoadonnhap.Columns[0].HeaderText = "Mã hóa đơn";
                    dgvhoadonnhap.Columns[1].HeaderText = "Mã nhân viên";
                    dgvhoadonnhap.Columns[2].HeaderText = "Ngày lập ";
                    dgvhoadonnhap.Columns[3].HeaderText = "Trạng Thái";

                }
            }
        }
        private bool kiemtra()
        {
            if (mtb_mahd.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtb_mahd.Focus();
                return false;
            }
            if (mtb_manv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dt_ngaylap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày lập hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ngaylap.Focus();
                return false;
            }
            return true;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.Connection = conn;
                            cmd.CommandText = "ThemHoaDonNhap";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@mahd", mtb_mahd.Text);
                            cmd.Parameters.AddWithValue("@manv", mtb_manv.Text);
                            cmd.Parameters.AddWithValue("@ngaynhap", dt_ngaylap.Text);
                            cmd.Parameters.AddWithValue("@trangthai", maskTrangThai.Text);

                            conn.Open();
                            using (SqlCommand check = new SqlCommand("SELECT * FROM tblHoaDonNhap ", conn))
                            {
                                bool KT = false;

                                using (SqlDataReader reader = check.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        if (int.Parse(mtb_mahd.Text) == reader.GetInt32(0))
                                        {
                                            MessageBox.Show("Hóa đơn này đã tồn tại");
                                            KT = true;
                                        }

                                    }
                                    reader.Close();

                                }
                                if (KT == false)
                                {
                                    cmd.ExecuteNonQuery();
                                    HDNhap_Load(sender, e);

                                }

                            }


                            MessageBox.Show("Thêm hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    cmd.Connection = conn;
                    cmd.CommandText = "xoaHD";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mahd", mtb_mahd.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    HDNhap_Load(sender, e);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = "SuaHoaDonNhap";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mahd", mtb_mahd.Text);
                    cmd.Parameters.AddWithValue("@manv", mtb_manv.Text);
                    cmd.Parameters.AddWithValue("@ngaylap", dt_ngaylap.Text);
                    cmd.Parameters.AddWithValue("@trangthai", maskTrangThai.Text);
                    conn.Open();
                    using (SqlCommand check = new SqlCommand("SELECT * FROM tblHoaDonNhap where sTrangThai like N'%Đã thanh toán%'", conn))
                    {
                        bool KT = false;

                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(mtb_mahd.Text) == reader.GetInt32(0))
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
                            HDNhap_Load(sender, e);

                        }

                    }


                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (mtb_mahd.Text != "" && mtb_manv.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' " +
                "and CONVERT({2}, System.String)like '%{3}%'"
                , "iMaHD", mtb_mahd.Text.Trim(), "iMaNV", mtb_manv.Text.Trim());
                (dgvhoadonnhap.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            else if (mtb_mahd.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' "
                , "iMaHD", mtb_mahd.Text.Trim());
                (dgvhoadonnhap.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            else if (mtb_manv.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%' "
                , "iMaNV", mtb_manv.Text.Trim());
                (dgvhoadonnhap.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            else if (dt_ngaylap.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                     "dNgayNhapSP", dt_ngaylap.Text.Trim());
                (dgvhoadonnhap.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            else if (maskTrangThai.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) LIKE N'%{1}%'",
                     "sTrangThai", maskTrangThai.Text.Trim());
                (dgvhoadonnhap.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
        }
        public void reset()
        {
            mtb_mahd.Text = "";
            mtb_manv.Text = "";
            dt_ngaylap.Text = "";
            maskTrangThai.Text = "";
        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvhoadonnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvhoadonnhap.CurrentRow.Index;
            mtb_mahd.Text = dgvhoadonnhap.Rows[i].Cells[0].Value.ToString();
            mtb_manv.Text = dgvhoadonnhap.Rows[i].Cells[1].Value.ToString();
            dt_ngaylap.Text = dgvhoadonnhap.Rows[i].Cells[2].Value.ToString();
            maskTrangThai.Text = dgvhoadonnhap.Rows[i].Cells[3].Value.ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HDNhap_Load(sender, e);
        }

        private void btnCTHDNhap_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDonNhap", conn))
                {
                    conn.Open();
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dgvhoadonnhap.DataSource = dt;
                    }
                    dgvhoadonnhap.Columns[0].HeaderText = "Mã hóa đơn";
                    dgvhoadonnhap.Columns[1].HeaderText = "Mã nhân viên";
                    dgvhoadonnhap.Columns[2].HeaderText = "Ngày lập ";
                    dgvhoadonnhap.Columns[3].HeaderText = "Trạng Thái";

                }
            }
        }
    }
}
