namespace Rente
{
    public class InterestService : IInterestService
    {
        public double CalcInterest(double interestRate, double amount)
        {
            return (interestRate * amount) / (12 * 100);
        }
    }
}