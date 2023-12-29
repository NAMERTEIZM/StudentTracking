using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTracking.BLL.Manager;
using StudentTracking.VM.Class;
using StudentTracking.VM.Question;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Controllers
{
    public class FastController : Controller
    {

       
        private readonly ClassManager _classManager;
        private readonly StudentManager _studentManager;
        private readonly QuestionManager _questionManager;
        public FastController(ClassManager classManager, StudentManager studentManager, QuestionManager questionManager)
        {
            _classManager = classManager;
            _studentManager = studentManager;
            _questionManager = questionManager;
        }

        // Sınıf seçme listesi
        [HttpGet]
        public IActionResult FastSelectClass(ClassSelectVM classSelectVM)
        {
            List<ClassSelectVM> classList = _classManager.GetAll().Data;
            return View(classList);
        }

        // Sınıf id si alınıp kartlara öğrenci listesi yollanacak
        [HttpPost]
        public IActionResult FastSelectClass(int SelectedClassId)
        {
            //selectedClassId dropdown dan secilen degeri alir
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
            };

            Response.Cookies.Append("ClassIDCookie", SelectedClassId.ToString(), options);


            return RedirectToAction("FastStudentManagement");
        }
        // Kartların gelmesini sağlayacak get işlemi
        [HttpGet]
        public IActionResult FastStudentManagement()
        {
			if (Request.Cookies.TryGetValue("ClassIDCookie", out string classId))
			{
				int selectedClassID;
				if (int.TryParse(classId, out selectedClassID))
				{
                    List<StudentSelectVM> selectedStudents = _studentManager.GetStudentWithDetailsByClassID(selectedClassID).Data;
                    var SortedByDescSelectedStudents = selectedStudents.OrderBy(x => x.Question.Count).ToList();
                    List<StudentSelectVM> selectedStudents2 = _studentManager.GetStudentWithDetailsReport(selectedClassID,2).Data;
                    return View(SortedByDescSelectedStudents);
				}
			}
			return View();
			////int? selectedClassID = HttpContext.Session.GetInt32("SelectedClassID");
			////List<StudentSelectVM> selectedStudents = _studentManager.GetByClassID(Convert.ToInt32(selectedClassID)).ToList();
		}

        // kartlardaki arka yüzde soru sorunca çalışan method
        [HttpPost]
        public IActionResult FastStudentManagement(QuestionInsertVM questionInsertVM)
        {
            return View();
        }

    }
}
