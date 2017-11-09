using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseGateway:Gateway
    {
        public List<Course> GetAllCourseName()
        {
            List<Course> courses = new List<Course>();

            string Query = "SELECT * FROM Course";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                Course aCourse = new Course();

                aCourse.CourseId= (int)Reader["CourseId"];

                aCourse.CourseCode = Reader["CourseCode"].ToString();

                aCourse.CourseName = Reader["CourseName"].ToString();

                aCourse.CourseCredit = Convert.ToDouble(Reader["CourseCredit"]);

                aCourse.DepartmentId = (int)Reader["DepartmentId"];

                aCourse.CourseDescription = Reader["CourseDescription"].ToString();

                aCourse.SemesterId = (int) Reader["SemesterId"];

                courses.Add(aCourse);

            }
            Reader.Close();
            Connection.Close();
            return courses;

        }
    }
}