using System;
using System.Drawing;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class ucMetinKutusu : UserControl
    {
        private bool sayisalMi;
        private int minDeger = 18;
        private int maxDeger = 65;
        private int maxUzunluk = int.MaxValue;
        private const int maxTextBoxWidth = 300;
        private const int maxLabelWidth = 300;
        private const int labelTextBoxSpacing = 10;

        public ucMetinKutusu()
        {
            InitializeComponent();
            sayisalMi = false;
            txtBuyukBox.KeyDown += textBox1_KeyDown;
            txtBuyukBox.Validating += textBox1_Validating;
            lblError.Visible = false;
            label1.AutoSize = true;
            txtKucukBox.Visible = false;
            txtBuyukBox.Visible = false;
            bilesenBoyutlariAyarla();
        }

        public string EtiketMetni
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
                bilesenBoyutlariAyarla();
            }
        }

        public string MetinDegeri
        {
            get
            {
                return sayisalMi ? txtKucukBox.Text : txtBuyukBox.Text;
            }
            set
            {
                if (sayisalMi && int.TryParse(value, out int sonuc))
                {
                    if (sonuc > maxDeger) sonuc = maxDeger;
                    if (sonuc < minDeger) sonuc = minDeger;

                    txtKucukBox.Text = sonuc.ToString();
                    lblError.Visible = false;
                }
                else if (!sayisalMi && value.Length <= maxUzunluk)
                {
                    txtBuyukBox.Text = value;
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Text = "Geçersiz giriş.";
                    lblError.Visible = true;
                    throw new ArgumentException("Geçersiz giriş.");
                }
                bilesenBoyutlariAyarla();
            }
        }

        public bool CokSatirliMi
        {
            get => txtBuyukBox.Multiline;
            set
            {
                txtBuyukBox.Multiline = value;
                txtBuyukBox.Visible = value;
                txtKucukBox.Visible = !value;
            }
        }

        public bool SayisalMi
        {
            get => sayisalMi;
            set
            {
                sayisalMi = value;
                txtKucukBox.Visible = value;
                txtBuyukBox.Visible = !value;
            }
        }

        public int MinDeger
        {
            get => minDeger;
            set
            {
                if (value <= maxDeger)
                {
                    minDeger = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("MinDeger, MaxDeger'den büyük olamaz.");
                }
            }
        }

        public int MaxDeger
        {
            get => maxDeger;
            set
            {
                if (value >= minDeger)
                {
                    maxDeger = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("MaxDeger, MinDeger'den küçük olamaz.");
                }
            }
        }

        public int MaxUzunluk
        {
            get => maxUzunluk;
            set
            {
                if (value > 0)
                {
                    maxUzunluk = value;
                    txtBuyukBox.MaxLength = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("MaxUzunluk 0'dan büyük olmalı.");
                }
            }
        }

        private void textBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sayisalMi)
            {
                if (int.TryParse(txtKucukBox.Text, out int sonuc))
                {
                    if (sonuc < minDeger || sonuc > maxDeger)
                    {
                        lblError.Text = $"Değer {minDeger} ile {maxDeger} arasında olmalıdır.";
                        lblError.Visible = true;
                        e.Cancel = true;
                    }
                    else
                    {
                        lblError.Visible = false;
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtKucukBox.Text))
                    {
                        lblError.Visible = false;
                    }
                    else
                    {
                        lblError.Text = "Geçerli bir sayı giriniz.";
                        lblError.Visible = true;
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (txtBuyukBox.Text.Length > maxUzunluk)
                {
                    lblError.Text = $"Metin uzunluğu {maxUzunluk} karakterden fazla olamaz.";
                    lblError.Visible = true;
                    e.Cancel = true;
                }
                else
                {
                    lblError.Visible = false;
                }
            }
            bilesenBoyutlariAyarla();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (sayisalMi)
            {
                if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode))
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void bilesenBoyutlariAyarla()
        {
            int desiredWidth = maxTextBoxWidth;
            desiredWidth = Math.Max(desiredWidth, lblError.Width + 20); 

            int labelWidth = label1.Width;

            if (labelWidth > maxLabelWidth)
            {
                label1.MaximumSize = new Size(maxLabelWidth, 0);
            }
            else
            {
                label1.MaximumSize = new Size(0, 0);
            }

            label1.AutoSize = true;
            labelWidth = Math.Min(labelWidth, maxLabelWidth); 

            desiredWidth = Math.Max(desiredWidth, labelWidth + 20); 
            txtBuyukBox.Width = desiredWidth; 
            txtKucukBox.Width = desiredWidth;

            
            txtKucukBox.Location = new Point(txtKucukBox.Location.X, label1.Bottom + labelTextBoxSpacing);
            txtBuyukBox.Location = new Point(txtBuyukBox.Location.X, label1.Bottom + labelTextBoxSpacing);

            
            if (txtKucukBox.Visible)
            {
                this.Height = txtKucukBox.Bottom + labelTextBoxSpacing + lblError.Height;
            }
            else
            {
                this.Height = txtBuyukBox.Bottom + labelTextBoxSpacing + lblError.Height;
            }

           
            this.Width = Math.Max(this.Width, desiredWidth);
        }
    }
}
