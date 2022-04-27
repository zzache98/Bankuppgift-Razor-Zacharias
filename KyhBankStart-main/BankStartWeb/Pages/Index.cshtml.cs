using BankStartWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BankStartWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //public string NameSort { get; set; }
        //public string DateSort { get; set; }
        //public string CurrentFilter { get; set; }
        //public string CurrentSort { get; set; }

        //public IList<Customer> Customers { get; set; }

        //public async Task OnGetAsync(string sortOrder)
        //{
        //    // using System;
        //    NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    DateSort = sortOrder == "Date" ? "date_desc" : "Date";

        //    IQueryable<Customer> customersIQ = from s in _context.Customers
        //                                     select s;

        //    switch (sortOrder)
        //    {
        //        case "givenname_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Givenname);
        //            break;
        //        case "givenname":
        //            customersIQ = customersIQ.OrderBy(s => s.Givenname);
        //            break;
        //        case "surname_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Surname);
        //            break;
        //        case "surname":
        //            customersIQ = customersIQ.OrderBy(s => s.Surname);
        //            break;
        //        case "streetaddress_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Streetaddress);
        //            break;
        //        case "streetaddress":
        //            customersIQ = customersIQ.OrderBy(s => s.Streetaddress);
        //            break;
        //        case "city_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.City);
        //            break;
        //        case "city":
        //            customersIQ = customersIQ.OrderBy(s => s.City);
        //            break;
        //        case "zipcode_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Zipcode);
        //            break;
        //        case "zipcode":
        //            customersIQ = customersIQ.OrderBy(s => s.Zipcode);
        //            break;
        //        case "country_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Country);
        //            break;
        //        case "country":
        //            customersIQ = customersIQ.OrderBy(s => s.Country);
        //            break;
        //        case "countrycode_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.CountryCode);
        //            break;
        //        case "countrycode":
        //            customersIQ = customersIQ.OrderBy(s => s.CountryCode);
        //            break;
        //        case "nationalid_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.NationalId);
        //            break;
        //        case "nationalid":
        //            customersIQ = customersIQ.OrderBy(s => s.NationalId);
        //            break;
        //        case "telephonecountrycode_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.TelephoneCountryCode);
        //            break;
        //        case "telephonecountrycode":
        //            customersIQ = customersIQ.OrderBy(s => s.TelephoneCountryCode);
        //            break;
        //        case "telephone_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Telephone);
        //            break;
        //        case "telephone":
        //            customersIQ = customersIQ.OrderBy(s => s.Telephone);
        //            break;
        //        case "emailaddress_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.EmailAddress);
        //            break;
        //        case "emailaddress":
        //            customersIQ = customersIQ.OrderBy(s => s.EmailAddress);
        //            break;
        //        case "birthday_desc":
        //            customersIQ = customersIQ.OrderByDescending(s => s.Birthday);
        //            break;
        //        case "birthday":
        //            customersIQ = customersIQ.OrderBy(s => s.Birthday);
        //            break;
        //    }

        //    Customers = await customersIQ.AsNoTracking().ToListAsync();
        //}

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}