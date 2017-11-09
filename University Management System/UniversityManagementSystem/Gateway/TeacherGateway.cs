using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class TeacherGateway:Gateway
    {

         public List<Teacher> GetAllTeacherName()
        {
            List<Teacher>teachers=new List<Teacher>();

            string Query = "SELECT * FROM Teacher";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                Teacher ateacher = new Teacher();

                ateacher.TeacherId = (int)Reader["TeacherId"];

                ateacher.TeacherName = Reader["TeacherName"].ToString();

                ateacher.CreditTaken = Convert.ToDouble(Reader["CreditTaken"]);

                ateacher.DepartmentId = (int) Reader["DepartmentId"];

                ateacher.RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"]);

                teachers.Add(ateacher);

            }
            Reader.Close();
            Connection.Close();
            return teachers;

        }

    }
    }
