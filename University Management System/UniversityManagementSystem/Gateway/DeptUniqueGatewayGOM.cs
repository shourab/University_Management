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
    public class DeptUniqueGatewayGOM:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public DepartmentGOM CheckUnique(DepartmentGOM aDepartmentGom)
        {
            Query = "SELECT * FROM Department WHERE DepartmentCode=@DeptCode OR DepartmentName=@DeptName";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("DeptCode", SqlDbType.VarChar);
            Command.Parameters["DeptCode"].Value = aDepartmentGom.DeptCode;


            Command.Parameters.Add("DeptName", SqlDbType.VarChar);
            Command.Parameters["DeptName"].Value = aDepartmentGom.DeptName;

            Connection.Open();

            Reader = Command.ExecuteReader();

            DepartmentGOM departments = new DepartmentGOM();

            while (Reader.Read())
            {
                departments.DeptCode = Reader["DepartmentCode"].ToString();
                departments.DeptName = Reader["DepartmentName"].ToString();
            }
            Connection.Close();
            Reader.Close();

            if (aDepartmentGom.DeptCode != departments.DeptCode)
            {
                departments.DeptCode = null;
            }
            if (aDepartmentGom.DeptName != departments.DeptName)
            {
                departments.DeptName = null;
            }

            return departments;
        }
    }
}