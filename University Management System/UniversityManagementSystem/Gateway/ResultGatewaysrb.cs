using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ResultGatewaysrb:Gateway
    {
        public int SaveResult(Resultsrb aResultsrb)
        {
            Query = "INSERT INTO StudentResult VALUES('"+aResultsrb.StudentId+"','"+aResultsrb.CourseId+"','"+aResultsrb.Grade+"')";
       Command=new SqlCommand(Query,Connection);
            Connection.Open();
            int rowaffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffected;
        }

        public bool isexist(Resultsrb aResultsrb)
        {
            Query = "SELECT* FROM StudentResult WHERE StudentId='" + aResultsrb.StudentId + "' AND CourseId='" + aResultsrb.CourseId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Connection.Close();
                Reader.Close();
                return true;

            }
            else
            {
                Connection.Close();
                Reader.Close();
                return false;
            }
        }
    }
}