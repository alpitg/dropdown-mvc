using MvcCRUD1.Models.Validations;
using MvcCRUD1.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCRUD1.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Firsty Name is required")]
        [MaxLength(20, ErrorMessage = "Should be less than 20 character")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(20, ErrorMessage = "Should be less than 20 character")]
        public string LastName { get; set; }


        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address")]
        //(ErrorMessage = "Email is required")

        //[IsEmailExist(ErrorMessage ="Is required !")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Remote("JsonEmailValid", "Students", ErrorMessage = "Already in use")]
        public string Email { get; set; }


        [Display(Name = "Contact")]
        [Required(ErrorMessage = "Contact is required")]
        public string Contact { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }


        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }


        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }


        [Display(Name = "Pin Code")]
        [Required(ErrorMessage = "PinCode is required")]
        //[Range(1, 6, ErrorMessage = "Enter Valid Pin Code")]
        public int PinCode { get; set; }



        [Display(Name = "Profile Image")]
        //[Required(ErrorMessage = "Firsty Name is required")]
        public string ProfileImage { get; set; }
    }

}