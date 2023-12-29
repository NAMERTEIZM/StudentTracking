using StudentTracking.CORE.Entities;
using StudentTracking.VM.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.DAL.Repositories.Abstract
{
    public interface IClassRepository
    {
        bool Add(Class VM);
        bool Update(Class VM);
        bool HardDelete(int ID);
        bool SoftDelete(int ID);
        Class GetByID(int ID);
        ClassSelectVM GetNameById(int id);
        IEnumerable<Class> GetAll();
    }
}
