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

	<%--Prueba para sobreescribir onClick del edit en InlineEdit--%>
	<%--<script type="text/javascript">

		function clickEdicion() {
			alert("holaaaa");
		}

		jQuery(document).ready(function () {

			jQuery('div.ui-pg-div.ui-inline-edit').attr("onClick", "clickEdicion()");

    	});
    </script>--%>
</asp:Content>
