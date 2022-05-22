using AutoMapper;
using DataAccess.Data;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace BusinessLogic.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly ApplicationDbContext _Context;
        private ApplicationUserManager _userManager;

        public ApplicationUserRepository()
        {
            _Context = new ApplicationDbContext();
            _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public IEnumerable<UsersDto> Get()
        {
            return _Context.Set<ApplicationUser>().ToList().Select(Mapper.Map<ApplicationUser, UsersDto>);
        }

        public UsersDto GetSingleByExp(Expression<Func<ApplicationUser, bool>> exp)
        {
            ApplicationUser entity = _Context.Set<ApplicationUser>().SingleOrDefault(exp);
            return Mapper.Map<ApplicationUser, UsersDto>(entity);
        }

        public IEnumerable<UsersDto> GetListByExp(Expression<Func<ApplicationUser, bool>> exp)
        {
            return _Context.Set<ApplicationUser>().Where(exp).ToList().Select(Mapper.Map<ApplicationUser, UsersDto>);
        }

        public void AddOrUpdateAsync(UsersDto usersDto)
        {
            try
            {
                if (usersDto == null) return;

                ApplicationUser user = Mapper.Map<UsersDto, ApplicationUser>(usersDto);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(usersDto.Password);
                user.SecurityStamp = Guid.NewGuid().ToString("D");

                if (string.IsNullOrEmpty(user.Id))
                {
                    user.Id = Guid.NewGuid().ToString();

                    foreach (var userBranch in user.UsersBranches)
                        userBranch.UserId = user.Id;

                    _Context.Users.Add(user);
                    _Context.SaveChanges();
                }
                else
                {
                    _Context.Configuration.ProxyCreationEnabled = false;
                    _Context.Configuration.LazyLoadingEnabled = false;
                    
                    foreach(var item in user.UsersBranches)
                    {
                        if(item.Id == 0)
                            _Context.Entry(item).State = EntityState.Added;
                        else if(item.Id != 0)
                            _Context.Entry(item).State = EntityState.Modified;
                    }
                    var L = user.UsersBranches.Select(y => y.Id);
                    List<UsersBranches> userBranches = _Context.UsersBranches.Where(x => x.UserId == user.Id && !L.Contains(x.Id)).ToList();
                    userBranches.ForEach(x=>_Context.UsersBranches.Remove(x));

                    _Context.Entry(user).State = EntityState.Modified;
                    _Context.SaveChanges();
                }
            }
            catch (AutoMapperMappingException ex)
            {
                new Exception("Something Happend in auto mapper");
            }
        }

        public void Delete(UsersDto entityDto)
        {
            ApplicationUser entity = Mapper.Map<UsersDto, ApplicationUser>(entityDto);
            _Context.Set<ApplicationUser>().Remove(entity);
            _Context.SaveChanges();
        }

        public void DeleteSingleByExp(Expression<Func<ApplicationUser, bool>> exp)
        {
            ApplicationUser entity = _Context.Set<ApplicationUser>().Single(exp);
            _Context.Set<ApplicationUser>().Remove(entity);
            _Context.SaveChanges();
        }
    }
}
