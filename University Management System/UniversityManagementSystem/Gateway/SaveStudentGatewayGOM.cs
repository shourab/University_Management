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
    public class SaveStudentGatewayGOM:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public int Save(StudentGom student)
        {
            Connection = new SqlConnection(connectionString);
            Query = "INSERT INTO Student(RegNo,StudentName,StudentEmail,StudentContactNo,RegDate,StudentAddress,DepartmentId) VALUES(@RegNo,@StudentName,@StudentEmail,@StudentContactNo,@RegDate,@StudentAddress,@DepartmentId)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("RegNo", SqlDbType.VarChar);
            Command.Parameters["RegNo"].Value = student.RegNo;

            Command.Parameters.Add("StudentName", SqlDbType.VarChar);
            Command.Parameters["StudentName"].Value = student.Name;


            Command.Parameters.Add("StudentEmail", SqlDbType.VarChar);
            Command.Parameters["StudentEmail"].Value = student.Email;


            Command.Parameters.Add("StudentContactNo", SqlDbType.VarChar);
            Command.Parameters["StudentContactNo"].Value = student.ContactNo;

            Command.Parameters.Add("RegDate", SqlDbType.Date);
            Command.Parameters["RegDate"].Value = student.RegDate;

            Command.Parameters.Add("StudentAddress", SqlDbType.VarChar);
            Command.Parameters["StudentAddress"].Value = student.Address;

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = student.DeptId;


            


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