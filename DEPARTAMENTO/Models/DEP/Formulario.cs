using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEPARTAMENTO.Models.DEP
{
    public partial class Formulario
    {
        public int IdFormulario { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdCliente { get; set; }

        // Codigo precio//
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Precio { get; set; }

        // config fech contrato//
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaContrato { get; set; }

        // config fech incio//
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaInicio { get; set; }

        // config fech final//
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFinal { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Detalledep IdDepartamentoNavigation { get; set; }
    }
}
