using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetForum.Models;
using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;

namespace InternetForum.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager) : base(unitOfWork, userManager)
		{
		}

		public IActionResult Index(int page = 1)
		{
			var posts = this.unitOfWork.PostRepository.GetMostRecentPosts(page, 20);

			var postsViewModels = posts.Select(p => PostPreviewViewModel.CreateFromEntity(p));

			var model = new HomeIndexViewModel(postsViewModels);

			return View(model);
		}
	}
}