using BankStartWeb.Data;
using Microsoft.EntityFrameworkCore;


namespace BankStartWeb.Services
{
    public class ManageAccount : IManageAccount
    {
        private readonly ApplicationDbContext _context;

        public ManageAccount(ApplicationDbContext context)
        {
            _context = context;
        }


       

        public IManageAccount.ErrorCode Deposit(int accountId, decimal amount)
        {
            if (amount < 0)
            {
                return IManageAccount.ErrorCode.AmountIsNegative;
            }

            var account = _context.Accounts
                .Include(e => e.Transactions)
                .FirstOrDefault(e => e.Id == accountId);

            account.Balance += amount;

            var transaction = new Transaction();
            transaction.Type = "Debit";
            transaction.Amount = amount;
            transaction.Operation = "Deposit";
            transaction.Date = DateTime.Now;
            transaction.NewBalance = account.Balance;

            account.Transactions.Add(transaction);
            _context.SaveChanges();

            return IManageAccount.ErrorCode.Ok;
        }

        public IManageAccount.ErrorCode WithDraw(int accountId, decimal amount)
        {
            var account = _context.Accounts.FirstOrDefault(e => e.Id == accountId);

            if (account.Balance < amount)
            {
                return IManageAccount.ErrorCode.BalanceIsTooLow;
            }
            else if (amount < 0)
            {
                return IManageAccount.ErrorCode.AmountIsNegative;
            }

            account.Balance -= amount;

            var transaction = new Transaction();
            transaction.Type = "ATM";
            transaction.Amount = amount;
            transaction.Operation = "Withdraw";
            transaction.Date = DateTime.Now;
            transaction.NewBalance = account.Balance;
            account.Transactions.Add(transaction);
            _context.SaveChanges();

            return IManageAccount.ErrorCode.Ok;

            
            }

        public IManageAccount.ErrorCode Transfer(int accountId, decimal amount, int recieverId)
        {
            if (amount < 0)
            {
                return IManageAccount.ErrorCode.AmountIsNegative;
            }

            var senderTransfer = _context.Accounts
                .Include(e => e.Transactions)
                .FirstOrDefault(e => e.Id == accountId);



            var receiverTransfer = _context.Accounts
                .Include(e => e.Transactions)
                .FirstOrDefault(e => e.Id == recieverId);

            var sender = new Transaction();
            {
                sender.Amount = amount;
                sender.Operation = "Transfer";
                sender.Date = DateTime.Now;
                sender.Type = "Credit";
                sender.NewBalance = senderTransfer.Balance - amount;
            }

            if (amount > senderTransfer.Balance)
            {
                return IManageAccount.ErrorCode.BalanceIsTooLow;
            }

            var receiver = new Transaction();
            {
                receiver.Amount = amount;
                receiver.Operation = "Transfer";
                receiver.Date = DateTime.Now;
                receiver.Type = "Credit";
                receiver.NewBalance = receiverTransfer.Balance + amount;
            }

            senderTransfer.Balance -= amount;
            receiverTransfer.Balance += amount;

            senderTransfer.Transactions.Add(sender);
            receiverTransfer.Transactions.Add(receiver);

            _context.SaveChanges();

            return IManageAccount.ErrorCode.Ok;
        }
    }
}
