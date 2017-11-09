using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Models;
using UniversityManagementSystem.Gateway;

namespace UniversityManagementSystem.Manager
{
    public class AssignTeacherManager
    {
        AssignTeacherGateway aAssignTeacherGateway = new AssignTeacherGateway();

        public string  SaveCourseAssigntoTeacherInformation(AssignTeacher aAssignTeacher,int courseId)
        {
                
           bool isCourseAssignToTeacher = aAssignTeacherGateway.IsCourseAssignToTeacher(courseId);

            if (isCourseAssignToTeacher)
            {
                return "The Course is Already Assigned To Someone";
            }

            else
            {
                
                aAssignTeacher.RemainingCredit = aAssignTeacher.RemainingCredit - aAssignTeacher.CourseCredit;
                int rowAffected = aAssignTeacherGateway.SaveCourseAssigntoTeacherInformation(aAssignTeacher);

              

                if (rowAffected > 0)
                {
                    return "Successfully Saved";
                }
                else
                {
                    return "Not SuccessFully Saved";
                }
                
            }
           
            }

        public int UpdateCourseStatus(int courseId)
        {
            return aAssignTeacherGateway.UpdateCourseStatus(courseId);
        }

        public int UpdateTeacherRemainingCredit(int teacherId, AssignTeacher aAssignTeacher)
        {
            return aAssignTeacherGateway.UpdateTeacherRemainingCredit(teacherId, aAssignTeacher);
        }


    }

       

       
    }
