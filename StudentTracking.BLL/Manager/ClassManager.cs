using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Class;
using System;
using System.Collections.Generic;
using System.Text;
using StudentTracking.BLL.Mapper;
using StudentTracking.CORE.Entities;
using StudentTracking.BLL.Common;
using System.Linq;
using StudentTracking.VM.Student;

namespace StudentTracking.BLL.Manager
{
    public class ClassManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyMapper _mapper;

        public ClassManager(IUnitOfWork unitOfWork, MyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<ClassInsertVM> Add(ClassInsertVM VM)
        {
            try
            {
                var entity = _mapper.Map<ClassInsertVM, Class>(VM);
                bool state = _unitOfWork.ClassRepository.Add(entity);

                return new Result<ClassInsertVM> { Success=true, Data=VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<ClassInsertVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<ClassUpdateVM> Update(ClassUpdateVM VM)
        {
            try
            {
                var entity = _mapper.Map<ClassUpdateVM, Class>(VM);
                bool state = _unitOfWork.ClassRepository.Update(entity);

                return new Result<ClassUpdateVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<ClassUpdateVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<int> HardDelete(int ID)
        {
            try
            {
                bool state = _unitOfWork.ClassRepository.HardDelete(ID);

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
                bool state = _unitOfWork.ClassRepository.SoftDelete(ID);

                return new Result<int> { Success = true, Data = ID };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<int> { Success = true, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<ClassSelectVM> GetByID(int ID)
        {
            ClassSelectVM VM = null;
            try
            {
                Class entity = _unitOfWork.ClassRepository.GetByID(ID);
                VM = _mapper.Map<Class, ClassSelectVM>(entity);

                return new Result<ClassSelectVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<ClassSelectVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<List<ClassSelectVM>> GetAll()
        {
            List<ClassSelectVM> VM = new List<ClassSelectVM>();
            try
            {
                List<Class> entity = _unitOfWork.ClassRepository.GetAll().ToList();

                entity.ForEach(x => 
                {
                    VM.Add(_mapper.Map<Class, ClassSelectVM>(x));
                });
              
                return new Result<List<ClassSelectVM>> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<List<ClassSelectVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public ClassSelectVM GetNameById(int id)
        {
            var vm = _unitOfWork.ClassRepository.GetNameById(id);
            return vm;
        }


    }
}
