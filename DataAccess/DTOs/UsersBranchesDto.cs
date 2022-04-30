using DataAccess.CustomValidation;
using DataAccess.Data;
using DataAccess.Models;
using Resources.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DTOs
{
    public class UsersBranchesDto
    {
        public int Id { get; set; }
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public int BranchId { get; set; }
        public virtual BranchDto Branches { get; set; }
        public virtual UsersDto Users { get; set; }
    }
}