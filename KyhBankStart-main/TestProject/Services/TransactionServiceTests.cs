using BankStartWeb.Data;
using BankStartWeb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace TestProject.Services
//{
//    class TransactionSenderService : ITransactionService
//    {
//        public ITransactionService.TransactionStatus Transaction(string type, string operation, string date, decimal amount, decimal newBalance)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    [TestClass]
//    public class TransactionServiceTests
//    {
//        private TransactionService _sut;
//        private readonly TransactionSenderService _transactionSender;
//        private ApplicationDbContext _context;

//        public TransactionServiceTests()
//        {
//            _transactionSender = new TransactionSenderService();
//            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//                .UseInMemoryDatabase(databaseName: "Test")
//                .Options;
//            _context = new ApplicationDbContext(options);
//            _sut = new TransactionService(_transactionSender, _context);
//        }
//    }
//}
