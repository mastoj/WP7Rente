namespace Rente
{
    public interface IInterestService
    {
        double CalcInterest(double interestRate, double amount);
    }
}