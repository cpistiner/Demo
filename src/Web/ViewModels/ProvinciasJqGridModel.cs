using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Trirand.Web.Mvc;
using Modelo;

namespace Web.ViewModels
{
	public class ProvinciasJqGridModel : IJQGridModel
	{
		public JQGrid Grid { get; set; }

		public ProvinciasJqGridModel(string dataAction, string editDataAction)
		{
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
			var fieldWidth450 = new JQGridEditFieldAttribute() { Name = "style", Value = "width: 450px" };

			var descripcionColumn = Grid.Columns.Find(c => c.DataField == "Descripcion");
			descripcionColumn.Editable = true;
			descripcionColumn.EditFieldAttributes.Add(fieldWidth450);
		}

		private void SetUpColumns()
		{
			var columnId = new JQGridColumn();
			columnId.DataField = "Id";
			columnId.Editable = false;
			columnId.Searchable = false;
			columnId.PrimaryKey = true;
			columnId.Visible = false;
			
			Grid.Columns.Add(columnId);

			var columnDescription = new JQGridColumn();
			columnDescription.HeaderText = "Descripción";
			columnDescription.DataField = "Descripcion";
			columnDescription.Width = 300;

			Grid.Columns.Add(columnDescription);
		}

		private void SetToolBar()
		{
			Grid.ToolBarSettings.ShowSearchToolBar = true;

			Grid.ToolBarSettings.ToolBarPosition = ToolBarPosition.Bottom;
			Grid.ToolBarSettings.ShowEditButton = true;
			Grid.ToolBarSettings.ShowAddButton = true;
			Grid.ToolBarSettings.ShowRefreshButton = true;
			Grid.ToolBarSettings.ShowViewRowDetailsButton = true;
		}
	}
}
