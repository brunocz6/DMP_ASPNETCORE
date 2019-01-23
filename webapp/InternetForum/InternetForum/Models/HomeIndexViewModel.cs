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

		public HomeIndexViewModel(PagingList<PostPreviewViewModel> posts,
			IEnumerable<ForumThreadInfoViewModel> forumThreads, ForumThreadInfoPanelViewModel forumThread)
		{
			this.Posts = posts;
			this.ForumThreads = forumThreads;
			this.CurrentForumThread = forumThread;
		}

		/// <summary>
		/// Vrací nebo nastavuje název vlákna příspěvků.
		/// </summary>
		public ForumThreadInfoPanelViewModel CurrentForumThread { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci základních informací o vláknech příspěvků.
		/// </summary>
		public IEnumerable<ForumThreadInfoViewModel> ForumThreads { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje kolekci příspěvků.
		/// </summary>
		public PagingList<PostPreviewViewModel> Posts { get; set; }
	}
}