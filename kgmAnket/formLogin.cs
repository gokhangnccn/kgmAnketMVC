using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class formLogin : Form
    {
        private string connectionString = "Server=localhost;Database=AnketUygulamasiDB;Integrated Security=True;";

        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int panelWidth = 800;
            int panelHeight = 400;

            panelLogin.Location = new Point((formWidth - panelWidth) / 2, (formHeight - panelHeight) / 2);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textKullanici.Text.Trim();
            string sifre = textSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Users WHERE UserName = @UserName AND Password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", kullaniciAdi);
                        command.Parameters.AddWithValue("@Password", sifre);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count == 1)
                        {
                            formMainDashboard dashboardForm = new formMainDashboard();
                            dashboardForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
