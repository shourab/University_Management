using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class SaveStudentManagerGOM
    {
        public StudentGom Save(StudentGom student)
        {
            
            //DateTime d=DateTime.Now;
            //string date = d.Year.ToString();

            string date = student.RegDate.Year.ToString();
           
            ViewDeptGateWayGOM dept=new ViewDeptGateWayGOM();

            ViewStudentManagerGOM viewStudent=new ViewStudentManagerGOM();
            
            string code = dept.ShowDeptCode(student.DeptId.ToString())+"-"+date;

            int count = viewStudent.CountStudentId(code);

            string id = "";
            count = count + 1;
            if (count > 0 && count < 10)
            {
                id = "00" + count.ToString();
            }

            if (count > 9 && count < 100)
            {
                id = "0" + count.ToString();
            }
            
            



            student.RegNo = code + "-"+id;

            string msg = "Data Insertion Failed";

            StudentUniqueEmailGatewayGOM email=new StudentUniqueEmailGatewayGOM();
            string ourEmail = email.CheckUniqueEmail(student.Email);

            StudentGom registeredStudent=new StudentGom();


            if (ourEmail != null)
            {
                registeredStudent.RegNo = "Please Enter Unique Email";
                return registeredStudent;
            }

            else
            {
                SaveStudentGatewayGOM saveStudent=new SaveStudentGatewayGOM();
                int rowAffected = saveStudent.Save(student);

                if (rowAffected > 0)
                {
                    ViewStudentGatewayGOM searchByEmail=new ViewStudentGatewayGOM();
                   //msg = "Data Successfull Inserted";
                    registeredStudent = searchByEmail.SeachStudentByEmail(student.Email);
                }
            }
            
            return registeredStudent;
        }
    }
}