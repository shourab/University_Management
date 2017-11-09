using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewDesignationManagerGOM
    {
        public List<DesignationGOM> Show()
        {
            ViewDesignationGatewayGOM aViewDeptGateWayGom = new ViewDesignationGatewayGOM();
            List<DesignationGOM> designation = aViewDeptGateWayGom.Show();
            return designation;
        }
    }
}