
namespace Rental_System
{
    partial class ApplianceTypeForm
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
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inputName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.inputDescription = new System.Windows.Forms.TextBox();
            this.inputUsageTips = new System.Windows.Forms.TextBox();
            this.applianceTypeDGV = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.inputId = new System.Windows.Forms.TextBox();
            this.imageView = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.applianceTypeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).BeginInit();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(566, 175);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 23);
            this.label24.TabIndex = 45;
            this.label24.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(524, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(18, 23);
            this.label20.TabIndex = 43;
            this.label20.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(466, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Description";
            // 
            // inputName
            // 
            this.inputName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputName.Location = new System.Drawing.Point(468, 89);
            this.inputName.Multiline = true;
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(323, 42);
            this.inputName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(465, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Name";
            // 
            // inputDescription
            // 
            this.inputDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputDescription.Location = new System.Drawing.Point(469, 200);
            this.inputDescription.Multiline = true;
            this.inputDescription.Name = "inputDescription";
            this.inputDescription.Size = new System.Drawing.Size(323, 42);
            this.inputDescription.TabIndex = 6;
            // 
            // inputUsageTips
            // 
            this.inputUsageTips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputUsageTips.Location = new System.Drawing.Point(827, 89);
            this.inputUsageTips.Multiline = true;
            this.inputUsageTips.Name = "inputUsageTips";
            this.inputUsageTips.Size = new System.Drawing.Size(323, 42);
            this.inputUsageTips.TabIndex = 3;
            // 
            // applianceTypeDGV
            // 
            this.applianceTypeDGV.AllowUserToAddRows = false;
            this.applianceTypeDGV.AllowUserToDeleteRows = false;
            this.applianceTypeDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.applianceTypeDGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.applianceTypeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.applianceTypeDGV.Location = new System.Drawing.Point(50, 504);
            this.applianceTypeDGV.Name = "applianceTypeDGV";
            this.applianceTypeDGV.ReadOnly = true;
            this.applianceTypeDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.applianceTypeDGV.RowTemplate.Height = 24;
            this.applianceTypeDGV.Size = new System.Drawing.Size(1940, 469);
            this.applianceTypeDGV.TabIndex = 46;
            this.applianceTypeDGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.applianceTypeDGV_CellMouseClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(828, 387);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(251, 46);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkRed;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(545, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(251, 46);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // inputId
            // 
            this.inputId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.inputId.HideSelection = false;
            this.inputId.Location = new System.Drawing.Point(108, 318);
            this.inputId.Multiline = true;
            this.inputId.Name = "inputId";
            this.inputId.Size = new System.Drawing.Size(187, 42);
            this.inputId.TabIndex = 99;
            this.inputId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputId.Visible = false;
            // 
            // imageView
            // 
            this.imageView.Location = new System.Drawing.Point(76, 89);
            this.imageView.Name = "imageView";
            this.imageView.Size = new System.Drawing.Size(247, 219);
            this.imageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageView.TabIndex = 100;
            this.imageView.TabStop = false;
            this.imageView.Click += new System.EventHandler(this.imageView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(824, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Usage Tips";
            // 
            // ApplianceTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 977);
            this.Controls.Add(this.imageView);
            this.Controls.Add(this.inputId);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.applianceTypeDGV);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inputDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputUsageTips);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApplianceTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApplianceType";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ApplianceTypeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.applianceTypeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inputDescription;
        private System.Windows.Forms.TextBox inputUsageTips;
        private System.Windows.Forms.DataGridView applianceTypeDGV;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox inputId;
        private System.Windows.Forms.PictureBox imageView;
        private System.Windows.Forms.Label label3;
    }
}