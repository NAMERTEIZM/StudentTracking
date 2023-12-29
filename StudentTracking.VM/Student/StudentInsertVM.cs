using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.VM.Student
{
    public class StudentInsertVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int StatusID { get; set; }
        public int ClassID { get; set; }
    }
}
