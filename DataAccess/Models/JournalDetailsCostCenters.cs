using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class JournalDetailsCostCenters
    {
        public int Id { get; set; }

        [ForeignKey("CostCenters")]
        public int CostCenterId { get; set; }

        [ForeignKey("JournalDetail")]
        public int JournalDetailsId { get; set; }

        public decimal Ratio { get; set; }

        public decimal Value { get; set; }

        public string Notes { get; set; }

        public virtual List<CostCenterTree> CostCenters { get; set; }

        public virtual JournalDetails JournalDetail { get; set; }
    }
}
