using Dapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.VM.Question;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace StudentTracking.DAL.Repositories.Concrete
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {

        public QuestionRepository(IDbConnection connection,IDbTransaction transaction) : base(connection, transaction)
        {

        }

        public bool Add(Question entity)
        {
            var sqlQuery = "INSERT INTO Question (QuestionName, Description, StudentID, Date) VALUES (@QuestionName, @Description, @StudentID, @Date)";

            var parameters = new DynamicParameters();

            parameters.Add("@QuestionName", entity.QuestionName, DbType.String);
            parameters.Add("@Description", entity.Description, DbType.String);
            parameters.Add("@StudentID", entity.StudentID, DbType.Int32);
            parameters.Add("@Date", entity.Date, DbType.DateTime);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool Update(Question entity)
        {
            var sqlQuery = "UPDATE Question SET QuestionName=@QuestionName, Description=@Description, StudentID = @StudentID, Date = @Date WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", entity.ID, DbType.Int32);
            parameters.Add("@QuestionName", entity.QuestionName, DbType.String);
            parameters.Add("@Description", entity.Description, DbType.String);
            parameters.Add("@StudentID", entity.StudentID, DbType.Int32);
            parameters.Add("@Date", entity.Date, DbType.DateTime);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool HardDelete(int ID)
        {
            var sqlQuery = "DELETE FROM Question WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool SoftDelete(int ID)
        {
            var sqlQuery = "UPDATE Question SET isActive=0 WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public Question GetByID(int ID)
        {
            var sqlQuery = "SELECT * FROM Question WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            return Connection.QuerySingleOrDefault<Question>(sqlQuery, parameters, Transaction);
        }

        public IEnumerable<Question> GetAll()
        {
            var sqlQuery = "SELECT * FROM Question";

            var parameters = new DynamicParameters();

            return Connection.Query<Question>(sqlQuery, parameters, Transaction);
        }

        public IEnumerable<Question> GetByStudentID(int StudentID)
        {

            var sqlQuery = "SELECT * FROM Question WHERE StudentID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", StudentID, DbType.Int32);

            return Connection.Query<Question>(sqlQuery, parameters, Transaction);
        }
    }
}
