using StudentTracking.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository QuestionRepository { get; }
        IReportRepository ReportRepository { get; }
        IClassRepository ClassRepository { get; }
        IExamRepository ExamRepository { get; }
        IStudentRepository StudentRepository { get; }
        IProjectRepository ProjectRepository { get; }

        IStatusRepository StatusRepository { get; }

        void Commit();
        void BeginTransaction();
    }
}
