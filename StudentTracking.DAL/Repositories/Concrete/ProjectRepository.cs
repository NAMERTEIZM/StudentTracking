using Dapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.Repositories.Abstract;
using StudentTracking.VM.Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace StudentTracking.DAL.Repositories.Concrete
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }

        public bool Add(Project entity)
        {
            var sqlQuery = "INSERT INTO Project (Name, StartedDate, EndDate, isFinal) VALUES (@Name, @StartedDate, @EndDate, @IsFinal)";
            var success = false;

            var parameters = new DynamicParameters();

            parameters.Add("@Name", entity.Name, DbType.String);
            parameters.Add("@StartedDate", entity.StartedDate, DbType.DateTime);
            parameters.Add("@EndDate", entity.EndDate, DbType.DateTime);
            parameters.Add("@IsFinal", entity.isFinal, DbType.Boolean);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            if (rowsAffected > 0)
            {
                success = AddProjectStudent(entity);
            }

            return success;
        }

        private bool AddProjectStudent(Project entity)
        {
            var sqlQueryProject = "INSERT INTO StudentProject (StudentID, ProjectID, Score, Description) VALUES (@StudentID, @ProjectID, @Score, @Description)";
            var success = false;

            var projectID = Connection.Query<int>("SELECT @@IDENTITY;", transaction: Transaction).FirstOrDefault();
            entity.StudentProject.ToList().ForEach(x =>
            {

                var parameters = new DynamicParameters();

                parameters.Add("@StudentID", x.StudentID, DbType.Int32);
                parameters.Add("@ProjectID", projectID, DbType.Int32);
                parameters.Add("@Score", 0, DbType.Int32);
                parameters.Add("@Description", "", DbType.String);

                int rowsAffected = Connection.Execute(sqlQueryProject, parameters, Transaction);

                if (rowsAffected > 0)
                {
                    success = true;
                }
            });

            return success;
        }

        private bool UpdateProjectStudent(Project entity)
        {
            var sqlQueryProject = "UPDATE StudentProject SET StudentID=@StudentID, ProjectID=@ProjectID, Score=@Score, Description=@Description";
            var success = false;

            entity.StudentProject.ToList().ForEach(x =>
            {
                var parameters = new DynamicParameters();

                parameters.Add("@StudentID", x.StudentID, DbType.Int32);
                parameters.Add("@ProjectID", x.ProjectID, DbType.Int32);
                parameters.Add("@Score", 0, DbType.Int32);
                parameters.Add("@Description", "", DbType.String);

                int rowsAffected = Connection.Execute(sqlQueryProject, parameters, Transaction);

                if (rowsAffected > 0)
                {
                    success = true;
                }
            });

            return success;
        }

        public IEnumerable<Project> GetAll()
        {
            var sqlQuery = "SELECT * FROM Project";

            return Connection.Query<Project>(sqlQuery, transaction: Transaction);
        }

        public Project GetByID(int ID)
        {
            var sqlQuery = "SELECT * FROM Project WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            return Connection.QuerySingleOrDefault<Project>(sqlQuery, parameters, Transaction);
        }

        public bool HardDelete(int ID)
        {
            var sqlQuery = "DELETE FROM Project WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool SoftDelete(int ID)
        {
            var sqlQuery = "UPDATE Project SET isActive = 0 WHERE ID = @ID";

            var parameters = new DynamicParameters();

            parameters.Add("@ID", ID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            return rowsAffected > 0;
        }

        public bool Update(Project entity)
        {
            var sqlQuery = "UPDATE Project SET Name=@Name, StartedDate=@StartedDate, EndDate=@EndDate, isFinal=@IsFinal WHERE ID = @ID";
            var success=false;

            var parameters = new DynamicParameters();

            parameters.Add("@ID", entity.ID, DbType.Int32);
            parameters.Add("@Name", entity.Name, DbType.String);
            parameters.Add("@StartedDate", entity.StartedDate, DbType.DateTime);
            parameters.Add("@EndDate", entity.EndDate, DbType.DateTime);
            parameters.Add("@IsFinal", entity.isFinal, DbType.Boolean);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            if (rowsAffected > 0)
            {
                success = UpdateProjectStudent(entity);
            }

            return success;
        }

        public void AddProjectStudent(int projectID, int studentID)
        {
            var sqlQuery = "INSERT INTO StudentProject (StudentID, ProjectID) VALUES (@StudentID, @ProjectID)";

            var parameters = new DynamicParameters();

            parameters.Add("@StudentID", studentID, DbType.Int32);
            parameters.Add("@ProjectID", projectID, DbType.Int32);

            var rowsAffected = Connection.Execute(sqlQuery, parameters, Transaction);

            //return rowsAffected > 0;
        }
    }
}
