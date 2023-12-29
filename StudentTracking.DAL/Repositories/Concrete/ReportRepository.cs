using Dapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.VM.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentTracking.DAL.Repositories.Concrete
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        //base repository yi IDBconnection, Itransaction değişkenlerini burada tekrar yazmamak için kullandik
        public ReportRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public bool Add(Report entity)
        {
            var sqlQuery = "INSERT INTO Report (StudentID, Description, Score, Date, WeekOfYear) VALUES (@StudentID, @Description, @Score, @Date, @WeekOfYear)";

            var parameters = new DynamicParameters();

            parameters.Add("@StudentID", entity.StudentID, DbType.Int32);
            parameters.Add("@Description", entity.Description, DbType.String);
            parameters.Add("@Score", entity.Score, DbType.Int32);
            parameters.Add("@Date", entity.Date, DbType.DateTime);
            parameters.Add("@WeekOfYear", entity.WeekOfYear, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public IEnumerable<Report> GetAll()
        {
            var sqlQuery = "SELECT * FROM Report";

            var parameters = new DynamicParameters();

            return Connection.Query<Report>(sqlQuery, parameters, Transaction);
        }

        public Report GetByID(int ID)
        {
            var sqlQuery = "SELECT * FROM Report WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            return Connection.QuerySingleOrDefault<Report>(sqlQuery, parameters, Transaction);
        }

        public bool HardDelete(int ID)
        {
            var sqlQuery = "DELETE FROM Report WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool SoftDelete(int ID)
        {
            var sqlQuery = "UPDATE Report SET isActive = 0 WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool Update(Report VM)
        {
            var sqlQuery = "UPDATE Report SET StudentID=@StudentID, Description=@Description, Score=@Score, Date=@Date, WeekOfYear=@WeekOfYear WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", VM.ID, DbType.Int32);
            parameters.Add("@StudentID", VM.StudentID, DbType.Int32);
            parameters.Add("@Description", VM.Description, DbType.String);
            parameters.Add("@Score", VM.Score, DbType.Int32);
            parameters.Add("@Date", VM.Date, DbType.DateTime);
            parameters.Add("@WeekOfYear", VM.WeekOfYear, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public IEnumerable<Report> GetAllWithStudentID()
        {
            var sqlQuery = "SELECT r.ID,FirstName+' '+LastName as FullName,r.isActive,student.firstName,student.LastName,r.Description,r.Score,r.Date,r.WeekOfYear\r\nFROM Report r\r\nJOIN Student ON r.StudentID = Student.ID;";
            var parameters = new DynamicParameters();

            return Connection.Query<Report>(sqlQuery, parameters, Transaction);

        }
    }
}