using System;
using System.ComponentModel.DataAnnotations;
using Modelo;

namespace Web.ViewModels
{
	public class ProvinciaViewModel : ViewModelBase
	{
		public ProvinciaViewModel()
		{
		}

		public ProvinciaViewModel(Provincia provincia)
		{
			Id = provincia.Id;
			Descripcion = provincia.Descripcion;
		}

		[Display(Name = "Descripción")]
		public string Descripcion { get; set; }
	}
}