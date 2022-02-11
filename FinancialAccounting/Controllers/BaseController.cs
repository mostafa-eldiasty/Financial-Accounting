using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Controllers
{
    public class BaseController : Controller
    {
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string lang/*,string view*/,string url)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }

            HttpCookie httpCookie = new HttpCookie("Lang");
            httpCookie.Value = lang;
            Response.Cookies.Add(httpCookie);

            ViewBag.CurrentLanguage = lang == "en-US"?"english":"arabic";
            
            return Redirect(url);
        }
    }
}