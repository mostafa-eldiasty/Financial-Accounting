using FinancialAccounting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class BranchesController : BaseController
    {
        // GET: Settings/Branches
        public ActionResult Index()
        {
            return View();
        }
    }
}