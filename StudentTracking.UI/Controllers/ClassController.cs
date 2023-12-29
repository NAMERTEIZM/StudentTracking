using Microsoft.AspNetCore.Mvc;
using StudentTracking.BLL.Manager;
using StudentTracking.VM.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Controllers
{
    public class ClassController : Controller
    {
        private readonly ClassManager _classManager;
        public ClassController(ClassManager classManager)
        {
            _classManager = classManager;
        }

        // Ekleme sayfası
        [HttpGet]
        public IActionResult AddClass()
        {     
            return View();
        }

        [HttpPost]
        public IActionResult AddClass(ClassInsertVM classInsertVM)
        {
            var result = _classManager.Add(classInsertVM);

            if (!result.Success)
            {
                //RedirectToAction("Error");
            } 

            return RedirectToAction("SelectClass");
        }



        // ID gelicek ona göre sayfadaki textler dolacak
        [HttpGet]
        public IActionResult UpdateClass(int ID)
        {
            var myClass = _classManager.GetByID(ID);

            ClassUpdateVM myUpdateClass = new ClassUpdateVM
            {
                ID = myClass.Data.ID,
                Name = myClass.Data.Name,
                Capacity = myClass.Data.Capacity,
                EndDate = myClass.Data.EndDate,
                StartedDate = myClass.Data.StartedDate
            };

            return View(myUpdateClass);
        }

        [HttpPost]
        public IActionResult UpdateClass(ClassUpdateVM classUpdateVM)
        {
            _classManager.Update(classUpdateVM);

            return RedirectToAction("SelectClass");
        }


        // Listeleme sayfası : update ve delete butonları tablonun en sağına koyulabilir.
        [HttpGet]
        public IActionResult SelectClass()
        {
            return View(_classManager.GetAll().Data);
        }


        public IActionResult DeleteClass(int ID)
        {
            _classManager.SoftDelete(ID);
            return RedirectToAction("SelectClass");
        }

    }
}
