using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.CORE.Entities
{
    public class StudentProject
    {
        public int StudentID { get; set; }
        public int ProjectID { get; set; }

        public int? Score { get; set; }

        public string Description { get; set; }

        public bool? isActive { get; set; }

        public virtual Project Project { get; set; }

        public virtual Student Student { get; set; }
    }
}
