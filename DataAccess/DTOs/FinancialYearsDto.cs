using DataAccess.CustomValidation;
using Resources.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DTOs
{
    public class FinancialYearsDto
    {
        public int Id { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        [Index(nameof(Code), IsUnique = true)]
        [Unique(IdName: "Id", TableName: "FinancialYears", ErrorMessageResourceName = "ThisCodeUsedBefore", ErrorMessageResourceType = typeof(Language))]
        public int Code { get; set; }

        [Display(Name = "ArabicName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string ArabicName { get; set; }

        [Display(Name = "EnglishName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string EnglishName { get; set; }

        [Display(Name = "Active", ResourceType = typeof(Language))]
        public bool IsActive { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "FromDate", ResourceType = typeof(Language))]
        public DateTime FromDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "ToDate", ResourceType = typeof(Language))]
        public DateTime ToDate { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }

        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }
    }
}
