using System.ComponentModel.DataAnnotations;

namespace AppFeriados.Domain.Models
{
    public class TipoFeriado
    {
        [Key]
        public int TipoFeriadoId { get; set; }

        public string Descricao { get; set; }
    }
}
