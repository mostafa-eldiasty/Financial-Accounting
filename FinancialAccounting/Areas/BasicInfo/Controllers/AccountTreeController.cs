using BusinessLogic.Repositories;
using DataAccess.DTOs;
using DataAccess.Models;
using FinancialAccounting.Controllers;
using FinancialAccounting.Enums;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.BasicInfo.Controllers
{
    public class AccountTreeController : BaseController
    {
        private readonly Repository<AccountTree, AccountTreeDto> repository;
        private readonly Repository<Currencies, CurrenciesDto> currencyRepository;
        private readonly Repository<AccountTypes, AccountTypesDto> accountTypeRepository;
        private readonly Repository<Branch, BranchDto> branchRepository;
        private readonly Repository<AnalaticalAccounts, AnalaticalAccountsDto> analaticalAccountsRepository;
        private readonly Repository<CostCenterTree, CostCenterTreeDto> costCentersRepository;

        public AccountTreeController()
        {
            repository = new Repository<AccountTree, AccountTreeDto>();
            currencyRepository = new Repository<Currencies, CurrenciesDto>();
            accountTypeRepository = new Repository<AccountTypes, AccountTypesDto>();
            branchRepository = new Repository<Branch, BranchDto>();
            analaticalAccountsRepository = new Repository<AnalaticalAccounts, AnalaticalAccountsDto>();
            costCentersRepository = new Repository<CostCenterTree, CostCenterTreeDto>();
        }

        // GET: BasicInfo/AccountTree
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(int? ParentId, int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            AccountTreeDto accountTreeDto = new AccountTreeDto();

            if (id == 0)
            {
                var accountTree = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                accountTreeDto.Code = accountTree != null ? accountTree.Code + 1 : 1;
            }
            else
                accountTreeDto = repository.GetSingleByExp(x => x.Id == id);

            accountTreeDto.ParentId = ParentId;
            accountTreeDto.currenciesLst = currencyRepository.Get().ToList();
            accountTreeDto.accountTypesLst = accountTypeRepository.Get().ToList();
            accountTreeDto.BranchesLst = branchRepository.Get().ToList();
            accountTreeDto.AnalyticalAccountsLst = analaticalAccountsRepository.Get().ToList();
            accountTreeDto.CostCentersLst = costCentersRepository.Get().ToList();
            return View(accountTreeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(AccountTreeDto accountTreeDto)
        {
            int formType = (int)FormType.Edit;
            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                accountTreeDto.currenciesLst = currencyRepository.Get().ToList();
                accountTreeDto.accountTypesLst = accountTypeRepository.Get().ToList();
                accountTreeDto.BranchesLst = branchRepository.Get().ToList();
                accountTreeDto.AnalyticalAccountsLst = analaticalAccountsRepository.Get().ToList();
                accountTreeDto.CostCentersLst = costCentersRepository.Get().ToList();
                return View(accountTreeDto);
            }

            if (accountTreeDto.Id == 0)
            {
                accountTreeDto.AddedDate = DateTime.Now;
                accountTreeDto.AddedUserId = User.Identity.GetUserId();
            }
            else
            {
                accountTreeDto.UpdatedDate = DateTime.Now;
                accountTreeDto.UpdatedUserId = User.Identity.GetUserId();
            }
            repository.AddOrUpdate(accountTreeDto);
            repository.SaveChanges();

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = accountTreeDto.Id, FormType = formType, ParentId = accountTreeDto.ParentId });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            repository.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAccountTree()
        {
            List<AccountTreeDto> accountTrees = repository.Get(ProxyCreationEnabled: false).ToList();
            foreach (var accountTree in accountTrees)
            {
                accountTree.Currency = currencyRepository.GetSingleByExp(x => x.Id == accountTree.CurrencyId);
                accountTree.AccountType = accountTypeRepository.GetSingleByExp(x => x.Id == accountTree.AccountTypeId);
            }
            return Json(new { accountTrees = accountTrees });
        }
    }
}