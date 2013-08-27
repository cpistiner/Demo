namespace Modelo
{
    public class Provincia : EntidadBase
    {
        private string _descripcion;
        
		public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public override string ToString()
        {
            return _descripcion;
        }
    }
}