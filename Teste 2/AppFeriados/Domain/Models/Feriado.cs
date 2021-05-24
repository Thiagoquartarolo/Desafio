using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppFeriados.Domain.Models
{
    public class Feriado
    {
        [Key]
        public int FeriadoId { get; set; }

        [ForeignKey("TipoFeriado")]
        public int TipoFeriadoId { get; set; }

        public string FeriadoNome { get; set; }

        public DateTime DataFeriado { get; set; }


        public TipoFeriado TipoFeriado { get; set; }
    }
}
