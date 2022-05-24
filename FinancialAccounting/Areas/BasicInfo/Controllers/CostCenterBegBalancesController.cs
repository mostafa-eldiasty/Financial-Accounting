using BusinessLogic.Repositories;
using DataAccess.DTOs;
using DataAccess.Models;
using FinancialAccounting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class CostCenterBegBalancesController : BaseController
    {
        private readonly Repository<CostCenterBranches, CostCenterBranchesDto> repository;
        private readonly Repository<Branch, BranchDto> branchRepository;

        public CostCenterBegBalancesController()
        {
            repository = new Repository<CostCenterBranches, CostCenterBranchesDto>();
            branchRepository = new Repository<Branch, BranchDto>();
        }
        
        public ActionResult Index()
        {
            ViewBag.Branches = branchRepository.Get().ToList();
            List<CostCenterBranchesDto> costCenterBranchesDto = repository.Get().ToList();
            return View(costCenterBranchesDto);
        }

        [HttpPost]
        public ActionResult Index(List<CostCenterBranchesDto> costCenterBranchesDtos)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Branches = branchRepository.Get().ToList();
                //List<CostCenterBranchesDto> costCenterBranchesDto = repository.Get().ToList();
                return View(costCenterBranchesDtos);
            }
            foreach (var costCenterBranchesDto in costCenterBranchesDtos)
                repository.AddOrUpdate(costCenterBranchesDto);
            repository.SaveChanges();

            TempData["Success"] = "True";
            return RedirectToAction("Index");
        }
    }
}