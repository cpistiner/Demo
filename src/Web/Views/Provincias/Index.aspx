<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Web.ViewModels.ProvinciasJqGridModel>" %>
<%@ Import Namespace="Trirand.Web.Mvc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Provincias
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Provincias</h2>

	<div class="clear"></div>

    <div class="DivData">
        <div class="DivDataGrid">
			<div style="display: inline-block">
				<%= Html.Trirand().JQGrid(Model.Grid, "JQGrid")%>
			</div>
		</div>
	</div>

</asp:Content>
