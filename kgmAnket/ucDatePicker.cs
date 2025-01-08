using System;
using System.Windows.Forms;

namespace kgmAnket
{
    public partial class ucDatePicker : UserControl
    {
        public ucDatePicker()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        
        public DateTime SelectedDate
        {
            get => dateTimePicker1.Value;
            set => dateTimePicker1.Value = value;
        }

        
        public DateTimePickerFormat DateFormat
        {
            get => dateTimePicker1.Format;
            set => dateTimePicker1.Format = value;
        }
    }
}
