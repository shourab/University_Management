using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ClassRoomGOM
    {

        [Required(ErrorMessage = "Please Enter A Classroom")]
        public int ClassRoomId { get; set; }


        [DisplayName("Department")]
        [Required(ErrorMessage = "Please Enter A Department")]
        public int DeptId { get; set; }


        [Required(ErrorMessage = "Please Enter A Department")]
        public String DeptName { get; set; }


        [DisplayName("Course")]
        [Required(ErrorMessage = "Please Enter A Course")]
        public int CourseId { get; set; }


        [Required(ErrorMessage = "Please Enter A Course")]
        public int CourseName { get; set; }


        [DisplayName("Room No.")]
        [Required(ErrorMessage = "Please Enter A Room")]
        public int RoomId { get; set; }


        public string RoomNo { get; set; }


        [DisplayName("Day")]
        [Required(ErrorMessage = "Please Enter A Day")]
        public int DayId { get; set; }


        public string DayName { get; set; }


        [Required(ErrorMessage = "Please Follow Time Format hh:mm A")]
        [DisplayName("From")]
        [StringLength(8, MinimumLength = 8,ErrorMessage = "Please Follow Time Format hh:mm A")]
        public string ScheduledFrom { get; set; }


        [Required(ErrorMessage = "Please Follow Time Format hh:mm A")]
        [DisplayName("To")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Please Follow Time Format hh:mm A")]
        public string ScheduledTo { get; set; } 

    }
}