using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Cobrancas
    {
        [Key]
        [Required]
        public int cobranca_id { get; set; }
        [ForeignKey("users")]
        public int user_id { get; set; }
        [ForeignKey("clientes")]
        public int client_id { get; set; }

        [Required(ErrorMessage = "O campo descricao é obrigatório")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public decimal valor { get; set; }
        [Required(ErrorMessage = "O campo data é obrigatório")]
        public DateTime data { get; set; }
        [Required(ErrorMessage = "O campo pago é obrigatório")]
        public Boolean pago { get; set; }
    }

}
