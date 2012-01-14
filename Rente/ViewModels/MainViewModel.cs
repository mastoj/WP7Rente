using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace Rente
{
    public class MainViewModel : INotifyPropertyChanged
    {
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
                    NotifyPropertyChanged("Interest");
                }
            }
        }

        private double _maxInterestRate = 10;
        public double MaxInterestRate
        {
            get
            {
                return _maxInterestRate;
            }
            set
            {
                if (value != _maxInterestRate)
                {
                    if (value > 100)
                    {
                        MessageBox.Show("Renten kan ikke være mer enn 100 %");
                        MaxInterestRate = value;
                    }
                    else if (value < 0)
                    {
                        MessageBox.Show("Renten kan ikke være mindre enn 0 %");
                        MaxInterestRate = value;
                    }
                    else
                    {
                        _maxInterestRate = value;
                        NotifyPropertyChanged("MaxInterestRate");
                        if (_maxInterestRate < InterestRate)
                        {
                            InterestRate = _maxInterestRate;
                        }
                    }
                }
            }
        }

        private int _maxAmount = 1000000;
        public int MaxAmount
        {
            get
            {
                return _maxAmount;
            }
            set
            {
                if (value != _maxAmount)
                {
                    if (value > 1000000000)
                    {
                        MessageBox.Show("Kalkylatorn støtter maks 1000000000 kr");
                        MaxAmount = value;
                    }
                    else if (value < 0)
                    {
                        MessageBox.Show("Du kan ikke angi et beløp mindre en 0 kr");
                        MaxAmount = value;
                    }
                    else
                    {
                        _maxAmount = value;
                        NotifyPropertyChanged("MaxAmount");
                        if (_maxAmount < _amount)
                        {
                            Amount = _maxAmount;
                        }
                    }
                }
            }
        }

        private int _numberOfYears = 40;
        public int NumberOfYears
        {
            get
            {
                return _numberOfYears;
            }
            set
            {
                if (value != _numberOfYears)
                {
                    _numberOfYears = value;
                    NotifyPropertyChanged("NumberOfYears");
                    NotifyPropertyChanged("Interest");
                }
            }
        }

        private bool _withPaymentPlan = false;
        public bool WithPaymentPlan
        {
            get { return _withPaymentPlan; }
            set
            {
                if (_withPaymentPlan != value)
                {
                    _withPaymentPlan = value;
                    NotifyPropertyChanged("WithPaymentPlan");
                    NotifyPropertyChanged("Interest");
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
                    NotifyPropertyChanged("Interest");
                }
            }
        }

        public double Interest
        {
            get
            {
                if (WithPaymentPlan)
                {
                    double interestPerMonth = InterestRate/(12*100);
                    int numberOfMonth = NumberOfYears*12;

                    double somePart = (1 + interestPerMonth);
                    for(int i = 1; i < numberOfMonth; i++)
                    {
                        somePart = somePart * (1 + interestPerMonth);
                    }
                    var monthlyAmount = (Amount*interestPerMonth*somePart)/(somePart - 1);
                    return monthlyAmount;
                }
                return (InterestRate * Amount)/ (12 * 100);
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