using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewSemesterGatewayGOM:Gateway
    {
        public List<SemesterGOM> Show()
        {
            Query = "SELECT * FROM Semester";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<SemesterGOM> semester = new List<SemesterGOM>();
            while (Reader.Read())
            {
                SemesterGOM aSemester = new SemesterGOM();

                aSemester.SemesterId = Convert.ToInt32(Reader["SemesterId"]);
                aSemester.SemesterName = Reader["SemesterName"].ToString();

                semester.Add(aSemester);
            }
            Connection.Close();
            Reader.Close();
            return semester;
        }
    }
}