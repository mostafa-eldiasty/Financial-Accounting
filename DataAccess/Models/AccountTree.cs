using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AccountTree
    {
        public int Id { get; set; }
        
        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        [Index(nameof(Code), IsUnique = true)]
        public int Code { get; set; }
        
        [Display(Name = "ArabicName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string ArabicName { get; set; }
        
        [Display(Name = "EnglishName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string EnglishName { get; set; }
        
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        
        public int? Level { get; set; }
        
        [Required]
        public bool IsGeneralAccount { get; set; }

        [ForeignKey("AccountType")]
        public int AccountTypeId { get; set; }

        [Required]
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        
        [Required]
        public bool IsDebit { get; set; }
        
        public string Notes { get; set; }
        
        public DateTime AddedDate { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }
        
        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }
        
        public virtual AccountTree Parent { get; set; }
        
        public virtual AccountTypes AccountType { get; set; }
        
        public virtual Currencies Currency { get; set; }

        public virtual List<AccountBranches> AccountBranches { get; set; }
        public virtual List<Account_AnalaticalAccounts> Account_AnalaticalAccounts { get; set; }
    }
}
