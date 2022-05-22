using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class AccountTypesDto
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
