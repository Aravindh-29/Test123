using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleAspWithLoginPage.Models;

namespace SampleAspWithLoginPage.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private static List<Student> students = new List<Student>();

        // Show Student Page
        public ActionResult Index()
        {
            return View(students);
        }

        // Add Student (POST)
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
            }
            return RedirectToAction("Index");
        }

        // Edit Student (GET)
        public ActionResult EditStudent(int id)
        {
            var student = students.Find(s => s.Id == id);
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        // Update Student (POST)
        [HttpPost]
        public ActionResult UpdateStudent(Student updatedStudent)
        {
            var student = students.Find(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Class = updatedStudent.Class;
                student.Gender = updatedStudent.Gender;
                student.Age = updatedStudent.Age;
            }
            return RedirectToAction("Index");
        }

        // Delete Student
        public ActionResult DeleteStudent(int id)
        {
            students.RemoveAll(s => s.Id == id);
            return RedirectToAction("Index");
        }
    }
}