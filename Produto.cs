using System.ComponentModel.DataAnnotations;

namespace LojaDeRoupas.Models;

public class Produto
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ProdutoNome { get; set; }
    [Required]
    public string ProdutoDesc { get; set; }
    [Required]
    public double ProdutoPreco { get; set; }
    [Required]
    public string ProdutoCategoria { get; set; }
    [Required]
    public int ProdutoQuant { get; set; }

    public Produto(int id, string produtoNome, string produtoDesc, double produtoPreco, string produtoCategoria, int produtoQuant)
    {
        Id = id;
        ProdutoNome = produtoNome;
        ProdutoDesc = produtoDesc;
        ProdutoPreco = produtoPreco;
        ProdutoCategoria = produtoCategoria;
        ProdutoQuant = produtoQuant;
    }
}