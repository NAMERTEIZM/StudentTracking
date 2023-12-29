using StudentTracking.BLL.Common;
using StudentTracking.BLL.Mapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTracking.BLL.Manager
{
    public class StudentManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyMapper _mapper;

        public StudentManager(IUnitOfWork unitOfWork, MyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<StudentInsertVM> Add(StudentInsertVM VM)
        {
            try
            {
                var entity = _mapper.Map<StudentInsertVM, Student>(VM);
                bool state = _unitOfWork.StudentRepository.Add(entity);

                return new Result<StudentInsertVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<StudentInsertVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<StudentUpdateVM> Update(StudentUpdateVM VM)
        {
            try
            {
                var entity = _mapper.Map<StudentUpdateVM, Student>(VM);
                bool state = _unitOfWork.StudentRepository.Update(entity);

                return new Result<StudentUpdateVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<StudentUpdateVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<int> HardDelete(int ID)
        {
            try
            {
                bool state = _unitOfWork.StudentRepository.HardDelete(ID);

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
                bool state = _unitOfWork.StudentRepository.SoftDelete(ID);

                return new Result<int> { Success = true, Data = ID };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<int> { Success = true, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<StudentSelectVM> GetByID(int ID)
        {
            StudentSelectVM VM = null;
            try
            {
                Student entity = _unitOfWork.StudentRepository.GetByID(ID);
                VM = _mapper.Map<Student, StudentSelectVM>(entity);

                return new Result<StudentSelectVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<StudentSelectVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<List<StudentSelectVM>> GetAll()
        {
            List<StudentSelectVM> VM = new List<StudentSelectVM>();
            try
            {
                List<Student> entity = _unitOfWork.StudentRepository.GetAll().ToList();

                entity.ForEach(x =>
                {
                    VM.Add(_mapper.Map<Student, StudentSelectVM>(x));
                });

                return new Result<List<StudentSelectVM>> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<List<StudentSelectVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<List<StudentFullNameVM>> GetAllStudentByProject(int projectId)
        {
            List<StudentFullNameVM> VM = new List<StudentFullNameVM>();
            try
            {
                List<Student> entity = _unitOfWork.StudentRepository.GetAllStudentByProject(projectId).ToList();

                entity.ForEach(x =>
                {
                    VM.Add(_mapper.Map<Student, StudentFullNameVM>(x));
                });

                return new Result<List<StudentFullNameVM>> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<List<StudentFullNameVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        //public IEnumerable<StudentSelectVM> GetByClassID(int ID)
        //{
        //    var vm = _unitOfWork.StudentRepository.GetByClassID(ID);

        //    return vm;
        //}

        public Result<List<StudentSelectVM>> GetStudentWithDetailsByClassID(int classID)
		{
            List<StudentSelectVM> VM = new List<StudentSelectVM>();
			try
			{
                List<Student>students = _unitOfWork.StudentRepository.GetStudentWithDetails(classID).ToList();

                VM = students.Select(x => _mapper.Map<Student, StudentSelectVM>(x)).ToList();
                return new Result<List<StudentSelectVM>> { Data = VM, Success = true };
			}
			catch (Exception ex)
			{
                return new Result<List<StudentSelectVM>>
                {
                    Success = false,
                    Data = VM,
                    Message = "Bir şeyler ters gitti."
                };
                throw;
			}

		}
        public Result<List<StudentSelectVM>> GetStudentWithDetailsReport(int classID,int week)
        {
            List<StudentSelectVM> VM = new List<StudentSelectVM>();
            try
            {
                List<Student> students = _unitOfWork.StudentRepository.GetStudentWithDetailsReport(classID,week).ToList();

                VM = students.Select(x => _mapper.Map<Student, StudentSelectVM>(x)).ToList();
                return new Result<List<StudentSelectVM>> { Data = VM, Success = true };
            }
            catch (Exception ex)
            {
                return new Result<List<StudentSelectVM>>
                {
                    Success = false,
                    Data = VM,
                    Message = "Bir şeyler ters gitti."
                };
                throw;
            }

        }


        public IEnumerable<StudentSelectVM> GetStudentsByClass(int classId)
        {
            var vm = _unitOfWork.StudentRepository.GetStudentsByClass(classId);

            return vm;
        }
    }
}
