using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewDeptManagerGOM
    {
        public List<DepartmentGOM> Show()
        {
            ViewDeptGateWayGOM aViewDeptGateWayGom=new ViewDeptGateWayGOM();
            List<DepartmentGOM> departments = aViewDeptGateWayGom.Show();
            return departments;
        }
    }
}