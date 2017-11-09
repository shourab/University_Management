using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class StudentGatewaySrb:Gateway
    {
        public List<StudentGom> GetallStudent()
        {
            Query = "SELECT * FROM Student";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

           List<StudentGom> students=new List<StudentGom>();

            while (Reader.Read())
            {
                StudentGom astudent=new StudentGom();

                astudent.StudentId = Convert.ToInt32(Reader["StudentId"]);
                astudent.RegNo = Reader["RegNo"].ToString();
                astudent.Name = Reader["StudentName"].ToString();
                astudent.Email = Reader["StudentEmail"].ToString();
               astudent.DeptId = Convert.ToInt32(Reader["DepartmentId"]);
                //studentInfo.StudentDeptName = Reader["DepartmentName"].ToString();
                //studentInfo.StudentDeptCode = Reader["DepartmentCode"].ToString();
                //studentInfo.CourseCode = Reader["CourseCode"].ToString();
                //studentInfo.CourseName = Reader["CourseName"].ToString();
                //studentInfo.Grade = Reader["Grade"].ToString();

                //student.StudentdeptName = Reader["DepartmentId"];

              students.Add(astudent);

            }
            Connection.Close();
            Reader.Close();
            return students;
        } 
    }
}