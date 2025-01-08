using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class formMainDashboard : Form
    {
        public formMainDashboard()
        {
            InitializeComponent();
           
        }

        private void formMainDashboard_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer1.Interval = 1000; // 1 saniye
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = ""+DateTime.Now.ToString("HH:mm:ss");
        }


        private void panelAnketOlustur_MouseClick(object sender, MouseEventArgs e)
        {
            formAnketOlusturma anketForm = new formAnketOlusturma();
            anketForm.Show();
            this.Hide();
        }

        private void panelAnketGoruntule_MouseClick(object sender, MouseEventArgs e)
        {
            var formAnketTasarimSorgu = new formAnketTasarimSorgu();
            formAnketTasarimSorgu.Show();
            this.Hide();
        }


        private void panelAnketIstatistikleri_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("YAPIM AŞAMASINDA.", "YAPIM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void panelAnketVeriGirisi_MouseClick(object sender, MouseEventArgs e)
        {
            formAnketTasarimSorgu a = new formAnketTasarimSorgu();
            a.btnAnketVeriGirisi_Click(sender,e);
        }





        
        private void panelAnketOlustur_MouseEnter(object sender, EventArgs e)
        {
            tiklanabilirPanel(1, panelAnketOlustur);
        }

        private void panelAnketOlustur_MouseLeave(object sender, EventArgs e)
        {
            tiklanabilirPanel(0, panelAnketOlustur);
        }


        private void panelAnketGoruntule_MouseEnter(object sender, EventArgs e)
        {
            tiklanabilirPanel(1, panelAnketGoruntule);
        }

        private void panelAnketGoruntule_MouseLeave(object sender, EventArgs e)
        {
            tiklanabilirPanel(0, panelAnketGoruntule);
        }

        private void panelAnketIstatistikleri_MouseEnter(object sender, EventArgs e)
        {
            tiklanabilirPanel(1, panelAnketIstatistikleri);
        }

        private void panelAnketIstatistikleri_MouseLeave(object sender, EventArgs e)
        {
            tiklanabilirPanel(0, panelAnketIstatistikleri);
        }

        private void panelAnketVeriGirisi_MouseEnter(object sender, EventArgs e)
        {
            tiklanabilirPanel(1, panelAnketVeriGirisi);
        }

        private void panelAnketVeriGirisi_MouseLeave(object sender, EventArgs e)
        {
            tiklanabilirPanel(0, panelAnketVeriGirisi);
        }



        
        private void tiklanabilirPanel(int logic, Panel panel)
        {
            //0 çıkış
            //1 giriş
            if (logic == 1)
            {
                panel.BorderStyle = BorderStyle.Fixed3D;
                panel.Cursor = Cursors.Hand;
            }
            else if (logic == 0)
            {
                panel.BorderStyle = BorderStyle.None;
                panel.Cursor = Cursors.Default;
            }
        }

        private void panelAnketGoruntule_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAnketVeriGirisi_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
