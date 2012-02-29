namespace Rente
{
    public class InterestService
    {
        public double CalcInterest(double interestRate, double amount)
        {
            return (interestRate * amount) / (12 * 100);
        }
    }
}