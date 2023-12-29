using StudentTracking.CORE.Entities;
using StudentTracking.VM.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.DAL.Repositories.Abstract
{
    public interface IQuestionRepository
    {
        bool Add(Question VM);
        bool Update(Question VM);
        bool HardDelete(int ID);
        bool SoftDelete(int ID);
        Question GetByID(int ID);
        IEnumerable<Question> GetAll();
        IEnumerable<Question> GetByStudentID(int StudentID);
    }
}
