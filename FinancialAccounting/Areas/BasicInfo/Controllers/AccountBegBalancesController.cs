using BusinessLogic.Repositories;
using DataAccess.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class AccountBegBalancesController : Controller
    {
        private readonly Repository<AccountBranches, AccountBranchesDto> repository;
        private readonly Repository<Branch, BranchDto> branchRepository;

        public AccountBegBalancesController()
        {
            repository = new Repository<AccountBranches, AccountBranchesDto>();
            branchRepository = new Repository<Branch, BranchDto>();
        }
        // GET: BasicInfo/AccountBegBalances
        public ActionResult Index()
        {
            ViewBag.Branches = branchRepository.Get().ToList();
            List<AccountBranchesDto> accountBranchesDto = repository.Get().ToList();
            return View(accountBranchesDto);
        }

        [HttpPost]
        public ActionResult Index(List<AccountBranchesDto> accountBranchesDtos)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Branches = branchRepository.Get().ToList();
                List<AccountBranchesDto> accountBranchesDto = repository.Get().ToList();
                return View(accountBranchesDto);
            }
            foreach (var accountbranchDto in accountBranchesDtos)
                repository.AddOrUpdate(accountbranchDto);
            repository.SaveChanges();

            TempData["Success"] = "True";
            return RedirectToAction("Index");
        }
    }
}