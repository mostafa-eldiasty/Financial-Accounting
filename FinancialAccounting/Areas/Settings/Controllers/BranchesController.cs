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

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class BranchesController : BaseController
    {
        Repository<Branch, BranchDto> repository;

        public BranchesController()
        {
            repository = new Repository<Branch, BranchDto>();
        }

        // GET: Settings/Branches
        public ActionResult Index()
        {
            List<BranchDto> branchDto = repository.Get().ToList();
            return View(branchDto);
        }

        // GET: Settings/Branches/Form ( /1 ?FormType= 1 )
        public ActionResult Form(int id = 0,int FormType = 0)
        {
            ViewBag.FormType = FormType;
            BranchDto branchDto = new BranchDto();

            if (id == 0)
            {
                var branch = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                branchDto.Code = branch != null ? branch.Code + 1 : 1;
                return View(branchDto);
            }

            branchDto = repository.GetSingleByExp(x => x.Id == id);
            return View(branchDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(BranchDto branchDto)
        {
            int formType = (int)FormType.Edit;
            if (branchDto.Id == 0)
            {
                branchDto.AddedDate = DateTime.Now;
                branchDto.AddedUserId = User.Identity.GetUserId();
                formType = (int)FormType.New;
            }
            else
            {
                branchDto.UpdatedDate = DateTime.Now;
                branchDto.UpdatedUserId = User.Identity.GetUserId();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                return View(branchDto);
            }
            //else if (!repository.IsUnique(branchDto, "Code"))
            //{
            //    ModelState.AddModelError("Code", "Code Already Exists");
            //    ViewBag.FormType = formType;
            //    return View(branchDto);
            //}

            repository.AddOrUpdate(branchDto);

            TempData["Success"] = "True";
                //return RedirectToAction("Form", new { FormType = (int)FormType.New});
            return RedirectToAction("Form", new { id = branchDto.Id, FormType = formType });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(b => b.Id == id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}


