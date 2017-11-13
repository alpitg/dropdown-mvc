using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MvcCRUD1.Models.Validator
{

    //public class IsEmailExistAttribute : RegularExpressionAttribute
    //{
    //    public IsEmailExistAttribute()
    //        : base(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}")
    //    {
    //        ErrorMessage = "Please provide a valid email address";
    //    }
    //}





    public class IsEmailExistAttribute : ValidationAttribute
    {
        private readonly string _email = "";

        public IsEmailExistAttribute(string email)
        {
            _email = email;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                StudentContext db = new StudentContext();

              //  string email = value.ToString();


                if (Regex.IsMatch(_email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                {

                    //bool newEmail = db.Students.Where(a => a.Email == emailByUser).FirstOrDefault() != null;

                    var asas = db.Students.FindAsync(_email);
                    if (asas != null)
                    {
                        this.ErrorMessage = "Email already taken !";

                        return new ValidationResult("Email already taken !");
                    }


                    return ValidationResult.Success;
                }
                else
                {
                    this.ErrorMessage = "Please provide a valid email address";
                    return new ValidationResult("Please Enter a Valid Email.");
                }
            }
            else
            {
                this.ErrorMessage = "Email is required";

                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }

    }

}