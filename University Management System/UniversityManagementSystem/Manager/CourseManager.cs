using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Gateway;

namespace UniversityManagementSystem.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();
        public List<Course> GetAllCourse()
        {
            return aCourseGateway.GetAllCourseName();
        }

        public List<Course> Getcoursebydepartment(int deprId)
        {
            courseGatewaysrb aCourseGatewaysrb = new courseGatewaysrb();
            return aCourseGatewaysrb.GetCoursesbydept(deprId);
        } 
    }
}