using PagedList;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class HomeIndexViewModel
	{
		public HomeIndexViewModel()
		{

		}

		public HomeIndexViewModel(PagingList<PostPreviewViewModel> posts, string forumThreadName)
		{
			this.Posts = posts;
			this.ForumThreadName = forumThreadName;
		}

		/// <summary>
		/// Vrací nebo nastavuje název vlákna příspěvků.
		/// </summary>
		public string ForumThreadName { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci příspěvků.
		/// </summary>
		public PagingList<PostPreviewViewModel> Posts { get; set; }
	}
}