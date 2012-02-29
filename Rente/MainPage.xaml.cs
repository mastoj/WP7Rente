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
            _amount = 100000;
            _interestRate = 3.10;
            _doubleToTwoDecimalsConverter = new DoubleTo2DecimalsStringConverter();
            UpdateUI();
        }
        
        private void InterestRateChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _interestRate = e.NewValue;
            UpdateUI();
        }

        private void OnAmountChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _amount = e.NewValue;
            UpdateUI();
        }

        private void UpdateUI()
        {
            AmountTextBlock.Text = ConvertFromDoubleToString(_amount);
            InterestRateTextBlock.Text = ConvertFromDoubleToString(_interestRate);
            InterestTextBlock.Text = GetInterestText();
        }

        private string GetInterestText()
        {
            var interest = InterestService.CalcInterest(_interestRate, _amount);
            var interestText = ConvertFromDoubleToString(interest);
            return interestText;
        }

        private string ConvertFromDoubleToString(double interest)
        {
            return (string)_doubleToTwoDecimalsConverter.Convert(interest, typeof(string), null, CultureInfo.InvariantCulture);
        }

        private InterestService InterestService
        {
            get
            {
                if(_interestService == null)
                {
                    _interestService = new InterestService();
                }
                return _interestService;
            }
        }
    }
}