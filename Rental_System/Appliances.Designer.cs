
namespace Rental_System
{
    partial class Appliances
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.cartPanel = new System.Windows.Forms.Panel();
            this.appliancesTypeListViewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.appliancesListViewPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.AutoSize = true;
            this.panelContainer.Controls.Add(this.cartPanel);
            this.panelContainer.Controls.Add(this.appliancesTypeListViewPanel);
            this.panelContainer.Controls.Add(this.appliancesListViewPanel);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1781, 797);
            this.panelContainer.TabIndex = 0;
            // 
            // cartPanel
            // 
            this.cartPanel.Location = new System.Drawing.Point(1650, 12);
            this.cartPanel.Name = "cartPanel";
            this.cartPanel.Size = new System.Drawing.Size(128, 101);
            this.cartPanel.TabIndex = 2;
            // 
            // appliancesTypeListViewPanel
            // 
            this.appliancesTypeListViewPanel.AutoScroll = true;
            this.appliancesTypeListViewPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.appliancesTypeListViewPanel.Location = new System.Drawing.Point(155, 12);
            this.appliancesTypeListViewPanel.Name = "appliancesTypeListViewPanel";
            this.appliancesTypeListViewPanel.Size = new System.Drawing.Size(1480, 220);
            this.appliancesTypeListViewPanel.TabIndex = 1;
            // 
            // appliancesListViewPanel
            // 
            this.appliancesListViewPanel.AutoScroll = true;
            this.appliancesListViewPanel.Location = new System.Drawing.Point(155, 230);
            this.appliancesListViewPanel.Name = "appliancesListViewPanel";
            this.appliancesListViewPanel.Size = new System.Drawing.Size(1865, 749);
            this.appliancesListViewPanel.TabIndex = 0;
            // 
            // Appliances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1781, 797);
            this.Controls.Add(this.panelContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Appliances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appliances";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Appliances_Load);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.FlowLayoutPanel appliancesTypeListViewPanel;
        private System.Windows.Forms.FlowLayoutPanel appliancesListViewPanel;
        private System.Windows.Forms.Panel cartPanel;
    }
}