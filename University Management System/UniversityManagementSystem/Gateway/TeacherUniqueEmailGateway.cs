using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class TeacherUniqueEmailGateway:Gateway
    {
        public string CheckUnique(string email)
        {
            Query = "SELECT * FROM Teacher WHERE TeacherEmail=@TeacherEmail";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("TeacherEmail", SqlDbType.VarChar);
            Command.Parameters["TeacherEmail"].Value = email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            TeacherGom teacher = new TeacherGom();

            while (Reader.Read())
            {
                teacher.Email = Reader["TeacherEmail"].ToString();
            }
            
            Reader.Close();
            Connection.Close();
            

            return teacher.Email;
            
        }
    }
}