using AutoMapper;
using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

        public IEnumerable<TDto> Get(bool ProxyCreationEnabled = true)
        {
            _Context.Configuration.ProxyCreationEnabled = ProxyCreationEnabled;
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

                T entity = Mapper.Map<TDto, T>(entityDto);
                object value = _Context.Entry(entity).Property("Id").CurrentValue;

                if (value.GetType() == typeof(int) && (int)value == 0)
                {
                    _Context.Set<T>().Add(entity);
                }
                else
                {
                    T entityInDB = _Context.Set<T>().Find(value);
                    var properties = entity.GetType().GetProperties().Where(x => typeof(IEnumerable).IsAssignableFrom(x.PropertyType) && x.PropertyType != typeof(string)).ToList();

                    foreach (var property in properties)
                    {
                        var propertyEntity = ((IEnumerable)_Context.Entry(entity).Collection(property.Name).CurrentValue).Cast<object>().ToList();
                        var propertylst = ((IEnumerable)_Context.Entry(entityInDB).Collection(property.Name).CurrentValue).Cast<object>().ToList();

                        Dictionary<int, object> dict = new Dictionary<int, object>();
                        foreach (var item in propertylst)
                        {
                            int id = (int)item.GetType().GetProperty("Id").GetValue(item);
                            dict.Add(id, item);
                        }

                        foreach (var item in propertyEntity)
                        {
                            int itemId = (int)_Context.Entry(item).Property("Id").CurrentValue;

                            if (dict.ContainsKey(itemId))
                            {
                                _Context.Entry(dict[itemId]).State = EntityState.Detached;
                                dict.Remove(itemId);
                            }

                            if (itemId == 0)
                                _Context.Entry(item).State = EntityState.Added;
                            else if (itemId != 0)
                                _Context.Entry(item).State = EntityState.Modified;
                        }

                        foreach(var item in dict.Values)
                            _Context.Entry(item).State = EntityState.Deleted;
                    }

                    _Context.Entry(entityInDB).State = EntityState.Detached;
                    _Context.Entry(entity).State = EntityState.Modified;
                }
            }
            catch (AutoMapperMappingException ex)
            {
                new Exception("Something Happend in auto mapper");
            }
        }

        public void Delete(TDto entityDto)
        {
            T entity = Mapper.Map<TDto, T>(entityDto);
            _Context.Set<T>().Remove(entity);
        }

        public void DeleteSingleByExp(Expression<Func<T, bool>> exp)
        {
            T entity = _Context.Set<T>().Single(exp);
            _Context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }
    }
}