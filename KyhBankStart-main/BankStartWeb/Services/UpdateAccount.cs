using BankStartWeb.Data;

namespace BankStartWeb.Services
{
    public class UpdateAccount : IUpdateAccount
    {
        private readonly ApplicationDbContext _context;

        public UpdateAccount(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public void Update(Account person)
        {
            _context.SaveChanges();
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.First(e => e.Id == id);
        }
    }
}
