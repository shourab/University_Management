using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewStudentGatewayGOM:Gateway
    {
        public List<ViewResultGOM> ShowStudentDetails()
        {
            //Query = "SELECT distinct s.RegNo,s.StudentId FROM Student AS s,Department AS d,StudentResult AS sr,Course AS c WHERE s.DepartmentId=d.DepartmentId AND s.StudentId=sr.StudentId AND c.CourseId=sr.CourseId ORDER BY s.RegNo";

            Query = "SELECT * FROM Student";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ViewResultGOM> StudentListAndResult=new List<ViewResultGOM>();
            
            while (Reader.Read())
            {
                ViewResultGOM studentInfo = new ViewResultGOM();

                studentInfo.StudentId = Convert.ToInt32(Reader["StudentId"]);
                studentInfo.StudentRegNo = Reader["RegNo"].ToString();
                //studentInfo.StudentName = Reader["StudentName"].ToString();
                //studentInfo.StudentEmail = Reader["StudentEmail"].ToString();
                //studentInfo.StudentDeptId = Convert.ToInt32(Reader["DepartmentId"]);
                //studentInfo.StudentDeptName = Reader["DepartmentName"].ToString();
                //studentInfo.StudentDeptCode = Reader["DepartmentCode"].ToString();
                //studentInfo.CourseCode = Reader["CourseCode"].ToString();
                //studentInfo.CourseName = Reader["CourseName"].ToString();
                //studentInfo.Grade = Reader["Grade"].ToString();

                //student.StudentdeptName = Reader["DepartmentId"];

                StudentListAndResult.Add(studentInfo);

            }
            Connection.Close();
            Reader.Close();
            return StudentListAndResult;
            
        }

        public int CountStudentId(string code)
        {
            

            Query = "SELECT COUNT(RegNo) as Registration FROM Student WHERE RegNo LIKE '%"+code+"%'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            StudentGom s = new StudentGom();

            while (Reader.Read())
            {
                s.StudentId = Convert.ToInt32(Reader["Registration"].ToString());
            }
            Connection.Close();
            Reader.Close();
            return s.StudentId;
            
        }

        public List<ViewResultGOM> ShowStudentDetailsById(int studentId)
        {

            Query = "SELECT * FROM StudentResultVw WHERE StudentId='"+studentId+"'";

            //Query = "Select s.StudentId,s.StudentName,s.RegNo,s.StudentEmail,d.DepartmentName,c.CourseCode,c.CourseName,sr.Grade FROM StudentResult AS sr,Student AS s,Course As c,Department AS d WHERE s.StudentId=sr.StudentId AND c.CourseId=sr.CourseId AND c.DepartmentId=d.DepartmentId AND s.StudentId='"+studentId+"'";
            //Query = "SELECT * FROM Student AS s,Department AS d,StudentResult AS sr,Course AS c WHERE s.DepartmentId=d.DepartmentId AND s.StudentId=sr.StudentId AND c.CourseId=sr.CourseId AND s.StudentId='"+studentId+"' ORDER BY s.RegNo";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ViewResultGOM> StudentListAndResult = new List<ViewResultGOM>();

            string msg = "";

            DateTime d = DateTime.Now;

            while (Reader.Read())
            {

                ViewResultGOM studentInfo = new ViewResultGOM();    

                studentInfo.StudentId = Convert.ToInt32(Reader["StudentId"]);
                studentInfo.StudentRegNo = Reader["RegNo"].ToString();
                studentInfo.StudentName = Reader["StudentName"].ToString();
                studentInfo.StudentEmail = Reader["StudentEmail"].ToString();
                //studentInfo.StudentDeptId = Convert.ToInt32(Reader["DepartmentId"]);
                studentInfo.StudentDeptName = Reader["DepartmentName"].ToString();
                //studentInfo.StudentDeptCode = Reader["DepartmentCode"].ToString();
                studentInfo.CourseCode = Reader["CourseCode"].ToString();
                studentInfo.CourseName = Reader["CourseName"].ToString();
                studentInfo.Grade = Reader["Result"].ToString();

                studentInfo.PresentDate = d;

                //student.StudentdeptName = Reader["DepartmentId"];

                msg = studentInfo.Grade;

                StudentListAndResult.Add(studentInfo);

            }
            Connection.Close();
            Reader.Close();

            if (msg == "")
            {
                StudentListAndResult = GetStudentDetailsInThisGateway(studentId);
            }

            
            

            return StudentListAndResult;

        }



        public List<ViewResultGOM> GetStudentDetailsInThisGateway(int studentId)
        {
            Query = "SELECT * FROM Student AS s,Department as d WHERE s.StudentId='" + studentId + "' AND d.DepartmentId=s.DepartmentId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ViewResultGOM> StudentListAndResult = new List<ViewResultGOM>();

            while (Reader.Read())
            {
                ViewResultGOM studentInfo = new ViewResultGOM();

                //studentInfo.StudentId = Convert.ToInt32(Reader["StudentId"]);
                studentInfo.StudentRegNo = Reader["RegNo"].ToString();
                studentInfo.StudentName = Reader["StudentName"].ToString();
                studentInfo.StudentEmail = Reader["StudentEmail"].ToString();
                //studentInfo.StudentDeptId = Convert.ToInt32(Reader["DepartmentId"]);
                studentInfo.StudentDeptName = Reader["DepartmentName"].ToString();
                //studentInfo.StudentDeptCode = Reader["DepartmentCode"].ToString();
                //studentInfo.CourseCode = Reader["CourseCode"].ToString();
                //studentInfo.CourseName = Reader["CourseName"].ToString();
                //studentInfo.Grade = Reader["Grade"].ToString();
                //student.StudentdeptName = Reader["DepartmentId"];

                StudentListAndResult.Add(studentInfo);

            }
            Connection.Close();
            Reader.Close();

            return StudentListAndResult;


        }


        public StudentGom SeachStudentByEmail(string email)
        {
           Query ="SELECT * FROM Student AS s,Department as d WHERE s.StudentEmail='"+email+"' AND s.DepartmentId=d.DepartmentId";


           Command = new SqlCommand(Query, Connection);

           Connection.Open();

           Reader = Command.ExecuteReader();

           StudentGom registeredStudent=new StudentGom();

           while (Reader.Read())
           {
               
               //studentInfo.StudentId = Convert.ToInt32(Reader["StudentId"]);
               
               registeredStudent.RegNo = Reader["RegNo"].ToString();
               registeredStudent.Name = Reader["StudentName"].ToString();
               registeredStudent.Email = Reader["StudentEmail"].ToString();
               
               //studentInfo.StudentDeptId = Convert.ToInt32(Reader["DepartmentId"]);
               
               registeredStudent.DeptName = Reader["DepartmentName"].ToString();
               registeredStudent.DeptCode = Reader["DepartmentCode"].ToString();
               registeredStudent.ContactNo = Reader["StudentContactNo"].ToString();
               registeredStudent.Address = Reader["StudentAddress"].ToString();
               registeredStudent.RegDate = Convert.ToDateTime(Reader["RegDate"]);
               
               //studentInfo.CourseName = Reader["CourseName"].ToString();
               //studentInfo.Grade = Reader["Grade"].ToString();
               //student.StudentdeptName = Reader["DepartmentId"];

               //StudentListAndResult.Add(studentInfo);

           }
           Connection.Close();
           Reader.Close();



           DateTime d=DateTime.Now;
           registeredStudent.PresentDate= d;


           return registeredStudent;

        
        }
    }
}