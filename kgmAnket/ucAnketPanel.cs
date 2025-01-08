using System;
using System.Drawing;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class ucAnketPanel : UserControl
    {
        public int SurveyID { get; set; }
        public string ConnectionString { get; set; }

        public ucAnketPanel()
        {
            InitializeComponent();
           
        }

        public string AnketBasligi
        {
            get { return lblAnketBasligi.Text; }
            set { lblAnketBasligi.Text = value; }
        }

        public string AnketiOlusturan
        {
            get { return txtAnketiOlusturan.Text; }
            set { txtAnketiOlusturan.Text = value; }
        }

        public string BeklenilenKatilimciSayisi
        {
            get { return txtBeklenilenKatilimciSayisi.Text; }
            set { txtBeklenilenKatilimciSayisi.Text = value; }
        }

        public DateTime BaslangicTarihi
        {
            get { return dateBaslangic.Value; }
            set { dateBaslangic.Value = value; }
        }

        public DateTime BitisTarihi
        {
            get { return dateBitis.Value; }
            set { dateBitis.Value = value; }
        }

        private void ucAnketPanel_Load(object sender, EventArgs e)
        {
            ucAnketSorulari sorularControl = new ucAnketSorulari();
            sorularControl.LoadQuestions(SurveyID);
           
            
            sorularControl.Location = new Point(305, 30);

            panelAnket.Controls.Add(sorularControl);
        }

        private void btnAnketVeriGirisi_Click(object sender, EventArgs e)
        {
            formAnketVeriGirisi veriGirisi = new formAnketVeriGirisi(SurveyID);

            veriGirisi.anketVeriGirisi();
        }
    }
}
