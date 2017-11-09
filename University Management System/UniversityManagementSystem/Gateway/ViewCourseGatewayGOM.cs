using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewCourseGatewayGOM:Gateway
    {
        public List<CourseGOM> GetCourseByDeptId(int deptId)
        {
            Query = "SELECT * FROM Course WHERE DepartmentId='"+deptId+"'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<CourseGOM> courseList = new List<CourseGOM>();
            while (Reader.Read())
            {
                CourseGOM course = new CourseGOM();

                course.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();

                courseList.Add(course);
            }
            Connection.Close();
            Reader.Close();
            return courseList;
        }
    }
}