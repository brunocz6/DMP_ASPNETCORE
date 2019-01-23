using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetForum.Models;
using InternetForum.DL;
using InternetForum.DL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using ReflectionIT.Mvc.Paging;

namespace InternetForum.Controllers
{
	[Authorize(Roles = "Administrator")]
	public class ForumThreadController : BaseController
	{
		public ForumThreadController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager) : base(unitOfWork, userManager)
		{
		}

		public IActionResult Create()
		{
			var model = new CreateForumThreadViewModel();

			return View(model);
		}

		public IActionResult List(int page = 1)
		{
			var posts = this.unitOfWork.ForumThreadRepository.GetAll().ToList();

			var model = posts.Select(ft => ForumThreadListItemViewModel.CreateFromEntity(ft));

			return View(model);
		}

		[HttpPost]
		public IActionResult Create(CreateForumThreadViewModel model)
		{
			var forumThread = model.CreateEntity();

			this.unitOfWork.ForumThreadRepository.Add(forumThread);
			this.unitOfWork.Save();

			return RedirectToAction("Index","Home");
		}

		public IActionResult Edit(int id)
		{
			var forumThread = this.unitOfWork.ForumThreadRepository.GetById(id);
			var model = EditForumThreadViewModel.CreateFromEntity(forumThread);

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(EditForumThreadViewModel model)
		{
			var forumThread = this.unitOfWork.ForumThreadRepository.GetById(model.Id);

			model.UpdateEntity(forumThread);
			this.unitOfWork.ForumThreadRepository.Update(forumThread);

			return RedirectToAction("List", "ForumThread");
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var forumThread = this.unitOfWork.ForumThreadRepository.GetById(id);

			if (forumThread != null && this.unitOfWork.ForumThreadRepository.GetAll().Count() != 1)
				this.unitOfWork.ForumThreadRepository.Remove(forumThread);

			this.unitOfWork.Save();

			return RedirectToAction("List", "ForumThread");
		}
	}
}