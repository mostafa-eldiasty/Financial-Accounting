using DataAccess.DTOs;
using FinancialAccounting.Enums;
using DataAccess.Models;
using BusinessLogic.Repositories;
using FinancialAccounting.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class FinancialYearsController : BaseController
    {
        Repository<FinancialYears, FinancialYearsDto> repository;

        public FinancialYearsController()
        {
            repository = new Repository<FinancialYears, FinancialYearsDto>();
        }

        // GET: BasicInfo/FinancialYears
        public ActionResult Index()
        {
            List<FinancialYearsDto> financialYearsDto = repository.Get().ToList();
            return View(financialYearsDto);
        }

        // GET: BasicInfo/FinancialYears/Form ( /1 ?FormType= 1 )
        public ActionResult Form(int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            FinancialYearsDto financialYearsDto = new FinancialYearsDto();

            if (id == 0)
            {
                var financialYears = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                financialYearsDto.Code = financialYears != null ? financialYears.Code + 1 : 1;
                financialYearsDto.FromDate = DateTime.Parse("01/01/1999");
                financialYearsDto.ToDate = DateTime.Now;
                return View(financialYearsDto);
            }

            financialYearsDto = repository.GetSingleByExp(x => x.Id == id);
            return View(financialYearsDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(FinancialYearsDto financialYearsDto)
        {
            int formType = (int)FormType.Edit;
            if (financialYearsDto.Id == 0)
            {
                financialYearsDto.AddedDate = DateTime.Now;
                financialYearsDto.AddedUserId = User.Identity.GetUserId();
                formType = (int)FormType.New;
            }
            else
            {
                financialYearsDto.UpdatedDate = DateTime.Now;
                financialYearsDto.UpdatedUserId = User.Identity.GetUserId();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                return View(financialYearsDto);
            }

            repository.AddOrUpdate(financialYearsDto);
            repository.SaveChanges();

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = financialYearsDto.Id, FormType = formType });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            repository.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}


