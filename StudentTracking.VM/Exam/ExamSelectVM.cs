using StudentTracking.VM.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Exam
{
    public class ExamSelectVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Body { get; set; }

        public int StatusID { get; set; }

        public DateTime Date { get; set; }

        public bool isActive { get; set; }


	}
}

