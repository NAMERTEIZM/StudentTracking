using AutoMapper;
using StudentTracking.CORE.Entities;
using StudentTracking.VM.Class;
using StudentTracking.VM.Exam;
using StudentTracking.VM.Question;
using StudentTracking.VM.Student;
using StudentTracking.VM.StudentExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTracking.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        //dest hedef
        //src kaynak
        public MapperProfile()
        {
            CreateMap<Student, StudentSelectVM>();
           CreateMap<Question, QuestionSelectVM>();
           CreateMap<StudentExam, StudentExamSelectVM>();
            CreateMap<Exam, ExamSelectVM>();
        }
        
    }
}
