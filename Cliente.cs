using System.ComponentModel.DataAnnotations;

namespace LojaDeRoupas.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClienteNome { get; set; }

        [Required]
        public string ClienteEndereco { get; set; }

        [Required]
        public string ClienteEmail { get; set; }

        // Construtor padrão sem parâmetros
        public Cliente()
        {
        }

        // Construtor com parâmetros
        public Cliente(int id, string clienteNome, string clienteEndereco, string clienteEmail)
        {
            Id = id;
            ClienteNome = clienteNome;
            ClienteEndereco = clienteEndereco;
            ClienteEmail = clienteEmail;
        }
    }
}
