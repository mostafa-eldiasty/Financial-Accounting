using FinancialAccounting.Controllers;
using FinancialAccounting.DTOs;
using FinancialAccounting.Models;
using FinancialAccounting.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class CompanyController : BaseController
    {
        Repository repository;

        public CompanyController()
        {
            repository = new Repository();
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

            repository.AddOrUpdate(companyDto);
            return View(companyDto);
        }
    }
}