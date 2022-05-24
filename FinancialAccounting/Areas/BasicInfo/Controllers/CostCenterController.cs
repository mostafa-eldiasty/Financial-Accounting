using BusinessLogic.Repositories;
using DataAccess.DTOs;
using DataAccess.Models;
using FinancialAccounting.Controllers;
using FinancialAccounting.Enums;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class CostCenterController : BaseController
    {
        private readonly Repository<CostCenterTree, CostCenterTreeDto> repository;
        private readonly Repository<Branch, BranchDto> branchRepository;

        public CostCenterController()
        {
            repository = new Repository<CostCenterTree, CostCenterTreeDto>();
            branchRepository = new Repository<Branch, BranchDto>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(int? ParentId, int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            CostCenterTreeDto costCenterTreeDto = new CostCenterTreeDto();

            if (id == 0)
            {
                var costCenterTree = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                costCenterTreeDto.Code = costCenterTree != null ? costCenterTree.Code + 1 : 1;
            }
            else
                costCenterTreeDto = repository.GetSingleByExp(x => x.Id == id);

            costCenterTreeDto.ParentId = ParentId;
            costCenterTreeDto.BranchesLst = branchRepository.Get().ToList();
            return View(costCenterTreeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(CostCenterTreeDto costCenterTreeDto)
        {
            int formType = (int)FormType.Edit;
            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                costCenterTreeDto.BranchesLst = branchRepository.Get().ToList();
                return View(costCenterTreeDto);
            }

            if (costCenterTreeDto.Id == 0)
            {
                costCenterTreeDto.AddedDate = DateTime.Now;
                costCenterTreeDto.AddedUserId = User.Identity.GetUserId();
            }
            else
            {
                costCenterTreeDto.UpdatedDate = DateTime.Now;
                costCenterTreeDto.UpdatedUserId = User.Identity.GetUserId();
            }
            repository.AddOrUpdate(costCenterTreeDto);
            repository.SaveChanges();

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = costCenterTreeDto.Id, FormType = formType, ParentId = costCenterTreeDto.ParentId });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            repository.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCostCenterTree()
        {
            List<CostCenterTreeDto> costCenterTree = repository.Get(ProxyCreationEnabled: false).ToList();
            return Json(new { costCenterTree = costCenterTree });
        }
    }
}