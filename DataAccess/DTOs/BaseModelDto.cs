using DataAccess.CustomValidation;
using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public abstract class BaseModelDto
    {
        [Display(Name = "Code", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "CodeIsRequired", ErrorMessageResourceType = typeof(Language))]
        //[Unique("Id", "AccountTree", ErrorMessageResourceName = "ThisCodeUsedBefore", ErrorMessageResourceType = typeof(Language))]
        public virtual int Code { get; set; }

        [Display(Name = "ArabicName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "ArabicNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual string ArabicName { get; set; }

        [Display(Name = "EnglishName", ResourceType = typeof(Language))]
        [Required(ErrorMessageResourceName = "EnglishNameIsRequired", ErrorMessageResourceType = typeof(Language))]
        public virtual string EnglishName { get; set; }

        public string CodeName
        {
            get
            {
                string Name = Thread.CurrentThread.CurrentCulture.Name == "en-US" ? EnglishName : ArabicName;
                return Code + " - " + Name;
            }
        }

        public string Name
        {
            get
            {
                string Name = Thread.CurrentThread.CurrentCulture.Name == "en-US" ? EnglishName : ArabicName;
                return Name;
            }
        }
    }
}
