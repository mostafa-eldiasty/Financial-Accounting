using DataAccess.CustomValidation;
using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DTOs
{
    public class JournalTypesDto : BaseModelDto
    {
        public int Id { get; set; }

        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        [Index(nameof(Code), IsUnique = true)]
        [Unique(IdName: "Id", TableName: "JournalTypes", ErrorMessageResourceName = "ThisCodeUsedBefore", ErrorMessageResourceType = typeof(Language))]
        public override int Code { get; set; }

        //[Display(Name = "ArabicName", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        //public string ArabicName { get; set; }

        //[Display(Name = "EnglishName", ResourceType = typeof(Language))]
        //[Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        //public string EnglishName { get; set; }

        [Display(Name = "IsDefault", ResourceType = typeof(Language))]
        public bool IsDefault { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }

        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }
    }
}
