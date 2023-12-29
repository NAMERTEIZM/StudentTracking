using Dapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.VM.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace StudentTracking.DAL.Repositories.Concrete
{
    public class ClassRepository : BaseRepository, IClassRepository
    {
        public ClassRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public bool Add(Class entity)
        {
            var sqlQuery = "INSERT INTO Class (Name, Capacity, StartedDate, EndDate) VALUES (@Name, @Capacity, @StartedDate, @EndDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@Name", entity.Name, DbType.String);
            parameters.Add("@Capacity", entity.Capacity, DbType.Int32);
            parameters.Add("@StartedDate", entity.StartedDate, DbType.DateTime);
            parameters.Add("@EndDate", entity.EndDate, DbType.DateTime);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public IEnumerable<Class> GetAll()
        {
            var sqlQuery = "SELECT * FROM Class";

            var parameters = new DynamicParameters();

            return Connection.Query<Class>(sqlQuery, parameters, Transaction);
        }

        public Class GetByID(int ID)
        {
            var sqlQuery = "SELECT * FROM Class WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            return Connection.QuerySingleOrDefault<Class>(sqlQuery, parameters, Transaction);
        }

        public bool HardDelete(int ID)
        {
            var sqlQuery = "DELETE FROM Class WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool SoftDelete(int ID)
        {
            var sqlQuery = "UPDATE Class SET isActive = 0 WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool Update(Class entity)
        {
            var sqlQuery = "UPDATE Class SET Name=@Name, Capacity=@Capacity, StartedDate=@StartedDate, EndDate=@EndDate WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", entity.ID, DbType.Int32);
            parameters.Add("@Name", entity.Name, DbType.String);
            parameters.Add("@Capacity", entity.Capacity, DbType.Int32);
            parameters.Add("@StartedDate", entity.StartedDate, DbType.DateTime);
            parameters.Add("@EndDate", entity.EndDate, DbType.DateTime);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public ClassSelectVM GetNameById(int id)
        {
            var sqlQuery = "SELECT Name FROM Class WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id);

            return Connection.QuerySingleOrDefault<ClassSelectVM>(sqlQuery, parameters, Transaction);
        }
    }
}
