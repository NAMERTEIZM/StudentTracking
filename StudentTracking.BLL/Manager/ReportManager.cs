using StudentTracking.BLL.Common;
using StudentTracking.BLL.Mapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTracking.BLL.Manager
{
    public class ReportManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyMapper _mapper;

        public ReportManager(IUnitOfWork unitOfWork, MyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<ReportInsertVM> Add(ReportInsertVM VM)
        {
            try
            {
                var entity = _mapper.Map<ReportInsertVM, Report>(VM);
                bool state = _unitOfWork.ReportRepository.Add(entity);

                return new Result<ReportInsertVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<ReportInsertVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<ReportUpdateVM> Update(ReportUpdateVM VM)
        {
            try
            {
                var entity = _mapper.Map<ReportUpdateVM, Report>(VM);
                bool state = _unitOfWork.ReportRepository.Update(entity);

                return new Result<ReportUpdateVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<ReportUpdateVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<int> HardDelete(int ID)
        {
            try
            {
                bool state = _unitOfWork.ReportRepository.HardDelete(ID);

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
                bool state = _unitOfWork.ReportRepository.SoftDelete(ID);

                return new Result<int> { Success = true, Data = ID };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<int> { Success = true, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<ReportSelectVM> GetByID(int ID)
        {
            ReportSelectVM VM = null;
            try
            {
                Report entity = _unitOfWork.ReportRepository.GetByID(ID);
                VM = _mapper.Map<Report, ReportSelectVM>(entity);

                return new Result<ReportSelectVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<ReportSelectVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<List<ReportSelectVM>> GetAll()
        {
            List<ReportSelectVM> VM = new List<ReportSelectVM>();
            try
            {
                List<Report> entity = _unitOfWork.ReportRepository.GetAll().ToList();

                entity.ForEach(x =>
                {
                    VM.Add(_mapper.Map<Report, ReportSelectVM>(x));
                });

                return new Result<List<ReportSelectVM>> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<List<ReportSelectVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }
    }
}

