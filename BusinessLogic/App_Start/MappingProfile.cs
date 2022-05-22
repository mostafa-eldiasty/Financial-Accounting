using AutoMapper;
using DataAccess.Data;
using DataAccess.DTOs;
using DataAccess.Models;
using System.Collections.Generic;

namespace BusinessLogic.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Company, CompanyDto>();
            Mapper.CreateMap<CompanyDto , Company>();

            Mapper.CreateMap<Branch, BranchDto>();
            Mapper.CreateMap<BranchDto, Branch>();

            Mapper.CreateMap<JournalTypes, JournalTypesDto>();
            Mapper.CreateMap<JournalTypesDto, JournalTypes>();

            Mapper.CreateMap<AnalaticalAccounts, AnalaticalAccountsDto>();
            Mapper.CreateMap<AnalaticalAccountsDto, AnalaticalAccounts>();

            Mapper.CreateMap<Currencies, CurrenciesDto>();
            Mapper.CreateMap<CurrenciesDto, Currencies>();

            Mapper.CreateMap<FinancialYears, FinancialYearsDto>();
            Mapper.CreateMap<FinancialYearsDto, FinancialYears>();

            Mapper.CreateMap<ApplicationUser, UsersDto>();
            Mapper.CreateMap<UsersDto, ApplicationUser>();

            Mapper.CreateMap<UsersBranches, UsersBranchesDto>();
            Mapper.CreateMap<UsersBranchesDto, UsersBranches>();

            Mapper.CreateMap<AccountTree, AccountTreeDto>();
            Mapper.CreateMap<AccountTreeDto, AccountTree>();

            Mapper.CreateMap<AccountTypes, AccountTypesDto>();
            Mapper.CreateMap<AccountTypesDto, AccountTypes>();

            Mapper.CreateMap<Currencies, CurrenciesDto>();
            Mapper.CreateMap<CurrenciesDto, Currencies>();

            Mapper.CreateMap<AccountBranches, AccountBranchesDto>();
            Mapper.CreateMap<AccountBranchesDto, AccountBranches>();

            Mapper.CreateMap<AnalaticalAccounts, AnalaticalAccountsDto>();
            Mapper.CreateMap<AnalaticalAccountsDto, AnalaticalAccounts>();
        }
    }
}