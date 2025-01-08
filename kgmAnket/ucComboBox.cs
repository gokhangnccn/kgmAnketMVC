using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class ucComboBox : UserControl
    {
        public ucComboBox()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        
        public string SelectedValue
        {
            get => comboBox1.SelectedItem?.ToString();
            set => comboBox1.SelectedItem = value;
        }
        public void AddChoice(string choiceText)
        {
            comboBox1.Items.Add(choiceText);
        }
        
        public IEnumerable<string> Items
        {
            get => comboBox1.Items.Cast<string>();
            set
            {
                comboBox1.Items.Clear();
                foreach (var item in value)
                {
                    comboBox1.Items.Add(item);
                }
            }
        }
    }
}
