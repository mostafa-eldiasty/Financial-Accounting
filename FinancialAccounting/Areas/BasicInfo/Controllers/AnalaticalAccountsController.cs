using DataAccess.DTOs;
using FinancialAccounting.Enums;
using DataAccess.Models;
using DataAccess.Repositories;
using FinancialAccounting.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class AnalaticalAccountsController : BaseController
    {
        Repository<AnalaticalAccounts, AnalaticalAccountsDto> repository;

        public AnalaticalAccountsController()
        {
            repository = new Repository<AnalaticalAccounts, AnalaticalAccountsDto>();
        }

        // GET: Settings/AnalaticalAccounts
        public ActionResult Index()
        {
            List<AnalaticalAccountsDto> analaticalAccountsDto = repository.Get().ToList();
            return View(analaticalAccountsDto);
        }

        // GET: Settings/AnalaticalAccounts/Form ( /1 ?FormType= 1 )
        public ActionResult Form(int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            AnalaticalAccountsDto analaticalAccountsDto = new AnalaticalAccountsDto();

            if (id == 0)
            {
                var journalType = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                analaticalAccountsDto.Code = journalType != null ? journalType.Code + 1 : 1;
                return View(analaticalAccountsDto);
            }

            analaticalAccountsDto = repository.GetSingleByExp(x => x.Id == id);
            return View(analaticalAccountsDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(AnalaticalAccountsDto analaticalAccountsDto)
        {
            int formType = (int)FormType.Edit;
            if (analaticalAccountsDto.Id == 0)
            {
                analaticalAccountsDto.AddedDate = DateTime.Now;
                analaticalAccountsDto.AddedUserId = User.Identity.GetUserId();
                formType = (int)FormType.New;
            }
            else
            {
                analaticalAccountsDto.UpdatedDate = DateTime.Now;
                analaticalAccountsDto.UpdatedUserId = User.Identity.GetUserId();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                return View(analaticalAccountsDto);
            }

            repository.AddOrUpdate(analaticalAccountsDto);

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = analaticalAccountsDto.Id, FormType = formType });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}


