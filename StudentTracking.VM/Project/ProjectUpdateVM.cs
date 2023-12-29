using StudentTracking.VM.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Project
{
    public class ProjectUpdateVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isFinal { get; set; }
        public string SelectedStudentIDs { get; set; }
        public List<int> SelectedStudentIDsList { get; set; }
        public int SelectedClassID { get; set; }
        public List<ClassSelectVM> Classes { get; set; }
    }
}
