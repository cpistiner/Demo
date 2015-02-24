using JQGridUtilities.JQGridBuilders;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Trirand.Web.Mvc;

namespace Web.ViewModels
{
	public class LocalidadesJqGridModel : IJQGridModel
	{
		IList<Provincia> _provincias;

		public JQGrid Grid { get; set; }

		public LocalidadesJqGridModel(string dataAction, string editDataAction, IList<Provincia> provincias)
		{
			_provincias = provincias;
			Setup(dataAction, editDataAction);
		}

		private void Setup(string dataAction, string editDataAction)
		{
			Grid = new JQGrid();
			Grid.Columns = new List<JQGridColumn>();

			//Grid.Width = Unit.Percentage(100);
			Grid.Width = Unit.Pixel(600);
			Grid.Height = Unit.Pixel(347);
			Grid.ShrinkToFit = false;

			Grid.PagerSettings.PageSize = 15;
			Grid.PagerSettings.PageSizeOptions = "[15, 50, 100]";

			Grid.DataUrl = dataAction;
			Grid.EditUrl = editDataAction;

			Grid.EditDialogSettings.Width = 550;
			Grid.AddDialogSettings.Width = 550;

			Grid.ClientSideEvents.BeforeEditDialogShown = "configurarEdicion";

			SetToolBar();
			SetUpColumns();
			SetUpEditableColumns();
			SetUpSearch();

			Grid.EditDialogSettings.CloseAfterEditing = true;
			Grid.AddDialogSettings.CloseAfterAdding = true;
			Grid.AddDialogSettings.Resizable = false;

			Grid.ViewRowDialogSettings.Width = 550;
		}

		private void SetUpSearch()
		{
			var descripcionColumn = Grid.Columns.Find(c => c.DataField == "Descripcion");
			descripcionColumn.DataType = typeof(string);
			descripcionColumn.SearchToolBarOperation = SearchOperation.Contains;
		}

		private void SetUpEditableColumns()
		{
			var maskColumn = Grid.Columns.Find(c => c.DataField == "MaskTest");
			maskColumn.Editable = true;
			maskColumn.EditTypeCustomCreateElement = "createGridEditElement";
			maskColumn.EditTypeCustomGetValue = "getGridElementValue";

			var builderAttribute = new JQGridEditFieldAttributeBuilder();

			var descripcionColumn = Grid.Columns.Find(c => c.DataField == "Descripcion");
			descripcionColumn.Editable = true;
			descripcionColumn.EditFieldAttributes.Add(builderAttribute.StyleWidth(450).BuildStyle());

			var provinciaColumn = Grid.Columns.Find(c => c.DataField == "ProvinciaDescripcion");
			provinciaColumn.Editable = true;
			provinciaColumn.EditType = EditType.DropDown;

			AjaxCallBackMode callBack;
			bool skipAjaxCallBackMode;

			try
			{
				callBack = Grid.AjaxCallBackMode;
				skipAjaxCallBackMode = false;
			}
			catch (System.NullReferenceException)
			{
				skipAjaxCallBackMode = true;
			}

			if (skipAjaxCallBackMode || Grid.AjaxCallBackMode == AjaxCallBackMode.RequestData)
			{
				var selectList = _provincias.Select(
					p => new SelectListItem
					{
						Value = p.Id.ToString(),
						Text = p.Descripcion
					}).ToList();

				provinciaColumn.EditList = selectList;
			}
		}

		private void SetUpColumns()
		{
			var builder = new JQGridColumnBuilder();

			var columnId = builder.GetStandard("Id", "Id");
			columnId.Editable = false;
			columnId.Searchable = false;
			columnId.PrimaryKey = true;
			columnId.Visible = false;
			
			Grid.Columns.Add(columnId);

			var columnDescription = builder.GetStandard("Descripción", "Descripcion");
			columnDescription.Width = 300;

			Grid.Columns.Add(columnDescription);

			var columnProvincia = builder.GetStandard("Provincia", "ProvinciaDescripcion");
			columnDescription.Width = 300;

			Grid.Columns.Add(columnProvincia);

			var maskColumn = new JQGridColumn();
			maskColumn.HeaderText = "MaskTest";
			maskColumn.DataField = "MaskTest";
			maskColumn.Width = 150;

			Grid.Columns.Add(maskColumn);
		}

		private void SetToolBar()
		{
			Grid.ToolBarSettings.ShowSearchToolBar = true;

			Grid.ToolBarSettings.ToolBarPosition = ToolBarPosition.Bottom;
			Grid.ToolBarSettings.ShowEditButton = true;
			Grid.ToolBarSettings.ShowAddButton = true;
			Grid.ToolBarSettings.ShowRefreshButton = true;
			Grid.ToolBarSettings.ShowViewRowDetailsButton = true;

			JQGridToolBarButtonBuilder.SetDefaultLanguage(jqGridBuildersLanguages.Spanish);
			var button = JQGridToolBarButtonBuilder.ColumnChooser();
			button.OnClick = "columnChooserOnClick";

			Grid.ToolBarSettings.CustomButtons.Add(button);
		}
	}
}
