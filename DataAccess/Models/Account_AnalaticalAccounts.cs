using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Account_AnalaticalAccounts
    {
        public int Id { get; set; }

        [ForeignKey("AnalaticalAccounts")]
        public int AnalaticalAccountId { get; set; }

        [ForeignKey("AccountTree")]
        public int AccountTreeId { get; set; }

        public virtual AnalaticalAccounts AnalaticalAccounts { get; set; }

        public virtual AccountTree AccountTree { get; set; }
    }
}
