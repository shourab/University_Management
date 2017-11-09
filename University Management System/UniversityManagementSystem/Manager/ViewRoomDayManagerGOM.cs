using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewRoomDayManagerGOM
    {
        public List<ClassRoomGOM> ShowClassroom()
        {
            ViewRoomDayGatewayGOM vrdg=new ViewRoomDayGatewayGOM();
            List<ClassRoomGOM> room = vrdg.ShowClassroom();
            return room;
        }

        public List<ClassRoomGOM> ShowDay()
        {
            ViewRoomDayGatewayGOM vrdg = new ViewRoomDayGatewayGOM();
            List<ClassRoomGOM> day = vrdg.ShowDay();
            return day;
        }
    }
}