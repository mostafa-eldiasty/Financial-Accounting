using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Models
{
    public class CostCenterBranches
    {
        public int Id { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [ForeignKey("CostCenterTree")]
        public int CostCenterTreeId { get; set; }

        public decimal DebitBegBalance { get; set; }

        public decimal CreditBegBalance { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual CostCenterTree CostCenterTree { get; set; }
    }
}
