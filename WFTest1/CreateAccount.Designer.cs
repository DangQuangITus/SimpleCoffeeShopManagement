namespace WFTest1
{
    partial class CreateAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbNhanVien = new System.Windows.Forms.CheckBox();
            this.ckbQuanLy = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCreateAcc = new System.Windows.Forms.Button();
            this.tbCreateDisplayName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCreatePass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCreateReEnterNewPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCreateNameLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckbNhanVien);
            this.panel1.Controls.Add(this.ckbQuanLy);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnCreateAcc);
            this.panel1.Controls.Add(this.tbCreateDisplayName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbCreatePass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbCreateReEnterNewPass);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbCreateNameLogin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 412);
            this.panel1.TabIndex = 1;
            // 
            // ckbNhanVien
            // 
            this.ckbNhanVien.AutoSize = true;
            this.ckbNhanVien.Location = new System.Drawing.Point(374, 225);
            this.ckbNhanVien.Name = "ckbNhanVien";
            this.ckbNhanVien.Size = new System.Drawing.Size(96, 21);
            this.ckbNhanVien.TabIndex = 16;
            this.ckbNhanVien.Text = "Nhân Viên";
            this.ckbNhanVien.UseVisualStyleBackColor = true;
            this.ckbNhanVien.CheckedChanged += new System.EventHandler(this.ckbNhanVien_CheckedChanged);
            // 
            // ckbQuanLy
            // 
            this.ckbQuanLy.AutoSize = true;
            this.ckbQuanLy.Location = new System.Drawing.Point(255, 225);
            this.ckbQuanLy.Name = "ckbQuanLy";
            this.ckbQuanLy.Size = new System.Drawing.Size(79, 21);
            this.ckbQuanLy.TabIndex = 15;
            this.ckbQuanLy.Text = "Quản lý";
            this.ckbQuanLy.UseVisualStyleBackColor = true;
            this.ckbQuanLy.CheckedChanged += new System.EventHandler(this.ckbQuanLy_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExit.Location = new System.Drawing.Point(382, 268);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 34);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.AutoSize = true;
            this.btnCreateAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCreateAcc.Location = new System.Drawing.Point(255, 268);
            this.btnCreateAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.Size = new System.Drawing.Size(107, 34);
            this.btnCreateAcc.TabIndex = 13;
            this.btnCreateAcc.Text = "Tạo";
            this.btnCreateAcc.UseVisualStyleBackColor = true;
            this.btnCreateAcc.Click += new System.EventHandler(this.btnCreateAcc_Click);
            // 
            // tbCreateDisplayName
            // 
            this.tbCreateDisplayName.Location = new System.Drawing.Point(255, 78);
            this.tbCreateDisplayName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCreateDisplayName.Multiline = true;
            this.tbCreateDisplayName.Name = "tbCreateDisplayName";
            this.tbCreateDisplayName.Size = new System.Drawing.Size(293, 25);
            this.tbCreateDisplayName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(27, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tên người dùng";
            // 
            // tbCreatePass
            // 
            this.tbCreatePass.Location = new System.Drawing.Point(255, 128);
            this.tbCreatePass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCreatePass.Multiline = true;
            this.tbCreatePass.Name = "tbCreatePass";
            this.tbCreatePass.Size = new System.Drawing.Size(293, 25);
            this.tbCreatePass.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(27, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 27);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mật khẩu";
            // 
            // tbCreateReEnterNewPass
            // 
            this.tbCreateReEnterNewPass.Location = new System.Drawing.Point(255, 176);
            this.tbCreateReEnterNewPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCreateReEnterNewPass.Multiline = true;
            this.tbCreateReEnterNewPass.Name = "tbCreateReEnterNewPass";
            this.tbCreateReEnterNewPass.Size = new System.Drawing.Size(293, 25);
            this.tbCreateReEnterNewPass.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(27, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nhập lại mật khẩu";
            // 
            // tbCreateNameLogin
            // 
            this.tbCreateNameLogin.Location = new System.Drawing.Point(255, 28);
            this.tbCreateNameLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCreateNameLogin.Multiline = true;
            this.tbCreateNameLogin.Name = "tbCreateNameLogin";
            this.tbCreateNameLogin.Size = new System.Drawing.Size(293, 25);
            this.tbCreateNameLogin.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên Đăng Nhập";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(628, 434);
            this.Controls.Add(this.panel1);
            this.Name = "CreateAccount";
            this.Text = "CreateAccount";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreateAcc;
        private System.Windows.Forms.TextBox tbCreateDisplayName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCreatePass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCreateReEnterNewPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCreateNameLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbNhanVien;
        private System.Windows.Forms.CheckBox ckbQuanLy;
    }
}