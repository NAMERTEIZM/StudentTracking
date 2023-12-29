using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentTracking.BLL.Manager;
using StudentTracking.VM.Exam;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamTracking.UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamManager _examManager;
        private readonly StatusManager _statusManager;
        public ExamController(ExamManager examManager, StatusManager statusManager)
        {
            _examManager = examManager;
            _statusManager = statusManager;
        }

        // Ekleme sayfası
        [HttpGet]
        public IActionResult AddExam()
        {
            ViewBag.StatusList = new SelectList(_statusManager.GetAll().Data.Where(a => a.ID > 200 && a.ID < 300), "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult AddExam(ExamInsertVM examInsertVM)
        {
            _examManager.Add(examInsertVM);
            return RedirectToAction("SelectExam");
        }



        // ID gelicek ona göre sayfadaki textler dolacak
        [HttpGet]
        public IActionResult UpdateExam(int ID)
        {
            ExamSelectVM examSelectVM = _examManager.GetByID(ID).Data;

            var status = _statusManager.GetByID(examSelectVM.StatusID);
            ExamUpdateVM ex = new ExamUpdateVM
            {
                Name = examSelectVM.Name,
                ID = examSelectVM.ID,
                Body = examSelectVM.Body,
                Date = examSelectVM.Date,
                StatusName = status.Data.Name,

            };
            ViewBag.StatusList = new SelectList(_statusManager.GetAll().Data.Where(a => a.ID > 200 && a.ID < 300), "ID", "Name", ex.StatusID);

            return View(ex);
        }

        [HttpPost]
        public IActionResult UpdateExam(ExamUpdateVM examUpdateVM)
        {
            _examManager.Update(examUpdateVM);
            return RedirectToAction("SelectExam");

        }


        // Listeleme sayfası : update ve delete butonları tablonun en sağına koyulabilir.
        //[HttpGet]
        //public IActionResult SelectExam()
        //{
        //    List<ExamSelectVM> exams = _examManager.GetAllWithStatus().ToList();

        //    return View(exams);

        //}


        public IActionResult DeleteExam(int ID)
        {
            _examManager.SoftDelete(ID);
            return RedirectToAction("SelectExam");
        }
    }
}