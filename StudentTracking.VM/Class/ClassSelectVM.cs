using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Class
{
    public class ClassSelectVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }

    }
}
