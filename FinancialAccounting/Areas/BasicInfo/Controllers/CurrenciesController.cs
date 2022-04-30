using DataAccess.DTOs;
using FinancialAccounting.Enums;
using DataAccess.Models;
//using BusinessLogic.Repositories;
using FinancialAccounting.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Repositories;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class CurrenciesController : BaseController
    {
        Repository<Currencies, CurrenciesDto> repository;

        public CurrenciesController()
        {
            repository = new Repository<Currencies, CurrenciesDto>();
        }

        // GET: BasicInfo/Currencies
        public ActionResult Index()
        {
            List<CurrenciesDto> currenciesDto = repository.Get().ToList();
            return View(currenciesDto);
        }

        // GET: BasicInfo/Currencies/Form ( /1 ?FormType= 1 )
        public ActionResult Form(int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            CurrenciesDto currenciesDto = new CurrenciesDto();

            if (id == 0)
            {
                var currencies = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                currenciesDto.Code = currencies != null ? currencies.Code + 1 : 1;
                return View(currenciesDto);
            }

            currenciesDto = repository.GetSingleByExp(x => x.Id == id);
            return View(currenciesDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(CurrenciesDto currenciesDto)
        {
            int formType = (int)FormType.Edit;
            if (currenciesDto.Id == 0)
            {
                currenciesDto.AddedDate = DateTime.Now;
                currenciesDto.AddedUserId = User.Identity.GetUserId();
                formType = (int)FormType.New;
            }
            else
            {
                currenciesDto.UpdatedDate = DateTime.Now;
                currenciesDto.UpdatedUserId = User.Identity.GetUserId();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                return View(currenciesDto);
            }

            repository.AddOrUpdate(currenciesDto);

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = currenciesDto.Id, FormType = formType });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}


