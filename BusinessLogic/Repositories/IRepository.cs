using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.Repositories
{
    interface IRepository<T, TDto>
    {
        IEnumerable<TDto> Get();
        TDto GetSingleByExp(Expression<Func<T, bool>> exp);
        void AddOrUpdate(TDto companyDto);
        void Delete(TDto companyDto);
        void DeleteSingleByExp(Expression<Func<T, bool>> exp);
        //void Dispose(bool Disposing);
    }
}
