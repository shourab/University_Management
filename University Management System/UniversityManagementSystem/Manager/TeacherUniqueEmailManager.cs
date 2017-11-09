using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class TeacherUniqueEmailManager
    {
        private TeacherUniqueEmailGateway unique = new TeacherUniqueEmailGateway();
        public string CheckUnique(string email)
        {
            string msg = null;

            string d = unique.CheckUnique(email);

            if (d != null)
            {
                msg = "Please Insert an Unique Email Address";
            }

            

            return msg;
        }
    }
}