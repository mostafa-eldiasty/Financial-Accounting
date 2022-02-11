using AutoMapper;
using FinancialAccounting.DTOs;
using FinancialAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAccounting.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Company, CompanyDto>();
            Mapper.CreateMap<CompanyDto , Company>();
        }
    }
}