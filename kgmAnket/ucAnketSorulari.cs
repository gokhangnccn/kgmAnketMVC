using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class ucAnketSorulari : UserControl
    {
        private string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True";

        public ucAnketSorulari()
        {
            InitializeComponent();
        }
        public Size panelBoyut
        {
            get { return panelSoru.Size; }
            set { panelSoru.Size = value; }
        }


        public void doUnVisible(){
            lblAnketinSorulari.Visible = false;
        }

        public void LoadQuestions(int surveyID)
        {
            panelSoru.Controls.Clear();
            int yOffset = 10;
            int soruSayi = 1;

            string questionQuery = "SELECT QuestionID, QuestionText, AnswerType FROM Questions WHERE SurveyID = @SurveyID";
            string choicesQuery = "SELECT ChoiceText FROM Choices WHERE QuestionID = @QuestionID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand questionCommand = new SqlCommand(questionQuery, connection))
                    {
                        questionCommand.Parameters.AddWithValue("@SurveyID", surveyID);
                        using (SqlDataReader questionReader = questionCommand.ExecuteReader())
                        {
                            while (questionReader.Read())
                            {
                                int questionID = (int)questionReader["QuestionID"];
                                string questionText = questionReader["QuestionText"].ToString();
                                string answerType = questionReader["AnswerType"].ToString();

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
                                    control.Location = new Point(5, yOffset);
                                    panelSoru.Controls.Add(control);
                                    yOffset += control.Height + 10;
                                }
                                soruSayi++;
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Hatası: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Genel Hata: {ex.Message}");
            }
        }


    }
}
