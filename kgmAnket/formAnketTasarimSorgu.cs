using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf.IO;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X9;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;




namespace kgmAnket
{
    public partial class formAnketTasarimSorgu : Form
    {
        private string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True;";
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        XFont anaBaslik = new XFont("Lucida Console", 18, XFontStyleEx.Bold);
        XFont anaBaslik2 = new XFont("Lucida Console", 14, XFontStyleEx.Bold);
        XFont altBaslik = new XFont("Lucida Console", 10);
        XFont titleFont = new XFont("Lucida Console", 10);
        XFont regularFont = new XFont("Lucida Console", 9);



        public formAnketTasarimSorgu()
        {
            InitializeComponent();
        }

        private void formAnketTasarimSorgu_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        public void LoadData()
        {
            string query = "SELECT SurveyID, SurveyName, ConductedBy, StartDate, EndDate, ExpectedParticipants FROM dbo.Surveys";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    table = new DataTable();
                    adapter.Fill(table);
                    dgwAnketler.DataSource = table;

                    // SurveyID sütununu gizle
                    dgwAnketler.Columns["SurveyID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public void searchData(string surveyName, string conductedBy, DateTime? startDateMin, DateTime? startDateMax, DateTime? endDateMin, DateTime? endDateMax)
        {
            string query = "SELECT SurveyID, SurveyName, ConductedBy, StartDate, EndDate, ExpectedParticipants FROM dbo.Surveys WHERE 1=1";

            if (!string.IsNullOrEmpty(surveyName))
            {
                query += " AND SurveyName LIKE @surveyName";
            }
            if (!string.IsNullOrEmpty(conductedBy))
            {
                query += " AND ConductedBy LIKE @conductedBy";
            }
            if (startDateMin.HasValue)
            {
                query += " AND StartDate >= @startDateMin";
            }
            if (startDateMax.HasValue)
            {
                query += " AND StartDate <= @startDateMax";
            }
            if (endDateMin.HasValue)
            {
                query += " AND EndDate >= @endDateMin";
            }
            if (endDateMax.HasValue)
            {
                query += " AND EndDate <= @endDateMax";
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    command = new SqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(surveyName))
                    {
                        command.Parameters.AddWithValue("@surveyName", "%" + surveyName + "%");
                    }
                    if (!string.IsNullOrEmpty(conductedBy))
                    {
                        command.Parameters.AddWithValue("@conductedBy", "%" + conductedBy + "%");
                    }
                    if (startDateMin.HasValue)
                    {
                        command.Parameters.AddWithValue("@startDateMin", startDateMin.Value.Date);
                    }
                    if (startDateMax.HasValue)
                    {
                        command.Parameters.AddWithValue("@startDateMax", startDateMax.Value.Date);
                    }
                    if (endDateMin.HasValue)
                    {
                        command.Parameters.AddWithValue("@endDateMin", endDateMin.Value.Date);
                    }
                    if (endDateMax.HasValue)
                    {
                        command.Parameters.AddWithValue("@endDateMax", endDateMax.Value.Date);
                    }

                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    dgwAnketler.DataSource = table;

                    // SurveyID sütununu gizle
                    dgwAnketler.Columns["SurveyID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            string surveyName = textAd.Text.ToString();
            string conductedBy = textOlusturan.Text.ToString();
            DateTime? startDateMin = dateBaslangicMin.Value != DateTime.MinValue ? (DateTime?)dateBaslangicMin.Value : null;
            DateTime? startDateMax = dateBaslangicMax.Value != DateTime.MinValue ? (DateTime?)dateBaslangicMax.Value : null;
            DateTime? endDateMin = dateBitisMin.Value != DateTime.MinValue ? (DateTime?)dateBitisMin.Value : null;
            DateTime? endDateMax = dateBitisMax.Value != DateTime.MinValue ? (DateTime?)dateBitisMax.Value : null;
            searchData(surveyName, conductedBy, startDateMin, startDateMax, endDateMin, endDateMax);
        }

        private void textAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAra.PerformClick(); // Butona tıklamayı simüle eder
                e.SuppressKeyPress = true; // Enter tuşunun başka bir işlem yapmasını engeller
            }
        }

        private void textOlusturan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAra.PerformClick(); 
                e.SuppressKeyPress = true;
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            formAnketOlusturma anketOlusturma = new formAnketOlusturma();
            anketOlusturma.Show();
            this.Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            formMainDashboard mainDashboard = new formMainDashboard();
            mainDashboard.Show();
            this.Hide();
        }

        private void dgwAnketler_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            formMainDashboard mainDashboard = new formMainDashboard();
            mainDashboard.Show();
            this.Hide();
        }


