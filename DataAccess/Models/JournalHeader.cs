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
    public class JournalHeader
    {
        public int Id { get; set; }

        [Required]
        [Index(nameof(Number), IsUnique = true)]
        public int Number { get; set; }

        [ForeignKey("JournalType")]
        public int JournalTypeId { get; set; }

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

        public virtual JournalTypes JournalType { get; set; }
        
        public virtual Branch Branch { get; set; }

        public virtual Currencies Currency { get; set; }

        public List<JournalDetails> journalDetails { get; set; }
    }
}
