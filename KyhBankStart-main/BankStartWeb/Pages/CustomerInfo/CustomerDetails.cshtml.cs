using AutoMapper;
using BankStartWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankStartWeb.Pages.CustomerInfo
{
    public class CustomerDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerDetailsModel(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CustomerDetailsViewModel CustomerDetails { get; private set; } 

        public class CustomerDetailsViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Streetaddress { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public string Country { get; set; }
            public string CountryCode { get; set; }
            public string NationalId { get; set; }

            public int TelephoneCountryCode { get; set; }
            public string Telephone { get; set; }

            public string EmailAddress { get; set; }
            public DateTime Birthday { get; set; }
            public decimal Balance { get; set; }
            public string AccountType { get; set; }
            public DateTime Created { get; set; }

            public List<AccountDetailsViewModel> Accounts { get; set; } = new List<AccountDetailsViewModel>();
        }

        public class AccountDetailsViewModel
        {
            public int Id { get; set; }
            public string AccountType { get; set; }
            public DateTime Created { get; set; }
            public decimal Balance { get; set; }
        }

        public void OnGet(int id)
        {
            CustomerDetails = _mapper.Map<CustomerDetailsViewModel>(_context.Customers.Include(a => a.Accounts).FirstOrDefault(a => a.Id == id));
        }

    }
}
