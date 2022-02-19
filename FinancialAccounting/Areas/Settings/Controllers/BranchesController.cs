using DataAccess.DTOs;
using DataAccess.Models;
using DataAccess.Repositories;
using FinancialAccounting.Controllers;
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
    }
}