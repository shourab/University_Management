using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Rotativa;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ResultStudentGOMController : Controller
    {

        private List<ViewResultGOM> ShowStudent()
        {
            ViewStudentManagerGOM studentResult = new ViewStudentManagerGOM();
            ViewBag.resultList = studentResult.ShowStudentDetails();
            return ViewBag.resultList;
        }

        private List<ViewResultGOM> ShowStudentDetailsById(int studentId)
        {
            ViewStudentManagerGOM studentResult = new ViewStudentManagerGOM();
            List<ViewResultGOM> studentList = studentResult.ShowStudentDetailsById(studentId);
            return studentList;
        }
        public ActionResult Index()
        {
            ShowStudent();
            return View();
        }

        [HttpPost]
        public ActionResult PrintResultSheet(ViewResultGOM result)
        {
            List<ViewResultGOM> studentResult = ShowStudentDetailsById(result.StudentId);
            ViewBag.studentResult = studentResult;

            return View();
        }


        //public ActionResult ExportPdf()
        //{
        //    return new ActionAsPdf("PrintResultSheet")
        //    {
        //        FileName = Server.MapPath("~/Content/Results.pdf")
        //    };
        //}




        public JsonResult GetStudentsResultByStudentId(int studentId)
        {
            
            List<ViewResultGOM> result = ShowStudentDetailsById(studentId);
            //List<ViewResultGOM> studentList = result.Where(a => a.StudentId == studentId).ToList();
            return Json(result);
        }

        

        [HttpGet]
        public ActionResult AllocateClassRoomGom()
        {

            ViewDeptManagerGOM aViewDeptManagerGom = new ViewDeptManagerGOM();
            ViewBag.departments = aViewDeptManagerGom.Show();

            ViewRoomDayManagerGOM rd=new ViewRoomDayManagerGOM();
            List<ClassRoomGOM> classRoom = rd.ShowClassroom();
            ViewBag.classRoom = classRoom;
            

            List<ClassRoomGOM> day =rd.ShowDay();
            ViewBag.day = day;

            List<ClassRoomGOM> nullList = new List<ClassRoomGOM>();
            ViewBag.nullList = nullList;

            return View();
        }


        [HttpPost]
        public ActionResult AllocateClassRoomGom(ClassRoomGOM classRoomGom)
        {


            AllocateClassRoomManagerGOM allocateClass = new AllocateClassRoomManagerGOM();
            string msg = allocateClass.InsertAllocation(classRoomGom);
            ViewBag.msg = msg;
            
            
            
            
            
            
            
            ViewDeptManagerGOM aViewDeptManagerGom = new ViewDeptManagerGOM();
            ViewBag.departments = aViewDeptManagerGom.Show();




            ViewRoomDayManagerGOM rd = new ViewRoomDayManagerGOM();
            List<ClassRoomGOM> classRoom = rd.ShowClassroom();
            ViewBag.classRoom = classRoom;




            List<ClassRoomGOM> day = rd.ShowDay();
            ViewBag.day = day;




            List<ClassRoomGOM> nullList = new List<ClassRoomGOM>();
            ViewBag.nullList = nullList;



            return View();
        }




        public JsonResult GetCourseByDeptId(int deptId)
        {
            
            ViewCourseManagerGOM vcm=new ViewCourseManagerGOM();
            List<CourseGOM> Courses = vcm.GetCourseByDeptId(deptId);
            
            return Json(Courses);
        }




        //________________________//



        public ActionResult ShowClassSchedule()
        {
            ViewDeptManagerGOM aViewDeptManagerGom = new ViewDeptManagerGOM();

            List<DepartmentGOM> departments= aViewDeptManagerGom.Show();
            ViewBag.departments = departments;

            return View();
        }


        public JsonResult ViewRoomAllocationInfo(int deptId)
        {
            AllocateClassRoomManagerGOM manager=new AllocateClassRoomManagerGOM();
            List<AllocatedClassroomGOM> Allocated = manager.ViewAllocatedRoomByDeptId(deptId);
            //List<ViewResultGOM> studentList = result.Where(a => a.StudentId == studentId).ToList();
            return Json(Allocated);
        }
        







    }
}