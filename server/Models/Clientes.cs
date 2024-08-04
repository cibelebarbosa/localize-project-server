using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models
{
    public class Clientes
    {

        [Key]
        [Required]
        public int client_id { get; set; }
        [ForeignKey("users")]
        public int user_id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O campo documento é obrigatório")]
        public string documento { get; set; }
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string telefone { get; set; }
        [Required(ErrorMessage = "O campo endereco é obrigatório")]
        public string endereco { get; set; }
    }
}
