using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Report
{
    public class ReportUpdateVM
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public int WeekOfYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}