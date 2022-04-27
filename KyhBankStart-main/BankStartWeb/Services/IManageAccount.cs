namespace BankStartWeb.Services
{
    public interface IManageAccount
    {
        public enum ErrorCode
        {
           Ok,
           BalanceIsTooLow,
           AmountIsNegative,
           InsufficientFunds
        }

        ErrorCode Deposit(int accountId, decimal amount);
        ErrorCode WithDraw(int accountId, decimal amount);
        ErrorCode Transfer(int accountId, decimal amount, int recieverId);


    }
}
