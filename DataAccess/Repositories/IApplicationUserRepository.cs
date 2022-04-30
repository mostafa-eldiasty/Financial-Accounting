using DataAccess.Data;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    interface IApplicationUserRepository
    {
        IEnumerable<UsersDto> Get();
        UsersDto GetSingleByExp(Expression<Func<ApplicationUser, bool>> exp);
        void AddOrUpdate(UsersDto companyDto);
        void Delete(UsersDto companyDto);
        void DeleteSingleByExp(Expression<Func<ApplicationUser, bool>> exp);
    }
}
