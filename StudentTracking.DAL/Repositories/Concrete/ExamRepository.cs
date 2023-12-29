using Dapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.VM.Exam;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentTracking.DAL.Repositories.Concrete
{
    public class ExamRepository : BaseRepository, IExamRepository
    {
        public ExamRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public bool Add(Exam entity)
        {
            var sqlQuery = "INSERT INTO Exam (Name, Body, StatusID, Date) VALUES (@Name ,@Body, @StatusID, @Date)";

            var parameters = new DynamicParameters();

            parameters.Add("@Body", entity.Body, DbType.String);
            parameters.Add("@Name", entity.Name, DbType.String);
            parameters.Add("@StatusID", entity.StatusID, DbType.Int32);
            parameters.Add("@Date", entity.Date, DbType.DateTime);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public IEnumerable<Exam> GetAll()
        {
            var sqlQuery = "SELECT * FROM Exam";

            var parameters = new DynamicParameters();

            return Connection.Query<Exam>(sqlQuery, parameters, Transaction);
        }

        public Exam GetByID(int ID)
        {
            var sqlQuery = "SELECT * FROM Exam WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            return Connection.QuerySingleOrDefault<Exam>(sqlQuery, parameters, Transaction);
        }

        public bool HardDelete(int ID)
        {
            var sqlQuery = "DELETE FROM Exam WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool SoftDelete(int ID)
        {
            var sqlQuery = "UPDATE Exam SET isActive = 0 WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool Update(Exam entity)
        {
            var sqlQuery = "UPDATE Exam SET Body=@Body, StatusID=@StatusID, Date=@Date, Name=@Name WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", entity.ID, DbType.Int32);
            parameters.Add("@Body", entity.Body, DbType.String);
            parameters.Add("@Name", entity.Name, DbType.String);
            parameters.Add("@StatusID", entity.StatusID, DbType.Int32);
            parameters.Add("@Date", entity.Date, DbType.DateTime);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public IEnumerable<Exam> GetAllWithStatus()
        {
            var sqlQuery = "select e.ID,e.[Name],e.Body,e.Date,e.isActive,s.Name as StatusName from Exam e \r\ninner join Status s ON s.ID = e.StatusID";

            var parameters = new DynamicParameters();


            return Connection.Query<Exam>(sqlQuery, parameters, Transaction);
        }
    }
}