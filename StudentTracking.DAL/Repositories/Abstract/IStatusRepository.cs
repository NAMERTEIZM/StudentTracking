using StudentTracking.CORE.Entities;
using StudentTracking.VM.Class;
using StudentTracking.VM.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.DAL.Repositories.Abstract
{
    public interface IStatusRepository
    {
        bool Add(Status VM);
        bool Update(Status VM);
        bool HardDelete(int ID);
        bool SoftDelete(int ID);
        public Status GetByID(int id);
        IEnumerable<Status> GetAll();
    }
}