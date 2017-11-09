using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using UniversityApp.Models;
using UniversityManagementApp.Models;

namespace UniversityManagementSystem.Gateway
{
    public class courseGatewaysrb:Gateway
    {
        public List<Course> GetCoursesbydept(int DeptId)
        {
            List<Course> courses=new List<Course>();
            Query = "SELECT* From Course WHERE DepartmentId='" + DeptId + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse=new Course();
                aCourse.CourseId = (int)Reader["CourseId"];

                aCourse.CourseCode = Reader["CourseCode"].ToString();

                aCourse.CourseName = Reader["CourseName"].ToString();

                aCourse.CourseCredit = Convert.ToDouble(Reader["CourseCredit"]);

                aCourse.DepartmentId = (int)Reader["DepartmentId"];

                aCourse.CourseDescription = Reader["CourseDescription"].ToString();

                aCourse.SemesterId = (int)Reader["SemesterId"];
                courses.Add(aCourse);
            }
            Connection.Close();
            Reader.Close();
            return courses;
        } 
    }
}