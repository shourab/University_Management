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
    public class TeacherAssignController : Controller
    {
        //
        // GET: /TeacherAssign/
        public ActionResult Index()
        {
            return View();
        }

        AssignTeacherManager aAssignTeacherManager = new AssignTeacherManager();
        DepartmentManager aDepartmentManager=new DepartmentManager();
        TeacherManager aTeacherManager=new TeacherManager();
        CourseManager aCourseManager=new CourseManager();

        [HttpGet]
        public ActionResult SaveCourseAssigntoTeacher()
        {

            List<Department> department = GetAllDepartments();

            if (department != null)
            {
                ViewBag.Departments = department;
            }
         
            
         
            
            return View();
        }


        [HttpPost]
        public ActionResult SaveCourseAssigntoTeacher(int courseId,int teacherId,int departmentId,AssignTeacher aAssignTeacher)
        {

           List<Department> department = GetAllDepartments();
           ViewBag.Departments = department;

           ViewBag.RemainingCredit = aAssignTeacher.RemainingCredit;
           ViewBag.CourseCredit = aAssignTeacher.CourseCredit;
          
           string save = aAssignTeacherManager.SaveCourseAssigntoTeacherInformation(aAssignTeacher,courseId);
           ViewBag.msg = save;

         

           int updateCourseStatus =aAssignTeacherManager.UpdateCourseStatus(courseId);

           int updateTeacherRemainingCredit = aAssignTeacherManager.UpdateTeacherRemainingCredit(teacherId,
                aAssignTeacher);
          

           return View();
        }


        public JsonResult GetTeacherNameByDepartmentId(int departmentId)
        {
            var teacher = GetAllTeacherName();

            var teacherList = teacher.Where(a => a.DepartmentId == departmentId).ToList();

            return Json(teacherList);
        }


        public JsonResult GetCourseCodeByDepartmentId(int departmentId)
        {
            var course =GetAllCourse();

            var courseList = course.Where(a => a.DepartmentId == departmentId).ToList();

            return Json(courseList);
        }

        public JsonResult GetCourseNameByCourseId(int courseId)
        {
            var course = GetAllCourse();

            var specificCourse = course.Where(a => a.CourseId == courseId).ToList();

            return Json(specificCourse);
        }

        public JsonResult GetCreditByTeacherId(int teacherId)
        {
            var teacher = GetAllTeacherName();

            var specificTeacher = teacher.Where(a =>a.TeacherId==teacherId).ToList();

            return Json(specificTeacher);
        }


        private List<Department> GetAllDepartments()
        {
            
          return aDepartmentManager.GetAllDepartments();

        }

        private List<Teacher> GetAllTeacherName()
        {
            return aTeacherManager.GetAllTeacherName();
        }

        private List<Course> GetAllCourse()
        {
            return aCourseManager.GetAllCourse();
        }

      
    }
}