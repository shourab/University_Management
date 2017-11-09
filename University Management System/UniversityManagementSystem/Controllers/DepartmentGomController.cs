using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentGomController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DepartmentGOM aDepartmentGom)
        {
            DeptUniqueManagerGOM unique=new DeptUniqueManagerGOM();
            string msg = unique.CheckUnique(aDepartmentGom);
            ViewBag.msg = msg;

            if (msg == null)
            {
                SaveDeptManagerGOM aSaveDeptManagerGom = new SaveDeptManagerGOM();
                msg = aSaveDeptManagerGom.SaveDept(aDepartmentGom);
                ViewBag.msg = msg;    
            }
            
            return View();
        }

        public ActionResult ShowDepartment()
        {
            ViewDeptManagerGOM aViewDeptManagerGom=new ViewDeptManagerGOM();
            ViewBag.departments = aViewDeptManagerGom.Show();
            return View();

        }

        [HttpGet]
        public ActionResult SaveCourse()
        {
            ShowDept();
            ShowSemister();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(CourseGOM aCourseGom)
        {
            ShowDept();
            ShowSemister();

            CourseUniqueManagerGOM unique = new CourseUniqueManagerGOM();
            string msg = unique.CheckUnique(aCourseGom);
            ViewBag.msg = msg;

            if (msg == null)
            {
                SaveCourseManagerGOM save = new SaveCourseManagerGOM();
                msg = save.Save(aCourseGom);
                ViewBag.msg = msg;    
            }
            

            return View();
        }

        private void ShowDept()
        {
            ViewDeptManagerGOM aViewDeptManagerGom = new ViewDeptManagerGOM();
            ViewBag.departments = aViewDeptManagerGom.Show();
        }

        private void ShowSemister()
        {
            ViewSemesterManagerGOM aViewSemesterManagerGom = new ViewSemesterManagerGOM();
            ViewBag.semester = aViewSemesterManagerGom.Show();
        }

        private void ShowDesignation()
        {
            ViewDesignationManagerGOM designation=new ViewDesignationManagerGOM();
            ViewBag.designation = designation.Show();
        }

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            ShowDept();
            ShowDesignation();
            return View();
        }


        [HttpPost]
        public ActionResult SaveTeacher(TeacherGom aTeacherGom)
        {
            ShowDept();
            ShowDesignation();
            string msg = null;
            TeacherUniqueEmailManager unique=new TeacherUniqueEmailManager();
            msg = unique.CheckUnique(aTeacherGom.Email);
            ViewBag.msg = msg;

            if (msg == null)
            {
                SaveTeacherManagerGOM save = new SaveTeacherManagerGOM();
                msg = save.Save(aTeacherGom);
                ViewBag.msg = msg;    
            }
            

            return View();
        }

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            ShowDept();
            return View();
        }


        [HttpPost]
        public ActionResult ViewRegisteredStudent(StudentGom student)
        {
            //ShowDept();
            string msg="";
            SaveStudentManagerGOM save=new SaveStudentManagerGOM();

            StudentGom registeredStudent = save.Save(student);
            ViewBag.registeredStudent = registeredStudent;

            
            //msg = save.Save(student);
            //ViewBag.msg = msg;

            return View();
        }


        public ActionResult ViewResult()
        {
            ShowStudent();
            return View();
        }


        private void ShowStudent()
        {
            ViewStudentManagerGOM studentResult=new ViewStudentManagerGOM();
            ViewBag.resultList = studentResult.ShowStudentDetails();
             
        }

        public ActionResult DemoLayout()
        {
            
            return View();
        }


        public ActionResult SaveStudentActionResult()
        {

            return View();
        }


	}
}