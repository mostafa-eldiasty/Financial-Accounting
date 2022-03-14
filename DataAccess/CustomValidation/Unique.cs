using AutoMapper;
using DataAccess.Data;
using DataAccess.DTOs;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DataAccess.CustomValidation
{
    class Unique : ValidationAttribute
    {
        ApplicationDbContext _context;
        string IdName;
        string TableName;

        public Unique(string IdName, string TableName)
        {
            _context = new ApplicationDbContext();
            this.IdName = IdName;
            this.TableName = TableName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string FieldName = validationContext.MemberName;
            string IdValue = validationContext.ObjectInstance
                            .GetType().GetProperty(IdName).GetValue(validationContext.ObjectInstance).ToString();

            bool IsUnique = _context.Database.SqlQuery<int>(
            string.Format("SELECT COUNT(*) FROM {0} WHERE {1}={2} and {3}<>{4}", TableName, FieldName, value, IdName,IdValue),
            new System.Data.SqlClient.SqlParameter(FieldName, value), new System.Data.SqlClient.SqlParameter(IdName, IdValue)).ToList()[0] == 0;

            if (IsUnique)
                return ValidationResult.Success;
            else
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
