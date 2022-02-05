using FinancialAccounting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class CompanyController : BaseController
    {
        // GET: Settings/Comapny
        public ActionResult Index()
        {
            return View();
        }
    }
}