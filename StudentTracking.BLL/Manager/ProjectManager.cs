using System;
using System.Collections.Generic;
using System.Text;
using StudentTracking.BLL.Common;
using StudentTracking.BLL.Mapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Project;
using System.Linq;

namespace StudentTracking.BLL.Manager
{
        public class ProjectManager
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly MyMapper _mapper;

            public ProjectManager(IUnitOfWork unitOfWork, MyMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public Result<ProjectInsertVM> Add(ProjectInsertVM VM)
            {
                try
                {
                    var entity = _mapper.Map<ProjectInsertVM, Project>(VM);

                    bool state = _unitOfWork.ProjectRepository.Add(entity);


                    return new Result<ProjectInsertVM> { Success = true, Data = VM };
                }
                catch (Exception ex)
                {
                    // exception loglama
                    return new Result<ProjectInsertVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
                }
            }

            public Result<ProjectUpdateVM> Update(ProjectUpdateVM VM)
            {
                try
                {
                    var entity = _mapper.Map<ProjectUpdateVM, Project>(VM);
                    bool state = _unitOfWork.ProjectRepository.Update(entity);

                    return new Result<ProjectUpdateVM> { Success = true, Data = VM };
                }
                catch (Exception ex)
                {
                    // exception loglama
                    return new Result<ProjectUpdateVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
                }
            }

            public Result<int> HardDelete(int ID)
            {
                try
                {
                    bool state = _unitOfWork.ProjectRepository.HardDelete(ID);

                    return new Result<int> { Success = true, Data = ID };
                }
                catch (Exception ex)
                {
                    // exception loglama
                    return new Result<int> { Success = false, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
                }
            }

            public Result<int> SoftDelete(int ID)
            {
                try
                {
                    bool state = _unitOfWork.ProjectRepository.SoftDelete(ID);

                    return new Result<int> { Success = true, Data = ID };
                }
                catch (Exception ex)
                {
                    // exception loglama
                    return new Result<int> { Success = true, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
                }
            }

            public Result<ProjectSelectVM> GetByID(int ID)
            {
                ProjectSelectVM VM = null;
                try
                {
                    Project entity = _unitOfWork.ProjectRepository.GetByID(ID);
                    VM = _mapper.Map<Project, ProjectSelectVM>(entity);

                    return new Result<ProjectSelectVM> { Success = true, Data = VM };
                }
                catch (Exception ex)
                {
                    // exception loglama
                    return new Result<ProjectSelectVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
                }
            }

            public Result<List<ProjectSelectVM>> GetAll()
            {
                List<ProjectSelectVM> VM = new List<ProjectSelectVM>();
                try
                {
                    List<Project> entity = _unitOfWork.ProjectRepository.GetAll().ToList();

                    entity.ForEach(x =>
                    {
                        VM.Add(_mapper.Map<Project, ProjectSelectVM>(x));
                    });

                    return new Result<List<ProjectSelectVM>> { Success = true, Data = VM };
                }
                catch (Exception ex)
                {
                    // exception loglama
                    return new Result<List<ProjectSelectVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
                }
            }
        }    
}
