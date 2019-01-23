using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetForum.DL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using InternetForum.DL.Entities;
using InternetForum.Models;

namespace InternetForum.Controllers
{
	[Authorize]
	public class CommentController : BaseController
	{
		public CommentController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager) : base(unitOfWork, userManager)
		{
		}

		public IActionResult Add(CreateCommentViewModel model)
		{
			var comment = model.CreateEntity(GetCurrentUserId());

			this.unitOfWork.CommentRepository.Add(comment);
			this.unitOfWork.Save();

			return RedirectToAction("Detail", "Post", new { id = model.PostId });
		}

		public IActionResult Delete(int commentId)
		{
			var comment = this.unitOfWork.CommentRepository.GetById(commentId);

			if (comment != null && comment.AuthorId == GetCurrentUserId())
			{
				this.unitOfWork.CommentRepository.Remove(comment);
				this.unitOfWork.Save();

				return Json(new { success = true, responseText = "Komentář byl úspěšně odebrán." });
			}
			else
			{
				return Json(new { success = false, responseText = "Komentář se nepodařilo odebrat." });
			}
		}
	}
}