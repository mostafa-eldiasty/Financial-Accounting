using DataAccess.CustomValidation;
using DataAccess.Models;
using Resources.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DTOs
{
    public class UsersDto
    {
        public string Id { get; set; }

        [Display(Name = "Email",ResourceType =typeof(Language))]
        ////[EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserName",ResourceType =typeof(Language))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Language))]
        public string Password { get; set; }

        [Required]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Language))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber1", ResourceType = typeof(Language))]
        public string PhoneNumber { get; set; }
        public virtual List<UsersBranchesDto> UsersBranches { get; set; }

    }
}