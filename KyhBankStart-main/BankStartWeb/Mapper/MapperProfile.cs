using AutoMapper;
using BankStartWeb.Data;

namespace BankStartWeb.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, Pages.CustomerInfo.CustomerDetailsModel.CustomerDetailsViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => $"{x.Givenname} {x.Surname}"))
                .ForMember(b => b.Balance, opt => opt.MapFrom(b => b.Accounts.Sum(b => b.Balance))).ReverseMap();
            CreateMap<Account, Pages.CustomerInfo.CustomerDetailsModel.AccountDetailsViewModel>().ReverseMap();



            CreateMap<Account, Pages.Account.CustomerTransactionDetailsModel.AccountDetailViewModel>()
                .ReverseMap();
            CreateMap<Transaction, Pages.Account.CustomerTransactionDetailsModel.TransactionViewModel>()
                .ReverseMap();


        }


    }
}
