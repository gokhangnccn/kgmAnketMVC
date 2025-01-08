using System;
using System.Drawing;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class textMetin : UserControl
    {
        public textMetin()
        {
            InitializeComponent();

            
            panel1.Paint += Panel1_Paint;
        }

        public string EtiketMetni
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
            }
        }

        public Size PanelSize
        {
            get => panel1.Size;
            set
            {
                panel1.Size = value;
                Invalidate(); 
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            int borderThickness = 1;
            Color borderColor = Color.Black;

            // Draw the thick border
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, panel1.Width - 2, panel1.Height - 2);
            }
        }


    }
}
