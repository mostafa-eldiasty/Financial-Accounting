using FinancialAccounting.DTOs;
using FinancialAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAccounting.Repositories
{
    interface IRepository
    {
        IEnumerable<CompanyDto> Get();
        CompanyDto GetById(int Id);
        void AddOrUpdate(CompanyDto companyDto);
        void Delete(CompanyDto companyDto);
        void DeleteById(int Id);
        //void Dispose(bool Disposing);
    }
}
