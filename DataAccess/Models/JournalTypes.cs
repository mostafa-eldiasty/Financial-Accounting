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
    public class JournalTypes
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

        public bool IsDefault { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(maximumLength: 128)]
        public string AddedUserId { get; set; }

        [StringLength(maximumLength: 128)]
        public string UpdatedUserId { get; set; }
    }
}
