using FinancialAccounting.Controllers;
using FinancialAccounting.DTOs;
using FinancialAccounting.Models;
using FinancialAccounting.Repositories;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class CompanyController : BaseController
    {
        Repository<Company,CompanyDto> repository;

        public CompanyController()
        {
            repository = new Repository<Company,CompanyDto>();
        }

        // GET: Settings/Comapny
        public ActionResult Index()
        {
            CompanyDto companyDto = repository.Get().SingleOrDefault();

            if(companyDto != null)
                return View(companyDto);

            return View(new CompanyDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
            {
                return View(companyDto);
            }

            if (companyDto.Id == 0)
            {
                companyDto.AddedDate = DateTime.Now;
                companyDto.AddedUserId = User.Identity.GetUserId();
            }
            companyDto.UpdatedDate = DateTime.Now;
            companyDto.UpdatedUserId = User.Identity.GetUserId();

            repository.AddOrUpdate(companyDto);
            return View(companyDto);
        }
    }
}