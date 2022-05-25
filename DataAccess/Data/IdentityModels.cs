using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual List<UsersBranches> UsersBranches { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<JournalTypes> JournalTypes { get; set; }
        public DbSet<AnalaticalAccounts> AnalaticalAccounts { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<FinancialYears> FinancialYears { get; set; }
        public DbSet<UsersBranches> UsersBranches { get; set; }
        public DbSet<AccountTree> AccountTree { get; set; }
        public DbSet<AccountTypes> AccountTypes { get; set; }
        public DbSet<AccountBranches> AccountBranches { get; set; }
        public DbSet<CostCenterTree> CostCenterTree { get; set; }
        public DbSet<CostCenterBranches> CostCenterBranches { get; set; }
        public DbSet<AccountsCostCenters> AccountsCostCenters { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}