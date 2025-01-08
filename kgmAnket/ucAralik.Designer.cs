namespace kgmAnket
{
    partial class ucAralik
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblText1 = new System.Windows.Forms.Label();
            this.lblText2 = new System.Windows.Forms.Label();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.txtBox2 = new System.Windows.Forms.TextBox();
            this.lblSoruMetni = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.lblText1.Location = new System.Drawing.Point(2, 43);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(43, 19);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "text1";
            // 
            // lblText2
            // 
            this.lblText2.AutoSize = true;
            this.lblText2.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.lblText2.Location = new System.Drawing.Point(216, 43);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(45, 19);
            this.lblText2.TabIndex = 0;
            this.lblText2.Text = "text2";
            // 
            // txtBox1
            // 
            this.txtBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox1.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.txtBox1.Location = new System.Drawing.Point(6, 65);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(154, 27);
            this.txtBox1.TabIndex = 1;
            // 
            // txtBox2
            // 
            this.txtBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox2.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.txtBox2.Location = new System.Drawing.Point(220, 65);
            this.txtBox2.Name = "txtBox2";
            this.txtBox2.Size = new System.Drawing.Size(154, 27);
            this.txtBox2.TabIndex = 1;
            // 
            // lblSoruMetni
            // 
            this.lblSoruMetni.AutoSize = true;
            this.lblSoruMetni.Font = new System.Drawing.Font("Zilla Slab SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoruMetni.Location = new System.Drawing.Point(2, 2);
            this.lblSoruMetni.Name = "lblSoruMetni";
            this.lblSoruMetni.Size = new System.Drawing.Size(70, 19);
            this.lblSoruMetni.TabIndex = 0;
            this.lblSoruMetni.Text = "textSoru";
            // 
            // ucAralik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBox2);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.lblText2);
            this.Controls.Add(this.lblSoruMetni);
            this.Controls.Add(this.lblText1);
            this.Name = "ucAralik";
            this.Size = new System.Drawing.Size(384, 96);
            this.Load += new System.EventHandler(this.ucAralik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.TextBox txtBox2;
        private System.Windows.Forms.Label lblSoruMetni;
    }
}
