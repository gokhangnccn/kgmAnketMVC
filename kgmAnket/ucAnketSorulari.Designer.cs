namespace kgmAnket
{
    partial class ucAnketSorulari
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
            this.panelSoru = new System.Windows.Forms.Panel();
            this.lblAnketinSorulari = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelSoru
            // 
            this.panelSoru.AutoScroll = true;
            this.panelSoru.BackColor = System.Drawing.Color.Transparent;
            this.panelSoru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSoru.Location = new System.Drawing.Point(3, 14);
            this.panelSoru.Name = "panelSoru";
            this.panelSoru.Size = new System.Drawing.Size(469, 247);
            this.panelSoru.TabIndex = 6;
            // 
            // lblAnketinSorulari
            // 
            this.lblAnketinSorulari.AutoSize = true;
            this.lblAnketinSorulari.BackColor = System.Drawing.Color.Transparent;
            this.lblAnketinSorulari.Font = new System.Drawing.Font("Zilla Slab Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnketinSorulari.Location = new System.Drawing.Point(12, 0);
            this.lblAnketinSorulari.Name = "lblAnketinSorulari";
            this.lblAnketinSorulari.Size = new System.Drawing.Size(162, 23);
            this.lblAnketinSorulari.TabIndex = 1;
            this.lblAnketinSorulari.Text = "Anketin Soruları";
            // 
            // ucAnketSorulari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblAnketinSorulari);
            this.Controls.Add(this.panelSoru);
            this.Name = "ucAnketSorulari";
            this.Size = new System.Drawing.Size(485, 268);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSoru;
        private System.Windows.Forms.Label lblAnketinSorulari;
    }
}
