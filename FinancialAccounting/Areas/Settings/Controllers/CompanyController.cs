using System;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.DTOs;
using DataAccess.Models;
using BusinessLogic.Repositories;
using FinancialAccounting.Controllers;

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
        public ActionResult Index(CompanyDto companyDto, HttpPostedFileBase LogoFile)
        {
            if (LogoFile != null)
            {
                companyDto.Logo = new byte[LogoFile.ContentLength];
                LogoFile.InputStream.Read(companyDto.Logo, 0, LogoFile.ContentLength);
            }

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
            return RedirectToAction("Index");
        }
    }
}