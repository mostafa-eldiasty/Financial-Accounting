using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AccountBranches
    {
        public int Id { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }

        [ForeignKey("AccountTree")]
        public int AccountTreeId { get; set; }

        public decimal DebitBegBalance { get; set; }

        public decimal CreditBegBalance { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual AccountTree AccountTree { get; set; }
    }
}
