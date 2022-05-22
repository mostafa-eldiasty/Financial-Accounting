using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AccountTypes
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
