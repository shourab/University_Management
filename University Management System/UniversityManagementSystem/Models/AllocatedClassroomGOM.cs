using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocatedClassroomGOM
    {
        [Required]
        [DisplayName("Department")]
        public int DeptId { get; set; }

        public string DeptName { get; set; }


        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public string RoomNo { get; set; }

        public string DayName { get; set; }

        public string ScheduleFrom { get; set; }

        public string ScheduleTo { get; set; }

        public string ScheduleInfo { get; set; }
    }
}