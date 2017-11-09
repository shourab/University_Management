using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Resultsrb
    {
        
        public int StudentId { get; set; }
        
        public int CourseId { get; set; }
        
        public string Grade { get; set; }
    }
}