using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class EnrollCourseManagersrb
    {
        public string EnrollCourse(EnrollCourse aEnrollCourse)
        {
            EnrollCourseGAtewaysrb atewaysrb=new EnrollCourseGAtewaysrb();
            bool isexist = atewaysrb.IsExist(aEnrollCourse);
            if (isexist)
            {
                return "This Course has been Already Taken by this Student";
            }
            else
            {


                int rowAffected = atewaysrb.EnrollCourse(aEnrollCourse);
                if (rowAffected > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save FAiled";
                }
            }
        }
    }
}