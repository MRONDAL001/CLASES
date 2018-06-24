using System;
using System.Collections.Generic;

namespace DEPARTAMENTO.Models.DEP
{
    public partial class Cliente
    {
        public Cliente()
        {
            Formulario = new HashSet<Formulario>();
        }

        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public ICollection<Formulario> Formulario { get; set; }
    }
}
