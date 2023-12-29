using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentTracking.BLL.Manager;
using StudentTracking.VM.Class;
using StudentTracking.VM.Report;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportManager _reportManager;
        private readonly StudentManager _studentManager;
        private readonly ClassManager _classManager;
        public ReportController(ReportManager reportManager, StudentManager studentManager,ClassManager classManager)
        {
            _reportManager = reportManager;
            _studentManager = studentManager;
            _classManager = classManager;
        }

        // Ekleme sayfası
        [HttpGet]
        public IActionResult AddReport()
        {
            //ViewBag.StudentList = new SelectList(_studentManager.GetAllJustFullName(), "ID", "FullName");
            return View();
        }

		//[HttpPost]
		//public IActionResult AddReport(ReportInsertVM reportInsertVM)
		//{
		//    _reportManager.Add(reportInsertVM);

		//    return RedirectToAction("SelectReport");
		//}



		//// ID gelicek ona göre sayfadaki textler dolacak
		//[HttpGet]
		//public IActionResult UpdateReport(int ID)
		//{
		//    ReportSelectVM myClass = _reportManager.GetByID(ID);

		//    var student = _studentManager.GetByID(myClass.StudentID);

		//    ReportUpdateVM myUpdateClass = new ReportUpdateVM
		//    {
		//        ID = myClass.ID,
		//        StudentID = myClass.StudentID,
		//        FirstName = student.FirstName,
		//        LastName = student.LastName,
		//        Description = myClass.Description,
		//        Score = myClass.Score,
		//        Date = myClass.Date,
		//        WeekOfYear = myClass.WeekOfYear
		//    };

		//    ViewBag.StudentList = new SelectList(_studentManager.GetAllJustFullName(), "ID", "FullName", myUpdateClass.StudentID);


		//    return View(myUpdateClass);
		//}

		//[HttpPost]
		//public IActionResult UpdateReport(ReportUpdateVM reportUpdateVM)
		//{
		//    _reportManager.Update(reportUpdateVM);

		//    return RedirectToAction("SelectReport");
		//}


		// Listeleme sayfası : update ve delete butonları tablonun en sağına koyulabilir.
		//[HttpGet]
		//public IActionResult SelectReport()
		//{


		//	var reports = _reportManager.GetAll().ToList();

		//	//foreach (var report in reports)
		//	//{

		//	//    var student = _studentManager.GetByID(report.StudentID);
		//	//    report.FirstName = student?.FirstName;
		//	//    report.LastName = student?.LastName;


		//	//}


		//	return View(_reportManager.GetAllWithStudentID().ToList());
		//}


		//public IActionResult DeleteReport(int ID)
		//{
		//    _reportManager.SoftDelete(ID);
		//    return RedirectToAction("SelectReport");
		//}

		[HttpGet]
        public IActionResult SelectSendReport()
        {
            ViewBag.classes = _classManager.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult SendReport(string konuBasligi, string mesajIcerigi, string sinifSecimi)
        {
            //_mailSender.SendEmail("furkangokirmak34@gmail.com", konuBasligi, mesajIcerigi);
            return View();
        }

    }
}