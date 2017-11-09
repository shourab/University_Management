using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class UnassignCourseGateway:Gateway
    {
        public int UpdateCourseStatus(Teacher aTeacher)
        {
           


            Query = "UPDATE Course SET Status='false' WHERE Status='true'";

             
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();


            //-----------------

            Query = "UPDATE CourseAssigntoTeacher SET Status='False' WHERE Status='True'";


            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            //-----------------------------

            Query = "UPDATE EnrollCourse SET Status='False' WHERE Status='True'";


            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            
          



           


            //------------
           // Query = "UPDATE Teacher SET RemainingCredit='" + aTeacher.CreditTaken + "' WHERE RemainingCredit='" + aTeacher.RemainingCredit + "'";

            Query = "UPDATE Teacher SET RemainingCredit=CreditTaken WHERE RemainingCredit=RemainingCredit";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            rowAffected = Command.ExecuteNonQuery();
            Connection.Close();


            return rowAffected;


            

        }


        public int UpdateAllocateClassroom()
        {
            Query = "UPDATE AllocateClassroom SET Status='false' WHERE Status='true'";


            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            
            return rowAffected;


        }



    }
}