using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinancialAccounting.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "CodeIsRequired")]
        public int Code { get; set; }
        [Required(ErrorMessageResourceName = "ArabicNameIsRequired")]
        public string ArabicName { get; set; }
        [Required(ErrorMessageResourceName = "EnglishNameIsRequired")]
        public string EnglishName { get; set; }
        public bool IsDefault { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
    }
}