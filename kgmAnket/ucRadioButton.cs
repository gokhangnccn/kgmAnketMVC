using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class ucRadioButton : UserControl
    {
        private List<RadioButton> radioButtons;

        public ucRadioButton()
        {
            InitializeComponent();

            radioButtons = new List<RadioButton>();
            this.Controls.Add(flowLayoutPanel1);
        }

        public string LabelText
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
                bilesenBoyutlariAyarla();
            }
        }

        public void ClearSelection()
        {
            foreach (RadioButton rb in this.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }
        }



        public string SelectedValue
        {
            get => radioButtons.FirstOrDefault(rb => rb.Checked)?.Text;
            set
            {
                foreach (var rb in radioButtons)
                {
                    if (rb.Text == value)
                    {
                        rb.Checked = true;
                        break;
                    }
                }
            }
        }

        public void AddChoice(string choiceText)
        {
            RadioButton radioButton = new RadioButton
            {
                Text = choiceText,
                Font = new Font("Zilla Slab", 12, FontStyle.Regular),
                AutoSize = true,
                MaximumSize = new Size(400, 0)
            };

            radioButtons.Add(radioButton);
            flowLayoutPanel1.Controls.Add(radioButton);

            
            panelBoyutuAyarla();
        }

        private void panelBoyutuAyarla()
        {
            if (!flowLayoutPanel1.Controls.OfType<RadioButton>().Any())
                return;

            int totalHeight = flowLayoutPanel1.Controls.OfType<RadioButton>().Sum(rb => rb.Height)+20;
            int maxWidth = flowLayoutPanel1.Controls.OfType<RadioButton>().Max(rb => rb.Width) + 20;

            flowLayoutPanel1.Height = totalHeight+10;
            flowLayoutPanel1.Width = maxWidth;

            this.Height = label1.Height + flowLayoutPanel1.Height + 50;
            this.Width = Math.Max(label1.Width, flowLayoutPanel1.Width) + 20;

            flowLayoutPanel1.Location = new Point(flowLayoutPanel1.Location.X, label1.Bottom + 5);
        }

        public IEnumerable<string> Options
        {
            get => radioButtons.Select(rb => rb.Text);
            set
            {
                flowLayoutPanel1.Controls.Clear();
                radioButtons.Clear();
                foreach (var option in value)
                {
                    var rb = new RadioButton
                    {
                        Text = option,
                        Font = new Font("Zilla Slab", 12, FontStyle.Regular),
                        AutoSize = true,
                        MaximumSize = new Size(400, 0)
                    };
                    radioButtons.Add(rb);
                    flowLayoutPanel1.Controls.Add(rb);
                }
                panelBoyutuAyarla();
            }
        }

        private void bilesenBoyutlariAyarla()
        {
            int labelWidth = label1.Width;

            if (labelWidth > 400)
            {
                label1.MaximumSize = new Size(400, 0);
                label1.AutoSize = true;
                labelWidth = 400;
            }
            else
            {
                label1.MaximumSize = new Size(0, 0);
                label1.AutoSize = true;
            }

            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(label1.Text, label1.Font);
                label1.Width = (int)size.Width + 10;
                this.Width = label1.Width + 20;
            }

            panelBoyutuAyarla();
        }
    }
}
