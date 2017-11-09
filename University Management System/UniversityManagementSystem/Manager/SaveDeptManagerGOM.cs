using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class SaveDeptManagerGOM
    {
        SaveDeptGatewayGom _aSaveDeptGatewayGom=new SaveDeptGatewayGom();
        public string SaveDept(DepartmentGOM aDepartmentGom)
        {
            string msg = "Insertion Failed";
            int rowAffected = _aSaveDeptGatewayGom.SaveDept(aDepartmentGom);
            if (rowAffected>0)
            {
                msg = "Data Successfully Inserted";
            }
            return msg;
        }
    }
}