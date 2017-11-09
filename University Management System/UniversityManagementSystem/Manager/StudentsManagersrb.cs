using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class StudentsManagersrb
    {
        public List<StudentGom> GetallStudent()
        {
            StudentGatewaySrb aGatewaySrb=new StudentGatewaySrb();
            return aGatewaySrb.GetallStudent();
        } 
    }
}