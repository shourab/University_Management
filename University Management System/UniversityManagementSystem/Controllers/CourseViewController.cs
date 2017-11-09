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
    public class CourseViewController : Controller
    {
        CourseviewManager aCourseviewManager = new CourseviewManager();
        public ActionResult Index()
        {
            ViewBag.Departments = GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Index(int departmentId, int courseId)
        {
            ViewBag.Departments = GetDepartments();
            return View();
        }

        public JsonResult GetCourseViewByDepartmentId(int departmentId)
        {
            var courses = GetAllInfo();
            var courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList);
        }

        private List<Department> GetDepartments()
        {

            List<Department> departments = aCourseviewManager.GetDepartments();
            return departments;
        }

        

        private List<Courseview> GetAllInfo()
        {


            List<Courseview> courses = aCourseviewManager.GetAllInfo();

            return courses;
        }

    }
}