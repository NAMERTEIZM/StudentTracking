using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.CORE.Entities
{
    public class Exam
    {
        public Exam()
        {
            StudentExam = new HashSet<StudentExam>();
        }

        public int ID { get; set; }

        public string Body { get; set; }

        public int? StatusID { get; set; }

        public DateTime? Date { get; set; }

        public bool? isActive { get; set; }

        public string Name { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<StudentExam> StudentExam { get; set; }
    }
}
