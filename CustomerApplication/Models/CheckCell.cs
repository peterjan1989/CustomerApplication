using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class CheckCellAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid
    (object value, ValidationContext validationContext)
        {
            Regex rx = new Regex(@"\d{4}-\d{6}");

            string cell = (string)value == null ? "" : (string)value;

            if (!rx.IsMatch(cell))
                return new ValidationResult("手機 格試錯誤");

            return ValidationResult.Success;
        }
    }
}