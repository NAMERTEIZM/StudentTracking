using StudentTracking.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Transactions;

namespace StudentTracking.DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get; private set; }
        

        public BaseRepository(IDbConnection connection,IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }
    }
}
