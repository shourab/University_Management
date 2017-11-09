using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Gateway;

namespace UniversityManagementSystem.Manager
{
    public class UnassignCourseManager
    {
        UnassignCourseGateway aUnassignCourseGateway=new UnassignCourseGateway();

        public int UpdateCourseStatus(Teacher aTeacher)
        {
            return aUnassignCourseGateway.UpdateCourseStatus(aTeacher) ;
        }

        public int UpdateAllocateClassroom()
        {
            return aUnassignCourseGateway.UpdateAllocateClassroom();
        }


    }
}