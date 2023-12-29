using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.CORE.Entities
{
    public class Student
    {
        public Student()
        {
            Report = new HashSet<Report>();
            Question = new HashSet<Question>();
            StudentExam = new HashSet<StudentExam>();
            StudentProject = new HashSet<StudentProject>();
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? StatusID { get; set; }

        public int? ClassID { get; set; }

        public bool? isActive { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Report> Report { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Question> Question { get; set; }

        public virtual ICollection<StudentExam> StudentExam { get; set; }

        public virtual ICollection<StudentProject> StudentProject { get; set; }
    }
}
