using MvcCRUD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCRUD1.ViewModels
{
    public class StudentViewModel
    {
        public  Student  Students { get; set; }
        public  State States { get; set; }
        public  City  Cities { get; set; }
        public IEnumerable<Student> StudentList { get; set; }
    }
}