using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class SaveCourseManagerGOM
    {
        SaveCourseGatewayGOM save=new SaveCourseGatewayGOM();
        public string Save(CourseGOM aCourseGom)
        {
            string msg="Data Insertion Failed";
            int rowAffected = save.Show(aCourseGom);
            if (rowAffected > 0)
            {
                msg = "Data Insertation Successed";
            }

            return msg;
        }
    }
}