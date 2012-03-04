using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace Rente.Messages
{
    public class CalculateInterest : MessageBase
    {
        public double InterestRate { get; set; }
        public double Amount { get; set; }

        public CalculateInterest(double interestRate, double amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }
    }

    public class InterestCalculated : MessageBase
    {
        public double Interest { get; set; }

        public InterestCalculated(double interest)
        {
            Interest = interest;
        }
    }
}
