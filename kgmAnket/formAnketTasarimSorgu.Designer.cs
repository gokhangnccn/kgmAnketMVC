namespace kgmAnket
{
    partial class formAnketTasarimSorgu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAnketTasarimSorgu));
            this.dgwAnketler = new System.Windows.Forms.DataGridView();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.panelSorgu = new System.Windows.Forms.Panel();
            this.dateBitisMax = new System.Windows.Forms.DateTimePicker();
            this.dateBitisMin = new System.Windows.Forms.DateTimePicker();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.dateBaslangicMax = new System.Windows.Forms.DateTimePicker();
            this.dateBaslangicMin = new System.Windows.Forms.DateTimePicker();
            this.lblOlusturan = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.textOlusturan = new System.Windows.Forms.TextBox();
            this.textAd = new System.Windows.Forms.TextBox();
            this.lblSorgula = new System.Windows.Forms.Label();
            this.lblAnketler = new System.Windows.Forms.Label();
            this.btnYeniAnketOlustur = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnAnketiDuzenle = new System.Windows.Forms.Button();
            this.btnAnketiSil = new System.Windows.Forms.Button();
            this.btnDetayliAnketListesi = new System.Windows.Forms.Button();
            this.btnAnketVeriGirisi = new System.Windows.Forms.Button();
            this.btnCiktiAl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnketler)).BeginInit();
            this.panelSorgu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwAnketler
            // 
            this.dgwAnketler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwAnketler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgwAnketler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAnketler.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgwAnketler.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgwAnketler.Location = new System.Drawing.Point(64, 392);
            this.dgwAnketler.Name = "dgwAnketler";
            this.dgwAnketler.ReadOnly = true;
            this.dgwAnketler.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgwAnketler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAnketler.Size = new System.Drawing.Size(580, 244);
            this.dgwAnketler.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslik.Font = new System.Drawing.Font("Unispace", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(204, 35);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(298, 29);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Anket Tasarım Sorgu";
            // 
            // panelSorgu
            // 
            this.panelSorgu.BackColor = System.Drawing.Color.Transparent;
            this.panelSorgu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSorgu.Controls.Add(this.dateBitisMax);
            this.panelSorgu.Controls.Add(this.dateBitisMin);
            this.panelSorgu.Controls.Add(this.btnTemizle);
            this.panelSorgu.Controls.Add(this.btnAra);
            this.panelSorgu.Controls.Add(this.dateBaslangicMax);
            this.panelSorgu.Controls.Add(this.dateBaslangicMin);
            this.panelSorgu.Controls.Add(this.lblOlusturan);
            this.panelSorgu.Controls.Add(this.label2);
            this.panelSorgu.Controls.Add(this.label4);
            this.panelSorgu.Controls.Add(this.label3);
            this.panelSorgu.Controls.Add(this.label1);
            this.panelSorgu.Controls.Add(this.lblTarih);
            this.panelSorgu.Controls.Add(this.lblAd);
            this.panelSorgu.Controls.Add(this.textOlusturan);
            this.panelSorgu.Controls.Add(this.textAd);
            this.panelSorgu.Location = new System.Drawing.Point(64, 99);
            this.panelSorgu.Name = "panelSorgu";
            this.panelSorgu.Size = new System.Drawing.Size(580, 252);
            this.panelSorgu.TabIndex = 2;
            // 
            // dateBitisMax
            // 
            this.dateBitisMax.Location = new System.Drawing.Point(392, 173);
            this.dateBitisMax.Name = "dateBitisMax";
            this.dateBitisMax.Size = new System.Drawing.Size(161, 20);
            this.dateBitisMax.TabIndex = 3;
            this.dateBitisMax.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            // 
            // dateBitisMin
            // 
            this.dateBitisMin.Location = new System.Drawing.Point(160, 173);
            this.dateBitisMin.Name = "dateBitisMin";
            this.dateBitisMin.Size = new System.Drawing.Size(166, 20);
            this.dateBitisMin.TabIndex = 3;
            this.dateBitisMin.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTemizle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTemizle.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Location = new System.Drawing.Point(300, 212);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(111, 35);
            this.btnTemizle.TabIndex = 2;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnAra
            // 
            this.btnAra.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAra.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.Location = new System.Drawing.Point(183, 212);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(111, 35);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = false;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // dateBaslangicMax
            // 
            this.dateBaslangicMax.Location = new System.Drawing.Point(392, 147);
            this.dateBaslangicMax.Name = "dateBaslangicMax";
            this.dateBaslangicMax.Size = new System.Drawing.Size(161, 20);
            this.dateBaslangicMax.TabIndex = 3;
            this.dateBaslangicMax.Value = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            // 
            // dateBaslangicMin
            // 
            this.dateBaslangicMin.Location = new System.Drawing.Point(160, 147);
            this.dateBaslangicMin.Name = "dateBaslangicMin";
            this.dateBaslangicMin.Size = new System.Drawing.Size(166, 20);
            this.dateBaslangicMin.TabIndex = 3;
            this.dateBaslangicMin.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            // 
            // lblOlusturan
            // 
            this.lblOlusturan.AutoSize = true;
            this.lblOlusturan.BackColor = System.Drawing.Color.Transparent;
            this.lblOlusturan.Font = new System.Drawing.Font("Zilla Slab Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOlusturan.Location = new System.Drawing.Point(20, 77);
            this.lblOlusturan.Name = "lblOlusturan";
            this.lblOlusturan.Size = new System.Drawing.Size(94, 19);
            this.lblOlusturan.TabIndex = 1;
            this.lblOlusturan.Text = "Oluşturan:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Zilla Slab", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(53, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bitiş:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Zilla Slab", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(351, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "ile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Zilla Slab", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(351, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "ile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Zilla Slab", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(53, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Başlangıç:";
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.BackColor = System.Drawing.Color.Transparent;
            this.lblTarih.Font = new System.Drawing.Font("Zilla Slab Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(20, 121);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(118, 19);
            this.lblTarih.TabIndex = 1;
            this.lblTarih.Text = "Tarih Aralığı:";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.BackColor = System.Drawing.Color.Transparent;
            this.lblAd.Font = new System.Drawing.Font("Zilla Slab Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.Location = new System.Drawing.Point(20, 26);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(93, 19);
            this.lblAd.TabIndex = 1;
            this.lblAd.Text = "Anket Adı:";
            // 
            // textOlusturan
            // 
            this.textOlusturan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textOlusturan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOlusturan.Font = new System.Drawing.Font("Zilla Slab", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textOlusturan.Location = new System.Drawing.Point(160, 74);
            this.textOlusturan.Name = "textOlusturan";
            this.textOlusturan.Size = new System.Drawing.Size(393, 27);
            this.textOlusturan.TabIndex = 0;
            this.textOlusturan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAd_KeyDown);
            // 
            // textAd
            // 
            this.textAd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAd.Font = new System.Drawing.Font("Zilla Slab", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textAd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textAd.Location = new System.Drawing.Point(160, 26);
            this.textAd.Name = "textAd";
            this.textAd.Size = new System.Drawing.Size(393, 27);
            this.textAd.TabIndex = 0;
            this.textAd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textAd_KeyDown);
            // 
            // lblSorgula
            // 
            this.lblSorgula.AutoSize = true;
            this.lblSorgula.BackColor = System.Drawing.Color.Transparent;
            this.lblSorgula.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSorgula.Location = new System.Drawing.Point(85, 82);
            this.lblSorgula.Name = "lblSorgula";
            this.lblSorgula.Size = new System.Drawing.Size(132, 23);
            this.lblSorgula.TabIndex = 1;
            this.lblSorgula.Text = "Anket Sorgula";
            // 
            // lblAnketler
            // 
            this.lblAnketler.AutoSize = true;
            this.lblAnketler.BackColor = System.Drawing.Color.Transparent;
            this.lblAnketler.Font = new System.Drawing.Font("Zilla Slab", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAnketler.Location = new System.Drawing.Point(85, 366);
            this.lblAnketler.Name = "lblAnketler";
            this.lblAnketler.Size = new System.Drawing.Size(84, 23);
            this.lblAnketler.TabIndex = 1;
            this.lblAnketler.Text = "Anketler";
            // 
            // btnYeniAnketOlustur
            // 
            this.btnYeniAnketOlustur.BackColor = System.Drawing.SystemColors.Control;
            this.btnYeniAnketOlustur.CausesValidation = false;
            this.btnYeniAnketOlustur.Font = new System.Drawing.Font("Zilla Slab SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniAnketOlustur.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnYeniAnketOlustur.Location = new System.Drawing.Point(454, 657);
            this.btnYeniAnketOlustur.Name = "btnYeniAnketOlustur";
            this.btnYeniAnketOlustur.Size = new System.Drawing.Size(190, 35);
            this.btnYeniAnketOlustur.TabIndex = 2;
            this.btnYeniAnketOlustur.Text = "Yeni Anket Oluştur";
            this.btnYeniAnketOlustur.UseVisualStyleBackColor = false;
            this.btnYeniAnketOlustur.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGeri.Font = new System.Drawing.Font("Zilla Slab", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.Location = new System.Drawing.Point(12, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(65, 30);
            this.btnGeri.TabIndex = 2;
            this.btnGeri.Text = "Geri";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnAnketiDuzenle
            // 
            this.btnAnketiDuzenle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnketiDuzenle.Font = new System.Drawing.Font("Zilla Slab SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnketiDuzenle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnketiDuzenle.Location = new System.Drawing.Point(64, 657);
            this.btnAnketiDuzenle.Name = "btnAnketiDuzenle";
            this.btnAnketiDuzenle.Size = new System.Drawing.Size(190, 35);
            this.btnAnketiDuzenle.TabIndex = 2;
            this.btnAnketiDuzenle.Text = "Seçilen Anketi Düzenle";
            this.btnAnketiDuzenle.UseVisualStyleBackColor = false;
            this.btnAnketiDuzenle.Click += new System.EventHandler(this.btnAnketiDuzenle_Click);
            // 
            // btnAnketiSil
            // 
            this.btnAnketiSil.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnketiSil.Font = new System.Drawing.Font("Zilla Slab SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnketiSil.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAnketiSil.Location = new System.Drawing.Point(260, 657);
            this.btnAnketiSil.Name = "btnAnketiSil";
            this.btnAnketiSil.Size = new System.Drawing.Size(190, 35);
            this.btnAnketiSil.TabIndex = 2;
            this.btnAnketiSil.Text = "Seçilen Anketi Sil";
            this.btnAnketiSil.UseVisualStyleBackColor = false;
            this.btnAnketiSil.Click += new System.EventHandler(this.btnAnketiSil_Click);
            // 
            // btnDetayliAnketListesi
            // 
            this.btnDetayliAnketListesi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetayliAnketListesi.Font = new System.Drawing.Font("Zilla Slab SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDetayliAnketListesi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDetayliAnketListesi.Location = new System.Drawing.Point(260, 739);
            this.btnDetayliAnketListesi.Name = "btnDetayliAnketListesi";
            this.btnDetayliAnketListesi.Size = new System.Drawing.Size(190, 35);
            this.btnDetayliAnketListesi.TabIndex = 2;
            this.btnDetayliAnketListesi.Text = "Detaylı Anket Listesi";
            this.btnDetayliAnketListesi.UseVisualStyleBackColor = false;
            this.btnDetayliAnketListesi.Click += new System.EventHandler(this.btnDetayliAnketListesi_Click);
            // 
            // btnAnketVeriGirisi
            // 
            this.btnAnketVeriGirisi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnketVeriGirisi.Font = new System.Drawing.Font("Zilla Slab SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAnketVeriGirisi.ForeColor = System.Drawing.Color.DarkRed;
            this.btnAnketVeriGirisi.Location = new System.Drawing.Point(160, 698);
            this.btnAnketVeriGirisi.Name = "btnAnketVeriGirisi";
            this.btnAnketVeriGirisi.Size = new System.Drawing.Size(190, 35);
            this.btnAnketVeriGirisi.TabIndex = 2;
            this.btnAnketVeriGirisi.Text = "Anket Veri Girişi";
            this.btnAnketVeriGirisi.UseVisualStyleBackColor = false;
            this.btnAnketVeriGirisi.Click += new System.EventHandler(this.btnAnketVeriGirisi_Click);
            // 
            // btnCiktiAl
            // 
            this.btnCiktiAl.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCiktiAl.Font = new System.Drawing.Font("Zilla Slab SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCiktiAl.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCiktiAl.Location = new System.Drawing.Point(356, 698);
            this.btnCiktiAl.Name = "btnCiktiAl";
            this.btnCiktiAl.Size = new System.Drawing.Size(190, 35);
            this.btnCiktiAl.TabIndex = 2;
            this.btnCiktiAl.Text = "PDF Çıktısı Al";
            this.btnCiktiAl.UseVisualStyleBackColor = false;
            this.btnCiktiAl.Click += new System.EventHandler(this.btnCiktiAl_Click);
            // 
            // formAnketTasarimSorgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(704, 798);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnAnketVeriGirisi);
            this.Controls.Add(this.btnCiktiAl);
            this.Controls.Add(this.btnDetayliAnketListesi);
            this.Controls.Add(this.btnAnketiSil);
            this.Controls.Add(this.btnAnketiDuzenle);
            this.Controls.Add(this.btnYeniAnketOlustur);
            this.Controls.Add(this.lblAnketler);
            this.Controls.Add(this.lblSorgula);
            this.Controls.Add(this.panelSorgu);
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.dgwAnketler);
            this.Name = "formAnketTasarimSorgu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "anketTasarimSorgu";
            this.Load += new System.EventHandler(this.formAnketTasarimSorgu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAnketler)).EndInit();
            this.panelSorgu.ResumeLayout(false);
            this.panelSorgu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwAnketler;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel panelSorgu;
        private System.Windows.Forms.Label lblSorgula;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox textAd;
        private System.Windows.Forms.Label lblOlusturan;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.TextBox textOlusturan;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Label lblAnketler;
        private System.Windows.Forms.Button btnYeniAnketOlustur;
        private System.Windows.Forms.DateTimePicker dateBaslangicMax;
        private System.Windows.Forms.DateTimePicker dateBaslangicMin;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnAnketiDuzenle;
        private System.Windows.Forms.Button btnAnketiSil;
        private System.Windows.Forms.DateTimePicker dateBitisMax;
        private System.Windows.Forms.DateTimePicker dateBitisMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetayliAnketListesi;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnAnketVeriGirisi;
        private System.Windows.Forms.Button btnCiktiAl;
    }
}