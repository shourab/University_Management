using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class AllocateClassRoomGatewayGOM:Gateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDbConnectionName"].ConnectionString;
        public int InsertAllocation(ClassRoomGOM classRoomGom)
        {
            Connection = new SqlConnection(connectionString);
            Query = "INSERT INTO AllocateClassroom(DepartmentId,CourseId,RoomId,DayId,ScheduleFrom,ScheduleTo,Status) VALUES(@DepartmentId,@CourseId,@RoomId,@DayId,@ScheduleFrom,@ScheduleTo,@Status)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();


            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = classRoomGom.DeptId;

            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = classRoomGom.CourseId;


            Command.Parameters.Add("RoomId", SqlDbType.Int);
            Command.Parameters["RoomId"].Value = classRoomGom.RoomId;


            Command.Parameters.Add("DayId", SqlDbType.Int);
            Command.Parameters["DayId"].Value = classRoomGom.DayId;

            Command.Parameters.Add("ScheduleFrom", SqlDbType.VarChar);
            Command.Parameters["ScheduleFrom"].Value = classRoomGom.ScheduledFrom;

            Command.Parameters.Add("ScheduleTo", SqlDbType.VarChar);
            Command.Parameters["ScheduleTo"].Value = classRoomGom.ScheduledTo;

            Command.Parameters.Add("Status", SqlDbType.Bit);
            Command.Parameters["Status"].Value = "True";


            Connection.Open();
            int rowAffected = 0;
            try
            {
                rowAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                rowAffected = -999;
            }

            Connection.Close();

            return rowAffected;
        }

        public List<AllocatedClassroomGOM> ViewAllocatedRoomByDeptId(int deptId)
        {
            Query = "SELECT * FROM ClassScheduleView WHERE DepartmentId='"+deptId+"'";

            //Query = "SELECT c.CourseCode,c.CourseId,c.CourseName,r.RoomNo,d.DayName,a.ScheduleFrom,a.ScheduleTo FROM AllocateClassroom AS a,Course AS c,RoomInformation AS r,DayInformation AS d WHERE a.DepartmentId='" + deptId + "' AND a.courseId=c.CourseId AND a.RoomId=r.RoomId AND a.DayId=d.DayId AND a.Status='True' ORDER BY CourseCode";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            string memory = "";
            string tempMemory = "";
            int i = -1;

            List<AllocatedClassroomGOM> allocatedList=new List<AllocatedClassroomGOM>();
            while (Reader.Read())
            {
                AllocatedClassroomGOM cls=new AllocatedClassroomGOM();

                cls.CourseId = Convert.ToInt32(Reader["CourseId"].ToString());
                cls.CourseCode = Reader["CourseCode"].ToString();
                cls.CourseName = Reader["CourseName"].ToString();
                cls.RoomNo = Reader["RoomNo"].ToString();
                cls.DayName = Reader["DayName"].ToString();
                cls.ScheduleFrom = Reader["FromSchedule"].ToString();
                cls.ScheduleTo = Reader["ToSchedule"].ToString();



                //" ------- "
                if (memory == cls.CourseCode)
                {
                    
                    allocatedList.RemoveAt(i);
                    tempMemory = tempMemory + " ------- Room No : " + cls.RoomNo + "," + cls.DayName + "," + cls.ScheduleFrom + "-" + cls.ScheduleTo + " ------- ";
                    cls.ScheduleInfo = tempMemory;
                }

                else
                {
                    tempMemory = null;
                    tempMemory = "------- Room No : " + cls.RoomNo + "," + cls.DayName + "," + cls.ScheduleFrom + "-" + cls.ScheduleTo + " ------- ";
                    cls.ScheduleInfo = tempMemory;
                    i++;
                }


                if (cls.RoomNo == "")
                {
                    cls.ScheduleInfo = "Not Scheduled Yet";
                }


                
                allocatedList.Add(cls);
                memory = cls.CourseCode;
                
            }
            Connection.Close();
            Reader.Close();


           
           
            

            
            return allocatedList;
        }
    }
}