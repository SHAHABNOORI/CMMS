namespace CMMS
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonItem14 = new DevComponents.DotNetBar.ButtonItem();
            this.mbtnShenasnameh = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnMashinAlat = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnGhalebha = new System.Windows.Forms.ToolStripMenuItem();
            this.انبارداریToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnGhataatYadaki = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ثبتسوابقتعمیراتیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSavabeghMaShin = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtnSavabeghGhaleb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonItem14
            // 
            this.buttonItem14.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem14.FontBold = true;
            this.buttonItem14.Name = "buttonItem14";
            this.buttonItem14.SubItemsExpandWidth = 14;
            this.buttonItem14.Text = "ماشین آلات";
            // 
            // mbtnShenasnameh
            // 
            this.mbtnShenasnameh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnMashinAlat,
            this.mbtnGhalebha});
            this.mbtnShenasnameh.Image = ((System.Drawing.Image)(resources.GetObject("mbtnShenasnameh.Image")));
            this.mbtnShenasnameh.Name = "mbtnShenasnameh";
            this.mbtnShenasnameh.Size = new System.Drawing.Size(82, 20);
            this.mbtnShenasnameh.Text = "شناسنامه";
            // 
            // mbtnMashinAlat
            // 
            this.mbtnMashinAlat.Image = ((System.Drawing.Image)(resources.GetObject("mbtnMashinAlat.Image")));
            this.mbtnMashinAlat.Name = "mbtnMashinAlat";
            this.mbtnMashinAlat.Size = new System.Drawing.Size(130, 22);
            this.mbtnMashinAlat.Text = "ماشین آلات";
            this.mbtnMashinAlat.Click += new System.EventHandler(this.mbtnMashinAlat_Click);
            // 
            // mbtnGhalebha
            // 
            this.mbtnGhalebha.Image = ((System.Drawing.Image)(resources.GetObject("mbtnGhalebha.Image")));
            this.mbtnGhalebha.Name = "mbtnGhalebha";
            this.mbtnGhalebha.Size = new System.Drawing.Size(130, 22);
            this.mbtnGhalebha.Text = "قالب ها";
            this.mbtnGhalebha.Click += new System.EventHandler(this.mbtnGhalebha_Click);
            // 
            // انبارداریToolStripMenuItem
            // 
            this.انبارداریToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnGhataatYadaki});
            this.انبارداریToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("انبارداریToolStripMenuItem.Image")));
            this.انبارداریToolStripMenuItem.Name = "انبارداریToolStripMenuItem";
            this.انبارداریToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.انبارداریToolStripMenuItem.Text = "انبارداری";
            // 
            // mbtnGhataatYadaki
            // 
            this.mbtnGhataatYadaki.Image = ((System.Drawing.Image)(resources.GetObject("mbtnGhataatYadaki.Image")));
            this.mbtnGhataatYadaki.Name = "mbtnGhataatYadaki";
            this.mbtnGhataatYadaki.Size = new System.Drawing.Size(140, 22);
            this.mbtnGhataatYadaki.Text = "قطعات یدکی";
            this.mbtnGhataatYadaki.Click += new System.EventHandler(this.mbtnGhataatYadaki_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.انبارداریToolStripMenuItem,
            this.mbtnShenasnameh,
            this.ثبتسوابقتعمیراتیToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(907, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ثبتسوابقتعمیراتیToolStripMenuItem
            // 
            this.ثبتسوابقتعمیراتیToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtnSavabeghMaShin,
            this.mbtnSavabeghGhaleb});
            this.ثبتسوابقتعمیراتیToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ثبتسوابقتعمیراتیToolStripMenuItem.Image")));
            this.ثبتسوابقتعمیراتیToolStripMenuItem.Name = "ثبتسوابقتعمیراتیToolStripMenuItem";
            this.ثبتسوابقتعمیراتیToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.ثبتسوابقتعمیراتیToolStripMenuItem.Text = "ثبت سوابق تعمیراتی";
            // 
            // mbtnSavabeghMaShin
            // 
            this.mbtnSavabeghMaShin.Image = ((System.Drawing.Image)(resources.GetObject("mbtnSavabeghMaShin.Image")));
            this.mbtnSavabeghMaShin.Name = "mbtnSavabeghMaShin";
            this.mbtnSavabeghMaShin.Size = new System.Drawing.Size(180, 22);
            this.mbtnSavabeghMaShin.Text = "ماشین آلات";
            this.mbtnSavabeghMaShin.Click += new System.EventHandler(this.mbtnSavabeghMaShin_Click);
            // 
            // mbtnSavabeghGhaleb
            // 
            this.mbtnSavabeghGhaleb.Image = ((System.Drawing.Image)(resources.GetObject("mbtnSavabeghGhaleb.Image")));
            this.mbtnSavabeghGhaleb.Name = "mbtnSavabeghGhaleb";
            this.mbtnSavabeghGhaleb.Size = new System.Drawing.Size(180, 22);
            this.mbtnSavabeghGhaleb.Text = "قالب ها";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 540);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonItem buttonItem14;
        private System.Windows.Forms.ToolStripMenuItem mbtnShenasnameh;
        private System.Windows.Forms.ToolStripMenuItem mbtnMashinAlat;
        private System.Windows.Forms.ToolStripMenuItem mbtnGhalebha;
        private System.Windows.Forms.ToolStripMenuItem انبارداریToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnGhataatYadaki;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ثبتسوابقتعمیراتیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtnSavabeghMaShin;
        private System.Windows.Forms.ToolStripMenuItem mbtnSavabeghGhaleb;
    }
}