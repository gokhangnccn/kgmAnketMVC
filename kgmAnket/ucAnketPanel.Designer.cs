namespace kgmAnket
{
    partial class ucAnketPanel
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelAnket = new System.Windows.Forms.Panel();
            this.btnAnketVeriGirisi = new System.Windows.Forms.Button();
            this.dateBitis = new System.Windows.Forms.DateTimePicker();
            this.dateBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBeklenilenKatilimciSayisi = new System.Windows.Forms.TextBox();
            this.txtAnketiOlusturan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAnketBasligi = new System.Windows.Forms.Label();
            this.panelAnket.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAnket
            // 
            this.panelAnket.AutoScroll = true;
            this.panelAnket.BackColor = System.Drawing.Color.Transparent;
            this.panelAnket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnket.Controls.Add(this.btnAnketVeriGirisi);
            this.panelAnket.Controls.Add(this.dateBitis);
            this.panelAnket.Controls.Add(this.dateBaslangic);
            this.panelAnket.Controls.Add(this.label3);
            this.panelAnket.Controls.Add(this.label2);
            this.panelAnket.Controls.Add(this.txtBeklenilenKatilimciSayisi);
            this.panelAnket.Controls.Add(this.txtAnketiOlusturan);
            this.panelAnket.Controls.Add(this.label1);
            this.panelAnket.Location = new System.Drawing.Point(3, 20);
            this.panelAnket.Name = "panelAnket";
            this.panelAnket.Size = new System.Drawing.Size(806, 320);
            this.panelAnket.TabIndex = 5;
            // 
            // btnAnketVeriGirisi
            // 
            this.btnAnketVeriGirisi.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnketVeriGirisi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAnketVeriGirisi.Location = new System.Drawing.Point(63, 267);
            this.btnAnketVeriGirisi.Name = "btnAnketVeriGirisi";
            this.btnAnketVeriGirisi.Size = new System.Drawing.Size(185, 41);
            this.btnAnketVeriGirisi.TabIndex = 4;
            this.btnAnketVeriGirisi.Text = "Anket Veri Girişi";
            this.btnAnketVeriGirisi.UseVisualStyleBackColor = true;
            this.btnAnketVeriGirisi.Click += new System.EventHandler(this.btnAnketVeriGirisi_Click);
            // 
            // dateBitis
            // 
            this.dateBitis.Enabled = false;
            this.dateBitis.Location = new System.Drawing.Point(30, 224);
            this.dateBitis.Name = "dateBitis";
            this.dateBitis.Size = new System.Drawing.Size(255, 20);
            this.dateBitis.TabIndex = 3;
            // 
            // dateBaslangic
            // 
            this.dateBaslangic.Enabled = false;
            this.dateBaslangic.Location = new System.Drawing.Point(30, 200);
            this.dateBaslangic.Name = "dateBaslangic";
            this.dateBaslangic.Size = new System.Drawing.Size(255, 20);
            this.dateBaslangic.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(26, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Beklenilen Katılımcı Sayısı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(26, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Anket Tarihi:";
            // 
            // txtBeklenilenKatilimciSayisi
            // 
            this.txtBeklenilenKatilimciSayisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeklenilenKatilimciSayisi.Enabled = false;
            this.txtBeklenilenKatilimciSayisi.Font = new System.Drawing.Font("Zilla Slab", 9.749999F);
            this.txtBeklenilenKatilimciSayisi.Location = new System.Drawing.Point(30, 133);
            this.txtBeklenilenKatilimciSayisi.Name = "txtBeklenilenKatilimciSayisi";
            this.txtBeklenilenKatilimciSayisi.Size = new System.Drawing.Size(255, 23);
            this.txtBeklenilenKatilimciSayisi.TabIndex = 2;
            // 
            // txtAnketiOlusturan
            // 
            this.txtAnketiOlusturan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnketiOlusturan.Enabled = false;
            this.txtAnketiOlusturan.Font = new System.Drawing.Font("Zilla Slab", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAnketiOlusturan.Location = new System.Drawing.Point(30, 60);
            this.txtAnketiOlusturan.Name = "txtAnketiOlusturan";
            this.txtAnketiOlusturan.Size = new System.Drawing.Size(255, 23);
            this.txtAnketiOlusturan.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Anketi Oluşturan:";
            // 
            // lblAnketBasligi
            // 
            this.lblAnketBasligi.AutoSize = true;
            this.lblAnketBasligi.BackColor = System.Drawing.Color.Transparent;
            this.lblAnketBasligi.Font = new System.Drawing.Font("Zilla Slab SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnketBasligi.Location = new System.Drawing.Point(30, 5);
            this.lblAnketBasligi.Name = "lblAnketBasligi";
            this.lblAnketBasligi.Size = new System.Drawing.Size(122, 23);
            this.lblAnketBasligi.TabIndex = 4;
            this.lblAnketBasligi.Text = "Anket Başlığı";
            // 
            // ucAnketPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAnketBasligi);
            this.Controls.Add(this.panelAnket);
            this.Name = "ucAnketPanel";
            this.Size = new System.Drawing.Size(815, 341);
            this.Load += new System.EventHandler(this.ucAnketPanel_Load);
            this.panelAnket.ResumeLayout(false);
            this.panelAnket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAnket;
        private System.Windows.Forms.Button btnAnketVeriGirisi;
        private System.Windows.Forms.DateTimePicker dateBitis;
        private System.Windows.Forms.DateTimePicker dateBaslangic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBeklenilenKatilimciSayisi;
        private System.Windows.Forms.TextBox txtAnketiOlusturan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAnketBasligi;
    }
}
