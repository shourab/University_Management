using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewCourseManagerGOM
    {
        public List<CourseGOM> GetCourseByDeptId(int deptId)
        {
            ViewCourseGatewayGOM vcg=new ViewCourseGatewayGOM();
            List<CourseGOM> Courses = vcg.GetCourseByDeptId(deptId);

            return Courses;

        }
    }
}