using DataAccess.Data;
using DataAccess.DTOs;
using DataAccess.Models;
using BusinessLogic.Repositories;
using FinancialAccounting.Controllers;
using FinancialAccounting.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FinancialAccounting.Areas.Settings.Controllers
{
    public class UsersController : BaseController
    {
        //Repository<ApplicationUser, UsersDto> repository;
        ApplicationUserRepository repository;
        Repository<UsersBranches, UsersBranchesDto> usersBranchesRepository;
        Repository<Branch, BranchDto> branchesRepository;
        JavaScriptSerializer js = new JavaScriptSerializer();

        public UsersController()
        {
            repository = new ApplicationUserRepository();
            usersBranchesRepository = new Repository<UsersBranches, UsersBranchesDto>();
            branchesRepository = new Repository<Branch, BranchDto>();
        }

        // GET: Settings/Users
        public ActionResult Index()
        {
            List<UsersDto> usersDto = repository.Get().ToList();
            return View(usersDto);
        }

        public ActionResult Form(string id, int FormType = 0)
        {
            ViewBag.FormType = FormType;
            UsersDto usersDto = new UsersDto();
            var branches = branchesRepository.Get();

            if (string.IsNullOrEmpty(id))
            {
                usersDto.UsersBranches = new List<UsersBranchesDto>();
                foreach (var branch in branches)
                    usersDto.UsersBranches.Add(new UsersBranchesDto() { Id=0, BranchId = branch.Id, Branches = branch });

                return View(usersDto);
            }

            usersDto = repository.GetSingleByExp(x => x.Id == id);
            usersDto.UsersBranches = usersDto.UsersBranches ?? new List<UsersBranchesDto>();
            foreach (var branch in branches)
            {
                var userBranch = usersBranchesRepository.GetSingleByExp(x => x.UserId == usersDto.Id && x.BranchId == branch.Id);
                if(userBranch == null)
                    usersDto.UsersBranches.Add(new UsersBranchesDto() { Id = 0, BranchId = branch.Id, Branches = branch });
            }
            
            return View(usersDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(UsersDto usersDto)
        {
            int formType = (int)FormType.Edit;
            if (!ModelState.IsValid)
            {
                var branches = branchesRepository.Get();
                foreach(var branch in branches)
                {
                    var userBranch = usersDto.UsersBranches.FirstOrDefault(x => x.BranchId == branch.Id);
                    if (userBranch != null)
                        userBranch.Branches = branchesRepository.GetSingleByExp(x => x.Id == userBranch.BranchId);
                    else
                        usersDto.UsersBranches.Add(new UsersBranchesDto() { Id = 0, BranchId = branch.Id, Branches = branch });
                }

                ViewBag.FormType = formType;
                return View(usersDto);
            }
            repository.AddOrUpdateAsync(usersDto);

            TempData["Success"] = "True";
            return RedirectToAction("Form", new { id = usersDto.Id, FormType = formType });
        }

        public JsonResult Delete(string id)
        {
            repository.DeleteSingleByExp(j => j.Id == id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}   