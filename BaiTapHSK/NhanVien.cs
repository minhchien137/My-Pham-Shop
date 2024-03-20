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
using System.Configuration;

namespace BaiTapHSK
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        public void NhanVien_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblNhanVien", cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dgvnhanvien.DataSource = dt;
                    }
                    dgvnhanvien.Columns[0].HeaderText = "Mã nhân viên";
                    dgvnhanvien.Columns[1].HeaderText = "Họ tên";
                    dgvnhanvien.Columns[2].HeaderText = "Ngày sinh";
                    dgvnhanvien.Columns[3].HeaderText = "Giới tính";
                    dgvnhanvien.Columns[4].HeaderText = "Phụ cấp";
                    dgvnhanvien.Columns[5].HeaderText = "Lương cơ bản";
                    dgvnhanvien.Columns[6].HeaderText = "SĐT";
                    
                }
                //string sql = "select * from tblNhanVien";
                //SqlDataAdapter da = new SqlDataAdapter(sql, constr);
                //DataSet1 ds = new DataSet1();
                //DataTable dtb = new DataTable();
                //da.Fill(ds, "nhanvien");
                //CrystalReport3 cry = new CrystalReport3();
                //cry.SetDataSource(ds.Tables[1]);
                //crystalReportViewer1.ReportSource = cry;
                //crystalReportViewer1.Refresh();
            }
        }
        private bool kiemtra()
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanv.Focus();
                return false;
            }
            if (txthoten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txthoten.Focus();
                return false;
            }
            if (dt_ns.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt_ns.Focus();
                return false;
            }
            if (cbbgioitinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbgioitinh.Focus();
                return false;
            }
            if (txtphucap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tiền phụ cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtphucap.Focus();
                return false;
            }
            if (txtluongcb.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tiền lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtluongcb.Focus();
                return false;
            }
            if (mtb_sdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtb_sdt.Focus();
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
                            cmd.CommandText = "themNV";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaNV", txtmanv.Text);
                            cmd.Parameters.AddWithValue("@HoTen", txthoten.Text);
                            cmd.Parameters.AddWithValue("@NgaySinh", dt_ns.Text);
                            cmd.Parameters.AddWithValue("@GioiTinh", cbbgioitinh.Text);
                            cmd.Parameters.AddWithValue("@PhuCap", txtphucap.Text);
                            cmd.Parameters.AddWithValue("@LuongCB", txtluongcb.Text);
                            cmd.Parameters.AddWithValue("@DienThoai", mtb_sdt.Text);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            NhanVien_Load(sender, e);

                            MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    cmd.CommandText = "xoaNV";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNV", txtmanv.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    NhanVien_Load(sender, e);
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
                    MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    cmd.Connection = conn;
                    cmd.CommandText = "suaNV";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNV", txtmanv.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txthoten.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dt_ns.Text);
                    cmd.Parameters.AddWithValue("@GioiTinh", cbbgioitinh.Text);
                    cmd.Parameters.AddWithValue("@PhuCap", txtphucap.Text);
                    cmd.Parameters.AddWithValue("@LuongCB", txtluongcb.Text);
                    cmd.Parameters.AddWithValue("@DienThoai", mtb_sdt.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    NhanVien_Load(sender, e);
                }
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                    "iMaNV", txtmanv.Text.Trim());
                (dgvnhanvien.DataSource as DataTable).DefaultView.RowFilter = RowFilter;

            }
            else
            {
                if (txthoten.Text != "")
                {
                    string RowFilter = string.Format("{0} like '{1}'", "sHoTen", "*" + txthoten.Text + "*");
                    (dgvnhanvien.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                }
                else
                {
                    if (cbbgioitinh.Text != "")
                    {
                        string RowFilter = string.Format("{0} like '{1}'", "sGioiTinh", "*" + cbbgioitinh.Text + "*");
                        (dgvnhanvien.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                    }
                    else
                    {
                        if (dt_ns.Text != "")
                        {
                            string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                                 "dNgaySinh", dt_ns.Text.Trim());
                            (dgvnhanvien.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                        }
                    }
                }
            }
        }
        public void reset()
        {
            txtmanv.Text = "";
            txthoten.Text = "";
            txtluongcb.Text = "";
            txtphucap.Text = "";
            mtb_sdt.Text = "";
            dt_ns.Text = "";
            cbbgioitinh.Text = "";
        }

       
      

        private void btndong_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnboqua_Click_1(object sender, EventArgs e)
        {
            reset();
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvnhanvien.CurrentRow.Index;
            txtmanv.Text = dgvnhanvien.Rows[i].Cells[0].Value.ToString();
            txthoten.Text = dgvnhanvien.Rows[i].Cells[1].Value.ToString();
            dt_ns.Text = dgvnhanvien.Rows[i].Cells[2].Value.ToString();
            cbbgioitinh.Text = dgvnhanvien.Rows[i].Cells[3].Value.ToString();
            txtphucap.Text = dgvnhanvien.Rows[i].Cells[4].Value.ToString();
            txtluongcb.Text = dgvnhanvien.Rows[i].Cells[5].Value.ToString();
            mtb_sdt.Text = dgvnhanvien.Rows[i].Cells[6].Value.ToString();

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            NhanVien_Load(sender, e);
        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
