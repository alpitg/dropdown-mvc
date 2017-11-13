using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCRUD1.Models.Validations
{
    public class EmailCheckAttribute : ValidationAttribute
    {
        private readonly string _email = "";

        public EmailCheckAttribute(string email)
        {
            _email = email;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            StudentContext db = new StudentContext();
            // string email = value.ToString();

            bool newEmail = db.Students.Where(a => a.Email == _email).FirstOrDefault() != null;

           // var emailPresent = db.Students.FindAsync(_email);

            if (newEmail)
            {
                // this.ErrorMessage = "Email already taken !";
                string errorMsg = "Email already taken ";

                return new ValidationResult(errorMsg);
            }
            
           
            return ValidationResult.Success;
        }

    }
}