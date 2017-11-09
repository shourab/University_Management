using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DepartmentManagersrb
    {
        public Departmentsrb GetDepartment(int id)
        {
            DepartmentGatewaysrb aGatewaysrb=new DepartmentGatewaysrb();
            return aGatewaysrb.GetDepartment(id);
        }
    }
}