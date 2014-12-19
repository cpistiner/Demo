<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Web.ViewModels.LocalidadesJqGridModel>" %>
<%@ Import Namespace="Trirand.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Localidades
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Localidades</h2>

	<div class="clear"></div>

    <div class="DivData">
        <div class="DivDataGrid">
			<div style="display: inline-block">
				<%= Html.Trirand().JQGrid(Model.Grid, "JQGrid")%>
			</div>
		</div>
	</div>

	<script type="text/javascript">
		function createGridEditElement(value, editOptions) {
			return "<input id='MaskTest' type='text'></input>";
		}
		function getGridElementValue(elem, two, three) {
			return $(elem).val();
		}

		function configurarEdicion() {
			jQuery("#MaskTest").mask("99-99");
		}
	</script>
</asp:Content>
