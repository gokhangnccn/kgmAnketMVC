using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class formAnketVeriGirisi : Form
    {
        private string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True;";
        private int selectedSurveyID;

        public formAnketVeriGirisi(int SID)
        {
            InitializeComponent();
            selectedSurveyID = SID;
        }

        public void anketVeriGirisi()
        {
            if (selectedSurveyID == 0)
            {
                MessageBox.Show("Lütfen veri girişi yapmak istediğiniz anketi seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string surveyQuery = "SELECT SurveyName, ConductedBy FROM dbo.Surveys WHERE SurveyID = @SurveyID";

            btnGeri.Click += (s, args) =>
            {
                Form formAnketTasarimSorgu = new formAnketTasarimSorgu();
                formAnketTasarimSorgu.Show();
                this.Close();
            };

            try
            {
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
                                labelBaslik.Text = reader["SurveyName"].ToString();
                                labelOlusturan.Text = reader["ConductedBy"].ToString();
                            }
                            reader.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }

            dinamikKatimciBilgileri(this, selectedSurveyID);
            dinamikSorulariEkle(this, selectedSurveyID);

            this.Show();
        }

        private void dinamikKatimciBilgileri(Form form, int surveyID)
        {
            string anketFieldID = "SELECT FieldID FROM dbo.SurveyParticipantFields WHERE SurveyID = @SurveyID";
            string anketFieldTip = "SELECT FieldType, FieldName, MinValue, MaxValue FROM dbo.ParticipantFields WHERE FieldID = @FieldID";

            int yOffset = panelKatilimci.Padding.Top + 20;
            int xOffset = panelKatilimci.Padding.Left + 10;
            int columnWidth = panelKatilimci.Width;
            int controlSpacing = 5;

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
                                                case "TextBox":
                                                    control = new ucMetinKutusu
                                                    {
                                                        EtiketMetni = fieldName,
                                                        SayisalMi = false,
                                                        MaxUzunluk = 100,
                                                        CokSatirliMi = false
                                                    };
                                                    break;

                                                case "RadioBox":
                                                    control = new ucRadioButton
                                                    {
                                                        LabelText = fieldName
                                                    };
                                                    break;

                                                case "ComboBox":
                                                    control = new ucComboBox
                                                    {
                                                        LabelText = fieldName
                                                    };
                                                    break;

                                                case "DatePicker":
                                                    control = new ucDatePicker
                                                    {
                                                        LabelText = fieldName
                                                    };
                                                    break;

                                                case "NumericBox":
                                                    int minValue = fieldTypeReader["MinValue"] != DBNull.Value ? (int)fieldTypeReader["MinValue"] : 0;
                                                    int maxValue = fieldTypeReader["MaxValue"] != DBNull.Value ? (int)fieldTypeReader["MaxValue"] : int.MaxValue;

                                                    control = new ucMetinKutusu
                                                    {
                                                        EtiketMetni = fieldName,
                                                        SayisalMi = true,
                                                        MinDeger = minValue,
                                                        MaxDeger = maxValue,
                                                        CokSatirliMi = false
                                                    };
                                                    break;
                                            }

                                            if (control != null)
                                            {
                                                control.Location = new Point(xOffset, yOffset);

                                                panelKatilimci.Controls.Add(control);

                                                xOffset += columnWidth + controlSpacing;
                                                if (xOffset + columnWidth > panelKatilimci.Width - panelKatilimci.Padding.Right)
                                                {
                                                    xOffset = panelKatilimci.Padding.Left + 10;
                                                    yOffset += control.Height + controlSpacing;
                                                }
                                            }
                                        }

                                        fieldTypeReader.Close();
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


        private void dinamikSorulariEkle(Form form, int surveyID)
        {
            string questionQuery = "SELECT QuestionID, QuestionText, AnswerType FROM Questions WHERE SurveyID = @SurveyID";
            string choicesQuery = "SELECT ChoiceText FROM Choices WHERE QuestionID = @QuestionID";

            int yOffset = panelSorular.Padding.Top + 10;
            int xOffset = panelSorular.Padding.Left + 10;
            int controlSpacing = 10;
            int soruSayi = 1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(questionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@SurveyID", surveyID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int questionID = (int)reader["QuestionID"];
                                string questionText = reader["QuestionText"].ToString();
                                string answerType = reader["AnswerType"].ToString();
                                UserControl control = null;

                                switch (answerType)
                                {
                                    case "Metin":
                                        control = new ucMetinKutusu
                                        {
                                            EtiketMetni = "Soru " + soruSayi + ") " + questionText,
                                            SayisalMi = false,
                                            MaxUzunluk = 100
                                        };
                                        break;
                                    case "Çoktan Tek Seçmeli":
                                        var radioButtonControl = new ucRadioButton
                                        {
                                            LabelText = "Soru " + soruSayi + ") " + questionText
                                        };

                                        using (SqlConnection choicesConnection = new SqlConnection(connectionString))
                                        {
                                            choicesConnection.Open();
                                            using (SqlCommand choicesCommand = new SqlCommand(choicesQuery, choicesConnection))
                                            {
                                                choicesCommand.Parameters.AddWithValue("@QuestionID", questionID);
                                                using (SqlDataReader choicesReader = choicesCommand.ExecuteReader())
                                                {
                                                    while (choicesReader.Read())
                                                    {
                                                        string choiceText = choicesReader["ChoiceText"].ToString();
                                                        radioButtonControl.AddChoice(choiceText);
                                                    }
                                                }
                                            }
                                        }

                                        control = radioButtonControl;
                                        break;
                                    case "Çoktan Çok Seçmeli":
                                        var comboBoxControl = new ucComboBox
                                        {
                                            LabelText = "Soru " + soruSayi + ") " + questionText
                                        };

                                        
                                        using (SqlConnection choicesConnection = new SqlConnection(connectionString))
                                        {
                                            choicesConnection.Open();
                                            using (SqlCommand choicesCommand = new SqlCommand(choicesQuery, choicesConnection))
                                            {
                                                choicesCommand.Parameters.AddWithValue("@QuestionID", questionID);
                                                using (SqlDataReader choicesReader = choicesCommand.ExecuteReader())
                                                {
                                                    while (choicesReader.Read())
                                                    {
                                                        comboBoxControl.AddChoice(choicesReader["ChoiceText"].ToString());
                                                    }
                                                }
                                            }
                                        }

                                        control = comboBoxControl;
                                        break;
                                    case "Sayı":
                                        control = new ucMetinKutusu
                                        {
                                            EtiketMetni = "Soru " + soruSayi + ") " + questionText,
                                            SayisalMi = true
                                        };
                                        break;
                                    case "Tarih":
                                        control = new ucMetinKutusu
                                        {
                                            EtiketMetni = "Soru " + soruSayi + ") " + questionText,
                                            SayisalMi = true
                                        };
                                        break;

                                    case "Sayı Aralığı":
                                        control = new ucAralik
                                        {
                                            EtiketMetni = "Soru " + soruSayi + ") " + questionText + " (Lütfen kutucuklara SAYI aralığı giriniz.)",
                                            label1 = "Sayı-1",
                                            label2 = "Sayı-2"
                                        };
                                        break;
                                    case "Tarih Aralığı":
                                        control = new ucAralik
                                        {
                                            EtiketMetni = "Soru " + soruSayi + ") " + questionText + " (Lütfen kutucuklara TARİH aralığı giriniz.)",
                                            label1 = "Tarih-1",
                                            label2 = "Tarih-2"
                                        };
                                        break;
                                }

                                if (control != null)
                                {
                                    control.Location = new Point(xOffset, yOffset);

                                    panelSorular.Controls.Add(control);

                                    yOffset += control.Height + controlSpacing;
                                    soruSayi++;
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

        private void btnKaydetVesonraki_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string participantInsertQuery = "INSERT INTO SurveyParticipants (SurveyID) OUTPUT INSERTED.ParticipantID VALUES (@SurveyID)";
                    int newParticipantID;
                    using (SqlCommand participantInsertCommand = new SqlCommand(participantInsertQuery, connection))
                    {
                        participantInsertCommand.Parameters.AddWithValue("@SurveyID", selectedSurveyID);
                        newParticipantID = (int)participantInsertCommand.ExecuteScalar(); // Get the new ParticipantID
                    }

                    
                    foreach (UserControl control in panelKatilimci.Controls)
                    {
                        if (control is ucMetinKutusu metinKutusu)
                        {
                            string responseText = metinKutusu.MetinDegeri;
                            int fieldID = GetFieldIDFromLabel(metinKutusu.EtiketMetni, connection);

                            string participantResponseQuery = "INSERT INTO ParticipantResponses (ParticipantID, FieldID, ResponseText) VALUES (@ParticipantID, @FieldID, @ResponseText)";
                            using (SqlCommand participantResponseCommand = new SqlCommand(participantResponseQuery, connection))
                            {
                                participantResponseCommand.Parameters.AddWithValue("@ParticipantID", newParticipantID);
                                participantResponseCommand.Parameters.AddWithValue("@FieldID", fieldID);
                                participantResponseCommand.Parameters.AddWithValue("@ResponseText", responseText);
                                participantResponseCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    
                    foreach (UserControl control in panelSorular.Controls)
                    {
                        int questionID = GetQuestionIDFromControl(control, connection);
                        string responseText = GetResponseFromControl(control);

                        string surveyResponseQuery = "INSERT INTO SurveyResponses (SurveyID, ParticipantID, QuestionID, ResponseText) VALUES (@SurveyID, @ParticipantID, @QuestionID, @ResponseText)";
                        using (SqlCommand surveyResponseCommand = new SqlCommand(surveyResponseQuery, connection))
                        {
                            surveyResponseCommand.Parameters.AddWithValue("@SurveyID", selectedSurveyID);
                            surveyResponseCommand.Parameters.AddWithValue("@ParticipantID", newParticipantID);
                            surveyResponseCommand.Parameters.AddWithValue("@QuestionID", questionID);
                            surveyResponseCommand.Parameters.AddWithValue("@ResponseText", responseText);
                            surveyResponseCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cevaplar başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetFieldIDFromLabel(string labelText, SqlConnection connection)
        {
            string query = "SELECT FieldID FROM ParticipantFields WHERE FieldName = @FieldName";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FieldName", labelText);
                var result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int fieldID))
                {
                    return fieldID;
                }
                else
                {
                    
                    MessageBox.Show($"Label metni '{labelText}' bulunamadı.");
                    return -1;
                }
            }
        }


        private int GetQuestionIDFromControl(UserControl control, SqlConnection connection)
        {
            string questionText = string.Empty;

            if (control is ucMetinKutusu metinKutusu)
            {
                questionText = metinKutusu.EtiketMetni.Trim();  // Trim whitespace
            }
            else if (control is ucRadioButton radioButton)
            {
                questionText = radioButton.LabelText.Trim();
            }
            else if (control is ucComboBox comboBox)
            {
                questionText = comboBox.LabelText.Trim();
            }
            MessageBox.Show($"Querying QuestionText: '{questionText}'");

            string query = @"
                SELECT 
                    QuestionID, 
                    LTRIM(RTRIM(SUBSTRING(QuestionText, 
                                          CASE 
                                              WHEN CHARINDEX(')', QuestionText) > 0 AND LEFT(QuestionText, CHARINDEX(')', QuestionText)) LIKE 'Soru %)' 
                                              THEN CHARINDEX(')', QuestionText) + 1 
                                              ELSE 1 
                                          END, 
                                          LEN(QuestionText)))) AS CleanedQuestionText
                FROM 
                    Questions
                WHERE 
                    UPPER(LTRIM(RTRIM(SUBSTRING(QuestionText, 
                                                 CASE 
                                                     WHEN CHARINDEX(')', QuestionText) > 0 AND LEFT(QuestionText, CHARINDEX(')', QuestionText)) LIKE 'Soru %)' 
                                                     THEN CHARINDEX(')', QuestionText) + 1 
                                                     ELSE 1 
                                                 END, 
                                                 LEN(QuestionText))))) = UPPER(@questionText);
            ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@QuestionText", questionText);
                var result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }





        private string GetResponseFromControl(UserControl control)
        {
            if (control is ucMetinKutusu metinKutusu)
            {
                return metinKutusu.MetinDegeri;
            }
            else if (control is ucRadioButton radioButton)
            {
                return radioButton.SelectedValue;
            }
            else if (control is ucComboBox comboBox)
            {
                return comboBox.SelectedValue;
            }
            
            return string.Empty;
        }

        public void clearSelection()
        {
            foreach (RadioButton rb in this.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }

        }
        private void ClearForm()
        {
            foreach (UserControl control in panelKatilimci.Controls)
            {
                if (control is ucMetinKutusu metinKutusu)
                {
                    metinKutusu.Text = string.Empty;
                }
                else if (control is ucRadioButton radioButton)
                {
                    radioButton.ClearSelection();
                }
            }

            foreach (UserControl control in panelSorular.Controls)
            {
                if (control is ucMetinKutusu metinKutusu)
                {
                    metinKutusu.Text = string.Empty;
                }
                else if (control is ucRadioButton radioButton)
                {
                    radioButton.ClearSelection();
                }

                
            }
        }
    }
}
