using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseviewGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public List<Courseview> GetAllInfo()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //string query = "SELECT* FROM Item";
            string query = "SELECT* FROM CourseStatusvw";
            SqlCommand command = new SqlCommand(query, connection);
            command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Courseview> courseviews = new List<Courseview>();

            while (reader.Read())
            {
                Courseview courseview = new Courseview();
                courseview.Code = reader["CourseCode"].ToString();
                courseview.Name = reader["CourseName"].ToString();
                courseview.Semester = reader["SemesterName"].ToString();
                courseview.AssignTo = reader["TeacherAssign"].ToString();
                courseview.DepartmentId = (int)reader["DepartmentId"];
                
                
                courseviews.Add(courseview);

            }
            reader.Close();
            connection.Close();
            return courseviews;


        }

        public List<Department> GetDepartments()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //string query = "SELECT* FROM Item";
            string query = "SELECT* FROM Department";
            SqlCommand command = new SqlCommand(query, connection);
            command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Department> departments = new List<Department>();

            while (reader.Read())
            {
               Department department=new Department();
                department.DepartmentId = (int) reader["DepartmentId"];
                department.DepartmentName = reader["DepartmentName"].ToString();

                departments.Add(department);

            }
            reader.Close();
            connection.Close();
            return departments;


        }


    }
}