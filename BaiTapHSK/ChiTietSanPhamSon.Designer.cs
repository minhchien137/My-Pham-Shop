namespace BaiTapHSK
{
    partial class ChiTietSanPhamSon
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
            this.dgctsanphamson = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnThem = new System.Windows.Forms.Button();
            this.bnSua = new System.Windows.Forms.Button();
            this.bnXoa = new System.Windows.Forms.Button();
            this.bnSearch = new System.Windows.Forms.Button();
            this.bnBoqua = new System.Windows.Forms.Button();
            this.bnThoat = new System.Windows.Forms.Button();
            this.tbmsp = new System.Windows.Forms.TextBox();
            this.tbdactinh = new System.Windows.Forms.TextBox();
            this.tbmausac = new System.Windows.Forms.TextBox();
            this.tbhangsp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbnsx = new System.Windows.Forms.MaskedTextBox();
            this.tbnhh = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgctsanphamson)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgctsanphamson
            // 
            this.dgctsanphamson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgctsanphamson.Location = new System.Drawing.Point(30, 24);
            this.dgctsanphamson.Name = "dgctsanphamson";
            this.dgctsanphamson.RowHeadersWidth = 51;
            this.dgctsanphamson.RowTemplate.Height = 24;
            this.dgctsanphamson.Size = new System.Drawing.Size(879, 249);
            this.dgctsanphamson.TabIndex = 0;
            this.dgctsanphamson.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgctsanphamson_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.Controls.Add(this.tbnhh);
            this.panel1.Controls.Add(this.tbnsx);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbhangsp);
            this.panel1.Controls.Add(this.tbmausac);
            this.panel1.Controls.Add(this.tbdactinh);
            this.panel1.Controls.Add(this.tbmsp);
            this.panel1.Controls.Add(this.bnThoat);
            this.panel1.Controls.Add(this.bnBoqua);
            this.panel1.Controls.Add(this.bnSearch);
            this.panel1.Controls.Add(this.bnXoa);
            this.panel1.Controls.Add(this.bnSua);
            this.panel1.Controls.Add(this.bnThem);
            this.panel1.Location = new System.Drawing.Point(45, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 263);
            this.panel1.TabIndex = 1;
            // 
            // bnThem
            // 
            this.bnThem.Location = new System.Drawing.Point(21, 199);
            this.bnThem.Name = "bnThem";
            this.bnThem.Size = new System.Drawing.Size(106, 44);
            this.bnThem.TabIndex = 0;
            this.bnThem.Text = "Thêm";
            this.bnThem.UseVisualStyleBackColor = true;
            this.bnThem.Click += new System.EventHandler(this.bnThem_Click);
            // 
            // bnSua
            // 
            this.bnSua.Location = new System.Drawing.Point(146, 199);
            this.bnSua.Name = "bnSua";
            this.bnSua.Size = new System.Drawing.Size(106, 44);
            this.bnSua.TabIndex = 1;
            this.bnSua.Text = "Sửa ";
            this.bnSua.UseVisualStyleBackColor = true;
            this.bnSua.Click += new System.EventHandler(this.bnSua_Click);
            // 
            // bnXoa
            // 
            this.bnXoa.Location = new System.Drawing.Point(280, 199);
            this.bnXoa.Name = "bnXoa";
            this.bnXoa.Size = new System.Drawing.Size(106, 44);
            this.bnXoa.TabIndex = 2;
            this.bnXoa.Text = "Xóa";
            this.bnXoa.UseVisualStyleBackColor = true;
            this.bnXoa.Click += new System.EventHandler(this.bnXoa_Click);
            // 
            // bnSearch
            // 
            this.bnSearch.Location = new System.Drawing.Point(421, 199);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(106, 44);
            this.bnSearch.TabIndex = 3;
            this.bnSearch.Text = "Tìm Kiếm";
            this.bnSearch.UseVisualStyleBackColor = true;
            this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click);
            // 
            // bnBoqua
            // 
            this.bnBoqua.Location = new System.Drawing.Point(567, 199);
            this.bnBoqua.Name = "bnBoqua";
            this.bnBoqua.Size = new System.Drawing.Size(106, 44);
            this.bnBoqua.TabIndex = 4;
            this.bnBoqua.Text = "Bỏ qua";
            this.bnBoqua.UseVisualStyleBackColor = true;
            this.bnBoqua.Click += new System.EventHandler(this.bnBoqua_Click);
            // 
            // bnThoat
            // 
            this.bnThoat.Location = new System.Drawing.Point(702, 199);
            this.bnThoat.Name = "bnThoat";
            this.bnThoat.Size = new System.Drawing.Size(106, 44);
            this.bnThoat.TabIndex = 5;
            this.bnThoat.Text = "Thoát";
            this.bnThoat.UseVisualStyleBackColor = true;
            this.bnThoat.Click += new System.EventHandler(this.bnThoat_Click);
            // 
            // tbmsp
            // 
            this.tbmsp.Location = new System.Drawing.Point(111, 26);
            this.tbmsp.Multiline = true;
            this.tbmsp.Name = "tbmsp";
            this.tbmsp.Size = new System.Drawing.Size(127, 33);
            this.tbmsp.TabIndex = 6;
            // 
            // tbdactinh
            // 
            this.tbdactinh.Location = new System.Drawing.Point(111, 97);
            this.tbdactinh.Multiline = true;
            this.tbdactinh.Name = "tbdactinh";
            this.tbdactinh.Size = new System.Drawing.Size(127, 33);
            this.tbdactinh.TabIndex = 7;
            // 
            // tbmausac
            // 
            this.tbmausac.Location = new System.Drawing.Point(373, 26);
            this.tbmausac.Multiline = true;
            this.tbmausac.Name = "tbmausac";
            this.tbmausac.Size = new System.Drawing.Size(127, 33);
            this.tbmausac.TabIndex = 8;
            // 
            // tbhangsp
            // 
            this.tbhangsp.Location = new System.Drawing.Point(373, 97);
            this.tbhangsp.Multiline = true;
            this.tbhangsp.Name = "tbhangsp";
            this.tbhangsp.Size = new System.Drawing.Size(127, 33);
            this.tbhangsp.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Đặc tính";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Màu sắc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Hãng sản phẩm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Ngày sản xuất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ngày hết hạn";
            // 
            // tbnsx
            // 
            this.tbnsx.Location = new System.Drawing.Point(691, 37);
            this.tbnsx.Mask = "00/00/0000";
            this.tbnsx.Name = "tbnsx";
            this.tbnsx.Size = new System.Drawing.Size(136, 22);
            this.tbnsx.TabIndex = 18;
            this.tbnsx.ValidatingType = typeof(System.DateTime);
            // 
            // tbnhh
            // 
            this.tbnhh.Location = new System.Drawing.Point(691, 104);
            this.tbnhh.Mask = "00/00/0000";
            this.tbnhh.Name = "tbnhh";
            this.tbnhh.Size = new System.Drawing.Size(136, 22);
            this.tbnhh.TabIndex = 19;
            this.tbnhh.ValidatingType = typeof(System.DateTime);
            // 
            // ChiTietSanPhamSon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(942, 601);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgctsanphamson);
            this.Name = "ChiTietSanPhamSon";
            this.Text = "ChiTietSanPhamSon";
            this.Load += new System.EventHandler(this.ChiTietSanPhamSon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgctsanphamson)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgctsanphamson;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bnThem;
        private System.Windows.Forms.Button bnBoqua;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.Button bnXoa;
        private System.Windows.Forms.Button bnSua;
        private System.Windows.Forms.Button bnThoat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbhangsp;
        private System.Windows.Forms.TextBox tbmausac;
        private System.Windows.Forms.TextBox tbdactinh;
        private System.Windows.Forms.TextBox tbmsp;
        private System.Windows.Forms.MaskedTextBox tbnhh;
        private System.Windows.Forms.MaskedTextBox tbnsx;
    }
}