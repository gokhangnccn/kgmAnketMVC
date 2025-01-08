using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kgmAnket
{

    public partial class ucAralik : UserControl
    {
        private const int maxLabelWidth = 375;
        private const int labelTextBoxSpacing = 20;
        private const int controlSpacing = 10;

        public ucAralik()
        {
            InitializeComponent();
        }

        private void ucAralik_Load(object sender, EventArgs e)
        {
            bilesenBoyutlariAyarla();
        }

        public string EtiketMetni
        {
            get => lblSoruMetni.Text;
            set
            {
                lblSoruMetni.Text = value;
                bilesenBoyutlariAyarla();
            }
        }

        public string label1
        {
            get => lblText1.Text;
            set
            {
                lblText1.Text = value;
                bilesenBoyutlariAyarla();
            }
        }

        public string label2
        {
            get => lblText2.Text;
            set
            {
                lblText2.Text = value;
                bilesenBoyutlariAyarla();
            }
        }

        private void bilesenBoyutlariAyarla()
        {
           
            lblSoruMetni.MaximumSize = new Size(maxLabelWidth, 0);
            lblSoruMetni.AutoSize = true;

            
            lblSoruMetni.Height = TextRenderer.MeasureText(lblSoruMetni.Text, lblSoruMetni.Font, new Size(maxLabelWidth, 0), TextFormatFlags.WordBreak).Height;

           
            lblText1.Top = lblSoruMetni.Bottom + labelTextBoxSpacing;
            lblText2.Top = lblSoruMetni.Bottom + labelTextBoxSpacing;

            
            txtBox1.Top = lblText1.Bottom + controlSpacing;
            txtBox1.Left = lblText1.Left;

            txtBox2.Top = lblText2.Bottom + controlSpacing;
            txtBox2.Left = lblText2.Left;

            
            this.Height = Math.Max(txtBox1.Bottom, txtBox2.Bottom) + controlSpacing;
        }
    }
}