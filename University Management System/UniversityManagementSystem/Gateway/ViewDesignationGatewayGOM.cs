using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewDesignationGatewayGOM:Gateway
    {
        public List<DesignationGOM> Show()
        {
            Query = "SELECT * FROM Designation";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<DesignationGOM> designationList = new List<DesignationGOM>();
            while (Reader.Read())
            {
                DesignationGOM designation=new DesignationGOM();

                designation.Id = Convert.ToInt32(Reader["DesignationId"].ToString());
                designation.NAME = Reader["DesignationName"].ToString();

                designationList.Add(designation);
            }
            Connection.Close();
            Reader.Close();
            return designationList;
        }
    }
}