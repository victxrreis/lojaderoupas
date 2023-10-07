using System.ComponentModel.DataAnnotations;

namespace LojaDeRoupas.Models;
// Criação da classe Cliente
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

    public Cliente(int id, string clienteNome, string clienteEndereco, string clienteEmail)
    {
        // Construtor personalizado
        Id = id;
        ClienteNome = clienteNome;
        ClienteEndereco = clienteEndereco;
        ClienteEmail = clienteEmail;
    }
}