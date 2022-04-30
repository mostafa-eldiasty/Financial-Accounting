﻿using AutoMapper;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessLogic.Repositories
{
    public class Repository<T,TDto> : IRepository<T, TDto> where T : class
    {
        private readonly ApplicationDbContext _Context;

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
            T entity = _Context.Set<T>().SingleOrDefault(exp);
            return Mapper.Map<T, TDto>(entity);
        }

        public IEnumerable<TDto> GetListByExp(Expression<Func<T, bool>> exp)
        {
            return _Context.Set<T>().Where(exp).ToList().Select(Mapper.Map<T, TDto>);
        }

        public void AddOrUpdate(TDto entityDto)
        {
            try
            {
                if (entityDto == null) return;

                //int value = (int)_Context.Entry(entityDto).Property("Id").CurrentValue;
                T entity = Mapper.Map<TDto, T>(entityDto);
                object value = _Context.Entry(entity).Property("Id").CurrentValue;

                //if(value == null)
                //{
                //    value = Guid.NewGuid().ToString();
                //    _Context.Entry(entity).Property("Id").CurrentValue = value;
                //    _Context.Set<T>().Add(entity);
                //    _Context.SaveChanges();
                //}
                //else
                if (value.GetType() == typeof(int) && (int)value == 0)
                {
                    //entityDto.AddedUserId = HttpContext.Current.User.Identity.GetUserId();
                    //entityDto.AddedDate = DateTime.Now;
                    //T entity = Mapper.Map<TDto, T>(entityDto);
                    _Context.Set<T>().Add(entity);
                    _Context.SaveChanges();
                }
                else
                {
                    //entityDto.UpdatedUserId = HttpContext.Current.User.Identity.GetUserId();
                    //entityDto.UpdatedDate = DateTime.Now;

                    T entityInDB = _Context.Set<T>().Find(value);
                    Mapper.Map(entityDto, entityInDB);
                    _Context.SaveChanges();
                }
            }
            catch(AutoMapperMappingException ex){
                new Exception("Something Happend in auto mapper");
            }
        }

        public void Delete(TDto entityDto)
        {
            T entity = Mapper.Map<TDto, T>(entityDto);
            _Context.Set<T>().Remove(entity);
            _Context.SaveChanges();
        }

        public void DeleteSingleByExp(Expression<Func<T, bool>> exp)
        {
            T entity = _Context.Set<T>().Single(exp);
            _Context.Set<T>().Remove(entity);
            _Context.SaveChanges();
        }
    }
}