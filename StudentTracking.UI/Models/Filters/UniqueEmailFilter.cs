using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentTracking.DAL.UnitOfWork;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.Models.Filters
{
	public class UniqueEmailFilter : ActionFilterAttribute
	{
		private readonly IUnitOfWork _unitOfWork;
		public UniqueEmailFilter(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{

			var student = context.ActionArguments["studentInsertVM"] as StudentInsertVM;

			if (!(_unitOfWork.StudentRepository.GetAll().Any(x => x.Email == student.Email)))
			{
				next();
			}
			else
			{
				context.Result = new ConflictObjectResult("Aynı email adresiyle kayıtlı bir öğrenci bulunmaktadır.");

			}
			return base.OnActionExecutionAsync(context, next);
		}
	}
}
