using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Rente
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        private void MaxAmountChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            int value = 0;
            var text = textBox.Text;
            bool isParseable = int.TryParse(textBox.Text, out value);
            if ((!isParseable && !string.IsNullOrEmpty(text)) || value > 1000000000 || value < 0)
            {
                MessageBox.Show("Du må angi et beløp i hela kroner mellom 0 - 1000000000");
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
        }

        private void MaxInteresteRateChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            double value = 0;
            var text = textBox.Text;
            bool isParseable = double.TryParse(textBox.Text, out value);
            if ((!isParseable && !string.IsNullOrEmpty(text)) || value > 100 || value < 0)
            {
                MessageBox.Show("Prosent må være mellom 0 - 100");
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
        }
    }
}