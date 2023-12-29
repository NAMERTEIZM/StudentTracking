using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.CORE.Entities
{
    public class Status
    {
        public Status()
        {
            Exam = new HashSet<Exam>();
            Student = new HashSet<Student>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public bool? isActive { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
