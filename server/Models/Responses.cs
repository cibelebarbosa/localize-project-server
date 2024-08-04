using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Responses
    {
        public int cobranca_id { get; set; }
        public int user_id { get; set; }
        public int client_id { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
        public string data { get; set; }
        public Boolean pago { get; set; }
    }

    public class ClientesResponse
    {
        public int client_id { get; set; }
        public string nome { get; set; }
        public int pago { get; set; }
        public int abertos { get; set; }
        public int atrasados { get; set; }
    }
}
