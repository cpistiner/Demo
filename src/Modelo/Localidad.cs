using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Modelo
{
    public class Localidad : EntidadBase
    {
        private string _codigo;
        private string _descripcion;
		private string _maskTest;
        private Provincia _provincia;

        public string Codigo
        {
            get { return _codigo != null ? _codigo.Trim() : ""; }
            set { _codigo = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

		public string MaskTest
		{
			get { return _maskTest; }
			set { _maskTest = value; }
		}

        public Provincia Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }

        public override string ToString()
        {
            return _descripcion != null ? _descripcion : "Desconocido" + 
                _provincia != null ? "(" + _provincia.ToString() + ")" : "";
        }

		public string DescripcionConCodigo
		{
			get { return _descripcion.Trim() + " (" + _codigo.Trim() + ")"; }
		}

    }
}
