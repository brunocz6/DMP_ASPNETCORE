using InternetForum.DL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetForum.DL.Entities
{
	public class Comment : IEntity<int>
	{
		/// <summary>
		/// Vrací nebo nastavuje ID komentáře.
		/// </summary>
		[Key]
		[Required]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje text komentáře.
		/// </summary>
		[MaxLength(255)]
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy byl příspěvek vytvořen.
		/// </summary>
		[Required]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje Id autora.
		/// </summary>
		[Required]
		public string AuthorId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje autora komentáře
		/// </summary>
		[Required]
		public virtual ApplicationUser Author { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje Id příspěvku, pod který komentář patří.
		/// </summary>
		[Required]
		public int PostId { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje příspěvek, pod který komentář patří.
		/// </summary>
		[Required]
		public virtual Post Post { get; set; }
	}
}