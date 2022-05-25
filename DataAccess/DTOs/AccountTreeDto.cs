using DataAccess.CustomValidation;
using DataAccess.Models;
using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class AccountTreeDto
    {
        public int Id { get; set; }
        
        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        [Unique("Id", "AccountTree", ErrorMessageResourceName = "ThisCodeUsedBefore", ErrorMessageResourceType = typeof(Language))]
        public int Code { get; set; }
        
        [Display(Name = "ArabicName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string ArabicName { get; set; }
        
        [Display(Name = "EnglishName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string EnglishName { get; set; }
        
        public int? ParentId { get; set; }
        
        public int? Level { get; set; }

        [Display(Name = "GeneralAccount", ResourceType = typeof(Language))]
        public bool IsGeneralAccount { get; set; }

        //[Required]
        [ForeignKey("AccountTypes")]
        [Display(Name = "AccountType", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "SelectFromLst", ErrorMessageResourceType = typeof(Language))]
        public int AccountTypeId { get; set; }

        //[Required]
        [ForeignKey("Currencies")]
        [Display(Name = "Currency", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "SelectFromLst", ErrorMessageResourceType = typeof(Language))]
        public int CurrencyId { get; set; }

        [Required]
        public bool IsDebit { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Language))]
        public string Notes { get; set; }

        public DateTime AddedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }
        
        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }

        public List<CurrenciesDto> currenciesLst { get; set; }
        
        public List<BranchDto> BranchesLst { get; set; }
        public List<AnalaticalAccountsDto> AnalyticalAccountsLst { get; set; }
        public List<CostCenterTreeDto> CostCentersLst { get; set; }


        public List<AccountTypesDto> accountTypesLst { get; set; }
        
        public virtual AccountTreeDto Parent { get; set; }

        public virtual AccountTypesDto AccountType { get; set; }

        public virtual CurrenciesDto Currency { get; set; }
        public virtual List<AccountBranchesDto> AccountBranches { get; set; }
        public virtual List<Account_AnalaticalAccounts> Account_AnalaticalAccounts { get; set; }
        public virtual List<AccountsCostCenters> AccountsCostCenters { get; set; }
    }
}
