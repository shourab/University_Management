using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewStudentManagerGOM
    {
        
        public List<ViewResultGOM> ShowStudentDetails()
        {
            ViewStudentGatewayGOM student=new ViewStudentGatewayGOM();
            List<ViewResultGOM> result = student.ShowStudentDetails();
            return result;

        }

        public int CountStudentId(string code)
        {
            ViewStudentGatewayGOM student=new ViewStudentGatewayGOM();
            int Count = student.CountStudentId(code);
            return Count;
        }

        public List<ViewResultGOM> ShowStudentDetailsById(int studentId)
        {
            ViewStudentGatewayGOM student = new ViewStudentGatewayGOM();
            List<ViewResultGOM> result = student.ShowStudentDetailsById(studentId);
            return result;
        }
    }
}