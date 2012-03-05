using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Rente.Messages;

namespace Rente.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IMessenger messenger)
        {
            MessengerInstance = messenger;
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            MessengerInstance.Register<InterestCalculated>(this, result => Interest = result.Interest);
        }

        /// <summary>
        /// The <see cref="Amount" /> property's name.
        /// </summary>
        public const string AmountPropertyName = "Amount";

        private double _amount = 0;

        /// <summary>
        /// Sets and gets the Amount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                if (_amount == value)
                {
                    return;
                }
                _amount = value;
                MessengerInstance.Send(new CalculateInterest(InterestRate, _amount));
                RaisePropertyChanged(AmountPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="InterestRate" /> property's name.
        /// </summary>
        public const string InterestRatePropertyName = "InterestRate";

        private double _interestRate = 0;

        /// <summary>
        /// Sets and gets the InterestRate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double InterestRate
        {
            get
            {
                return _interestRate;
            }

            set
            {
                if (_interestRate == value)
                {
                    return;
                }

                _interestRate = value;
                MessengerInstance.Send(new CalculateInterest(_interestRate, Amount));
                RaisePropertyChanged(InterestRatePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Interest" /> property's name.
        /// </summary>
        public const string InterestPropertyName = "Interest";

        private double _interest = 0;

        /// <summary>
        /// Sets and gets the Interest property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double Interest
        {
            get
            {
                return _interest;
            }

            set
            {
                if (_interest == value)
                {
                    return;
                }

                _interest = value;
                RaisePropertyChanged(InterestPropertyName);
            }
        }
    }
}