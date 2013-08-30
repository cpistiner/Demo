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
	public class ProvinciasController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			IJQGridModel gridModel = new ProvinciasJqGridModel(Url.Action("EnlazarDatos"), Url.Action("Actualizar"));
			
			return View(gridModel);
		}

		public JsonResult EnlazarDatos()
		{
			var datosGrid = ObtenerDatos();

			IJQGridModel gridModel = new ProvinciasJqGridModel(Url.Action("EnlazarDatos"), Url.Action("Actualizar"));

			JQGridState gridState = gridModel.Grid.GetState();
			Session["GridState"] = gridState;

			return gridModel.Grid.DataBind(datosGrid);
		}

		public ActionResult Actualizar(ProvinciaViewModel viewModel)
		{
			IJQGridModel gridModel = new ProvinciasJqGridModel(Url.Action("EnlazarDatos"), Url.Action("Actualizar"));

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

		private ActionResult Modificar(ProvinciaViewModel viewModel, IJQGridModel gridModel)
		{
			try
			{
				var provincia = ListaDeProvincias().Where(p => p.Id == viewModel.Id).Single();
				
				provincia.Descripcion = viewModel.Descripcion;
			}
			catch (Exception ex)
			{
				return gridModel.Grid.ShowEditValidationMessage(ex.Message);
			}

			return Content("");
		}

		private ActionResult Agregar(ProvinciaViewModel viewModel, IJQGridModel gridModel)
		{
			try
			{
				var provincia = new Provincia() { Id = Guid.NewGuid(), Descripcion = viewModel.Descripcion };
				ListaDeProvincias().Add(provincia);
			}
			catch (Exception ex)
			{
				return gridModel.Grid.ShowEditValidationMessage(ex.Message);
			}

			return Content("");
		}

		private IQueryable<ProvinciaViewModel> ObtenerDatos()
		{
			var datos = ListaDeProvincias().AsQueryable();

			return (from entidad in datos select new ProvinciaViewModel(entidad));
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
	}
}
