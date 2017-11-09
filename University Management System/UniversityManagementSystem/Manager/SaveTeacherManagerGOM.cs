using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class SaveTeacherManagerGOM
    {
        SaveTeacherGatewayGOM save = new SaveTeacherGatewayGOM();
        public string Save(TeacherGom aTeacherGom)
        {
            string msg="Data Insertion Failed";
            int rowAffected = save.Show(aTeacherGom);
            if (rowAffected > 0)
            {
                msg = "Data Insertation Successed";
            }

            return msg;
        
        }
    }
}