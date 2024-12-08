namespace GUI
{
    partial class QL_Phong
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeView_Phong = new System.Windows.Forms.TreeView();
            this.panelCapNhat = new System.Windows.Forms.Panel();
            this.Panel_capNhat = new System.Windows.Forms.Panel();
            this.cbo_maPhong = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_CapNhatThongTin = new System.Windows.Forms.Button();
            this.txt_SVToiDa = new Control.txt_ChiChuaSo();
            this.label5 = new System.Windows.Forms.Label();
            this.rdo_ngungHoatDong = new System.Windows.Forms.RadioButton();
            this.rdo_hoatDong = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_loaiPhong = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.panel_button = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelCapNhat.SuspendLayout();
            this.Panel_capNhat.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(267, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thông Tin Phòng";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.btn_CapNhat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 70);
            this.panel1.TabIndex = 3;
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhat.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_CapNhat.Location = new System.Drawing.Point(8, 20);
            this.btn_CapNhat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(157, 30);
            this.btn_CapNhat.TabIndex = 6;
            this.btn_CapNhat.Text = "Cập nhật";
            this.btn_CapNhat.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeView_Phong);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 70);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(165, 495);
            this.panel5.TabIndex = 11;
            // 
            // treeView_Phong
            // 
            this.treeView_Phong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Phong.Location = new System.Drawing.Point(0, 0);
            this.treeView_Phong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView_Phong.Name = "treeView_Phong";
            this.treeView_Phong.Size = new System.Drawing.Size(165, 495);
            this.treeView_Phong.TabIndex = 0;
            this.treeView_Phong.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_Phong_AfterSelect);
            // 
            // panelCapNhat
            // 
            this.panelCapNhat.Controls.Add(this.Panel_capNhat);
            this.panelCapNhat.Location = new System.Drawing.Point(275, 4);
            this.panelCapNhat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCapNhat.Name = "panelCapNhat";
            this.panelCapNhat.Size = new System.Drawing.Size(354, 386);
            this.panelCapNhat.TabIndex = 9;
            // 
            // Panel_capNhat
            // 
            this.Panel_capNhat.BackColor = System.Drawing.SystemColors.Highlight;
            this.Panel_capNhat.Controls.Add(this.cbo_maPhong);
            this.Panel_capNhat.Controls.Add(this.label6);
            this.Panel_capNhat.Controls.Add(this.btn_CapNhatThongTin);
            this.Panel_capNhat.Controls.Add(this.txt_SVToiDa);
            this.Panel_capNhat.Controls.Add(this.label5);
            this.Panel_capNhat.Controls.Add(this.rdo_ngungHoatDong);
            this.Panel_capNhat.Controls.Add(this.rdo_hoatDong);
            this.Panel_capNhat.Controls.Add(this.label3);
            this.Panel_capNhat.Controls.Add(this.cbo_loaiPhong);
            this.Panel_capNhat.Controls.Add(this.label4);
            this.Panel_capNhat.Controls.Add(this.panel4);
            this.Panel_capNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_capNhat.ForeColor = System.Drawing.SystemColors.Control;
            this.Panel_capNhat.Location = new System.Drawing.Point(0, 0);
            this.Panel_capNhat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Panel_capNhat.Name = "Panel_capNhat";
            this.Panel_capNhat.Size = new System.Drawing.Size(354, 386);
            this.Panel_capNhat.TabIndex = 5;
            // 
            // cbo_maPhong
            // 
            this.cbo_maPhong.FormattingEnabled = true;
            this.cbo_maPhong.Location = new System.Drawing.Point(143, 53);
            this.cbo_maPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbo_maPhong.Name = "cbo_maPhong";
            this.cbo_maPhong.Size = new System.Drawing.Size(164, 21);
            this.cbo_maPhong.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã phòng";
            // 
            // btn_CapNhatThongTin
            // 
            this.btn_CapNhatThongTin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_CapNhatThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CapNhatThongTin.Location = new System.Drawing.Point(205, 290);
            this.btn_CapNhatThongTin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CapNhatThongTin.Name = "btn_CapNhatThongTin";
            this.btn_CapNhatThongTin.Size = new System.Drawing.Size(100, 39);
            this.btn_CapNhatThongTin.TabIndex = 9;
            this.btn_CapNhatThongTin.Text = "Cập nhật";
            this.btn_CapNhatThongTin.UseVisualStyleBackColor = false;
            // 
            // txt_SVToiDa
            // 
            this.txt_SVToiDa.Location = new System.Drawing.Point(143, 219);
            this.txt_SVToiDa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_SVToiDa.Name = "txt_SVToiDa";
            this.txt_SVToiDa.Size = new System.Drawing.Size(164, 20);
            this.txt_SVToiDa.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số SV tối đa";
            // 
            // rdo_ngungHoatDong
            // 
            this.rdo_ngungHoatDong.AutoSize = true;
            this.rdo_ngungHoatDong.Location = new System.Drawing.Point(143, 170);
            this.rdo_ngungHoatDong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdo_ngungHoatDong.Name = "rdo_ngungHoatDong";
            this.rdo_ngungHoatDong.Size = new System.Drawing.Size(109, 17);
            this.rdo_ngungHoatDong.TabIndex = 6;
            this.rdo_ngungHoatDong.Text = "Ngưng hoạt động";
            this.rdo_ngungHoatDong.UseVisualStyleBackColor = true;
            // 
            // rdo_hoatDong
            // 
            this.rdo_hoatDong.AutoSize = true;
            this.rdo_hoatDong.Location = new System.Drawing.Point(143, 144);
            this.rdo_hoatDong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdo_hoatDong.Name = "rdo_hoatDong";
            this.rdo_hoatDong.Size = new System.Drawing.Size(76, 17);
            this.rdo_hoatDong.TabIndex = 5;
            this.rdo_hoatDong.Text = "Hoạt động";
            this.rdo_hoatDong.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 144);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng thái";
            // 
            // cbo_loaiPhong
            // 
            this.cbo_loaiPhong.FormattingEnabled = true;
            this.cbo_loaiPhong.Location = new System.Drawing.Point(143, 95);
            this.cbo_loaiPhong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbo_loaiPhong.Name = "cbo_loaiPhong";
            this.cbo_loaiPhong.Size = new System.Drawing.Size(164, 21);
            this.cbo_loaiPhong.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Loại Phòng";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.btn_Huy);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(354, 39);
            this.panel4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(105, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 39);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label1.Location = new System.Drawing.Point(47, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cập Nhật Phòng";
            // 
            // btn_Huy
            // 
            this.btn_Huy.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_Huy.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.Location = new System.Drawing.Point(0, 0);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(105, 39);
            this.btn_Huy.TabIndex = 0;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = false;
            this.btn_Huy.Click += new System.EventHandler(this.Btn_Huy_Click);
            // 
            // panel_button
            // 
            this.panel_button.Controls.Add(this.panelCapNhat);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_button.Location = new System.Drawing.Point(165, 70);
            this.panel_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(660, 495);
            this.panel_button.TabIndex = 12;
            // 
            // QL_Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 565);
            this.Controls.Add(this.panel_button);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QL_Phong";
            this.Text = "QL_Phong";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panelCapNhat.ResumeLayout(false);
            this.Panel_capNhat.ResumeLayout(false);
            this.Panel_capNhat.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TreeView treeView_Phong;
        private System.Windows.Forms.Panel panelCapNhat;
        private System.Windows.Forms.Panel Panel_capNhat;
        private System.Windows.Forms.Button btn_CapNhatThongTin;
        private Control.txt_ChiChuaSo txt_SVToiDa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdo_ngungHoatDong;
        private System.Windows.Forms.RadioButton rdo_hoatDong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_loaiPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.ComboBox cbo_maPhong;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Panel panel_button;
    }
}