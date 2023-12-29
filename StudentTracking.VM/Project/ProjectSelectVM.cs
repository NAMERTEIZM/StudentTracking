using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Project
{
    public class ProjectSelectVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> FullName { get; set; } = new List<string>();
        public bool isFinal { get; set; }
        public bool isActive { get; set; }
    }
}
