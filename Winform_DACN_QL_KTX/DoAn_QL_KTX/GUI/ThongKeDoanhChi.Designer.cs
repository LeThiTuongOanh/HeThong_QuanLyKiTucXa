namespace GUI
{
    partial class ThongKeDoanhChi
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_CustomRedButton1 = new Control.Control.btn_CustomRedButton();
            this.btn_ThongKeChi = new Control.Control.btn_CustomRedButton();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.data_GV_ThongKeChi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.char1_ThongKeChi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_GV_ThongKeChi)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.char1_ThongKeChi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 99);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống Kế Doanh Chi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_CustomRedButton1);
            this.groupBox1.Controls.Add(this.btn_ThongKeChi);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.data_GV_ThongKeChi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 343);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Kê Chi";
            // 
            // btn_CustomRedButton1
            // 
            this.btn_CustomRedButton1.BackColor = System.Drawing.Color.DarkRed;
            this.btn_CustomRedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CustomRedButton1.FlatAppearance.BorderSize = 0;
            this.btn_CustomRedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CustomRedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btn_CustomRedButton1.ForeColor = System.Drawing.Color.White;
            this.btn_CustomRedButton1.Location = new System.Drawing.Point(403, 43);
            this.btn_CustomRedButton1.Name = "btn_CustomRedButton1";
            this.btn_CustomRedButton1.Size = new System.Drawing.Size(126, 40);
            this.btn_CustomRedButton1.TabIndex = 4;
            this.btn_CustomRedButton1.Text = "Báo Cáo";
            this.btn_CustomRedButton1.UseVisualStyleBackColor = false;
            // 
            // btn_ThongKeChi
            // 
            this.btn_ThongKeChi.BackColor = System.Drawing.Color.DarkRed;
            this.btn_ThongKeChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ThongKeChi.FlatAppearance.BorderSize = 0;
            this.btn_ThongKeChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ThongKeChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btn_ThongKeChi.ForeColor = System.Drawing.Color.White;
            this.btn_ThongKeChi.Location = new System.Drawing.Point(260, 43);
            this.btn_ThongKeChi.Name = "btn_ThongKeChi";
            this.btn_ThongKeChi.Size = new System.Drawing.Size(126, 40);
            this.btn_ThongKeChi.TabIndex = 3;
            this.btn_ThongKeChi.Text = "Thống Kê";
            this.btn_ThongKeChi.UseVisualStyleBackColor = false;
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(94, 43);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(124, 26);
            this.txtNam.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            // 
            // data_GV_ThongKeChi
            // 
            this.data_GV_ThongKeChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_GV_ThongKeChi.Location = new System.Drawing.Point(19, 89);
            this.data_GV_ThongKeChi.Name = "data_GV_ThongKeChi";
            this.data_GV_ThongKeChi.RowHeadersWidth = 62;
            this.data_GV_ThongKeChi.RowTemplate.Height = 28;
            this.data_GV_ThongKeChi.Size = new System.Drawing.Size(764, 226);
            this.data_GV_ThongKeChi.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.char1_ThongKeChi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox2.Location = new System.Drawing.Point(31, 478);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1251, 389);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Biểu Đồ Thống Kê";
            // 
            // char1_ThongKeChi
            // 
            chartArea1.Name = "ChartArea1";
            this.char1_ThongKeChi.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.char1_ThongKeChi.Legends.Add(legend1);
            this.char1_ThongKeChi.Location = new System.Drawing.Point(20, 34);
            this.char1_ThongKeChi.Name = "char1_ThongKeChi";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.char1_ThongKeChi.Series.Add(series1);
            this.char1_ThongKeChi.Size = new System.Drawing.Size(1204, 332);
            this.char1_ThongKeChi.TabIndex = 0;
            this.char1_ThongKeChi.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(827, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 334);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông Tin ";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(216, 280);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(212, 26);
            this.textBox4.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tổng Tiền";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(216, 219);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(212, 26);
            this.textBox3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phí Nhập Nguyên Liệu";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(216, 146);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(212, 26);
            this.textBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Phí Nhập Trang Thiết Bị";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(216, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(212, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phí Yêu Cầu Sửa Chữa";
            // 
            // ThongKeDoanhChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 997);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ThongKeDoanhChi";
            this.Text = "ThongKeDoanhChi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_GV_ThongKeChi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.char1_ThongKeChi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView data_GV_ThongKeChi;
        private Control.Control.btn_CustomRedButton btn_ThongKeChi;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart char1_ThongKeChi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private Control.Control.btn_CustomRedButton btn_CustomRedButton1;
    }
}