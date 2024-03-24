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

namespace BaiTapHSK
{
    public partial class FrmDangKi : Form
    {
        public FrmDangKi()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string conn = "Data Source = MSI\\MINHCHIEN ;Initial Catalog = QLBanMyPham;User ID = sa;Password = 123";
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
            //if(txtTenDangNhap.Text == "")
            //{
            //    MessageBox.Show("thiếu", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}    
            //if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            //{
            //    MessageBox.Show("Mật Khẩu không Trùng nhau", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            /////////////////////////////mail///////////////////////
            //if (isEmail(txtEmail.Text)==false)
            //{
            //    MessageBox.Show("mail", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}    

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.CommandText = "ThemTaiKhoan";
            sqlCommand.Parameters.AddWithValue("@sTenTaiKhoan", txtTênDN.Text);
            sqlCommand.Parameters.AddWithValue("@sMatKhau", txtMatKhau.Text);
            int i = sqlCommand.ExecuteNonQuery();
            if (i > 0)
            {
                DialogResult result = MessageBox.Show("Bạn đã đăng kí thành công. bạn có muốn đăng nhập không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FrmDangNhap dangNhap = new FrmDangNhap();
                    this.Close();
                    dangNhap.Show();

                }
            }
            else
            {
                MessageBox.Show("đăng kí thất bại");
            }
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        
    }
        /* -- Validating mat khau nhap phai dung */

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDangNhap dangNhap = new FrmDangNhap();
            this.Close();
            dangNhap.Show();
        }

        private void FrmDangKi_Load(object sender, EventArgs e)
        {

        }
    }
}
