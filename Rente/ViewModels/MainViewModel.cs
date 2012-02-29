using System;
using System.ComponentModel;

namespace Rente
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            PropertyChanged += HandleChangeOfAnyProperty;
            _interestService = new InterestService();
            Interest = _interestService.CalcInterest(InterestRate, Amount);
        }

        private void HandleChangeOfAnyProperty(object sender, PropertyChangedEventArgs e)
        {
            var prop = e.PropertyName;
            if (prop != "Interest")
            {
                Interest = _interestService.CalcInterest(InterestRate, Amount);
            }
        }

        private int _amount = 100000;

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value != _amount)
                {
                    _amount = value;
                    NotifyPropertyChanged("Amount");
                }
            }
        }

        private double _interestRate = 3.5;

        public double InterestRate
        {
            get
            {
                return _interestRate;
            }
            set
            {
                if (value != _interestRate)
                {
                    _interestRate = value;
                    NotifyPropertyChanged("InterestRate");
                }
            }
        }

        private double _interest;
        private InterestService _interestService;

        public double Interest
        {
            get { return _interest; }
            set
            {
                if (value != _interest)
                {
                    _interest = value;
                    NotifyPropertyChanged("Interest");
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}