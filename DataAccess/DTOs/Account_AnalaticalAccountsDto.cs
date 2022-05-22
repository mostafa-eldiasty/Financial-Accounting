using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    class Account_AnalaticalAccountsDto
    {
        public int Id { get; set; }

        public int AnalaticalAccountId { get; set; }

        public int AccountTreeId { get; set; }

        public virtual AnalaticalAccountsDto AnalaticalAccounts { get; set; }

        public virtual AccountTreeDto AccountTree { get; set; }
    }
}
