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
            if (!ModelState.IsValid)
            {
                return View(branchDto);
            }

            if (branchDto.Id == 0)
            {
                ViewBag.FormType = FormType.New;
                branchDto.AddedDate = DateTime.Now;
                branchDto.AddedUserId = User.Identity.GetUserId();
            }
            else
            {
                ViewBag.FormType = FormType.Edit;
                branchDto.UpdatedDate = DateTime.Now;
                branchDto.UpdatedUserId = User.Identity.GetUserId();
            }

            repository.AddOrUpdate(branchDto);
            return View(branchDto);
        }
    }
}


