namespace GUI
{
    partial class Form1
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
            this.txt_MatKhau1 = new Control.txt_MatKhau();
            this.txt_MatKhau2 = new Control.txt_MatKhau();
            this.SuspendLayout();
            // 
            // txt_MatKhau1
            // 
            this.txt_MatKhau1.Location = new System.Drawing.Point(0, 0);
            this.txt_MatKhau1.Name = "txt_MatKhau1";
            this.txt_MatKhau1.Size = new System.Drawing.Size(200, 94);
            this.txt_MatKhau1.TabIndex = 0;
            // 
            // txt_MatKhau2
            // 
            this.txt_MatKhau2.Location = new System.Drawing.Point(195, 141);
            this.txt_MatKhau2.Name = "txt_MatKhau2";
            this.txt_MatKhau2.Size = new System.Drawing.Size(200, 26);
            this.txt_MatKhau2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_MatKhau2);
            this.Controls.Add(this.txt_MatKhau1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.txt_MatKhau txt_MatKhau1;
        private Control.txt_MatKhau txt_MatKhau2;
    }
}

