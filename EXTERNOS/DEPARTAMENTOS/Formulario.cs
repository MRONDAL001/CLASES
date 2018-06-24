using System;
using System.Collections.Generic;

namespace EXTERNOS.DEPARTAMENTOS
{
    public partial class Formulario
    {
        public int IdFormulario { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Precio { get; set; }
        public DateTime? FechaContrato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Detalledep IdDepartamentoNavigation { get; set; }
    }
}
