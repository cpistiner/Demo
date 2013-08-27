using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
	public abstract class ViewModelBase
	{
		[ScaffoldColumn(false)]
		public Guid Id { get; set; }
	}
}
