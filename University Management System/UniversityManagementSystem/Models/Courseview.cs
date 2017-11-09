using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class Courseview
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }

        public string AssignTo { get; set; }

        public int DepartmentId { get; set; }
    }
}