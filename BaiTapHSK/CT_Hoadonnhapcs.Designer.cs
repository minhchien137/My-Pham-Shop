
namespace BaiTapHSK
{
    partial class CT_Hoadonnhapcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvhdn = new System.Windows.Forms.DataGridView();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Mahd = new System.Windows.Forms.TextBox();
            this.txt_Masp = new System.Windows.Forms.TextBox();
            this.txt_Soluong = new System.Windows.Forms.TextBox();
            this.txt_Gianhap = new System.Windows.Forms.TextBox();
            this.errCheck = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhdn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvhdn
            // 
            this.dgvhdn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvhdn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhdn.Location = new System.Drawing.Point(143, 23);
            this.dgvhdn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvhdn.Name = "dgvhdn";
            this.dgvhdn.RowHeadersWidth = 51;
            this.dgvhdn.RowTemplate.Height = 24;
            this.dgvhdn.Size = new System.Drawing.Size(783, 315);
            this.dgvhdn.TabIndex = 0;
            this.dgvhdn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvhdn_CellClick);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Location = new System.Drawing.Point(491, 139);
            this.btntimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(106, 42);
            this.btntimkiem.TabIndex = 80;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            // 
            // btnsua
            // 
            this.btnsua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Location = new System.Drawing.Point(163, 139);
            this.btnsua.Margin = new System.Windows.Forms.Padding(4);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(100, 42);
            this.btnsua.TabIndex = 78;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            // 
            // btnxoa
            // 
            this.btnxoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Location = new System.Drawing.Point(330, 139);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(100, 42);
            this.btnxoa.TabIndex = 77;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthem.Location = new System.Drawing.Point(6, 139);
            this.btnthem.Margin = new System.Windows.Forms.Padding(4);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(100, 42);
            this.btnthem.TabIndex = 76;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 81;
            this.label1.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 82;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(583, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 83;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(583, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 22);
            this.label4.TabIndex = 84;
            this.label4.Text = "Giá nhập";
            // 
            // txt_Mahd
            // 
            this.txt_Mahd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mahd.Location = new System.Drawing.Point(256, 19);
            this.txt_Mahd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Mahd.Name = "txt_Mahd";
            this.txt_Mahd.Size = new System.Drawing.Size(144, 30);
            this.txt_Mahd.TabIndex = 85;
            // 
            // txt_Masp
            // 
            this.txt_Masp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Masp.Location = new System.Drawing.Point(256, 73);
            this.txt_Masp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Masp.Name = "txt_Masp";
            this.txt_Masp.Size = new System.Drawing.Size(144, 30);
            this.txt_Masp.TabIndex = 86;
            // 
            // txt_Soluong
            // 
            this.txt_Soluong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Soluong.Location = new System.Drawing.Point(671, 17);
            this.txt_Soluong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Soluong.Name = "txt_Soluong";
            this.txt_Soluong.Size = new System.Drawing.Size(188, 30);
            this.txt_Soluong.TabIndex = 87;
            // 
            // txt_Gianhap
            // 
            this.txt_Gianhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Gianhap.Location = new System.Drawing.Point(670, 76);
            this.txt_Gianhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Gianhap.Name = "txt_Gianhap";
            this.txt_Gianhap.Size = new System.Drawing.Size(188, 30);
            this.txt_Gianhap.TabIndex = 88;
            // 
            // errCheck
            // 
            this.errCheck.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.txt_Gianhap);
            this.panel1.Controls.Add(this.btntimkiem);
            this.panel1.Controls.Add(this.txt_Soluong);
            this.panel1.Controls.Add(this.txt_Masp);
            this.panel1.Controls.Add(this.btnsua);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.txt_Mahd);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(43, 380);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 212);
            this.panel1.TabIndex = 89;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(835, 139);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 42);
            this.btnRefresh.TabIndex = 92;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(670, 139);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(106, 42);
            this.btnHuy.TabIndex = 91;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // CT_Hoadonnhapcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvhdn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CT_Hoadonnhapcs";
            this.Text = "CT_Hoadonnhapcs";
            this.Load += new System.EventHandler(this.CT_Hoadonnhapcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhdn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errCheck)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvhdn;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Mahd;
        private System.Windows.Forms.TextBox txt_Masp;
        private System.Windows.Forms.TextBox txt_Soluong;
        private System.Windows.Forms.TextBox txt_Gianhap;
        private System.Windows.Forms.ErrorProvider errCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHuy;
    }
}