using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class CostCenterBranchesDto
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public int CostCenterTreeId { get; set; }

        public decimal? DebitBegBalance { get; set; }

        public decimal? CreditBegBalance { get; set; }

        public virtual BranchDto Branch { get; set; }

        public virtual CostCenterTreeDto CostCenterTree { get; set; }
    }
}
