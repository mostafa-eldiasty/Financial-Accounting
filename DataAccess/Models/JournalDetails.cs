using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class JournalDetails
    {
        public int Id { get; set; }

        [ForeignKey("JournalHeader")]
        public int JournalHeaderId { get; set; }

        [ForeignKey("Account")]
        public int? AccountId { get; set; }

        //[ForeignKey("CostCenter")]
        //public int? CostCenterId { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }
        
        public string Notes { get; set; }

        public virtual JournalHeader JournalHeader { get; set; }

        public virtual AccountTree Account { get; set; }

        //public virtual CostCenterTree CostCenter { get; set; }
        public virtual List<JournalDetailsCostCenters> JournalDetailsCostCenters { get; set; }
    }
}
