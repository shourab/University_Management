using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewSemesterManagerGOM
    {
        ViewSemesterGatewayGOM aGatewayGom=new ViewSemesterGatewayGOM();
        public List<SemesterGOM> Show()
        {
            List<SemesterGOM> semester=aGatewayGom.Show();
            return semester;
        }
    }
}