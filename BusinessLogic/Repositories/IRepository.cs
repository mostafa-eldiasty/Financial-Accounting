using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic.Repositories
{
    interface IRepository<T, TDto>
    {
        IEnumerable<TDto> Get(bool ProxyCreationEnabled);
        TDto GetSingleByExp(Expression<Func<T, bool>> exp, bool ProxyCreationEnabled , params Expression<Func<T, object>>[] includes);
        IEnumerable<TDto> GetListByExp(Expression<Func<T, bool>> exp, bool ProxyCreationEnabled, bool AsNoTracking);

        void AddOrUpdate(TDto companyDto);
        void AddorUpdateLst(List<TDto> entityLstDto);
        void Delete(TDto companyDto);
        void DeleteSingleByExp(Expression<Func<T, bool>> exp);
        //void Dispose(bool Disposing);
        void DeleteRange(List<TDto> entityDtoLst);
    }
}
