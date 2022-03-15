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
    public class JournalTypesController : BaseController
    {
        Repository<JournalTypes, JournalTypesDto> repository;

        public JournalTypesController()
        {
            repository = new Repository<JournalTypes, JournalTypesDto>();
        }

        // GET: Settings/JournalTypes
        public ActionResult Index()
        {
            List<JournalTypesDto> journalTypesDto = repository.Get().ToList();
            return View(journalTypesDto);
        }

        // GET: Settings/JournalTypes/Form ( /1 ?FormType= 1 )
        public ActionResult Form(int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            JournalTypesDto journalTypesDto = new JournalTypesDto();

            if (id == 0)
            {
                var journalType = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                journalTypesDto.Code = journalType != null ? journalType.Code + 1 : 1;
                return View(journalTypesDto);
            }

            journalTypesDto = repository.GetSingleByExp(x => x.Id == id);
            return View(journalTypesDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(JournalTypesDto journalTypesDto)
        {
            int formType = (int)FormType.Edit;
            if (journalTypesDto.Id == 0)
            {
                journalTypesDto.AddedDate = DateTime.Now;
                journalTypesDto.AddedUserId = User.Identity.GetUserId();
                formType = (int)FormType.New;
            }
            else
            {
                journalTypesDto.UpdatedDate = DateTime.Now;
                journalTypesDto.UpdatedUserId = User.Identity.GetUserId();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                return View(journalTypesDto);
            }

            repository.AddOrUpdate(journalTypesDto);

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = journalTypesDto.Id, FormType = formType });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}


