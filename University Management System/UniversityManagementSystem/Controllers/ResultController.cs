using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Models;

//using UniversityApp.Manager;
//using UniversityApp.Models;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ResultController : Controller
    {
        StudentGom aStudentGom=new StudentGom();
        //
        // GET: /Result/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GenerateResult()
        {
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            ViewBag.students = aManagersrb.GetallStudent();
            return View();
        }
        [HttpPost]

        public ActionResult GenerateResult(Resultsrb aResultsrb)
        {
            
            aStudentGom.StudentId= aResultsrb.StudentId;
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            ViewBag.students = aManagersrb.GetallStudent();
            ResultManagersrb aResultManagersrb=new ResultManagersrb();
            string result = aResultManagersrb.SaveResult(aResultsrb);
            if (result == "Sorry This Course is Graded Before.Try a new One" || result == "This Course is not Enrolled by this Student")
            {
                 ViewBag.failed=result;
            }
            else if (result == "Result has been Saved")
            {
                 ViewBag.success=result;
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
            DepartmentManagersrb aManager = new DepartmentManagersrb();
            List<Departmentsrb> departments = new List<Departmentsrb>();
            Departmentsrb aDepartmentsrb = aManager.GetDepartment(departmentid);
            departments.Add(aDepartmentsrb);
            return Json(departments);

        }

       
        public JsonResult GetCourse(int studentId)
        {
            aStudentGom.StudentId = studentId;
            
            int departmentid = 0;
            StudentsManagersrb aManagersrb = new StudentsManagersrb();
            var students = aManagersrb.GetallStudent();
            var requiredstudent = students.Where(m => m.StudentId == studentId).ToList();
            foreach (var i in requiredstudent)
            {
                departmentid = i.DeptId;
            }
            CourseManager aCourseManager = new CourseManager();
            List<Course> courses = aCourseManager.Getcoursebydepartment(departmentid);
            return Json(courses);
        }

        

        public ActionResult Details()
        {
            ViewBag.student = aStudentGom.StudentId;
            return View();
        }
	}
}