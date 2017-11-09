using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class AssignTeacherGateway : Gateway
    {
        public int SaveCourseAssigntoTeacherInformation(AssignTeacher aAssignTeacher)
        {

            Query = "INSERT INTO CourseAssigntoTeacher VALUES(@departmentId,@teacherId,@courseId,@status,@remainingCredit)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = aAssignTeacher.DepartmentId;


            Command.Parameters.Add("teacherId", SqlDbType.Int);
            Command.Parameters["teacherId"].Value = aAssignTeacher.TeacherId;


            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = aAssignTeacher.CourseId;

            Command.Parameters.Add("status", SqlDbType.Bit);
            Command.Parameters["status"].Value = aAssignTeacher.Status;


            Command.Parameters.Add("remainingCredit", SqlDbType.Decimal);
            Command.Parameters["remainingCredit"].Value = aAssignTeacher.RemainingCredit;

         

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;


        }
         






        public int UpdateCourseStatus(int courseId)
        {
            Query = "UPDATE Course SET Status='true' WHERE Course.CourseId='" + courseId + "' AND Course.Status='False'";

            Command = new SqlCommand(Query,Connection);
            

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;


        }

        public bool IsCourseIdDepartmentIdTeacherIdExists(int courseId,int departmentId,int teacherId)
        {
            Query = "SELECT * FROM CourseAssigntoTeacher WHERE CourseId='" + courseId + "' AND  DepartmentId='" + departmentId + "' AND  teacherId='" + teacherId + "'";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();

            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }

            else
            {
                Reader.Close();
                Connection.Close();
                return false;
            }



        }






        public int UpdateTeacherRemainingCredit(int teacherId,AssignTeacher aAssignTeacher)
        {
            Query = "UPDATE Teacher SET RemainingCredit='"+aAssignTeacher.RemainingCredit+"' WHERE Teacher.TeacherId='" + teacherId + "'";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;


        }






        public bool IsCourseAssignToTeacher(int courseId)
        {
            Query = "SELECT * FROM CourseAssigntoTeacher WHERE CourseAssigntoTeacher.CourseId='" + courseId + "' AND CourseAssigntoTeacher.Status='true'";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();

            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Close();
                Connection.Close();
                return true;
            }

            else
            {
                Reader.Close();
                Connection.Close();
                return false;
            }



        }



    }
}