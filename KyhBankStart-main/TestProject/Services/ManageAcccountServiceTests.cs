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
    public class ManageAccountServiceTests 
    {
        private readonly ManageAccount _sut;
        private ApplicationDbContext _context;

        
        public  ManageAccountServiceTests
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;
            _context = new ApplicationDbContext(options)
            _sut = new ManageAccountServiceTests(_context);
        }

        [TestMethod]
        public void When_making_transaction_should_add_log_event()
        {
            _context.ManageAccountUsers.Add(new ManageAccountUsers
            {
                
            })
        }
    }

    
    
    }
}
