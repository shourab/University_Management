using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class StudentGom
    {
        public int StudentId { get; set; }
        public string RegNo { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Please Enter an Unique Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please Enter a Contact Number")]
        [DisplayName("Contact No")]
        public String ContactNo { get; set; }
        [DisplayName("Date")]
        [Required(ErrorMessage = "Please Enter a Registration Date")]

       
        public DateTime RegDate { get; set; }

        [Required(ErrorMessage = "Please Enter an Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter a Department")]
        [DisplayName("Dapartment")]
        public int DeptId { get; set; }

        public string DeptCode { get; set; }

        //....................
        public string DeptName { get; set; }

        //...................

        public DateTime PresentDate { get; set; }


    }
}