using System;
using System.Collections.Generic;

namespace EXTERNOS.DEPARTAMENTOS
{
    public partial class Detalledep
    {
        public Detalledep()
        {
            Formulario = new HashSet<Formulario>();
        }

        public int IdDepartamento { get; set; }
        public string Dormitorios { get; set; }
        public string Banios { get; set; }
        public string Ubicacion { get; set; }
        public string Detalle { get; set; }

        public ICollection<Formulario> Formulario { get; set; }
    }
}
