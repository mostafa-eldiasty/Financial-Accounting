using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UsersBranches
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branches { get; set; }
        public virtual ApplicationUser Users { get; set; }
    }
}
