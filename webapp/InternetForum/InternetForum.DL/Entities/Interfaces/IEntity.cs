using System;
using System.Collections.Generic;
using System.Text;

namespace InternetForum.DL.Entities.Interfaces
{
	public interface IEntity<T>
	{
		/// <summary>
		/// Vrací nebo nastavuje ID entity.
		/// </summary>
		T Id { get; set; }
	}
}