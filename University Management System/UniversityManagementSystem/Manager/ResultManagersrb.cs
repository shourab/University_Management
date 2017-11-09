using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ResultManagersrb
    {
        public string SaveResult(Resultsrb aResultsrb)
        {
            EnrollCourseGAtewaysrb aenrollAtewaysrb=new EnrollCourseGAtewaysrb();
            EnrollCourse aEnrollCourse=new EnrollCourse();
            aEnrollCourse.StudentId = aResultsrb.StudentId;
            aEnrollCourse.CourseId = aResultsrb.CourseId;
            bool isenrolled = aenrollAtewaysrb.IsExist(aEnrollCourse);
            if (isenrolled)
            {
                ResultGatewaysrb aGatewaysrb = new ResultGatewaysrb();
                bool Isexist = aGatewaysrb.isexist(aResultsrb);
                if (Isexist)
                {
                    return "Sorry This Course is Graded Before.Try a new One";
                }
                else
                {


                    int rowaffected = aGatewaysrb.SaveResult(aResultsrb);
                    if (rowaffected > 0)
                    {
                        return "Result has been Saved";
                    }
                    else
                    {
                        return "Save Failed";
                    }
                } 
            }
            else
            {
                return "This Course is not Enrolled by this Student";
            }
           
        }
    }
}