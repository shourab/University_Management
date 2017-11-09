using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ViewResultGOM
    {
        [Required(ErrorMessage = "Please Select a Registration Number")]
        [DisplayName("Student Reg.No")]
        public int StudentId { get; set; }
        public string StudentRegNo { get; set; }

        [DisplayName("Email")]
        public string StudentEmail { get; set; }

        public int StudentDeptId { get; set; }

        [DisplayName("Name")]
        public string StudentName { get; set; }

        [DisplayName("Department")]
        public string StudentDeptName { get; set; }

        public string StudentDeptCode { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }
        public string Grade { get; set; }

        public DateTime PresentDate { get;set; }

    }
}