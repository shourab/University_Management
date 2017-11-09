using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Please Enter a Name")]
        [Column(TypeName = "varchar")]
        public string TeacherName { get; set; }
        [Required(ErrorMessage = "Please Enter an Address")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter an Unique Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]
        public  string Email { get; set; }
        [Required(ErrorMessage = "Please Enter a Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Enter a Designation")]
        
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please Enter a Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Enter Credit to be Taken")]
        [DisplayName("Credit To Be Taken")]
        [Range(0.0,20.0,ErrorMessage="Credit to be taken should be between 0.0 to 20.0")]
        public double CreditTaken { get; set; }


        public double RemainingCredit { get; set; }
    }
}