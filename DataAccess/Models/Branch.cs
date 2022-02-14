using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        public int Code { get; set; }
        [Display(Name = "ArabicName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string ArabicName { get; set; }
        [Display(Name = "EnglishName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public string EnglishName { get; set; }

        public bool IsDefault { get; set; }
        [Display(Name = "PhoneNumber1", ResourceType = typeof(Language))]
        [Phone(ErrorMessageResourceName = "InvalidPhoneNum", ErrorMessageResourceType = typeof(Language))]
        public string PhoneNumber1 { get; set; }
        [Display(Name = "PhoneNumber2", ResourceType = typeof(Language))]
        [Phone(ErrorMessageResourceName = "InvalidPhoneNum", ErrorMessageResourceType =typeof(Language))]
        public string PhoneNumber2 { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Language))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmailAddress", ErrorMessageResourceType = typeof(Language))]
        public string Email { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }
        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }
    }
}