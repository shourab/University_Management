using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class AssignTeacher
    {
        public int Id { get; set; }
  
        public int DepartmentId { get; set; }
     
        public int TeacherId { get; set; }
       
        public string TeacherName { get; set; }

    
        
        public double RemainingCredit { get; set; }

      
        public int CourseId { get; set; }
   
        public string CourseName { get; set; }
          
        public double CourseCredit { get; set; }

        public bool Status { get; set; }

    


        public AssignTeacher()
        {
            Status = true;
        }
    }
    }
