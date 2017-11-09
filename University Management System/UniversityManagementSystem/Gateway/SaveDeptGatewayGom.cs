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
    public class SaveDeptGatewayGom:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public int SaveDept(DepartmentGOM aDepartmentGom)
        {
            Connection = new SqlConnection(connectionString);
            Query = "INSERT INTO Department(DepartmentCode,DepartmentName) VALUES(@DeptCode,@DeptName)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("DeptCode", SqlDbType.VarChar);
            Command.Parameters["DeptCode"].Value = aDepartmentGom.DeptCode;


            Command.Parameters.Add("DeptName", SqlDbType.VarChar);
            Command.Parameters["DeptName"].Value = aDepartmentGom.DeptName;


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