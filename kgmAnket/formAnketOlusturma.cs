using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class formAnketOlusturma : Form
    {
        private int sayac = 1;
        string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True;";
        private int? surveyID;



        public formAnketOlusturma(int? surveyID = null)
        {
            InitializeComponent();
            this.surveyID = surveyID;

            if (surveyID.HasValue)
            {
                LoadSurveyData(surveyID.Value);
            }

            
        }

        public void LoadSurveyData(int surveyID)
        {
            string surveyQuery = "SELECT SurveyName, ConductedBy, StartDate, EndDate, ExpectedParticipants FROM dbo.Surveys WHERE SurveyID = @SurveyID";
            string questionsQuery = @"
                SELECT 
                    q.QuestionID AS stnSoruID, 
                    q.QuestionText AS stnSoru, 
                    q.AnswerType AS stnCevapTipi, 
                    STUFF(
                        (SELECT ', ' + c.ChoiceText
                         FROM dbo.Choices c
                         WHERE c.QuestionID = q.QuestionID
                         FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS stnSecenekler
                FROM dbo.Questions q
                WHERE q.SurveyID = @SurveyID";
            string participantFieldsQuery = "SELECT FieldID FROM dbo.SurveyParticipantFields WHERE SurveyID = @SurveyID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand surveyCommand = new SqlCommand(surveyQuery, connection))
                    {
                        surveyCommand.Parameters.AddWithValue("@SurveyID", surveyID);
                        using (SqlDataReader reader = surveyCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBaslik.Text = reader["SurveyName"].ToString();
                                textOlusturan.Text = reader["ConductedBy"].ToString();
                                date1.Value = Convert.ToDateTime(reader["StartDate"]);
                                date2.Value = Convert.ToDateTime(reader["EndDate"]);
                                textBeklenilenKatilimciSayisi.Text = reader["ExpectedParticipants"].ToString();
                            }
                        }
                    }

                    using (SqlCommand questionsCommand = new SqlCommand(questionsQuery, connection))
                    {
                        questionsCommand.Parameters.AddWithValue("@SurveyID", surveyID);
                        using (SqlDataAdapter questionsAdapter = new SqlDataAdapter(questionsCommand))
                        {
                            DataTable questionsTable = new DataTable();
                            questionsAdapter.Fill(questionsTable);

                            dgwSorular.Rows.Clear(); 

                            foreach (DataRow row in questionsTable.Rows)
                            {
                                int rowIndex = dgwSorular.Rows.Add();
                                DataGridViewRow dgwRow = dgwSorular.Rows[rowIndex];
                                dgwRow.Cells["stnSoruID"].Value = row["stnSoruID"];
                                dgwRow.Cells["stnSoru"].Value = row["stnSoru"];
                                dgwRow.Cells["stnCevapTipi"].Value = row["stnCevapTipi"];
                                dgwRow.Cells["stnSecenekler"].Value = row["stnSecenekler"];
                            }

                            dgwSorular.Columns["stnSoruID"].HeaderText = "Soru ID";
                            dgwSorular.Columns["stnSoru"].HeaderText = "Soru";
                            dgwSorular.Columns["stnCevapTipi"].HeaderText = "Cevap Tipi";
                            dgwSorular.Columns["stnSecenekler"].HeaderText = "Şıklar";

                            dgwSorular.Columns["stnSoruID"].Visible = false; 
                        }
                    }


                    
                    using (SqlCommand participantFieldsCommand = new SqlCommand(participantFieldsQuery, connection))
                    {
                        participantFieldsCommand.Parameters.AddWithValue("@SurveyID", surveyID);
                        using (SqlDataReader reader = participantFieldsCommand.ExecuteReader())
                        {
                            HashSet<int> participantFields = new HashSet<int>();
                            while (reader.Read())
                            {
                                participantFields.Add(Convert.ToInt32(reader["FieldID"]));
                            }

                            
                            SetCheckBoxes(participantFields);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void SetCheckBoxes(HashSet<int> participantFields)
        {
            var checkBoxMappings = new Dictionary<int, CheckBox>
            {
                { 1, cbAd }, { 2, cbSoyad }, { 3, cbYas }, { 4, cbCinsiyet }, { 5, cbMedeniHali },
                { 6, cbEposta }, { 7, cbTelefon }, { 8, cbDogumTarihi }, { 9, cbGelir }, { 10, cbOgrenimDurumu },
                { 11, cbKilo }, { 12, cbBoy }, { 13, cbCalismaDurumu }, { 14, cbEvSahipligi }, { 15, cbMeslek },
                { 16, cbAdres }
             };  

            foreach (var checkBox in checkBoxMappings.Values)
            {
                checkBox.Checked = false;
            }

            foreach (var fieldID in participantFields)
            {
                if (checkBoxMappings.TryGetValue(fieldID, out var checkBox))
                {
                    checkBox.Checked = true;
                }
            }
        }







        private void btnGeri_Click(object sender, EventArgs e)
        {
            formMainDashboard mainDashboard = new formMainDashboard();
            mainDashboard.Show();
            this.Hide();
        }



         private void btnSoruEkle_Click_1(object sender, EventArgs e)
        {
            using (formSoruEkle formSoruEkle = new formSoruEkle())
            {
                formSoruEkle.TopMost = true;
                if (formSoruEkle.ShowDialog() == DialogResult.OK)
                {
                    foreach (string soru in formSoruEkle.Sorular)
                    {
                        int rowIndex = dgwSorular.Rows.Add();
                        DataGridViewRow row = dgwSorular.Rows[rowIndex];
                        row.Cells["stnSoru"].Value = soru;
                        row.Cells["stnCevapTipi"].Value = formSoruEkle.CevapTipi;
                        row.Cells["stnSecenekler"].Value = string.Join(", ", formSoruEkle.Secenekler);
                        row.Cells["stnSoruID"].Value = sayac;
                        sayac++;
                    }
                }
            }
        }



        private void btnAnketiOlustur_Click(object sender, EventArgs e)
        {
            if (!IsFormValid())
            {
                MessageBox.Show("Lütfen tüm gerekli alanları doldurduğunuzdan emin olun;\n" +
                    "\t* Anketin başlığı ve oluşturan bilgisi,\n" +
                    "\t* En az bir soru,\n" +
                    "\t* En az bir istenilen katılımcı bilgisi,\n" +
                    "\t* Beklenilen katılımcı sayısı.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    if (surveyID.HasValue)
                    {
                        UpdateSurvey(conn, transaction, surveyID.Value);
                        UpdateQuestions(conn, transaction, surveyID.Value);
                        UpdateParticipantFields(conn, transaction, surveyID.Value);
                    }
                    else
                    {
                        surveyID = InsertSurvey(conn, transaction);
                        InsertQuestions(conn, transaction, surveyID.Value);
                        InsertParticipantFields(conn, transaction, surveyID.Value);
                    }

                    transaction.Commit();
                    MessageBox.Show("Anket başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSurveyDesignForm();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Anket kaydedilirken bir hata oluştu: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void UpdateSurvey(SqlConnection conn, SqlTransaction transaction, int surveyID)
        {
            string query = "UPDATE Surveys SET SurveyName = @SurveyName, ConductedBy = @ConductedBy, StartDate = @StartDate, EndDate = @EndDate, ExpectedParticipants = @ExpectedParticipants WHERE SurveyID = @SurveyID";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@SurveyName", textBaslik.Text);
            cmd.Parameters.AddWithValue("@ConductedBy", textOlusturan.Text);
            cmd.Parameters.AddWithValue("@StartDate", date1.Value);
            cmd.Parameters.AddWithValue("@EndDate", date2.Value);
            cmd.Parameters.AddWithValue("@ExpectedParticipants", int.Parse(textBeklenilenKatilimciSayisi.Text));
            cmd.Parameters.AddWithValue("@SurveyID", surveyID);

            cmd.ExecuteNonQuery();
        }

        private void UpdateQuestions(SqlConnection conn, SqlTransaction transaction, int surveyID)
        {
            
            string deleteChoicesQuery = "DELETE FROM Choices WHERE QuestionID IN (SELECT QuestionID FROM Questions WHERE SurveyID = @SurveyID)";
            SqlCommand deleteChoicesCmd = new SqlCommand(deleteChoicesQuery, conn, transaction);
            deleteChoicesCmd.Parameters.AddWithValue("@SurveyID", surveyID);
            deleteChoicesCmd.ExecuteNonQuery();

            
            string deleteQuestionsQuery = "DELETE FROM Questions WHERE SurveyID = @SurveyID";
            SqlCommand deleteQuestionsCmd = new SqlCommand(deleteQuestionsQuery, conn, transaction);
            deleteQuestionsCmd.Parameters.AddWithValue("@SurveyID", surveyID);
            deleteQuestionsCmd.ExecuteNonQuery();

            InsertQuestions(conn, transaction, surveyID);   
        }

        private void UpdateParticipantFields(SqlConnection conn, SqlTransaction transaction, int surveyID)
        {
            
            string deleteOldParticipantFieldsQuery = "DELETE FROM SurveyParticipantFields WHERE SurveyID = @SurveyID";
            SqlCommand deleteCmd = new SqlCommand(deleteOldParticipantFieldsQuery, conn, transaction);
            deleteCmd.Parameters.AddWithValue("@SurveyID", surveyID);
            deleteCmd.ExecuteNonQuery();

            
            InsertParticipantFields(conn, transaction, surveyID);
        }


        private bool IsFormValid()
        {
            return !string.IsNullOrWhiteSpace(textBaslik.Text) &&
                   !string.IsNullOrWhiteSpace(textOlusturan.Text) &&
                   !string.IsNullOrWhiteSpace(textBeklenilenKatilimciSayisi.Text) &&
                   dgwSorular.Rows.Count > 1 &&
                   CheckAtLeastOneParticipantFieldSelected();
        }

        private int InsertSurvey(SqlConnection conn, SqlTransaction transaction)
        {
            string query = "INSERT INTO Surveys (SurveyName, ConductedBy, StartDate, EndDate, ExpectedParticipants) " +
                           "OUTPUT INSERTED.SurveyID VALUES (@SurveyName, @ConductedBy, @StartDate, @EndDate, @ExpectedParticipants)";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@SurveyName", textBaslik.Text);
            cmd.Parameters.AddWithValue("@ConductedBy", textOlusturan.Text);
            cmd.Parameters.AddWithValue("@StartDate", date1.Value);
            cmd.Parameters.AddWithValue("@EndDate", date2.Value);
            cmd.Parameters.AddWithValue("@ExpectedParticipants", int.Parse(textBeklenilenKatilimciSayisi.Text));

            return (int)cmd.ExecuteScalar();
        }

        private void InsertQuestions(SqlConnection conn, SqlTransaction transaction, int surveyID)
        {
            foreach (DataGridViewRow row in dgwSorular.Rows)
            {
                if (row.IsNewRow) continue;

                string questionText = row.Cells["stnSoru"].Value.ToString();
                string answerType = row.Cells["stnCevapTipi"].Value.ToString();

                int questionID = InsertQuestion(conn, transaction, surveyID, questionText, answerType);

                if (row.Cells["stnSecenekler"].Value != null)
                {
                    InsertChoices(conn, transaction, questionID, row.Cells["stnSecenekler"].Value.ToString());
                }
            }
        }

        private int InsertQuestion(SqlConnection conn, SqlTransaction transaction, int surveyID, string questionText, string answerType)
        {
            // Duplicate kontrolü
            string checkDuplicateQuery = "SELECT QuestionID FROM Questions WHERE SurveyID = @SurveyID AND QuestionText = @QuestionText";
            SqlCommand checkDuplicateCmd = new SqlCommand(checkDuplicateQuery, conn, transaction);
            checkDuplicateCmd.Parameters.AddWithValue("@SurveyID", surveyID);
            checkDuplicateCmd.Parameters.AddWithValue("@QuestionText", questionText);

            object result = checkDuplicateCmd.ExecuteScalar();

            if (result != null)
            {
                
                return (int)result;
            }
            else
            {
                
                string query = "INSERT INTO Questions (SurveyID, QuestionText, AnswerType) OUTPUT INSERTED.QuestionID VALUES (@SurveyID, @QuestionText, @AnswerType)";
                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                cmd.Parameters.AddWithValue("@SurveyID", surveyID);
                cmd.Parameters.AddWithValue("@QuestionText", questionText);
                cmd.Parameters.AddWithValue("@AnswerType", answerType);

                return (int)cmd.ExecuteScalar();
            }
        }


        private void InsertChoices(SqlConnection conn, SqlTransaction transaction, int questionID, string choicesString)
        {
            string[] choices = choicesString.Split(',');

            foreach (string choice in choices)
            {
                string query = "INSERT INTO Choices (QuestionID, ChoiceText) VALUES (@QuestionID, @ChoiceText)";
                SqlCommand cmd = new SqlCommand(query, conn, transaction);
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                cmd.Parameters.AddWithValue("@ChoiceText", choice.Trim());

                cmd.ExecuteNonQuery();
            }
        }

        private void InsertParticipantFields(SqlConnection conn, SqlTransaction transaction, int surveyID)
        {
            var fieldMapping = new Dictionary<string, string>
    {
        { "Ad", "TextBox" }, { "Soyad", "TextBox" }, { "Yaş", "NumericBox" }, { "Cinsiyet", "ComboBox" },
        { "Medeni Hali", "RadioBox" }, { "e-posta", "TextBox" }, { "Telefon Numarası", "TextBox" },
        { "Doğum Tarihi", "DatePicker" }, { "Gelir Düzeyi", "ComboBox" }, { "Öğrenim Durumu", "ComboBox" },
        { "Kilo", "NumericBox" }, { "Boy", "NumericBox" }, { "Çalışma Durumu", "RadioBox" },
        { "Ev Sahipliği", "RadioBox" }, { "Meslek", "TextBox" }, { "Adres", "TextBox" }
    };

            foreach (var checkBox in GetParticipantFieldCheckBoxes())
            {
                if (checkBox.Checked)
                {
                    string fieldName = checkBox.Text;
                    string fieldType = fieldMapping[fieldName];
                    int fieldID = GetOrInsertFieldID(conn, transaction, fieldName, fieldType);

                    InsertSurveyParticipantField(conn, transaction, surveyID, fieldID);
                }
            }
        }

        private IEnumerable<CheckBox> GetParticipantFieldCheckBoxes()
        {
            return new List<CheckBox>
    {
        cbMedeniHali, cbAdres, cbYas, cbEposta, cbOgrenimDurumu, cbGelir,
        cbCalismaDurumu, cbEvSahipligi, cbCinsiyet, cbDogumTarihi, cbTelefon,
        cbMeslek, cbSoyad, cbAd, cbKilo, cbBoy
    };
        }

        private int GetOrInsertFieldID(SqlConnection conn, SqlTransaction transaction, string fieldName, string fieldType)
        {
            string selectQuery = "SELECT FieldID FROM ParticipantFields WHERE FieldName = @FieldName";
            SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction);
            selectCmd.Parameters.AddWithValue("@FieldName", fieldName);

            object fieldIDObj = selectCmd.ExecuteScalar();

            if (fieldIDObj != null)
            {
                return (int)fieldIDObj;
            }

            string insertQuery = "INSERT INTO ParticipantFields (FieldName, FieldType) OUTPUT INSERTED.FieldID VALUES (@FieldName, @FieldType)";
            SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
            insertCmd.Parameters.AddWithValue("@FieldName", fieldName);
            insertCmd.Parameters.AddWithValue("@FieldType", fieldType);

            return (int)insertCmd.ExecuteScalar();
        }

        private void InsertSurveyParticipantField(SqlConnection conn, SqlTransaction transaction, int surveyID, int fieldID)
        {
            string query = "INSERT INTO SurveyParticipantFields (SurveyID, FieldID) VALUES (@SurveyID, @FieldID)";
            SqlCommand cmd = new SqlCommand(query, conn, transaction);
            cmd.Parameters.AddWithValue("@SurveyID", surveyID);
            cmd.Parameters.AddWithValue("@FieldID", fieldID);

            cmd.ExecuteNonQuery();
        }

        private void ShowSurveyDesignForm()
        {
            formAnketTasarimSorgu a = new formAnketTasarimSorgu();
            a.Show();
            this.Hide();
        }

        private bool CheckAtLeastOneParticipantFieldSelected()
        {
            return GetParticipantFieldCheckBoxes().Any(cb => cb.Checked);
        }



        private void btnSoruSil_Click(object sender, EventArgs e)
        {
            if (dgwSorular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz soruyu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Seçili soruyu silmek istediğinizden emin misiniz?", "Soru Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            int selectedQuestionID;
            if (!int.TryParse(dgwSorular.SelectedRows[0].Cells["stnSoruID"].Value?.ToString(), out selectedQuestionID))
            {
                MessageBox.Show("Geçersiz soru seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string deleteChoicesQuery = "DELETE FROM Choices WHERE QuestionID = @QuestionID";
                        using (SqlCommand deleteChoicesCmd = new SqlCommand(deleteChoicesQuery, connection, transaction))
                        {
                            deleteChoicesCmd.Parameters.AddWithValue("@QuestionID", selectedQuestionID);
                            deleteChoicesCmd.ExecuteNonQuery();
                        }

                        string deleteQuestionQuery = "DELETE FROM Questions WHERE QuestionID = @QuestionID";
                        using (SqlCommand deleteQuestionCmd = new SqlCommand(deleteQuestionQuery, connection, transaction))
                        {
                            deleteQuestionCmd.Parameters.AddWithValue("@QuestionID", selectedQuestionID);
                            deleteQuestionCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Soru başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgwSorular.Rows.RemoveAt(dgwSorular.SelectedRows[0].Index);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Soru silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantısı kurulurken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSoruDuzenle_Click(object sender, EventArgs e)
        {
            if (dgwSorular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz soruyu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DataGridViewRow selectedRow = dgwSorular.SelectedRows[0];
            int selectedQuestionID = Convert.ToInt32(selectedRow.Cells["stnSoruID"].Value);
            string selectedQuestionText = selectedRow.Cells["stnSoru"].Value.ToString();
            string selectedAnswerType = selectedRow.Cells["stnCevapTipi"].Value.ToString();
            string selectedChoices = selectedRow.Cells["stnSecenekler"].Value?.ToString() ?? "";

            
            using (formSoruEkle formSoruDuzenle = new formSoruEkle(selectedQuestionText, selectedAnswerType, selectedChoices))
            {
                if (formSoruDuzenle.ShowDialog() == DialogResult.OK)
                {
                    
                    selectedRow.Cells["stnSoru"].Value = formSoruDuzenle.Sorular.FirstOrDefault();
                    selectedRow.Cells["stnCevapTipi"].Value = formSoruDuzenle.CevapTipi;
                    selectedRow.Cells["stnSecenekler"].Value = string.Join(", ", formSoruDuzenle.Secenekler);

                   
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            
                            string updateQuestionQuery = "UPDATE Questions SET QuestionText = @QuestionText, AnswerType = @AnswerType WHERE QuestionID = @QuestionID";
                            using (SqlCommand updateQuestionCmd = new SqlCommand(updateQuestionQuery, connection, transaction))
                            {
                                updateQuestionCmd.Parameters.AddWithValue("@QuestionText", formSoruDuzenle.Sorular.FirstOrDefault());
                                updateQuestionCmd.Parameters.AddWithValue("@AnswerType", formSoruDuzenle.CevapTipi);
                                updateQuestionCmd.Parameters.AddWithValue("@QuestionID", selectedQuestionID);

                                updateQuestionCmd.ExecuteNonQuery();
                            }

                            
                            string deleteChoicesQuery = "DELETE FROM Choices WHERE QuestionID = @QuestionID";
                            using (SqlCommand deleteChoicesCmd = new SqlCommand(deleteChoicesQuery, connection, transaction))
                            {
                                deleteChoicesCmd.Parameters.AddWithValue("@QuestionID", selectedQuestionID);
                                deleteChoicesCmd.ExecuteNonQuery();
                            }

                            
                            foreach (string choice in formSoruDuzenle.Secenekler)
                            {
                                string insertChoiceQuery = "INSERT INTO Choices (QuestionID, ChoiceText) VALUES (@QuestionID, @ChoiceText)";
                                using (SqlCommand insertChoiceCmd = new SqlCommand(insertChoiceQuery, connection, transaction))
                                {
                                    insertChoiceCmd.Parameters.AddWithValue("@QuestionID", selectedQuestionID);
                                    insertChoiceCmd.Parameters.AddWithValue("@ChoiceText", choice.Trim());
                                    insertChoiceCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Soru başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Soru güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        
    }


}
