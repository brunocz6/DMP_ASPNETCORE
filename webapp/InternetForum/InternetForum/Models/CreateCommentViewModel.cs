﻿using InternetForum.DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternetForum.Models
{
	public class CreateCommentViewModel
	{
		/// <summary>
		/// Vrací nebo nastavuje obsah komentáře. 
		/// </summary>
		[Required]
		[MinLength(1)]
		[MaxLength(255)]
		public string Body { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje ke kterému příspěvku komentář patří.
		/// </summary>
		public int PostId { get; set; }

		public Comment CreateEntity(string authorId)
		{
			return Comment.Create(this.Body, authorId, this.PostId, DateTime.Now);
		}
	}
}