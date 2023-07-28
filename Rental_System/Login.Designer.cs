
namespace Rental_System
{
    partial class Login
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
            this.loginTab = new System.Windows.Forms.TabControl();
            this.customerLoginTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customerRegisterLink = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnCustomerLogin = new System.Windows.Forms.Button();
            this.inputCustomerPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inputCustomerEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.adminLoginTab = new System.Windows.Forms.TabPage();
            this.adminGroupBox = new System.Windows.Forms.GroupBox();
            this.adminRegisterLink = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdminLogin = new System.Windows.Forms.Button();
            this.inputAdminPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inputAdminEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.loginTab.SuspendLayout();
            this.customerLoginTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.adminLoginTab.SuspendLayout();
            this.adminGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.customerLoginTab);
            this.loginTab.Controls.Add(this.adminLoginTab);
            this.loginTab.ItemSize = new System.Drawing.Size(405, 30);
            this.loginTab.Location = new System.Drawing.Point(12, 12);
            this.loginTab.Name = "loginTab";
            this.loginTab.SelectedIndex = 0;
            this.loginTab.Size = new System.Drawing.Size(1086, 620);
            this.loginTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.loginTab.TabIndex = 0;
            // 
            // customerLoginTab
            // 
            this.customerLoginTab.Controls.Add(this.groupBox1);
            this.customerLoginTab.Location = new System.Drawing.Point(4, 34);
            this.customerLoginTab.Name = "customerLoginTab";
            this.customerLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.customerLoginTab.Size = new System.Drawing.Size(1078, 582);
            this.customerLoginTab.TabIndex = 0;
            this.customerLoginTab.Text = "Customer Login";
            this.customerLoginTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customerRegisterLink);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.btnCustomerLogin);
            this.groupBox1.Controls.Add(this.inputCustomerPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inputCustomerEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(232, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 512);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Login";
            // 
            // customerRegisterLink
            // 
            this.customerRegisterLink.AutoSize = true;
            this.customerRegisterLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerRegisterLink.ForeColor = System.Drawing.Color.MediumBlue;
            this.customerRegisterLink.Location = new System.Drawing.Point(377, 445);
            this.customerRegisterLink.Name = "customerRegisterLink";
            this.customerRegisterLink.Size = new System.Drawing.Size(72, 20);
            this.customerRegisterLink.TabIndex = 82;
            this.customerRegisterLink.Text = "Register";
            this.customerRegisterLink.Click += new System.EventHandler(this.customerRegisterLink_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(181, 445);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(176, 20);
            this.label30.TabIndex = 81;
            this.label30.Text = "Are you new member?";
            // 
            // btnCustomerLogin
            // 
            this.btnCustomerLogin.BackColor = System.Drawing.Color.DarkBlue;
            this.btnCustomerLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCustomerLogin.FlatAppearance.BorderSize = 0;
            this.btnCustomerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerLogin.ForeColor = System.Drawing.Color.White;
            this.btnCustomerLogin.Location = new System.Drawing.Point(228, 310);
            this.btnCustomerLogin.Name = "btnCustomerLogin";
            this.btnCustomerLogin.Size = new System.Drawing.Size(251, 46);
            this.btnCustomerLogin.TabIndex = 59;
            this.btnCustomerLogin.Text = "Login";
            this.btnCustomerLogin.UseVisualStyleBackColor = false;
            this.btnCustomerLogin.Click += new System.EventHandler(this.btnCustomerLogin_Click);
            // 
            // inputCustomerPassword
            // 
            this.inputCustomerPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputCustomerPassword.Location = new System.Drawing.Point(191, 213);
            this.inputCustomerPassword.Multiline = true;
            this.inputCustomerPassword.Name = "inputCustomerPassword";
            this.inputCustomerPassword.PasswordChar = '*';
            this.inputCustomerPassword.Size = new System.Drawing.Size(323, 42);
            this.inputCustomerPassword.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Password";
            // 
            // inputCustomerEmail
            // 
            this.inputCustomerEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputCustomerEmail.Location = new System.Drawing.Point(191, 99);
            this.inputCustomerEmail.Multiline = true;
            this.inputCustomerEmail.Name = "inputCustomerEmail";
            this.inputCustomerEmail.Size = new System.Drawing.Size(323, 42);
            this.inputCustomerEmail.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Email";
            // 
            // adminLoginTab
            // 
            this.adminLoginTab.Controls.Add(this.adminGroupBox);
            this.adminLoginTab.Location = new System.Drawing.Point(4, 34);
            this.adminLoginTab.Name = "adminLoginTab";
            this.adminLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.adminLoginTab.Size = new System.Drawing.Size(1078, 582);
            this.adminLoginTab.TabIndex = 1;
            this.adminLoginTab.Text = "Admin Login";
            this.adminLoginTab.UseVisualStyleBackColor = true;
            // 
            // adminGroupBox
            // 
            this.adminGroupBox.Controls.Add(this.adminRegisterLink);
            this.adminGroupBox.Controls.Add(this.label3);
            this.adminGroupBox.Controls.Add(this.btnAdminLogin);
            this.adminGroupBox.Controls.Add(this.inputAdminPassword);
            this.adminGroupBox.Controls.Add(this.label4);
            this.adminGroupBox.Controls.Add(this.inputAdminEmail);
            this.adminGroupBox.Controls.Add(this.label6);
            this.adminGroupBox.Location = new System.Drawing.Point(232, 29);
            this.adminGroupBox.Name = "adminGroupBox";
            this.adminGroupBox.Size = new System.Drawing.Size(614, 512);
            this.adminGroupBox.TabIndex = 85;
            this.adminGroupBox.TabStop = false;
            this.adminGroupBox.Text = "Admin Login";
            // 
            // adminRegisterLink
            // 
            this.adminRegisterLink.AutoSize = true;
            this.adminRegisterLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminRegisterLink.ForeColor = System.Drawing.Color.MediumBlue;
            this.adminRegisterLink.Location = new System.Drawing.Point(377, 445);
            this.adminRegisterLink.Name = "adminRegisterLink";
            this.adminRegisterLink.Size = new System.Drawing.Size(72, 20);
            this.adminRegisterLink.TabIndex = 82;
            this.adminRegisterLink.Text = "Register";
            this.adminRegisterLink.Click += new System.EventHandler(this.adminRegisterLink_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(181, 445);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Are you new member?";
            // 
            // btnAdminLogin
            // 
            this.btnAdminLogin.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAdminLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdminLogin.FlatAppearance.BorderSize = 0;
            this.btnAdminLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminLogin.ForeColor = System.Drawing.Color.White;
            this.btnAdminLogin.Location = new System.Drawing.Point(228, 310);
            this.btnAdminLogin.Name = "btnAdminLogin";
            this.btnAdminLogin.Size = new System.Drawing.Size(251, 46);
            this.btnAdminLogin.TabIndex = 59;
            this.btnAdminLogin.Text = "Login";
            this.btnAdminLogin.UseVisualStyleBackColor = false;
            this.btnAdminLogin.Click += new System.EventHandler(this.btnAdminLogin_Click);
            // 
            // inputAdminPassword
            // 
            this.inputAdminPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputAdminPassword.Location = new System.Drawing.Point(191, 213);
            this.inputAdminPassword.Multiline = true;
            this.inputAdminPassword.Name = "inputAdminPassword";
            this.inputAdminPassword.PasswordChar = '*';
            this.inputAdminPassword.Size = new System.Drawing.Size(323, 42);
            this.inputAdminPassword.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 58;
            this.label4.Text = "Password";
            // 
            // inputAdminEmail
            // 
            this.inputAdminEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputAdminEmail.Location = new System.Drawing.Point(191, 99);
            this.inputAdminEmail.Multiline = true;
            this.inputAdminEmail.Name = "inputAdminEmail";
            this.inputAdminEmail.Size = new System.Drawing.Size(323, 42);
            this.inputAdminEmail.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 56;
            this.label6.Text = "Email";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1110, 644);
            this.Controls.Add(this.loginTab);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.Login_Load);
            this.loginTab.ResumeLayout(false);
            this.customerLoginTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.adminLoginTab.ResumeLayout(false);
            this.adminGroupBox.ResumeLayout(false);
            this.adminGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl loginTab;
        private System.Windows.Forms.TabPage customerLoginTab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label customerRegisterLink;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnCustomerLogin;
        private System.Windows.Forms.TextBox inputCustomerPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputCustomerEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage adminLoginTab;
        private System.Windows.Forms.GroupBox adminGroupBox;
        private System.Windows.Forms.Label adminRegisterLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdminLogin;
        private System.Windows.Forms.TextBox inputAdminPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputAdminEmail;
        private System.Windows.Forms.Label label6;
    }
}