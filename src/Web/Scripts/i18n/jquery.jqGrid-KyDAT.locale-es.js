;(function($){
/**
 * jqGrid Spanish Translation for KyDAT
**/
$.jgrid = $.jgrid || {};
$.extend($.jgrid,{
	edit : {
	    addCaption: "Agregar registro",
	    editCaption: "Modificar registro",
	    bSubmit: "Guardar",
	    bCancel: "Cancelar",
		bClose: "Cerrar",
		saveData: "Se han modificado los datos, ¿guardar cambios?",
		bYes : "Si",
		bNo : "No",
		bExit : "Cancelar",
	    msg: {
	        required:"Campo obligatorio",
	        number:"Introduzca un número",
	        minValue:"El valor debe ser mayor o igual a ",
	        maxValue:"El valor debe ser menor o igual a ",
	        email: "no es una dirección de correo válida",
	        integer: "Introduzca un valor entero",
			date: "Introduza una fecha correcta ",
			url: "no es una URL válida. Prefijo requerido ('http://' or 'https://')",
			nodefined : " no está definido.",
			novalue : " valor de retorno es requerido.",
			customarray : "La función personalizada debe devolver un array.",
			customfcheck : "La función personalizada debe estar presente en el caso de validación personalizada."
		}
	},
	nav : {
		edittext: " ",
	    edittitle: "Modificar fila seleccionada (Ctrl+M)",
		addtext:" ",
	    addtitle: "Agregar nueva fila (Ctrl+N)",
	    deltext: " ",
	    deltitle: "Eliminar fila seleccionada (Ctrl+B)",
	    searchtext: " ",
	    searchtitle: "Buscar información",
	    refreshtext: "",
	    refreshtitle: "Recargar datos",
	    alertcap: "Aviso",
	    alerttext: "Seleccione una fila",
		viewtext: "",
		viewtitle: "Ver fila seleccionada"
	}
});
})(jQuery);