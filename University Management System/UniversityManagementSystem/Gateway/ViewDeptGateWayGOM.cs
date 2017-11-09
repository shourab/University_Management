using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewDeptGateWayGOM:Gateway
    {
        public List<DepartmentGOM> Show()
        {
            Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<DepartmentGOM> departments=new List<DepartmentGOM>();
            while (Reader.Read())
            { 
                DepartmentGOM aDepartmentGom=new DepartmentGOM();

                aDepartmentGom.DeptId = Convert.ToInt32(Reader["DepartmentId"].ToString());
                aDepartmentGom.DeptCode = Reader["DepartmentCode"].ToString();
                aDepartmentGom.DeptName = Reader["DepartmentName"].ToString();

                departments.Add(aDepartmentGom);
            }
            Connection.Close();
            Reader.Close();
            return departments;
        }

        public string ShowDeptCode(string deptId)
        {
            int Id = Convert.ToInt32(deptId);

            Query = "SELECT * FROM Department WHERE DepartmentId='" + Id + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            DepartmentGOM aDepartmentGom = new DepartmentGOM();
            while (Reader.Read())
            {
                aDepartmentGom.DeptCode = Reader["DepartmentCode"].ToString();
            }
            Connection.Close();
            Reader.Close();

            return aDepartmentGom.DeptCode;
        }
    }
}