using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class AllocateClassRoomManagerGOM
    {
        public string InsertAllocation(ClassRoomGOM classRoomGom)
        {


            CheckEmplyClassroomGateway check=new CheckEmplyClassroomGateway();
            bool isEmpty = check.IsClassroomEmpty(classRoomGom);



            AllocateClassRoomGatewayGOM classRoom=new AllocateClassRoomGatewayGOM();
            int rowAffected=-77;
            string msg = "";

            if (isEmpty == true)
            {
                rowAffected = classRoom.InsertAllocation(classRoomGom);
            }

            else
            {
                msg = "Classroom is Already Allocated";
            }
            


            if (rowAffected > 0)
            {
                msg = "Classroom Is Successfully Allocated";
            }

            else
            {
                msg = "Classroom Is Already Allocated";
            }

            return msg;

        }

        public List<AllocatedClassroomGOM> ViewAllocatedRoomByDeptId(int deptId)
        {
            AllocateClassRoomGatewayGOM gateway=new AllocateClassRoomGatewayGOM();
            List<AllocatedClassroomGOM> Allocated = gateway.ViewAllocatedRoomByDeptId(deptId);
            return Allocated;

        }
    }
}