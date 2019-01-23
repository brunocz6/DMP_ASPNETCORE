using InternetForum.DL;
using InternetForum.DL.Entities;
using InternetForum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Controllers
{
	public class PostController : BaseController
	{
		public PostController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
			: base(unitOfWork, userManager)
		{
		}


		[Authorize]
		public IActionResult MyPosts(int page = 1)
		{
			var posts = this.unitOfWork.PostRepository.GetAll().ToList();

			var model = posts.Select(p => PostDetailsViewModel.CreateFromEntity(p));

			return View(model);
		}

		[Authorize]
		public IActionResult Create()
		{
			var model = new CreatePostViewModel();

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(CreatePostViewModel model)
		{
			var forumThreadId = this.unitOfWork.ForumThreadRepository.FirstOrDefault().Id;
			var post = model.CreateEntity(GetCurrentUser().Id, forumThreadId);

			this.unitOfWork.PostRepository.Add(post);
			this.unitOfWork.Save();

			return RedirectToAction("Index", "Home", null);
		}

		[Authorize]
		public IActionResult Edit(int id)
		{
			var post = this.unitOfWork.PostRepository.GetById(id);
			var model = EditPostViewModel.CreateFromEntity(post);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Edit(EditPostViewModel model)
		{
			var post = this.unitOfWork.PostRepository.GetById(model.Id);

			model.UpdateEntity(post);
			this.unitOfWork.PostRepository.Update(post);

			return RedirectToAction("Index", "Home", null);
		}

		public IActionResult Detail(int id, int page = 1)
		{
			var post = this.unitOfWork.PostRepository.GetById(id);

			if (post == null)
				return NotFound();

			var model = PostViewModel.CreateFromEntity(post, page, 10);

			model.Comments.Action = nameof(Detail);

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public IActionResult Delete(int id)
		{
			var post = this.unitOfWork.PostRepository.GetById(id);

			if (post != null && post.Author.Id == GetCurrentUserId())
			{
				this.unitOfWork.PostRepository.Remove(post);
				this.unitOfWork.Save();
			}

			return RedirectToAction(nameof(MyPosts));
		}
	}
}