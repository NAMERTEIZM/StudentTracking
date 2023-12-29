using StudentTracking.CORE.Entities;
using StudentTracking.VM.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracking.DAL.Repositories.Abstract
{
    public interface IReportRepository
    {
        bool Add(Report VM);
        bool Update(Report VM);
        bool HardDelete(int ID);
        bool SoftDelete(int ID);
        Report GetByID(int ID);
        IEnumerable<Report> GetAll();
        IEnumerable<Report> GetAllWithStudentID();
    }
}
