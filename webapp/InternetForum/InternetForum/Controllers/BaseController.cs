using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IUnitOfWork unitOfWork;
		protected readonly UserManager<ApplicationUser> userManager;

		protected IUnitOfWork UnitOfWork => unitOfWork;

		public BaseController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
		{
			this.unitOfWork = unitOfWork;
			this.userManager = userManager;
		}

		protected ApplicationUser GetCurrentUser()
		{
			return this.userManager.FindByIdAsync(GetCurrentUserId()).Result;
		}

		protected string GetCurrentUserId()
		{
			return this.userManager.GetUserId(HttpContext.User);
		}
	}
}