        private void btnAnketiSil_Click(object sender, EventArgs e)
        {
            if (dgwAnketler.SelectedRows.Count == 0 || dgwAnketler.RowCount < 2)
            {
                MessageBox.Show("Lütfen silmek istediğiniz anketi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Seçili anketi silmek istediğinizden emin misiniz?", "Anket Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            int selectedSurveyID = (int)dgwAnketler.SelectedRows[0].Cells["SurveyID"].Value;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        //choices tablosundaki seceneklerini sil
                        string deleteChoicesQuery = "DELETE FROM Choices WHERE QuestionID IN (SELECT QuestionID FROM Questions WHERE SurveyID = @SurveyID)";
                        SqlCommand deleteChoicesCmd = new SqlCommand(deleteChoicesQuery, connection, transaction);
                        deleteChoicesCmd.Parameters.AddWithValue("@SurveyID", selectedSurveyID);
                        deleteChoicesCmd.ExecuteNonQuery();

                        //anketin sorularini sil
                        string deleteQuestionsQuery = "DELETE FROM Questions WHERE SurveyID = @SurveyID";
                        SqlCommand deleteQuestionsCmd = new SqlCommand(deleteQuestionsQuery, connection, transaction);
                        deleteQuestionsCmd.Parameters.AddWithValue("@SurveyID", selectedSurveyID);
                        deleteQuestionsCmd.ExecuteNonQuery();

                        //SurveyParticipantFields tablosundan sil
                        string deleteSurveyParticipantFieldsQuery = "DELETE FROM SurveyParticipantFields WHERE SurveyID = @SurveyID";
                        SqlCommand deleteSurveyParticipantFieldsCmd = new SqlCommand(deleteSurveyParticipantFieldsQuery, connection, transaction);
                        deleteSurveyParticipantFieldsCmd.Parameters.AddWithValue("@SurveyID", selectedSurveyID);
                        deleteSurveyParticipantFieldsCmd.ExecuteNonQuery();

                        //veri tabanindan sil
                        string deleteSurveyQuery = "DELETE FROM Surveys WHERE SurveyID = @SurveyID";
                        SqlCommand deleteSurveyCmd = new SqlCommand(deleteSurveyQuery, connection, transaction);
                        deleteSurveyCmd.Parameters.AddWithValue("@SurveyID", selectedSurveyID);
                        deleteSurveyCmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Anket başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //dgw'den sil
                        dgwAnketler.Rows.RemoveAt(dgwAnketler.SelectedRows[0].Index);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Anket silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantısı kurulurken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnketiDuzenle_Click(object sender, EventArgs e)
        {
            if (dgwAnketler.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz anketi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Seçili SurveyID'yi al
                int selectedSurveyID = (int)dgwAnketler.SelectedRows[0].Cells["SurveyID"].Value;

                // formAnketOlusturma formunu aç
                formAnketOlusturma duzenlenecekAnket = new formAnketOlusturma(selectedSurveyID);

                // formAnketOlusturma formundaki bileşenlerin düzenlenmesi
                duzenlenecekAnket.btnAnketiOlustur.Text = "Anketi Güncelle";
                duzenlenecekAnket.lblAnaFormBasligi.Location = new Point(duzenlenecekAnket.Width / 2 - 20, 30);
                duzenlenecekAnket.lblAnaFormBasligi.Text = "Anketi Güncelle";

                // Seçili anket verilerini formAnketOlusturma formuna yükleme
                duzenlenecekAnket.LoadSurveyData(selectedSurveyID);

                duzenlenecekAnket.Show();
                this.Hide();
            }
        }


        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Arama kriterlerini temizle
            textAd.Clear();
            textOlusturan.Clear();
            dateBaslangicMin.Value = new DateTime(2024, 1, 1);
            dateBaslangicMax.Value = new DateTime(2024, 12, 31);
            dateBitisMin.Value = new DateTime(2024, 1, 1);
            dateBitisMax.Value = new DateTime(2024, 12, 31);

            // Veritabanındaki anketleri geri yükle
            LoadData();
        }

        private void btnDetayliAnketListesi_Click(object sender, EventArgs e)
        {
            formDetayliAnketListesi dal = new formDetayliAnketListesi();
            dal.Show();
            this.Hide();
        }

        public void btnAnketVeriGirisi_Click(object sender, EventArgs e)
        {
            formAnketVeriGirisi veriGirisi = new formAnketVeriGirisi((int)dgwAnketler.SelectedRows[0].Cells["SurveyID"].Value);
            veriGirisi.anketVeriGirisi();
            this.Close();
        }



        

        private void btnCiktiAl_Click(object sender, EventArgs e)
        {
            int selectedSurveyID = (int)dgwAnketler.SelectedRows[0].Cells["SurveyID"].Value;

            string surveyQuery = "SELECT SurveyID, SurveyName, ConductedBy, StartDate, EndDate, ExpectedParticipants FROM dbo.Surveys WHERE SurveyID = @SurveyID";

            try
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Anket Raporu";
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand surveyCommand = new SqlCommand(surveyQuery, connection))
                    {
                        surveyCommand.Parameters.AddWithValue("@SurveyID", selectedSurveyID);

                        using (SqlDataReader reader = surveyCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nameAnket = reader["SurveyName"].ToString();
                                string nameOlusturan = reader["ConductedBy"].ToString();

                                DrawCenteredString(nameAnket, anaBaslik, 50, gfx, page);
                                DrawCenteredString(nameOlusturan, altBaslik, 75, gfx, page);

                                int leftMargin = 30;
                                int currentYPosition = 140;
                                int lineSpacing = 20;

                                gfx.DrawString("Başlangıç Tarihi:", titleFont, XBrushes.Black, new XRect(leftMargin, currentYPosition, page.Width, page.Height), XStringFormat.TopLeft);
                                gfx.DrawString(Convert.ToDateTime(reader["StartDate"]).ToString("dd/MM/yyyy"), regularFont, XBrushes.Black, new XRect(leftMargin + 150, currentYPosition, page.Width, page.Height), XStringFormat.TopLeft);

                                currentYPosition += lineSpacing;

                                gfx.DrawString("Bitiş Tarihi:", titleFont, XBrushes.Black, new XRect(leftMargin, currentYPosition, page.Width, page.Height), XStringFormat.TopLeft);
                                gfx.DrawString(Convert.ToDateTime(reader["EndDate"]).ToString("dd/MM/yyyy"), regularFont, XBrushes.Black, new XRect(leftMargin + 150, currentYPosition, page.Width, page.Height), XStringFormat.TopLeft);

                                currentYPosition += lineSpacing;

                                gfx.DrawString("Beklenen Katılımcılar:", titleFont, XBrushes.Black, new XRect(leftMargin, currentYPosition, page.Width, page.Height), XStringFormat.TopLeft);
                                gfx.DrawString(reader["ExpectedParticipants"].ToString(), regularFont, XBrushes.Black, new XRect(leftMargin + 150, currentYPosition, page.Width, page.Height), XStringFormat.TopLeft);

                                currentYPosition += 2 * lineSpacing;
                                gfx.DrawLine(XPens.Black, leftMargin, currentYPosition, page.Width - leftMargin, currentYPosition);

                                currentYPosition += lineSpacing;

                                DrawCenteredString("Katilimci Bilgileri", anaBaslik2, 230, gfx, page);

                                currentYPosition += lineSpacing;

                                KatilimciBilgileriniPdfEkle(document, gfx, selectedSurveyID, currentYPosition + 10, leftMargin);
                                page = document.AddPage();

                                reader.Close();
                            }
                        }
                    }
                }

