using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.CORE.Entities
{
    public class StudentExam
    {
        public int StudentID { get; set; }

        public int ExamID { get; set; }

        public int? Score { get; set; }

        public string Description { get; set; }

        public bool? isActive { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Student Student { get; set; }
    }
}
