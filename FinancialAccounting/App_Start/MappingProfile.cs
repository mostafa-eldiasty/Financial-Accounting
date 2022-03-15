using AutoMapper;
using DataAccess.DTOs;
using DataAccess.Models;

namespace FinancialAccounting.App_Start
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
        }
    }
}