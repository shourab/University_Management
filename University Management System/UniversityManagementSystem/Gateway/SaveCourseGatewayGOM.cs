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
    public class SaveCourseGatewayGOM:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public int Show(CourseGOM aCourseGom)
        {
            Connection = new SqlConnection(connectionString);
            Query = "INSERT INTO Course(CourseCode,CourseName,CourseCredit,CourseDescription,DepartmentId,SemesterId,Status) VALUES(@CourseCode,@CourseName,@CourseCredit,@CourseDescription,@DepartmentId,@SemesterId,'False')";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("CourseCode", SqlDbType.VarChar);
            Command.Parameters["CourseCode"].Value = aCourseGom.CourseCode;

            Command.Parameters.Add("CourseName", SqlDbType.VarChar);
            Command.Parameters["CourseName"].Value = aCourseGom.CourseName;


            Command.Parameters.Add("CourseCredit", SqlDbType.Decimal);
            Command.Parameters["CourseCredit"].Value = aCourseGom.Credit;


            Command.Parameters.Add("CourseDescription", SqlDbType.VarChar);
            Command.Parameters["CourseDescription"].Value = aCourseGom.Description;

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = aCourseGom.DeptId;


            Command.Parameters.Add("SemesterId", SqlDbType.Int);
            Command.Parameters["SemesterId"].Value = aCourseGom.SemesterId;

            //Command.Parameters.Add("Status", SqlDbType.Bit);
            //Command.Parameters["Status"].Value = false;


            Connection.Open();
            int rowAffected = 0;
            try
            {
                rowAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                rowAffected = -999;
            }

            Connection.Close();

            return rowAffected;
        }
    }
}