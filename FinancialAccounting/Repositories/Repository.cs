using AutoMapper;
using FinancialAccounting.DTOs;
using FinancialAccounting.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialAccounting.Repositories
{
    public class Repository : IRepository
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

        public IEnumerable<CompanyDto> Get()
        {
            return _Context.Company.ToList().Select(Mapper.Map<Company,CompanyDto>);
        }

        public CompanyDto GetById(int Id)
        {
            Company company = _Context.Company.SingleOrDefault(c => c.Id == Id);
            return Mapper.Map<Company, CompanyDto>(company);
        }

        public void AddOrUpdate(CompanyDto companyDto)
        {
            if(companyDto.Id == 0)
            {
                companyDto.AddedUserId = HttpContext.Current.User.Identity.GetUserId();
                companyDto.AddedDate = DateTime.Now;
                Company company = Mapper.Map<CompanyDto, Company>(companyDto);
                _Context.Company.Add(company);
            }
            else
            {
                companyDto.UpdatedUserId = HttpContext.Current.User.Identity.GetUserId();
                companyDto.UpdatedDate = DateTime.Now;

                Company companyInDB = _Context.Company.SingleOrDefault(c => c.Id == companyDto.Id);
                Mapper.Map(companyDto, companyInDB);
            }
            _Context.SaveChanges();
        }

        public void Delete(CompanyDto companyDto)
        {
            Company company = Mapper.Map<CompanyDto, Company>(companyDto);
            _Context.Company.Remove(company);
        }

        public void DeleteById(int Id)
        {
            Company company = _Context.Company.Single(c => c.Id == Id);
            _Context.Company.Remove(company);
        }
    }
}