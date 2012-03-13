namespace Rente
{
    public class InterestServiceStub : IInterestService
    {
        public double CalcInterest(double interestRate, double amount)
        {
            return 1.0;
        }
    }
}