using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class AccountsCostCentersDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CostCenterId { get; set; }
        public virtual AccountTreeDto AccountTree { get; set; }
        public virtual CostCenterTreeDto CostCenterTree { get; set; }
    }
}
