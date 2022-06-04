using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class JournalDetailsDto
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

        public virtual JournalHeaderDto JournalHeader { get; set; }

        public virtual AccountTreeDto Account { get; set; }

        //public virtual CostCenterTreeDto CostCenter { get; set; }

        public virtual List<JournalDetailsCostCentersDto> JournalDetailsCostCenters { get; set; }
    }
}
