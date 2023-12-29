using StudentTracking.VM.Exam;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.StudentExam
{
    public class StudentExamSelectVM
    {
        public int StudentID { get; set; }

        public int ExamID { get; set; }

        public int? Score { get; set; }

        public string Description { get; set; }

        public bool? isActive { get; set; }

        public virtual ExamSelectVM Exam { get; set; }

        public virtual StudentSelectVM Student { get; set; }
    }
}
