using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trirand.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
	public class LocalidadesController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			IJQGridModel gridModel = ArmarGrid();
			
			return View(gridModel);
		}

		public JsonResult EnlazarDatos()
		{
			var datosGrid = ObtenerDatos();

			IJQGridModel gridModel = ArmarGrid();

			JQGridState gridState = gridModel.Grid.GetState();
			Session["GridState"] = gridState;

			return gridModel.Grid.DataBind(datosGrid);
		}

		public ActionResult Actualizar(LocalidadViewModel viewModel)
		{
			IJQGridModel gridModel = ArmarGrid();

			switch (gridModel.Grid.AjaxCallBackMode)
			{
				case AjaxCallBackMode.AddRow:
					return Agregar(viewModel, gridModel);
				case AjaxCallBackMode.EditRow:
					return Modificar(viewModel, gridModel);
				default:
					return gridModel.Grid.ShowEditValidationMessage("Opción no manejada.");
			}
		}

		private ActionResult Modificar(LocalidadViewModel viewModel, IJQGridModel gridModel)
		{
			viewModel.BindDropDowns(ListaDeProvincias());

			try
			{
				var localidad = ListaDeLocalidades().Where(p => p.Id == viewModel.Id).Single();

				localidad.Descripcion = viewModel.Descripcion;
				localidad.Provincia = ListaDeProvincias().Where(p => p.Id == viewModel.ProvinciaId).Single();

			}
			catch (Exception ex)
			{
				return gridModel.Grid.ShowEditValidationMessage(ex.Message);
			}

			return Content("");
		}

		private ActionResult Agregar(LocalidadViewModel viewModel, IJQGridModel gridModel)
		{
			viewModel.BindDropDowns(ListaDeProvincias());

			try
			{
				var localidad = new Localidad()
				{
					Id = Guid.NewGuid(),
					Descripcion = viewModel.Descripcion,
					Provincia = ListaDeProvincias().Where(p => p.Id == viewModel.ProvinciaId).Single()
				};

				ListaDeLocalidades().Add(localidad);
			}
			catch (Exception ex)
			{
				return gridModel.Grid.ShowEditValidationMessage(ex.Message);
			}

			return Content("");
		}

		private IQueryable<LocalidadViewModel> ObtenerDatos()
		{
			var datos = ListaDeLocalidades().AsQueryable();

			return (from entidad in datos select new LocalidadViewModel(entidad));
		}

		private IList<Localidad> ListaDeLocalidades()
		{
			if (Session["localidades"] == null)
			{
				var provincias = ListaDeProvincias();
				var localidad1 = new Localidad() { Id = Guid.NewGuid(), Descripcion = "Localidad 1", Provincia = provincias[0] };
				var localidad2 = new Localidad() { Id = Guid.NewGuid(), Descripcion = "Localidad 2", Provincia = provincias[1] };

				var lista = new List<Localidad>();
				lista.Add(localidad1);
				lista.Add(localidad2);

				Session["localidades"] = lista;
			}

			return Session["localidades"] as List<Localidad>;
		}

		private IList<Provincia> ListaDeProvincias()
		{
			if (Session["provincias"] == null)
			{
				var provincia1 = new Provincia() { Id = Guid.NewGuid(), Descripcion = "Pronvincia 1" };
				var provincia2 = new Provincia() { Id = Guid.NewGuid(), Descripcion = "Pronvincia 2" };

				var lista = new List<Provincia>();
				lista.Add(provincia1);
				lista.Add(provincia2);

				Session["provincias"] = lista;
			}

			return Session["provincias"] as List<Provincia>;
		}

		private IJQGridModel ArmarGrid()
		{
			IJQGridModel gridModel = new LocalidadesJqGridModel(Url.Action("EnlazarDatos"), Url.Action("Actualizar"),
				ListaDeProvincias());
			return gridModel;
		}
	}
}
