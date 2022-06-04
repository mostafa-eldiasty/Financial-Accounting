using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class JournalDetailsCostCentersDto
    {
        public int Id { get; set; }

        public int CostCenterId { get; set; }

        public int JournalDetailsId { get; set; }

        public decimal Ratio { get; set; }

        public decimal Value { get; set; }

        public string Notes { get; set; }

        public virtual List<CostCenterTreeDto> CostCenters { get; set; }

        public virtual JournalDetailsDto JournalDetail { get; set; }
    }
}
