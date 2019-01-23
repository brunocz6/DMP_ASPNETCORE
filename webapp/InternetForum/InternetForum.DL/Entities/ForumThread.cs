using InternetForum.DL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetForum.DL.Entities
{
	public class ForumThread : IEntity<int>
	{
		/// <summary>
		/// Vrací nebo nastavuje ID vlákna.
		/// </summary>
		[Key]
		[Required]
		public int Id { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje název vlákna.
		/// </summary>
		[MaxLength(100)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje, kdy bylo vlákno vytvořeno.
		/// </summary>
		[Required]
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje popis vlákna.
		/// </summary>
		[Required]
		public string Description { get; set; }

		/// <summary>
		/// Vrací nebo nastavuje příspěvky, které jsou součástí tohoto vlákna.
		/// </summary>
		public virtual IEnumerable<Post> Posts { get; set; }

		public static ForumThread Create(string name, DateTime createdAt, string description)
		{
			var entity = new ForumThread();

			entity.Name = name;
			entity.CreatedAt = createdAt;
			entity.Description = description;

			return entity;
		}
	}
}