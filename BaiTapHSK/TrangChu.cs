using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapHSK
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            
        }

        public bool isLoggedIn;
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoggedIn == true)
            {
                KhachHang khachHang = new KhachHang();
                khachHang.MdiParent = this;
                khachHang.Show();
            }
            else
            {
                MessageBox.Show("Vui Lòng Đăng Nhập Để Sử Dụng Chức Năng Này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isLoggedIn != true)
            {
                HoaDonBan hoaDonBan = new HoaDonBan();
                hoaDonBan.MdiParent = this;
                hoaDonBan.Show();
            }
            else
            {
                MessageBox.Show("Vui Lòng Đăng Nhập Để Sử Dụng Chức Năng Này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

        }


        private void báoCáoHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCao_HDB form1 = new BaoCao_HDB();
            form1.MdiParent = this;
            form1.Show();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            
        }

        private void hóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            

            if (isLoggedIn != true)
            {
                HDNhap form1 = new HDNhap();
                form1.MdiParent = this;
                form1.Show();
            }
            else
            {
                MessageBox.Show("Vui Lòng Đăng Nhập Để Sử Dụng Chức Năng Này", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien form1 = new NhanVien();
            form1.MdiParent = this;
            form1.Show();
        }

        private void báoCáoHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCao_HDN form1 = new BaoCao_HDN();
            form1.MdiParent = this;
            form1.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nhacungcap form1 = new Nhacungcap();
            form1.MdiParent = this;
            form1.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SanPham form1 = new SanPham();
            form1.MdiParent = this;
            form1.Show();
        }

        private void chiTiếtHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CT_Hoadonnhapcs form1 = new CT_Hoadonnhapcs();
            form1.MdiParent = this;
            form1.Show();
        }

        private void chiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CT_HDBan form1 = new CT_HDBan();
            form1.MdiParent = this;
            form1.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
                
            }
            

        }

        

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDangNhap dangNhap = new FrmDangNhap();
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                isLoggedIn = true;
            }
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDangKi dangki = new FrmDangKi();
            dangki.Show();
        }
    }
}
