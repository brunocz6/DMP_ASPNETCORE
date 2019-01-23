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
using ReflectionIT.Mvc.Paging;

namespace InternetForum.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager) : base(unitOfWork, userManager)
		{
		}

		public IActionResult Index(int page = 1)
		{
			var mainThreadId = this.unitOfWork.ForumThreadRepository.FirstOrDefault().Id;

			var postsViewModels = this.unitOfWork.PostRepository
				.GetPostsByForumThreadId(mainThreadId)
				.ToList()
				.Select(p => PostPreviewViewModel.CreateFromEntity(p));

			var pagedPosts = PagingList.Create(postsViewModels, 10, page);

			var model = new HomeIndexViewModel(pagedPosts);

			return View(model);
		}
	}
}