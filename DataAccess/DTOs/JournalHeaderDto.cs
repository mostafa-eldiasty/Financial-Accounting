using DataAccess.CustomValidation;
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
    public class JournalHeaderDto
    {
        public int Id { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        [Unique("Id", "JournalHeader", ErrorMessageResourceName = "ThisCodeUsedBefore", ErrorMessageResourceType = typeof(Language))]
        public int Number { get; set; }

        [ForeignKey("JournalType")]
        public int JournalTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }

        public decimal Factor { get; set; }

        public string Notes { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }

        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }

        public virtual JournalTypesDto JournalType { get; set; }

        public virtual BranchDto Branch { get; set; }

        public virtual CurrenciesDto Currency { get; set; }
        
        public List<JournalDetailsDto> journalDetails { get; set; }

        public List<JournalTypesDto> JournalTypeLst { get; set; }

        public List<CurrenciesDto> CurrenciesLst { get; set; }
        
        public List<BranchDto> BranchesLst { get; set; }

        public List<AccountTreeDto> AccountLst { get; set; }

        public List<CostCenterTreeDto> CostCentersLst { get; set; }


    }
}
