using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class formDetayliAnketListesi : Form
    {
        private string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True;";
        private int panelHeight = 340;
        private int panelSpacing = 50;

        public formDetayliAnketListesi()
        {
            InitializeComponent();
        }

        private void formDetayliAnketListesi_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Başlık ve arama kontrollerini merkezle
            CenterHeaderControls();

            
            txtAra.KeyDown += TxtAra_KeyDown;

            
            LoadData(null);
        }

        private void TxtAra_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                string aranan = txtAra.Text;
                LoadData(aranan);
            }
        }

        private void CenterHeaderControls()
        {
            // btnGeriUst butonunu merkeze yerleştir
            btnGeriUst.Location = new Point((this.ClientSize.Width - btnGeriUst.Width) / 2, 10);
            // lblAnaBaslik etiketini btnGeriUst butonunun altına yerleştir
            lblAnaBaslik.Location = new Point((this.ClientSize.Width - lblAnaBaslik.Width) / 2, btnGeriUst.Bottom + 10);
            // lblAra etiketini merkeze yerleştir
            lblAra.Location = new Point((this.ClientSize.Width - lblAra.Width) / 2, lblAnaBaslik.Bottom + 20);
            // txtAra arama kutusunu merkeze yerleştir
            txtAra.Location = new Point((this.ClientSize.Width - txtAra.Width) / 2, lblAra.Bottom + 5);
        }

        private void formDetayliAnketListesi_Resize(object sender, EventArgs e)
        {
            // Pencere boyutlandırıldığında başlık ve panelleri merkezle
            CenterHeaderControls();
            CenterPanels();
        }

        private void LoadData(string aranan)
        {
            
            string query = "SELECT SurveyID, SurveyName, ConductedBy, StartDate, EndDate, ExpectedParticipants FROM dbo.Surveys";

            // Eğer arama terimi varsa sorguyu filtrele
            if (!string.IsNullOrEmpty(aranan))
            {
                query += " WHERE SurveyName LIKE @aranan OR ConductedBy LIKE @aranan";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand surveyCommand = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(aranan))
                        {
                            surveyCommand.Parameters.AddWithValue("@aranan", "%" + aranan + "%");
                        }

                        using (SqlDataReader reader = surveyCommand.ExecuteReader())
                        {
                            // Mevcut panelleri kaldır
                            List<Control> panelsToRemove = new List<Control>();
                            foreach (Control control in this.Controls)
                            {
                                if (control is ucAnketPanel)
                                {
                                    panelsToRemove.Add(control);
                                }
                            }
                            foreach (Control panel in panelsToRemove)
                            {
                                this.Controls.Remove(panel);
                                panel.Dispose(); 
                                // Arama esnasında işimize yaramayan panelleri sill
                            }

                            int yOffset = lblAra.Bottom + 40;
                            int panelCount = 0;

                            while (reader.Read())
                            {
                                ucAnketPanel anketPanel = new ucAnketPanel
                                {
                                    SurveyID = (int)reader["SurveyID"], // SurveyIDyi ayarla
                                    AnketBasligi = reader["SurveyName"].ToString(),
                                    AnketiOlusturan = reader["ConductedBy"].ToString(),
                                    BeklenilenKatilimciSayisi = reader["ExpectedParticipants"].ToString(),
                                    BaslangicTarihi = DateTime.Parse(reader["StartDate"].ToString()),
                                    BitisTarihi = DateTime.Parse(reader["EndDate"].ToString()),
                                    Size = new Size(815, panelHeight)
                                };

                                // Yeni paneli merkeze yerleştir
                                anketPanel.Location = new Point((this.ClientSize.Width - anketPanel.Width) / 2, yOffset + (panelCount * (panelHeight + panelSpacing)));

                                this.Controls.Add(anketPanel);
                                panelCount++;
                            }

                           
                            

                            // btnGeriAlt butonunu son panelin altına yerleştir
                            btnGeriAlt.Location = new Point((this.ClientSize.Width - btnGeriAlt.Width) / 2, yOffset + (panelCount * (panelHeight + panelSpacing)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void CenterPanels()
        {
            // Panelleri ve butonu merkeze yerleştir
            int yOffset = lblAnaBaslik.Bottom + 20;
            int panelCount = 0;

            foreach (Control control in this.Controls)
            {
                if (control is ucAnketPanel)
                {
                    control.Location = new Point((this.ClientSize.Width - control.Width) / 2, yOffset + (panelCount * (panelHeight + panelSpacing)));
                    panelCount++;
                }
            }

            // btnGeriAlt butonunu yeniden konumlandır
            btnGeriAlt.Location = new Point((this.ClientSize.Width - btnGeriAlt.Width) / 2, yOffset + (panelCount * (panelHeight + panelSpacing)));
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            formAnketTasarimSorgu ats = new formAnketTasarimSorgu();
            ats.Show();
            this.Hide();
        }
    }
}
