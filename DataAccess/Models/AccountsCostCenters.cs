using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AccountsCostCenters
    {
        public int Id { get; set; }
        [ForeignKey("AccountTree")]
        public int AccountId { get; set; }
        [ForeignKey("CostCenterTree")]
        public int CostCenterId { get; set; }
        public virtual AccountTree AccountTree { get; set; }
        public virtual CostCenterTree CostCenterTree { get; set; }
    }
}
