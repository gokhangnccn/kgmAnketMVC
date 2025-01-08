namespace kgmAnket
{
    partial class formMainDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMainDashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAnketOlustur = new System.Windows.Forms.Panel();
            this.panelAnketGoruntule = new System.Windows.Forms.Panel();
            this.panelAnketIstatistikleri = new System.Windows.Forms.Panel();
            this.panelAnketVeriGirisi = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Unispace", 108F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(58, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1129, 173);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOŞGELDİNİZ!";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Unispace", 87.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(298, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(627, 140);
            this.label2.TabIndex = 2;
            this.label2.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelAnketOlustur
            // 
            this.panelAnketOlustur.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAnketOlustur.BackColor = System.Drawing.Color.Transparent;
            this.panelAnketOlustur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAnketOlustur.BackgroundImage")));
            this.panelAnketOlustur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAnketOlustur.Location = new System.Drawing.Point(170, 507);
            this.panelAnketOlustur.Name = "panelAnketOlustur";
            this.panelAnketOlustur.Size = new System.Drawing.Size(200, 200);
            this.panelAnketOlustur.TabIndex = 4;
            this.panelAnketOlustur.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAnketOlustur_MouseClick);
            this.panelAnketOlustur.MouseEnter += new System.EventHandler(this.panelAnketOlustur_MouseEnter);
            this.panelAnketOlustur.MouseLeave += new System.EventHandler(this.panelAnketOlustur_MouseLeave);
            // 
            // panelAnketGoruntule
            // 
            this.panelAnketGoruntule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAnketGoruntule.BackColor = System.Drawing.Color.Transparent;
            this.panelAnketGoruntule.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAnketGoruntule.BackgroundImage")));
            this.panelAnketGoruntule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAnketGoruntule.Location = new System.Drawing.Point(395, 507);
            this.panelAnketGoruntule.Name = "panelAnketGoruntule";
            this.panelAnketGoruntule.Size = new System.Drawing.Size(200, 200);
            this.panelAnketGoruntule.TabIndex = 4;
            this.panelAnketGoruntule.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAnketGoruntule_Paint);
            this.panelAnketGoruntule.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAnketGoruntule_MouseClick);
            this.panelAnketGoruntule.MouseEnter += new System.EventHandler(this.panelAnketGoruntule_MouseEnter);
            this.panelAnketGoruntule.MouseLeave += new System.EventHandler(this.panelAnketGoruntule_MouseLeave);
            // 
            // panelAnketIstatistikleri
            // 
            this.panelAnketIstatistikleri.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAnketIstatistikleri.BackColor = System.Drawing.Color.Transparent;
            this.panelAnketIstatistikleri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAnketIstatistikleri.BackgroundImage")));
            this.panelAnketIstatistikleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAnketIstatistikleri.Location = new System.Drawing.Point(620, 507);
            this.panelAnketIstatistikleri.Name = "panelAnketIstatistikleri";
            this.panelAnketIstatistikleri.Size = new System.Drawing.Size(200, 200);
            this.panelAnketIstatistikleri.TabIndex = 4;
            this.panelAnketIstatistikleri.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAnketIstatistikleri_MouseClick);
            this.panelAnketIstatistikleri.MouseEnter += new System.EventHandler(this.panelAnketIstatistikleri_MouseEnter);
            this.panelAnketIstatistikleri.MouseLeave += new System.EventHandler(this.panelAnketIstatistikleri_MouseLeave);
            // 
            // panelAnketVeriGirisi
            // 
            this.panelAnketVeriGirisi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAnketVeriGirisi.BackColor = System.Drawing.Color.Transparent;
            this.panelAnketVeriGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAnketVeriGirisi.BackgroundImage")));
            this.panelAnketVeriGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAnketVeriGirisi.Location = new System.Drawing.Point(845, 507);
            this.panelAnketVeriGirisi.Name = "panelAnketVeriGirisi";
            this.panelAnketVeriGirisi.Size = new System.Drawing.Size(200, 200);
            this.panelAnketVeriGirisi.TabIndex = 4;
            this.panelAnketVeriGirisi.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAnketVeriGirisi_Paint);
            this.panelAnketVeriGirisi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelAnketVeriGirisi_MouseClick);
            this.panelAnketVeriGirisi.MouseEnter += new System.EventHandler(this.panelAnketVeriGirisi_MouseEnter);
            this.panelAnketVeriGirisi.MouseLeave += new System.EventHandler(this.panelAnketVeriGirisi_MouseLeave);
            // 
            // formMainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1217, 745);
            this.Controls.Add(this.panelAnketVeriGirisi);
            this.Controls.Add(this.panelAnketIstatistikleri);
            this.Controls.Add(this.panelAnketGoruntule);
            this.Controls.Add(this.panelAnketOlustur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formMainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMainDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formMainDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelAnketOlustur;
        private System.Windows.Forms.Panel panelAnketGoruntule;
        private System.Windows.Forms.Panel panelAnketIstatistikleri;
        private System.Windows.Forms.Panel panelAnketVeriGirisi;
    }
}