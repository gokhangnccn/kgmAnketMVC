using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class formSoruEkle : Form
    {
        private int sayac = 1;
        string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True;";

        public List<string> Sorular { get; private set; } = new List<string>();
        public string CevapTipi { get; private set; }
        public List<string> Secenekler { get; private set; } = new List<string>();

        public formSoruEkle()
        {
            InitializeComponent();
            panelCevaplar.AutoScroll = true; // AutoScroll özelliğini etkinleştir
            btnSecenekEkle.Visible = false;
        }

        public formSoruEkle(string soruMetni, string cevapTipi, string secenekler)
        {
            InitializeComponent();

            textSoruMetni.Text = soruMetni;
            CevapTipi = cevapTipi;

            //sorunun secenekleri varsa onu da çek
            if (!string.IsNullOrWhiteSpace(secenekler))
            {
                var secenekListesi = secenekler.Split(',').Select(s => s.Trim()).ToList();
                foreach (var secenek in secenekListesi)
                {
                    RichTextBox tempTextBox = new RichTextBox
                    {
                        Text = secenek,
                        Location = new Point(10, panelCevaplar.Controls.Count * 30 + 20),
                        Size = new Size(490, 40)
                    };
                    panelCevaplar.Controls.Add(tempTextBox);
                }
                Secenekler = secenekListesi;
            }
        }


        private void rbMetin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMetin.Checked)
            {
                CevapTipi = "Metin";
                panelCevaplar.Controls.Clear();
                btnSecenekEkle.Visible = false;

                Label tempLabel = new Label
                {
                    Location = new Point(10, 20),
                    AutoSize = true,
                    Text = "Bu cevap tipi, kullanıcıya açık uçlu metin olarak bırakılacak."
                };

                panelCevaplar.Controls.Add(tempLabel);
            }
        }

        private void rbCoktanTek_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoktanTek.Checked)
            {
                CevapTipi = "Çoktan Tek Seçmeli";
                panelCevaplar.Controls.Clear();
                sayac = 1;
                btnSecenekEkle.Visible = true;
                AddChoiceField();
            }
        }

        private void rbCoktanCok_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCoktanCok.Checked)
            {
                CevapTipi = "Çoktan Çok Seçmeli";
                panelCevaplar.Controls.Clear();
                sayac = 1;
                btnSecenekEkle.Visible = true;
                AddChoiceField();
            }
        }

        private void rbSayi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSayi.Checked)
            {
                CevapTipi = "Sayı";
                panelCevaplar.Controls.Clear();
                btnSecenekEkle.Visible = false;
                AddNumberFields();
            }
        }

        private void rbSayiAraligi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSayiAraligi.Checked)
            {
                CevapTipi = "Sayı Aralığı";
                panelCevaplar.Controls.Clear();
                btnSecenekEkle.Visible = false;
                AddNumberRangeFields();
            }
        }

        private void rbTarih_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTarih.Checked)
            {
                CevapTipi = "Tarih";
                panelCevaplar.Controls.Clear();
                btnSecenekEkle.Visible = false;

                Label tempLabel = new Label
                {
                    Location = new Point(10, 20),
                    AutoSize = true,
                    Text = "Kullanıcı kendi tarihini seçecek."
                };

                panelCevaplar.Controls.Add(tempLabel);
            }
        }

        private void rbTarihAraligi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTarihAraligi.Checked)
            {
                CevapTipi = "Tarih Aralığı";
                panelCevaplar.Controls.Clear();
                btnSecenekEkle.Visible = false;
                AddDateRangeFields();
            }
        }

        private void btnSecenekEkle_Click(object sender, EventArgs e)
        {
            if (panelCevaplar.Controls.OfType<Label>().Count() < 20)
            {
                AddChoiceField();
            }
        }

        private void btnAnketeEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textSoruMetni.Text))
            {
                Sorular.Add(textSoruMetni.Text);

                foreach (Control control in panelCevaplar.Controls)
                {
                    if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        Secenekler.Add(textBox.Text);
                    }
                    else if (control is RichTextBox richTextBox && !string.IsNullOrWhiteSpace(richTextBox.Text))
                    {
                        Secenekler.Add(richTextBox.Text);
                    }
                    else if (control is DateTimePicker dateTimePicker)
                    {
                        Secenekler.Add(dateTimePicker.Value.ToString("dd-MM-yyyy")); // Tarih formatını ihtiyacınıza göre değiştirebilirsiniz
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen soru metnini girin.");
            }
        }

        private void AddChoiceField()
        {
            int verticalPadding = 10;

            int startY = panelCevaplar.Controls.OfType<Control>().LastOrDefault()?.Bottom + verticalPadding ?? 0;

            Label tempLabel = new Label
            {
                Location = new Point(10, startY),
                Text = $"Şık-{sayac++}"
            };

            RichTextBox tempTextBox = new RichTextBox
            {
                Location = new Point(10, tempLabel.Bottom + verticalPadding),
                Size = new Size(490, 40)
            };

            panelCevaplar.Controls.Add(tempLabel);
            panelCevaplar.Controls.Add(tempTextBox);
        }

        private void AddNumberFields()
        {
            CheckBox cbMin = new CheckBox
            {
                Location = new Point(10, 20),
                Text = "Minimum Sayı"
            };

            TextBox tbMin = new TextBox
            {
                Location = new Point(120, 20),
                Size = new Size(100, 20),
                Enabled = false
            };

            cbMin.CheckedChanged += (s, e) => tbMin.Enabled = cbMin.Checked;

            CheckBox cbMax = new CheckBox
            {
                Location = new Point(10, 50),
                Text = "Maksimum Sayı"
            };

            TextBox tbMax = new TextBox
            {
                Location = new Point(120, 50),
                Size = new Size(100, 20),
                Enabled = false
            };

            cbMax.CheckedChanged += (s, e) => tbMax.Enabled = cbMax.Checked;

            panelCevaplar.Controls.Add(cbMin);
            panelCevaplar.Controls.Add(tbMin);
            panelCevaplar.Controls.Add(cbMax);
            panelCevaplar.Controls.Add(tbMax);
        }

        private void AddNumberRangeFields()
        {
            CheckBox cbMin = new CheckBox
            {
                Location = new Point(10, 20),
                Text = "Minimum Sayı"
            };

            TextBox tbMin = new TextBox
            {
                Location = new Point(120, 20),
                Size = new Size(100, 20),
                Enabled = false
            };

            cbMin.CheckedChanged += (s, e) => tbMin.Enabled = cbMin.Checked;

            CheckBox cbMax = new CheckBox
            {
                Location = new Point(10, 50),
                Text = "Maksimum Sayı"
            };

            TextBox tbMax = new TextBox
            {
                Location = new Point(120, 50),
                Size = new Size(100, 20),
                Enabled = false
            };

            cbMax.CheckedChanged += (s, e) => tbMax.Enabled = cbMax.Checked;

            panelCevaplar.Controls.Add(cbMin);
            panelCevaplar.Controls.Add(tbMin);
            panelCevaplar.Controls.Add(cbMax);
            panelCevaplar.Controls.Add(tbMax);
        }

        private void AddDateRangeFields()
        {
            CheckBox cbMin = new CheckBox
            {
                Location = new Point(10, 20),
                Text = "Minimum Tarih"
            };

            DateTimePicker dtpMin = new DateTimePicker
            {
                Location = new Point(120, 20),
                Size = new Size(200, 20),
                Enabled = false
            };

            cbMin.CheckedChanged += (s, e) => dtpMin.Enabled = cbMin.Checked;

            CheckBox cbMax = new CheckBox
            {
                Location = new Point(10, 50),
                Text = "Maksimum Tarih"
            };

            DateTimePicker dtpMax = new DateTimePicker
            {
                Location = new Point(120, 50),
                Size = new Size(200, 20),
                Enabled = false
            };

            cbMax.CheckedChanged += (s, e) => dtpMax.Enabled = cbMax.Checked;

            panelCevaplar.Controls.Add(cbMin);
            panelCevaplar.Controls.Add(dtpMin);
            panelCevaplar.Controls.Add(cbMax);
            panelCevaplar.Controls.Add(dtpMax);
        }
    }
}
