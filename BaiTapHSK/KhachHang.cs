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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
           
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection con = new SqlConnection(db))
            {


                using (SqlCommand cmd = new SqlCommand("select*from tblKhachHang", con))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                    dataGridView1.Columns[0].HeaderText = "Mã Khách hàng";
                    dataGridView1.Columns[1].HeaderText = "Tên Khách hàng";
                    dataGridView1.Columns[2].HeaderText = "Số Điện Thoại";
                    dataGridView1.Columns[3].HeaderText = "Địa chỉ";

                }

            }
            
        }
        /*private void report()
        {
            ReportDocument cry = new ReportDocument();
            cry.Load(@"D:\LTHSK\BaiTapHSK\BaiTapHSK\CrystalReport1.rpt");
            crystalReportViewer1.ReportSource = cry;
            crystalReportViewer1.Refresh();
            //cry.RecordSelectionFormula = "{tblKhachHang.iMaKH} = 211";
            //loc theo dieu kien
            cry.RecordSelectionFormula = "{tblKhachHang.sDiaChi} = 'Hà Nội'";

        }*/
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(db))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnn;
                    cmd.CommandText = "ThemKH";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@Hoten", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@DT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                    using (SqlCommand check = new SqlCommand("select *from tblKhachHang", cnn))
                    {
                        bool KT = false;
                        cnn.Open();
                        using (SqlDataReader reader = check.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(txtMaKH.Text) == reader.GetInt32(0))
                                {
                                    MessageBox.Show("Mã khách hàng này đã tồn tại. Mời nhập mã khác");
                                    KT = true;
                                }

                            }
                            reader.Close();

                        }
                        if (KT == false)
                        {
                            cmd.ExecuteNonQuery();
                            KhachHang_Load(sender, e);

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
                    cmd.CommandText = "suaKhachHang";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@Hoten", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@DT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    KhachHang_Load(sender, e);



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
                        cmd.CommandText = "XoaKH";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        KhachHang_Load(sender, e);

                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dataGridView1.CurrentRow.Cells["iMaKH"].Value.ToString();
            txtHoTen.Text = dataGridView1.CurrentRow.Cells["sHoTen"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["sDienThoai"].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["sDiaChi"].Value.ToString();
        }

        private void txtMaKH_Validating(object sender, CancelEventArgs e)
        {
           /* string db = ConfigurationManager.ConnectionStrings["QLMP"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(db))
            {
                cnn.Open();

                using (SqlCommand kt = new SqlCommand("select *from tblKhachHang", cnn))
                {


                    using (SqlDataReader reader = kt.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (int.Parse(txtMaKH.Text) == reader.GetInt32(0))
                            {
                                errorProvider1.SetError(txtMaKH, "Mã KH không được trùng");
                                break;
                            }
                            else
                            {
                                errorProvider1.SetError(txtMaKH, "");
                            }

                        }
                        reader.Close();

                    }



                }
            }*/
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            
           
               
           /* if(txtHoTen.Text!="")
            {
                
                string rowFilter = string.Format("{0} like '{1}'", "sHoTen", "*" + txtHoTen.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            else
            {
                if(txtMaKH.Text !="")
                {
                    
                    string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                             "iMaKH", txtMaKH.Text.Trim());
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
                }
                else
                {
                    if(txtDiaChi.Text !="")
                    {   
                        string rowFilter = string.Format("{0} like '{1}'", "sDiaChi", "*" + txtDiaChi.Text + "*");
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
                    }
                    else
                    {
                        string rowFilter = string.Format("{0} like '{1}'", "sDienThoai", "*" + txtSDT.Text + "*");
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

                    }
                }

            } */
           if(txtHoTen.Text != "")
            {
                string rowFilter = string.Format("{0} like '{1}'", "sHoTen", "*" + txtHoTen.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            if(txtMaKH.Text != "")
            {
                string RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'",
                            "iMaKH", txtMaKH.Text.Trim());
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = RowFilter;
            }
            if(txtDiaChi.Text != "")
            {
                string rowFilter = string.Format("{0} like '{1}'", "sDiaChi", "*" + txtDiaChi.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            if (txtSDT.Text != "")
            {
                string rowFilter = string.Format("{0} like '{1}'", "sDienThoai", "*" + txtSDT.Text + "*");
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
            }
            
            
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            /*string rowFilter = string.Format("{0} like '{1}'", "sHoTen", "*" + txtHoTen.Text + "*");
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;*/
        }

        private void KhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("do you want to exit?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = ("");
            txtMaKH.Text = ("");
            txtSDT.Text = "";
            txtHoTen.Text = ""; 
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

