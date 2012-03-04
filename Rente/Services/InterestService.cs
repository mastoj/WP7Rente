using System;
using GalaSoft.MvvmLight.Messaging;
using Rente.Messages;

namespace Rente
{
    public class InterestService
    {
        public void CalcInterest(CalculateInterest command, Action<double> callBack)
        {
            var interest = (command.InterestRate * command.Amount) / (12 * 100);
            callBack(interest);
        }
    }
}