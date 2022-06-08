using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess.DTOs
{
    public class CompanyDto : BaseModelDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        //[Display(Name = "Code", ResourceType = typeof(Language))]
        //public int Code { get; set; }
        //[Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        //[Display(Name = "ArabicName", ResourceType = typeof(Language))]
        //public string ArabicName { get; set; }
        //[Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        //[Display(Name = "EnglishName", ResourceType = typeof(Language))]
        //public string EnglishName { get; set; }
        [Display(Name = "PhoneNumber1", ResourceType = typeof(Language))]
        [Phone(ErrorMessageResourceName = "InvalidPhoneNum", ErrorMessageResourceType = typeof(Language))]
        public string PhoneNumber1 { get; set; }
        [Display(Name = "PhoneNumber2", ResourceType = typeof(Language))]
        [Phone(ErrorMessageResourceName = "InvalidPhoneNum", ErrorMessageResourceType = typeof(Language))]
        public string PhoneNumber2 { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Language))]
        [EmailAddress(ErrorMessageResourceName ="InvalidEmailAddress",ErrorMessageResourceType =typeof(Language))]
        public string Email { get; set; }
        [Display(Name = "Website", ResourceType = typeof(Language))]
        public string Website { get; set; }
        [Display(Name = "TaxRegistrationNumber", ResourceType = typeof(Language))]
        public string TaxRegistrationNumber { get; set; }
        public byte[] Logo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }
        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }
    }
}