                SorulariPdfeEkle(document, selectedSurveyID, 1);

                string filename = "Anket-" + selectedSurveyID + ".pdf";
                document.Save(filename);
                Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }




        private void KatilimciBilgileriniPdfEkle(PdfDocument document, XGraphics gfx, int surveyID, int yOffset, int leftMargin)
        {
            string anketFieldID = "SELECT FieldID FROM dbo.SurveyParticipantFields WHERE SurveyID = @SurveyID";
            string anketFieldTip = "SELECT FieldType, FieldName, MinValue, MaxValue FROM dbo.ParticipantFields WHERE FieldID = @FieldID";
            string optionText = "SELECT OptionText FROM dbo.FieldOptions WHERE FieldID = @FieldID";

            int pageHeight = (int)gfx.PageSize.Height;
            int currentYPosition = yOffset;
            int columnWidth = 200;
            int columnCount = 0;
            int maxHeightInRow = 0;
            int spacing = 1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand surveyFieldsCommand = new SqlCommand(anketFieldID, connection))
                    {
                        surveyFieldsCommand.Parameters.AddWithValue("@SurveyID", surveyID);
                        using (SqlDataReader surveyFieldsReader = surveyFieldsCommand.ExecuteReader())
                        {
                            List<int> fieldIDs = new List<int>();

                            while (surveyFieldsReader.Read())
                            {
                                fieldIDs.Add((int)surveyFieldsReader["FieldID"]);
                            }

                            surveyFieldsReader.Close();

                            foreach (int fieldID in fieldIDs)
                            {
                                using (SqlCommand fieldTypeCommand = new SqlCommand(anketFieldTip, connection))
                                {
                                    fieldTypeCommand.Parameters.AddWithValue("@FieldID", fieldID);
                                    using (SqlDataReader fieldTypeReader = fieldTypeCommand.ExecuteReader())
                                    {
                                        if (fieldTypeReader.Read())
                                        {
                                            string controlType = fieldTypeReader["FieldType"].ToString();
                                            string fieldName = fieldTypeReader["FieldName"].ToString();
                                            UserControl control = null;

                                            switch (controlType)
                                            {
                                                case "DatePicker":
                                                case "NumericBox":
                                                case "TextBox":
                                                    control = new textMetin
                                                    {
                                                        EtiketMetni = fieldName,
                                                        Width = 450,
                                                        Height = 80,
                                                        PanelSize = new Size(250, 40)
                                                    };
                                                    break;

                                                case "ComboBox":
                                                case "RadioBox":
                                                    control = new radioButton
                                                    {
                                                        LabelText = fieldName,
                                                        Width = columnWidth
                                                    };

                                                    fieldTypeReader.Close();

                                                    using (SqlCommand optionTextCommand = new SqlCommand(optionText, connection))
                                                    {
                                                        optionTextCommand.Parameters.AddWithValue("@FieldID", fieldID);
                                                        using (SqlDataReader optionsReader = optionTextCommand.ExecuteReader())
                                                        {
                                                            List<string> choices = new List<string>();
                                                            while (optionsReader.Read())
                                                            {
                                                                choices.Add(optionsReader["OptionText"].ToString());
                                                            }
                                                            ((radioButton)control).AddChoices(choices);
                                                            optionsReader.Close();
                                                        }
                                                    }
                                                    break;
                                            }

                                            if (control != null)
                                            {
                                                int remainingSpace = pageHeight - currentYPosition - spacing + 300;

                                                if (control.Height > remainingSpace)
                                                {
                                                    PdfPage newPage = document.AddPage();
                                                    gfx.Dispose();
                                                    gfx = XGraphics.FromPdfPage(newPage);
                                                    currentYPosition = yOffset;
                                                    columnCount = 0;
                                                    maxHeightInRow = 0;
                                                }

                                                int xOffset = leftMargin + (columnCount % 3) * (columnWidth + spacing);

                                                maxHeightInRow = Math.Max(maxHeightInRow, control.Height);

                                                Bitmap ucBitmap = RenderControlToBitmap(control);
                                                if (ucBitmap != null)
                                                {
                                                    XImage image = ConvertBitmapToXImage(ucBitmap);
                                                    gfx.DrawImage(image, xOffset, currentYPosition);
                                                }

                                                columnCount++;

                                                if (columnCount % 3 == 0) //her 3 kontrolde bir yeni satıra geç
                                                {
                                                    currentYPosition += 80 + spacing; //dinamik olarak en yüksek kontrol kadar aşağıya in
                                                    maxHeightInRow = 0; //yeni satır için en yüksek kontrol yüksekliğini sıfırla
                                                }
                                                maxHeightInRow = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void SorulariPdfeEkle(PdfDocument document, int surveyID, int startPageIndex)
        {
            try
            {
                ucAnketSorulari uc = new ucAnketSorulari();
                uc.LoadQuestions(surveyID);
                uc.panelBoyut = new Size(700, 1000);
                uc.AutoScroll = false;

                uc.Size = new Size(700, 1000);
                uc.doUnVisible();

                Bitmap controlBitmap = RenderControlToBitmap(uc);

                int currentPageIndex = startPageIndex;
                PdfPage currentPage = document.Pages[currentPageIndex];
                XGraphics gfx = XGraphics.FromPdfPage(currentPage);
                DrawCenteredString("Anketin Soruları", anaBaslik2, 30, gfx, currentPage);

                XImage image = ConvertBitmapToXImage(controlBitmap);

                gfx.DrawImage(image, 50, 50, image.PixelWidth * 0.70, image.PixelHeight* 0.70);


                gfx.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }





        void DrawCenteredString(string text, XFont font, double yPosition, XGraphics gfx, PdfPage page)
        {
            XSize size = gfx.MeasureString(text, font);
            double xPosition = (page.Width - size.Width) / 2;
            gfx.DrawString(text, font, XBrushes.Black, new XRect(xPosition, yPosition, page.Width, page.Height), XStringFormat.TopLeft);
        }

        private XImage ConvertBitmapToXImage(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
                return XImage.FromStream(stream);
            }
        }

        private Bitmap RenderControlToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            bitmap.SetResolution(180, 180); 
            control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
            return bitmap;
        }

    }



}

