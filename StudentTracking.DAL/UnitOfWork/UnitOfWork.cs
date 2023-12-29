using StudentTracking.DAL.Helper;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StudentTracking.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        
        private bool _dispose;

        private IQuestionRepository _questionRepository;
        private IReportRepository _reportRepository;
        private IClassRepository _classRepository;
        private IExamRepository _examRepository;
        private IStudentRepository _studentRepository;
        private IProjectRepository _projectRepository;
        private IStatusRepository _statusRepository;

        public UnitOfWork()
        {
            _connection = new SqlConnection(ConnectionHelper.GetConnectionString());
            _connection.Open();          
        }

        // IQuestionRepository çünkü QuestionRepository yerine başka bir class daha newleyip gönderebiliriz. örn: QuestionRepository2
        public IQuestionRepository QuestionRepository
        {
            get { return _questionRepository ?? (_questionRepository = new QuestionRepository(_connection,_transaction)); }
        }

        public IStatusRepository StatusRepository
        {
            get { return _statusRepository ?? (_statusRepository = new StatusRepository(_connection, _transaction)); }
        }

        public IReportRepository ReportRepository
        {
            get { return _reportRepository ?? (_reportRepository = new ReportRepository(_connection, _transaction)); }
        }

        public IClassRepository ClassRepository
        {
            get { return _classRepository ?? (_classRepository = new ClassRepository(_connection, _transaction)); }
        }

        public IExamRepository ExamRepository
        {
            get { return _examRepository ?? (_examRepository = new ExamRepository(_connection, _transaction)); }
        }

        public IStudentRepository StudentRepository
        {
            get { return _studentRepository ?? (_studentRepository = new StudentRepository(_connection, _transaction)); }
        }

        public IProjectRepository ProjectRepository
        {
            get { return _projectRepository ?? (_projectRepository = new ProjectRepository(_connection, _transaction)); }
        }

        public void BeginTransaction()
        {
            try
            {
                _transaction = _connection.BeginTransaction();
            }
            catch (Exception)
            {

                throw;
            }         
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();  
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();                        
                //resetRepositories(); // bagacaz
            }
        }

        //private void resetRepositories()
        //{
        //    _questionRepository = null;
        //}

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_dispose)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _dispose = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
