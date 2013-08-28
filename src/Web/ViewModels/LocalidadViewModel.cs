using Modelo;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Web.ViewModels
{
	public class LocalidadViewModel : ViewModelBase
	{
		public LocalidadViewModel()
		{
		}

		public LocalidadViewModel(Localidad localidad)
		{
			Id = localidad.Id;
			Descripcion = localidad.Descripcion;
			ProvinciaId = localidad.Provincia.Id;
			ProvinciaDescripcion = localidad.Provincia.Descripcion;

		}

		[Display(Name = "Descripción")]
		public string Descripcion { get; set; }

		public Provincia Provincia { get; set; }

		public Guid ProvinciaId { get; set; }
		public string ProvinciaDescripcion { get; set; }

		internal void BindDropDowns(IList<Provincia> provincias)
		{
			ProvinciaId = new Guid(ProvinciaDescripcion);
			ProvinciaDescripcion = provincias.Where(p => p.Id == ProvinciaId).Single().Descripcion;
		}
	}
}