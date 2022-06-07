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

namespace FinancialAccounting.Areas.Transactions.Controllers
{
    public class JournalController : BaseController
    {
        private readonly Repository<JournalHeader, JournalHeaderDto> repository;
        private readonly Repository<Currencies, CurrenciesDto> currencyRepository;
        private readonly Repository<Branch, BranchDto> branchRepository;
        private readonly Repository<JournalTypes, JournalTypesDto> journalTypesRepository;
        private readonly Repository<JournalDetails, JournalDetailsDto> JournalDetailsRepository;
        private readonly Repository<CostCenterTree, CostCenterTreeDto> costCentersRepository;
        private readonly Repository<AccountTree, AccountTreeDto> accountRepository;
        private readonly Repository<JournalDetailsCostCenters, JournalDetailsCostCentersDto> journalDetailsCostCentersRepository;

        public JournalController()
        {
            repository = new Repository<JournalHeader, JournalHeaderDto>();
            currencyRepository = new Repository<Currencies, CurrenciesDto>();
            branchRepository = new Repository<Branch, BranchDto>();
            journalTypesRepository = new Repository<JournalTypes, JournalTypesDto>();
            JournalDetailsRepository = new Repository<JournalDetails, JournalDetailsDto>();
            costCentersRepository = new Repository<CostCenterTree, CostCenterTreeDto>();
            accountRepository = new Repository<AccountTree, AccountTreeDto>();
            journalDetailsCostCentersRepository = new Repository<JournalDetailsCostCenters, JournalDetailsCostCentersDto>();
        }

        public ActionResult Index()
        {
            List<JournalHeaderDto> journalHeaders = repository.Get().ToList();
            return View(journalHeaders);
        }

        public ActionResult Form(int id = 0, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            JournalHeaderDto journalHeaderDto = new JournalHeaderDto();

            if (id == 0)
            {
                var journalHeader = repository.Get().OrderByDescending(b => b.Number).FirstOrDefault();
                journalHeaderDto.Number = journalHeader != null ? journalHeader.Number + 1 : 1;
                journalHeaderDto.journalDetails = new List<JournalDetailsDto>();
                journalHeaderDto.Date = DateTime.Now;
            }
            else
                journalHeaderDto = repository.GetSingleByExp(x => x.Id == id,includes: x => x.journalDetails);

            journalHeaderDto.JournalTypeLst = journalTypesRepository.Get().ToList();
            journalHeaderDto.CurrenciesLst = currencyRepository.Get().ToList();
            journalHeaderDto.BranchesLst = branchRepository.Get().ToList();
            journalHeaderDto.AccountLst = accountRepository.Get().ToList();
            journalHeaderDto.CostCentersLst = costCentersRepository.Get().ToList();
            //journalHeaderDto.AnalyticalAccountsLst = analaticalAccountsRepository.Get().ToList();
            return View(journalHeaderDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(JournalHeaderDto journalHeaderDto)
        {
            int formType = (int)FormType.Edit;
            if (!ModelState.IsValid)
            {
                ViewBag.FormType = formType;
                journalHeaderDto.JournalTypeLst = journalTypesRepository.Get().ToList();
                journalHeaderDto.CurrenciesLst = currencyRepository.Get().ToList();
                journalHeaderDto.BranchesLst = branchRepository.Get().ToList();
                journalHeaderDto.AccountLst = accountRepository.Get().ToList();
                journalHeaderDto.CostCentersLst = costCentersRepository.Get().ToList();
                return View(journalHeaderDto);
            }

            if (journalHeaderDto.Id == 0)
            {
                journalHeaderDto.AddedDate = DateTime.Now;
                journalHeaderDto.AddedUserId = User.Identity.GetUserId();
            }
            else
            {
                journalHeaderDto.UpdatedDate = DateTime.Now;
                journalHeaderDto.UpdatedUserId = User.Identity.GetUserId();
            }
            repository.AddOrUpdateNew(journalHeaderDto);
            foreach (var journalDetail in journalHeaderDto.journalDetails)
            {
                JournalDetailsRepository.AddOrUpdateNew(journalDetail);
                if (journalDetail.JournalDetailsCostCenters != null)
                {
                    List<int> L = journalDetail.JournalDetailsCostCenters.Select(y => y.Id).ToList();
                    journalDetailsCostCentersRepository.DeleteRange(journalDetailsCostCentersRepository.GetListByExp(x => x.JournalDetailsId == journalDetail.Id && !L.Contains(x.Id)).ToList());
                    journalDetailsCostCentersRepository.AddorUpdateLst(journalDetail.JournalDetailsCostCenters);
                }
            }
            repository.SaveChanges();
            JournalDetailsRepository.SaveChanges();
            journalDetailsCostCentersRepository.SaveChanges();

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = journalHeaderDto.Id, FormType = formType });
        }

        public JsonResult Delete(int id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            repository.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFactor(int CurrencyId)
        {
            decimal Factor = currencyRepository.GetSingleByExp(x => x.Id == CurrencyId, ProxyCreationEnabled: false).Factor;
            return Json(new { Factor = Factor });
        }

        [HttpPost]
        public JsonResult GetJournalDetailsCostCenters(int journalDetailsId)
        {
            var journalDetailsCostCenters = journalDetailsCostCentersRepository.GetListByExp(x => x.JournalDetailsId == journalDetailsId,ProxyCreationEnabled:false,AsNoTracking:true).ToList();
            return Json(new { journalDetailsCostCenters = journalDetailsCostCenters });
        }
    }
}