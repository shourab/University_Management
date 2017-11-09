using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewRoomDayGatewayGOM:Gateway
    {
        public List<ClassRoomGOM> ShowClassroom()
        {
            Query = "SELECT * FROM RoomInformation";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ClassRoomGOM> roomList = new List<ClassRoomGOM>();

            while (Reader.Read())
            {
               ClassRoomGOM room=new ClassRoomGOM();

               room.RoomId = Convert.ToInt32(Reader["RoomId"]);
               room.RoomNo = Reader["RoomNo"].ToString();
               roomList.Add(room);

            }
            Connection.Close();
            Reader.Close();
            return roomList;
        }

        public List<ClassRoomGOM> ShowDay()
        {
            Query = "SELECT * FROM DayInformation";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ClassRoomGOM> dayList = new List<ClassRoomGOM>();

            while (Reader.Read())
            {
                ClassRoomGOM day = new ClassRoomGOM();

                day.DayId = Convert.ToInt32(Reader["DayId"]);
                day.DayName = Reader["DayName"].ToString();
                dayList.Add(day);

            }
            Connection.Close();
            Reader.Close();
            return dayList;
        }
    }
}