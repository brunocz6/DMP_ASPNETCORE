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

		public HomeIndexViewModel(IEnumerable<PostPreviewViewModel> posts)
		{
			this.Posts = posts;
		}

		/// <summary>
		/// Vrací nebo nastavuje kolekci příspěvků.
		/// </summary>
		public IEnumerable<PostPreviewViewModel> Posts { get; set; }
	}
}