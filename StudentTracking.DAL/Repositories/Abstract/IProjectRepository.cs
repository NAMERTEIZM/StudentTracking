using StudentTracking.CORE.Entities;
using StudentTracking.VM.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.DAL.Repositories.Abstract
{
    public interface IProjectRepository
    {
        bool Add(Project VM);
        bool Update(Project VM);
        bool HardDelete(int ID);
        bool SoftDelete(int ID);
        Project GetByID(int ID);
        IEnumerable<Project> GetAll();
    }
}
