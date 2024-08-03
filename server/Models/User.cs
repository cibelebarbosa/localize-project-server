using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class User
    {
        [Key]
        [Required]
        public int user_id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string username { get; set; }
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string password { get; set; }
    }
}
