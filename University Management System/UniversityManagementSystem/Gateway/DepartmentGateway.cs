using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DepartmentGateway:Gateway
    {
        public List<Department> GetAllDepartments()
        {

            List<Department> departments = new List<Department>();

            string Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                Department adepartment = new Department();

                adepartment.DepartmentId = (int)Reader["DepartmentId"];

                adepartment.DepartmentName = Reader["DepartmentName"].ToString();


                departments.Add(adepartment);

            }
            Reader.Close();
            Connection.Close();
            return departments;
        }
    }
}