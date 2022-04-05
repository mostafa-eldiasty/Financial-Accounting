using DataAccess.Data;
using DataAccess.DTOs;
using DataAccess.Models;
using DataAccess.Repositories;
using FinancialAccounting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class UsersController : BaseController
    {
        Repository<ApplicationUser, UsersDto> repository;

        public UsersController()
        {
            repository = new Repository<ApplicationUser, UsersDto>();
        }

        // GET: Settings/Users
        public ActionResult Index()
        {
            List<UsersDto> usersDto = repository.Get().ToList();
            return View(usersDto);
        }

        public ActionResult Form(string id)
        {
            UsersDto usersDto = new UsersDto();

            if (string.IsNullOrEmpty(id))
            {
                //var users = repository.Get().OrderByDescending(b => b.Code).FirstOrDefault();
                //usersDto.Code = users != null ? branch.Code + 1 : 1;
                return View(usersDto);
            }

            usersDto = repository.GetSingleByExp(x => x.Id == id);
            return View(usersDto);
        }

        [HttpPost]
        public ActionResult Form(UsersDto usersDto)
        {
            if (!ModelState.IsValid)
            {
                return View(usersDto);
            }

            repository.AddOrUpdate(usersDto);

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = usersDto.Id});
        }
    }
}