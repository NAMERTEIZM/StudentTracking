using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentTracking.BLL.Manager;
using StudentTracking.UI.Models.Filters;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentManager _studentManager;
        private readonly ClassManager _classManager;
        private readonly StatusManager _statusManager;

        public StudentController(StudentManager studentManager, ClassManager classManager, StatusManager statusManager)
        {
            _studentManager = studentManager;
            _classManager = classManager;
            _statusManager = statusManager;
        }
        // Ekleme sayfası
        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewBag.ClassList = new SelectList(_classManager.GetAll().Data, "ID", "Name");
            ViewBag.StatusList = new SelectList(_statusManager.GetAll().Data.Where(a => a.ID < 200 && a.ID > 100), "ID", "Name");

            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(UniqueEmailFilter))]
        public IActionResult AddStudent(StudentInsertVM studentInsertVM)
        {
            _studentManager.Add(studentInsertVM);
            return RedirectToAction("SelectStudent");
        }



        // ID gelicek ona göre sayfadaki textler dolacak
        [HttpGet]
        public IActionResult UpdateStudent(int ID)
        {
            StudentSelectVM studentSelectVM = _studentManager.GetByID(ID).Data;

            // Status ve Class adını getir
            var status = _statusManager.GetByID(studentSelectVM.StatusID);
            var classInfo = _classManager.GetNameById(studentSelectVM.ClassID);

            // StudentUpdateVM'yi doldur
            StudentUpdateVM studentUpdateVM = new StudentUpdateVM
            {
                ID = studentSelectVM.ID,
                FirstName = studentSelectVM.FirstName,
                LastName = studentSelectVM.LastName,
                Email = studentSelectVM.Email,
                StatusID = studentSelectVM.StatusID,
                StatusName = status?.Data.Name, // Status adını set et
                ClassID = studentSelectVM.ClassID,
                ClassName = classInfo?.Name // Class adını set et
            };

            // SelectList'leri oluştur
            ViewBag.ClassList = new SelectList(_classManager.GetAll().Data, "ID", "Name", studentUpdateVM.ClassID);
            ViewBag.StatusList = new SelectList(_statusManager.GetAll().Data.Where(a => a.ID < 200 && a.ID > 99), "ID", "Name", studentUpdateVM.StatusID);

            return View(studentUpdateVM);
        }

        [HttpPost]
        public IActionResult UpdateStudent(StudentUpdateVM studentUpdateVM)
        {
            _studentManager.Update(studentUpdateVM);
            return RedirectToAction("SelectStudent");
        }


        // Listeleme sayfası : update ve delete butonları tablonun en sağına koyulabilir.
        [HttpGet]
        public IActionResult SelectStudent()
        {
            var students = _studentManager.GetAll().Data;

            foreach (var student in students)
            {
                // Status adını getir
                var status = _statusManager.GetByID(student.StatusID).Data;
                student.StatusName = status?.Name;

                //Class adını getir
                var classInfo = _classManager.GetNameById(student.ClassID);
                student.ClassName = classInfo?.Name;
            }

            return View(students);
        }


        public IActionResult DeleteStudent(int ID)
        {
            _studentManager.SoftDelete(ID);
            return RedirectToAction("SelectStudent");
        }

        [HttpGet]
        public IActionResult GetStudentsByClass(int classId)
        {
            var students = _studentManager.GetStudentsByClass(classId).ToList();

            return Json(students); // JSON formatında öğrenci listesini döndür
        }
    }
}