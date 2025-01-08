using System.Drawing;

namespace kgmAnket
{
    partial class ucMetinKutusu
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.txtBuyukBox = new System.Windows.Forms.RichTextBox();
            this.txtKucukBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Label";
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblError.Font = new System.Drawing.Font("Zilla Slab Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(0, 81);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(222, 23);
            this.lblError.TabIndex = 2;
            this.lblError.Visible = false;
            // 
            // txtBuyukBox
            // 
            this.txtBuyukBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuyukBox.Font = new System.Drawing.Font("Zilla Slab Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBuyukBox.Location = new System.Drawing.Point(4, 26);
            this.txtBuyukBox.Name = "txtBuyukBox";
            this.txtBuyukBox.Size = new System.Drawing.Size(215, 52);
            this.txtBuyukBox.TabIndex = 0;
            this.txtBuyukBox.Text = "";
            this.txtBuyukBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.txtBuyukBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // txtKucukBox
            // 
            this.txtKucukBox.Font = new System.Drawing.Font("Zilla Slab", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKucukBox.Location = new System.Drawing.Point(4, 26);
            this.txtKucukBox.Name = "txtKucukBox";
            this.txtKucukBox.Size = new System.Drawing.Size(215, 23);
            this.txtKucukBox.TabIndex = 3;
            // 
            // ucMetinKutusu
            // 
            this.Controls.Add(this.txtKucukBox);
            this.Controls.Add(this.txtBuyukBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblError);
            this.Name = "ucMetinKutusu";
            this.Size = new System.Drawing.Size(222, 104);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label1;

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.RichTextBox txtBuyukBox;
        private System.Windows.Forms.TextBox txtKucukBox;
    }
}
