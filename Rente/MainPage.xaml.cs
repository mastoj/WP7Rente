using System.Globalization;
using System.Windows;
using Microsoft.Phone.Controls;
using Rente.Converters;

namespace Rente
{
    public partial class MainPage : PhoneApplicationPage
    {
        private InterestService _interestService;
        private double _amount;
        private double _interestRate;
        private DoubleTo2DecimalsStringConverter _doubleToTwoDecimalsConverter;

        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
        }
        
      
    }
}