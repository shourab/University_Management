using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Gateway;

namespace UniversityManagementSystem.Manager
{
    public class CourseviewManager
    {
        CourseviewGateway courserGateway=new CourseviewGateway();
        public List<Department> GetDepartments()
        {
            return courserGateway.GetDepartments();
        }

        public List<Courseview> GetAllInfo()
        {
            return courserGateway.GetAllInfo();
        }
    }
}