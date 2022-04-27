using BankStartWeb.Data;

//namespace BankStartWeb.Services
//{
//    public class TransactionService : ITransactionService
//    {
//        private readonly ApplicationDbContext _context;

//        public TransactionService(ApplicationDbContext context)
//        {
//            _context = context; 
//        }

//        public ITransactionService.TransactionStatus Transaction(string type, string operation, string date, decimal amount, decimal newBalance)
//        {
//            if (CheckCorrectAccountBalance(newBalance) == )
//                return ITransactionService.TransactionStatus.AccountBalanceNegative;
//        }

//        private bool CheckCorrectAccountBalance( decimal newBalance)
//        {
//            if (newBalance < 0)
//                return ("Account Balance Is Too Low");
//            else return "Ok";
//        }
//    }
//}
