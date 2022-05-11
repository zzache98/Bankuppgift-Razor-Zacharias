using BankStartWeb.Data;

namespace BankStartWeb.Services
{
    public interface IUpdateAccount
    {
        public List<Account> GetAll();

        void Update(Account account);
        Account GetAccount(int id);
    }
}
