using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class UnassignCourseController : Controller
    {
        //
        // GET: /UnassignCourse/

        
        UnassignCourseManager aUnassignCourseManager=new UnassignCourseManager();


        
        public ActionResult UnassignCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourse(UnassignCourse aCourse,Teacher aTeacher)
        {
            int updateCourseStatus =aUnassignCourseManager.UpdateCourseStatus(aTeacher);

            return View();
        }

        public ActionResult UnassignClassroom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignClassroom(UnassignClassroom aUnassignClassroom)
        {
            int updateAllocateClassroom = aUnassignCourseManager.UpdateAllocateClassroom();
            return View();
        }



        
        
      

    }
}