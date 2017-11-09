using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using UniversityApp.Gateway;
//using UniversityApp.Manager;
//using UniversityApp.Models;
using UniversityManagementApp.Models;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollStudentsrbController : Controller
    {
        //
        // GET: /EnrollStudentsrb/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enroll()
        {
            StudentsManagersrb aManagersrb=new StudentsManagersrb();
            ViewBag.students = aManagersrb.GetallStudent();
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(EnrollCourse aEnrollCourse)
        {
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            ViewBag.students = aManagersrb.GetallStudent();
            EnrollCourseManagersrb aenEnrollCourseManagersrb=new EnrollCourseManagersrb();
            string result= aenEnrollCourseManagersrb.EnrollCourse(aEnrollCourse);
            if (result == "Save Successful")
            {
                ViewBag.success = result;
            }
            else if (result == "This Course has been Already Taken by this Student")
            {
                ViewBag.failed = result;
            }
            return View();
        }

        public JsonResult Getstudent(int studentId)
        {
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            var students = aManagersrb.GetallStudent();
            var requiredstudent = students.Where(m => m.StudentId == studentId).ToList();
            return Json(requiredstudent);
        }

        public JsonResult GetDepartment(int studentId)
        {
            int departmentid = 0;
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            var students = aManagersrb.GetallStudent();
            var requiredstudent = students.Where(m => m.StudentId == studentId).ToList();
            foreach (var i in requiredstudent)
            {
                departmentid = i.DeptId;
            }
            DepartmentManagersrb aManager=new DepartmentManagersrb();
            List<Departmentsrb> departments=new List<Departmentsrb>();
            Departmentsrb aDepartmentsrb = aManager.GetDepartment(departmentid);
            departments.Add(aDepartmentsrb);
            return Json(departments);

        }

        public JsonResult GetCourse(int studentId)
        {
             int departmentid = 0;
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            var students = aManagersrb.GetallStudent();
            var requiredstudent = students.Where(m => m.StudentId == studentId).ToList();
            foreach (var i in requiredstudent)
            {
                departmentid = i.DeptId;
            }
            CourseManager aCourseManager=new CourseManager();
            List<Course> courses = aCourseManager.Getcoursebydepartment(departmentid);
            return Json(courses);
        }
	}
}