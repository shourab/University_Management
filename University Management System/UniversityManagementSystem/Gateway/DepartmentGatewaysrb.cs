using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DepartmentGatewaysrb:Gateway
    {
        public Departmentsrb GetDepartment(int id)
        {
            Departmentsrb aDepartment=new Departmentsrb();
            Query = "SELECT * FROM Department WHERE DepartmentId='" + id + "'";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                aDepartment.Id = Convert.ToInt32(Reader["DepartmentId"]);
                aDepartment.NAME = Reader["DepartmentName"].ToString();
            }
            return aDepartment;
        } 
    }
}