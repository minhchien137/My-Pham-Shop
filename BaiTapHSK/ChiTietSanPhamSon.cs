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
    public partial class ChiTietSanPhamSon : Form
    {
        public ChiTietSanPhamSon()
        {
            InitializeComponent();
        }

        private void ChiTietSanPhamSon_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand smd = new SqlCommand("select * from tblCT_SanPhamSon", cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter adt = new SqlDataAdapter(smd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dgctsanphamson.DataSource = dt;
                    }
                    dgctsanphamson.Columns[0].HeaderText = "Mã Sản Phẩm";
                    dgctsanphamson.Columns[1].HeaderText = "Đặc Tính";
                    dgctsanphamson.Columns[2].HeaderText = "Màu Sắc";
                    dgctsanphamson.Columns[3].HeaderText = "Hãng Sản Phẩm";
                    dgctsanphamson.Columns[4].HeaderText = "Ngày Sản Xuất";
                    dgctsanphamson.Columns[5].HeaderText = "Ngày Hết Hạn";


                }

            }
        }

        private void bnThem_Click(object sender, EventArgs e)
        {

        }

        private void bnSua_Click(object sender, EventArgs e)
        {

        }

        private void bnXoa_Click(object sender, EventArgs e)
        {

        }

        private void bnSearch_Click(object sender, EventArgs e)
        {

        }

        private void bnBoqua_Click(object sender, EventArgs e)
        {
            tbmsp.Text = "";
            tbdactinh.Text = "";
            tbmausac.Text = "";
            tbhangsp.Text = "";
            tbnsx.Text = "";
            tbnhh.Text = "";
        }

        private void bnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgctsanphamson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbmsp.Text = dgctsanphamson.CurrentRow.Cells["sMaSP"].Value.ToString();
            tbdactinh.Text = dgctsanphamson.CurrentRow.Cells["sDactinh"].Value.ToString();
            tbmausac.Text = dgctsanphamson.CurrentRow.Cells["sMauSac"].Value.ToString();
            tbhangsp.Text = dgctsanphamson.CurrentRow.Cells["sHangSanPham"].Value.ToString();
            tbnsx.Text = dgctsanphamson.CurrentRow.Cells["dNgaySanXuat"].Value.ToString();
            tbnhh.Text = dgctsanphamson.CurrentRow.Cells["dNgayHetHan"].Value.ToString();
        }
    }
}
