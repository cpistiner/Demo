using System;

namespace Modelo
{
	public interface IEntidad
	{
		Guid Id { get; }
	}

	public abstract class EntidadBase : IEntidad, IComparable
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			IEntidad entidad = obj as IEntidad;

			return entidad.Id == this.Id;
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode();
		}

		public int CompareTo(object obj)
		{
			EntidadBase e = (EntidadBase)obj;
			return String.Compare(this.ToString(), e.ToString());
		}
	}
}
