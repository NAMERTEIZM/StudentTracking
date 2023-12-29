using Microsoft.AspNetCore.Mvc;
using StudentTracking.BLL.Manager;
using StudentTracking.UI.Extensions;
using StudentTracking.VM.Class;
using StudentTracking.VM.Project;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectManager _projectManager;
        private readonly ClassManager _classManager;
        private readonly StudentManager _studentManager;

        public ProjectController(ProjectManager projectManager, ClassManager classManager, StudentManager studentManager)
        {
            _projectManager = projectManager;
            _classManager = classManager;
            _studentManager = studentManager;
        }

        // Ekleme sayfası
        [HttpGet]
        public IActionResult AddProject()
        {
            var classes = _classManager.GetAll().Data;

            var projectInsertVM = new ProjectInsertVM
            {
                Classes = classes
            };

            return View(projectInsertVM);
        }

        [HttpPost]
        public IActionResult AddProject(ProjectInsertVM projectInsertVM)
        {
            var vm = projectInsertVM;
            vm.SelectedStudentIDsList = vm.SelectedStudentIDs.ConvertStringToList();

            var a = _projectManager.Add(vm);


            return RedirectToAction("SelectProject");
        }

        // ID gelicek ona göre sayfadaki textler dolacak
        [HttpGet]
        public IActionResult UpdateProject(int ID)
        {
            ProjectSelectVM vm = _projectManager.GetByID(ID).Data;

            

            return View(new ProjectUpdateVM
            {
                ID = vm.ID,
                Name = vm.Name,
                StartedDate = vm.StartedDate,
                EndDate = vm.EndDate,


            });
        }

        [HttpPost]
        public IActionResult UpdateProject(ProjectUpdateVM projectUpdateVM)
        {
            return View();
        }


        // Listeleme sayfası : update ve delete butonları tablonun en sağına koyulabilir.
        [HttpGet]
        public IActionResult SelectProject()
        {
            var projects = _projectManager.GetAll().Data;

            projects.ForEach(x => 
            {
                var students = _studentManager.GetAllStudentByProject(x.ID).Data;
                students.ForEach(y => 
                {
                    x.FullName.Add(y.FirstName);
                });            
            });

            return View(projects);
        }


        public IActionResult DeleteProject(int ID)
        {
            _projectManager.SoftDelete(ID);

            return RedirectToAction("SelectProject");
        }


    }
}
