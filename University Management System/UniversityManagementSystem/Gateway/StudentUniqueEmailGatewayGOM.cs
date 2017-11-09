using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class StudentUniqueEmailGatewayGOM:Gateway
    {
        public string CheckUniqueEmail(string email)
        {
            Query = "SELECT * FROM Student WHERE StudentEmail=@StudentEmail";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("StudentEmail", SqlDbType.VarChar);
            Command.Parameters["StudentEmail"].Value = email;

            Connection.Open();

            StudentGom student = new StudentGom();
            try
            {
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    student.Email = Reader["StudentEmail"].ToString();
                }
                Reader.Close();
            }

            catch
            {
                student.Email = null;
            }
            

           
            Connection.Close();

            return student.Email;
        }
    }
}