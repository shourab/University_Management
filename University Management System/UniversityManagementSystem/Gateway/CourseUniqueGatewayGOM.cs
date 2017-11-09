using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseUniqueGatewayGOM:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public CourseGOM CheckUnique(CourseGOM aCourseGom)
        {
            Query = "SELECT * FROM Course WHERE CourseCode=@CourseCode OR CourseName=@CourseName";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseCode"].Value = aCourseGom.CourseCode;

            Command.Parameters.Add("CourseName", SqlDbType.VarChar);
            Command.Parameters["CourseName"].Value = aCourseGom.CourseName;

            Connection.Open();

            Reader = Command.ExecuteReader();

            CourseGOM course=new CourseGOM();

            while (Reader.Read())
            {
                course.CourseCode = Reader["CourseCode"].ToString();
                course.CourseName = Reader["CourseName"].ToString();
            }
            Connection.Close();
            Reader.Close();

            if (aCourseGom.CourseCode != course.CourseCode)
            {
                course.CourseCode = null;
            }
            if (aCourseGom.CourseName != course.CourseName)
            {
                course.CourseName = null;
            }

            return course;

        }
    }
}