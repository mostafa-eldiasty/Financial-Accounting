using AutoMapper;
using FinancialAccounting.DTOs;
using FinancialAccounting.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FinancialAccounting.Repositories
{
    public class Repository<T,TDto> : IRepository<T, TDto> where T : class
    {
        private ApplicationDbContext _Context;

        public Repository()
        {
            _Context = new ApplicationDbContext();
        }

        //protected void Dispose(bool disposing)
        //{
        //    _Context.Dispose();
        //}

        public IEnumerable<TDto> Get()
        {
            return _Context.Set<T>().ToList().Select(Mapper.Map<T, TDto>);
        }

        public TDto GetSingleByExp(Expression<Func<T, bool>> exp)
        {
            T company = _Context.Set<T>().SingleOrDefault(exp);
            return Mapper.Map<T, TDto>(company);
        }

        public void AddOrUpdate(TDto companyDto)
        {
            try
            {
                //int value = (int)_Context.Entry(companyDto).Property("Id").CurrentValue;
                T company = Mapper.Map<TDto, T>(companyDto);
                object value = _Context.Entry(company).Property("Id").CurrentValue;

                if ((int)value == 0)
                {
                    //companyDto.AddedUserId = HttpContext.Current.User.Identity.GetUserId();
                    //companyDto.AddedDate = DateTime.Now;
                    //T company = Mapper.Map<TDto, T>(companyDto);
                    _Context.Set<T>().Add(company);
                    _Context.SaveChanges();
                }
                else
                {
                    //companyDto.UpdatedUserId = HttpContext.Current.User.Identity.GetUserId();
                    //companyDto.UpdatedDate = DateTime.Now;

                    T companyInDB = _Context.Set<T>().Find(value);
                    Mapper.Map(companyDto, companyInDB);
                    _Context.SaveChanges();
                }
            }
            catch{ }
        }

        public void Delete(TDto companyDto)
        {
            T company = Mapper.Map<TDto, T>(companyDto);
            _Context.Set<T>().Remove(company);
        }

        public void DeleteSingleByExp(Expression<Func<T, bool>> exp)
        {
            T company = _Context.Set<T>().Single(exp);
            _Context.Set<T>().Remove(company);
        }
    }
}