using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Serialization.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CheckEmplyClassroomGateway:Gateway
    {
        public bool IsClassroomEmpty(ClassRoomGOM classRoomGom)
        {

            int startTime = ConvertTime(classRoomGom.ScheduledFrom);
            int endTime = ConvertTime(classRoomGom.ScheduledTo);

            if (startTime == endTime)
            {
                return false;
            }

            bool isEmpty = false;

            bool travelInLoop = false;

            Query = "SELECT * FROM AllocateClassroom WHERE RoomId='"+classRoomGom.RoomId+"' AND DayId='"+classRoomGom.DayId+"' AND Status='True'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ClassRoomGOM> cls=new List<ClassRoomGOM>();

            while (Reader.Read())
            {
                ClassRoomGOM room = new ClassRoomGOM();

                isEmpty = false;
  
                room.ScheduledFrom = Reader["ScheduleFrom"].ToString();
                room.ScheduledTo = Reader["ScheduleTo"].ToString();

                int dataStartTime = ConvertTime(room.ScheduledFrom);
                int dataEndTime = ConvertTime(room.ScheduledTo);


                if ((startTime<dataStartTime && startTime<=dataEndTime))
                {
                    if (endTime<=dataStartTime && endTime<dataEndTime)
                    {
                       isEmpty = true;    
                    }
                    
                }

                else if (startTime > dataStartTime && startTime >= dataEndTime)
                {
                    if (endTime >= dataStartTime && endTime > dataEndTime)
                    {
                        isEmpty = true;
                    }
                }

                travelInLoop =true;

                if (isEmpty == false)
                {
                    return false;
                }

                cls.Add(room);
            }



            Connection.Close();
            Reader.Close();


            if (travelInLoop == false)
            {
                isEmpty = true;
            }

            return isEmpty;
        }



        private int ConvertTime(string time)
        {
            int start = 0;

            for (int i = 0; i < time.Length - 1; i++)
            {
                char d = time[i];
                if (time[i] != ':' && time[i] != 'A' && time[i] != 'P' && time[i] != ' ')
                {
                    start = 10 * start + (Convert.ToInt32(time[i]) - 48);
                }
                else
                {
                    if (time[i] == 'A')
                    {
                        start = start * 1;
                    }

                    else if (time[i] == 'P' && start<=1159)
                    {
                        start = start + 1200;
                    }
                }

            }

            if (time[time.Length - 2] == 'A' && time.StartsWith("12"))
            {
                start = 0;
            }


            return start;
        }



    }
}