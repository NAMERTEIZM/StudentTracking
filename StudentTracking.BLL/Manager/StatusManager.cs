using StudentTracking.BLL.Common;
using StudentTracking.BLL.Mapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Class;
using StudentTracking.VM.Exam;
using StudentTracking.VM.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTracking.BLL.Manager
{
    public class StatusManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyMapper _mapper;

        public StatusManager(IUnitOfWork unitOfWork, MyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<StatusInsertVM> Add(StatusInsertVM VM)
        {
            try
            {
                var entity = _mapper.Map<StatusInsertVM, Status>(VM);
                bool state = _unitOfWork.StatusRepository.Add(entity);

                return new Result<StatusInsertVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<StatusInsertVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<StatusUpdateVM> Update(StatusUpdateVM VM)
        {
            try
            {
                var entity = _mapper.Map<StatusUpdateVM, Status>(VM);
                bool state = _unitOfWork.StatusRepository.Update(entity);

                return new Result<StatusUpdateVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<StatusUpdateVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<int> HardDelete(int ID)
        {
            try
            {
                bool state = _unitOfWork.StatusRepository.HardDelete(ID);

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
                bool state = _unitOfWork.StatusRepository.SoftDelete(ID);

                return new Result<int> { Success = true, Data = ID };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<int> { Success = true, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<StatusSelectVM> GetByID(int ID)
        {
            StatusSelectVM VM = null;
            try
            {
                Status entity = _unitOfWork.StatusRepository.GetByID(ID);
                VM = _mapper.Map<Status, StatusSelectVM>(entity);

                return new Result<StatusSelectVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<StatusSelectVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<List<StatusSelectVM>> GetAll()
        {
            List<StatusSelectVM> VM = new List<StatusSelectVM>();
            try
            {
                List<Status> entity = _unitOfWork.StatusRepository.GetAll().ToList();

                entity.ForEach(x =>
                {
                    VM.Add(_mapper.Map<Status, StatusSelectVM>(x));
                });

                return new Result<List<StatusSelectVM>> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<List<StatusSelectVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }
    }
}
