using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class EnrollCourseGAtewaysrb:Gateway
    {
        public int EnrollCourse(EnrollCourse aEnrollCourse)
        {
          DateTime date= DateTime.ParseExact(aEnrollCourse.EnrollDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Query="INSERT INTO EnrollCourse VALUES('"+aEnrollCourse.StudentId+"','"+aEnrollCourse.CourseId+"','"+date+"','"+true+"')";
             Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowaffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffected;
        }

        public bool IsExist(EnrollCourse aEnrollCourse)
        {
            Query = "SELECT* FROM EnrollCourse WHERE StudentId='" + aEnrollCourse.StudentId + "' AND CourseId='" + aEnrollCourse.CourseId + "' AND Status='True'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            else
            {
                Connection.Close();
                return false;
            }
           
        }
    }
}