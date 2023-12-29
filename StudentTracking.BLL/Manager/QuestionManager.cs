using StudentTracking.BLL.Common;
using StudentTracking.BLL.Mapper;
using StudentTracking.CORE.Entities;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTracking.BLL.Manager
{
    public class QuestionManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MyMapper _mapper;

        public QuestionManager(IUnitOfWork unitOfWork, MyMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result<QuestionInsertVM> Add(QuestionInsertVM VM)
        {
            try
            {
                var entity = _mapper.Map<QuestionInsertVM, Question>(VM);
                bool state = _unitOfWork.QuestionRepository.Add(entity);

                return new Result<QuestionInsertVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<QuestionInsertVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<QuestionUpdateVM> Update(QuestionUpdateVM VM)
        {
            try
            {
                var entity = _mapper.Map<QuestionUpdateVM, Question>(VM);
                bool state = _unitOfWork.QuestionRepository.Update(entity);

                return new Result<QuestionUpdateVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<QuestionUpdateVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<int> HardDelete(int ID)
        {
            try
            {
                bool state = _unitOfWork.QuestionRepository.HardDelete(ID);

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
                bool state = _unitOfWork.QuestionRepository.SoftDelete(ID);

                return new Result<int> { Success = true, Data = ID };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<int> { Success = true, Data = ID, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<QuestionSelectVM> GetByID(int ID)
        {
            QuestionSelectVM VM = null;
            try
            {
                Question entity = _unitOfWork.QuestionRepository.GetByID(ID);
                VM = _mapper.Map<Question, QuestionSelectVM>(entity);

                return new Result<QuestionSelectVM> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<QuestionSelectVM> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        public Result<List<QuestionSelectVM>> GetAll()
        {
            List<QuestionSelectVM> VM = new List<QuestionSelectVM>();
            try
            {
                List<Question> entity = _unitOfWork.QuestionRepository.GetAll().ToList();

                entity.ForEach(x =>
                {
                    VM.Add(_mapper.Map<Question, QuestionSelectVM>(x));
                });

                return new Result<List<QuestionSelectVM>> { Success = true, Data = VM };
            }
            catch (Exception ex)
            {
                // exception loglama
                return new Result<List<QuestionSelectVM>> { Success = false, Data = VM, Message = "Bir hata oluştu. Detaylar için logları kontrol edin." };
            }
        }

        //public IEnumerable<QuestionSelectVM> GetByStudentID(int StudentID)
        //{
        //    var vm = _unitOfWork.QuestionRepository.GetByStudentID(StudentID);

        //    return vm;
        //}
    }
}

