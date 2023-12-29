using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Question
{
    public class QuestionSelectVM
    {
        public int ID { get; set; }

        public string QuestionName { get; set; }

        public string Description { get; set; }

        public int StudentID { get; set; }

        public bool? isActive { get; set; }

        public DateTime? Date { get; set; }
    }
}
