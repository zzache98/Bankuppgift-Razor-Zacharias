using BankStartWeb.Data;
using BankStartWeb.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace BankStartWeb.Pages
{
    public class CustomerModel : PageModel
    {
        
       
        public CustomerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string SortOrder { get; set; }
        public string SortCol { get; set; }
        public int PageNo { get; set; }
        public int TotalPageCount { get; set; }
        //public string NameSort { get; set; }
        //public string DateSort { get; set; }
        //public string CurrentFilter { get; set; }
        //public string CurrentSort { get; set; }

        public string SearchWord { get; set; }

        public List<CustomerViewModel> Customers { get; set; }

        private readonly ApplicationDbContext _context;

        public class CustomerViewModel
        {
            public int Id { get; set; }
            public string Givenname { get; set; }
            public string Surname { get; set; }
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


        }

        
        public void OnGet(string searchWord, string col = "Id", string order = "asc", int pageno=1)
        {
            PageNo = pageno;
            SearchWord = searchWord;
            SortCol = col;
            SortOrder = order;

            //NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            //CurrentFilter = searchString;

            IQueryable<Customer> customerIQ = from s in _context.Customers
                                              select s;

            var o = _context.Customers.AsQueryable();

            if (!String.IsNullOrEmpty(SearchWord))
            {
                o = o.Where(ord => ord.Surname.Contains(SearchWord)
                                             || ord.Givenname.Contains(SearchWord));
            }

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        customerIQ = customerIQ.OrderByDescending(s => s.Surname);
            //        break;
            //    default: 
            //        customerIQ = customerIQ.OrderBy(s => s.Givenname);
            //        break;

            //}

            

            

            o = o.OrderBy(col,
                order == "asc" ? ExtentionMethods.QuerySortOrder.Asc :
                    ExtentionMethods.QuerySortOrder.Desc);

            //Customer = await customerIQ.AsNoTracking().ToListAsync();

            var pageResult = o.GetPaged(PageNo, 50);
            TotalPageCount = pageResult.PageCount;

            Customers = pageResult.Results.Select(o => new CustomerViewModel
            {
                Id = o.Id,
                Givenname = o.Givenname,
                Surname = o.Surname,
                Streetaddress = o.Streetaddress,
                City = o.City,
                Zipcode = o.Zipcode,
                Country = o.Country,
                CountryCode = o.CountryCode,
                NationalId = o.NationalId,
                TelephoneCountryCode = o.TelephoneCountryCode,
                Telephone = o.Telephone,
                EmailAddress = o.EmailAddress,
                Birthday = o.Birthday
            }).ToList();

        }
  

    }
}

