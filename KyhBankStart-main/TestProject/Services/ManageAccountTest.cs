using BankStartWeb.Data;
using BankStartWeb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Services
{

    [TestClass]
    public class ManageAccountTest
    {
        private readonly ApplicationDbContext _context;
        private readonly ManageAccount _sut;
        public ManageAccountTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;
            _context = new ApplicationDbContext(options);
            _sut = new ManageAccount(_context);
        }

        [TestMethod]
        public void When_deposit_amount_is_negative_should_return_errorcode()
        {
            // Arrange
            _context.Accounts.Add(new Account
            {
                Balance = 150,
                AccountType = "Personal",
                Created = DateTime.Now,
                Transactions = new List<Transaction>()
            });

            _context.Customers.Add(new Customer
            {
                Givenname = "Arnold",
                Surname = "Swats",
                Streetaddress = "Proteinroad 21b",
                Zipcode = "765 32",
                City = "Uppsala",
                Country = "Sweden",
                CountryCode = "SE",
                NationalId = "nationalTest",
                TelephoneCountryCode = 45,
                Telephone = "5646456234",
                EmailAddress = "arnold.swats@gmail.com",
                Birthday = DateTime.Now,
                Accounts = new List<Account>()

            });

            // Act
            _context.SaveChanges();

            var result = _sut.Deposit(1, -1000);

            // Assert
            Assert.AreEqual(IManageAccount.ErrorCode.AmountIsNegative, result);

        }

        [TestMethod]
        public void When_withdraw_amount_is_not_negative_should_return_ok()
        {
            // Arrange
            _context.Accounts.Add(new Account
            {
                Balance = 5000,
                AccountType = "Personal",
                Created = DateTime.Now,
                Transactions = new List<Transaction>()
            });

            _context.Customers.Add(new Customer
            {
                Givenname = "Arnold",
                Surname = "Swats",
                Streetaddress = "Proteinroad 21b",
                Zipcode = "765 32",
                City = "Uppsala",
                Country = "Sweden",
                CountryCode = "SE",
                NationalId = "nationalTest",
                TelephoneCountryCode = 45,
                Telephone = "5646456234",
                EmailAddress = "arnold.swats@gmail.com",
                Birthday = DateTime.Now,
                Accounts = new List<Account>()

            });

            // Act
            _context.SaveChanges();

            var result = _sut.WithDraw(1, -6000);

            // Assert
            Assert.AreEqual(IManageAccount.ErrorCode.AmountIsNegative, result);

        }

        [TestMethod]
        public void When_withdraw_amount_do_not_exceed_balance_should_return_ok()
        {
            // Arrange
            _context.Accounts.Add(new Account
            {
                Balance = 3400,
                AccountType = "Personal",
                Created = DateTime.Now,
                Transactions = new List<Transaction>()
            });

            _context.Customers.Add(new Customer
            {
                Givenname = "Ernst",
                Surname = "Kirschteiger",
                Streetaddress = "Sommarroad 21b",
                Zipcode = "455 32",
                City = "Torp",
                Country = "Sweden",
                CountryCode = "SE",
                NationalId = "nationalTest",
                TelephoneCountryCode = 45,
                Telephone = "5646456237",
                EmailAddress = "ernst.kirschsteiger@gmail.com",
                Birthday = DateTime.Now,
                Accounts = new List<Account>()

            });

            // Act
            _context.SaveChanges();

            var result = _sut.WithDraw(1, 5000);

            // Assert
            Assert.AreEqual(IManageAccount.ErrorCode.BalanceIsTooLow, result);
        }

        [TestMethod]
        public void When_transfer_amount_do_not_exceed_balance_should_return_ok()
        {
            // Arrange
            _context.Accounts.Add(new Account
            {
                Balance = 5000,
                AccountType = "Personal",
                Created = DateTime.Now,
                Transactions = new List<Transaction>()
            });

            _context.Customers.Add(new Customer
            {
                Givenname = "Ernst",
                Surname = "Kirschteiger",
                Streetaddress = "Sommarroad 21b",
                Zipcode = "455 32",
                City = "Torp",
                Country = "Sweden",
                CountryCode = "SE",
                NationalId = "nationalTest",
                TelephoneCountryCode = 45,
                Telephone = "5646456237",
                EmailAddress = "ernst.kirschsteiger@gmail.com",
                Birthday = DateTime.Now,
                Accounts = new List<Account>()

            });

            _context.Accounts.Add(new Account
            {
                Balance = 5000,
                AccountType = "Personal",
                Created = DateTime.Now,
                Transactions = new List<Transaction>()
            });

            // Act
            _context.SaveChanges();

            var result = _sut.Transfer(1,10000, 2);

            // Assert
            Assert.AreEqual(IManageAccount.ErrorCode.BalanceIsTooLow, result);
        }
    }
}
