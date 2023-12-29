using Microsoft.AspNetCore.Mvc;
using StudentTracking.VM.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTracking.UI.ViewComponents
{
	public class CardViewComponent :ViewComponent
	{
		public IViewComponentResult Invoke(StudentSelectVM model)
		{
			return View(model);
		}
	}
}
