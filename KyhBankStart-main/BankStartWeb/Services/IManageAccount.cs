namespace BankStartWeb.Services
{
    public interface IManageAccount
    {
        public enum ErrorCode
        {
           Ok,
           BalanceIsTooLow,
           AmountIsNegative,
           AccountNotFound
        }

        ErrorCode Deposit(int accountId, decimal amount);
        ErrorCode WithDraw(int accountId, decimal amount);
        ErrorCode Transfer(int accountId, decimal amount, int receiverId);

    }
}
