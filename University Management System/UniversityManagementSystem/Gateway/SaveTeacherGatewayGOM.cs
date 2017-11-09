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
    public class SaveTeacherGatewayGOM:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public int Show(TeacherGom aTeacherGom)
        {
            Connection = new SqlConnection(connectionString);
            Query = "INSERT INTO Teacher(TeacherName,TeacherAddress,TeacherEmail,TeacherContactNo,DesignationId,DepartmentId,CreditTaken,RemainingCredit) VALUES(@TeacherName,@TeacherAddress,@TeacherEmail,@TeacherContactNo,@DesignationId,@DepartmentId,@CreditTaken,@CreditTaken)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("TeacherName", SqlDbType.VarChar);
            Command.Parameters["TeacherName"].Value = aTeacherGom.Name;

            Command.Parameters.Add("TeacherAddress", SqlDbType.VarChar);
            Command.Parameters["TeacherAddress"].Value = aTeacherGom.Address;


            Command.Parameters.Add("TeacherEmail", SqlDbType.VarChar);
            Command.Parameters["TeacherEmail"].Value = aTeacherGom.Email;


            Command.Parameters.Add("TeacherContactNo", SqlDbType.VarChar);
            Command.Parameters["TeacherContactNo"].Value = aTeacherGom.ContactNo;

            Command.Parameters.Add("DesignationId", SqlDbType.Int);
            Command.Parameters["DesignationId"].Value = aTeacherGom.DesignationId;

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = aTeacherGom.DepartmentId;


            Command.Parameters.Add("CreditTaken", SqlDbType.Decimal);
            Command.Parameters["CreditTaken"].Value = aTeacherGom.CreditTaken;


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