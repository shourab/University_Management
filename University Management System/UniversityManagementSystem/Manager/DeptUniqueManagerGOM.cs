using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Windows.Forms;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DeptUniqueManagerGOM
    {
        DeptUniqueGatewayGOM unique=new DeptUniqueGatewayGOM();
        public string CheckUnique(DepartmentGOM aDepartmentGom)
        {
            string msg = null;

            DepartmentGOM d = unique.CheckUnique(aDepartmentGom);

            if (d.DeptCode != null)
            {
                msg = "Please Insert an Unique Department Code";
            }

            if (d.DeptName != null)
            {
                msg = "Please Insert an Unique Department Name";
            }

            return msg;
        }
    }
}