namespace kgmAnket
{
    partial class formDetayliAnketListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDetayliAnketListesi));
            this.lblAnaBaslik = new System.Windows.Forms.Label();
            this.btnGeriAlt = new System.Windows.Forms.Button();
            this.btnGeriUst = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.lblAra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAnaBaslik
            // 
            this.lblAnaBaslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnaBaslik.AutoSize = true;
            this.lblAnaBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblAnaBaslik.Font = new System.Drawing.Font("Zilla Slab Medium", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnaBaslik.Location = new System.Drawing.Point(241, 33);
            this.lblAnaBaslik.Name = "lblAnaBaslik";
            this.lblAnaBaslik.Size = new System.Drawing.Size(372, 44);
            this.lblAnaBaslik.TabIndex = 1;
            this.lblAnaBaslik.Text = "Detaylı Anket Listesi";
            // 
            // btnGeriAlt
            // 
            this.btnGeriAlt.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGeriAlt.Font = new System.Drawing.Font("Zilla Slab", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriAlt.Location = new System.Drawing.Point(690, 12);
            this.btnGeriAlt.Name = "btnGeriAlt";
            this.btnGeriAlt.Size = new System.Drawing.Size(134, 36);
            this.btnGeriAlt.TabIndex = 4;
            this.btnGeriAlt.Text = "Geri";
            this.btnGeriAlt.UseVisualStyleBackColor = false;
            this.btnGeriAlt.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnGeriUst
            // 
            this.btnGeriUst.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGeriUst.Font = new System.Drawing.Font("Zilla Slab", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeriUst.Location = new System.Drawing.Point(12, 12);
            this.btnGeriUst.Name = "btnGeriUst";
            this.btnGeriUst.Size = new System.Drawing.Size(134, 36);
            this.btnGeriUst.TabIndex = 4;
            this.btnGeriUst.Text = "Geri";
            this.btnGeriUst.UseVisualStyleBackColor = false;
            this.btnGeriUst.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // txtAra
            // 
            this.txtAra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAra.Font = new System.Drawing.Font("Zilla Slab Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAra.Location = new System.Drawing.Point(332, 115);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(246, 27);
            this.txtAra.TabIndex = 5;
            // 
            // lblAra
            // 
            this.lblAra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAra.AutoSize = true;
            this.lblAra.BackColor = System.Drawing.Color.Transparent;
            this.lblAra.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAra.Location = new System.Drawing.Point(269, 117);
            this.lblAra.Name = "lblAra";
            this.lblAra.Size = new System.Drawing.Size(39, 23);
            this.lblAra.TabIndex = 1;
            this.lblAra.Text = "Ara";
            // 
            // formDetayliAnketListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(836, 706);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.btnGeriUst);
            this.Controls.Add(this.lblAra);
            this.Controls.Add(this.btnGeriAlt);
            this.Controls.Add(this.lblAnaBaslik);
            this.Name = "formDetayliAnketListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formDetayliAnketListesi";
            this.Load += new System.EventHandler(this.formDetayliAnketListesi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblAnaBaslik;
        private System.Windows.Forms.Button btnGeriAlt;
        private System.Windows.Forms.Button btnGeriUst;
        private System.Windows.Forms.TextBox txtAra;
        public System.Windows.Forms.Label lblAra;
    }
}