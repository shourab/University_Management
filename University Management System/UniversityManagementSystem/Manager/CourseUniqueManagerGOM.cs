using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseUniqueManagerGOM
    {
        CourseUniqueGatewayGOM unique = new CourseUniqueGatewayGOM();
        public string CheckUnique(CourseGOM aCourseGom)
        {
            string msg = null;

            CourseGOM d = unique.CheckUnique(aCourseGom);

            if (d.CourseCode != null)
            {
                msg = "Please Insert an Unique Department Code";
            }

            if (d.CourseName != null)
            {
                msg = "Please Insert an Unique Department Name";
            }

            return msg;
        }
    }
}