using Dapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.VM.Class;
using StudentTracking.VM.Status;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StudentTracking.DAL.Repositories.Concrete
{
    public class StatusRepository : BaseRepository, IStatusRepository
    {
        public StatusRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public bool Add(Status entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Status> GetAll()
        {
            var sqlQuery = "SELECT * FROM Status";

            var parameters = new DynamicParameters();

            return Connection.Query<Status>(sqlQuery, parameters, Transaction);
        }

        public Status GetByID(int id)
        {
            var sqlQuery = "SELECT * FROM Status WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("ID", id);

            return Connection.QuerySingleOrDefault<Status>(sqlQuery, parameters, Transaction);
        }

        public bool HardDelete(int ID)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Update(Status VM)
        {
            throw new NotImplementedException();
        }


    }
}