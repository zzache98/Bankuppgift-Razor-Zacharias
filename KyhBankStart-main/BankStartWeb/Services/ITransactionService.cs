using System.Transactions;

namespace BankStartWeb.Services
{
    public interface ITransactionService
    {
        public enum TransactionStatus
        {
            Success,
            InvalidTransactionAmount,
            AccountBalanceNegative
            
        }
        TransactionStatus Transaction(string type, string operation, string date, decimal amount, decimal newBalance);
    }
}
