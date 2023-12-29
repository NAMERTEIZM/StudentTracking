using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Exam
{
    public class ExamInsertVM
    {
        public string Name { get; set; }
        public string Body { get; set; }

        public int StatusID { get; set; }

        public DateTime Date { get; set; }
        public string StatusName { get; set; }

    }
}