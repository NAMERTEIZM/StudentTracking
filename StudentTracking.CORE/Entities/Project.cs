using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.CORE.Entities
{
    public class Project
    {
        public Project()
        {
            StudentProject = new HashSet<StudentProject>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime? StartedDate { get; set; }

        public bool? isFinal { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? isActive { get; set; }

        public virtual ICollection<StudentProject> StudentProject { get; set; }
    }
}
