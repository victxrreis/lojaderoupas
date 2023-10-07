using LojaDeRoupas.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaDeRoupas.Data;
public class LojaDeRoupasDbContext : DbContext
{
    public DbSet<Cliente>? Cliente { get; set;}
    public DbSet<Produto>? Produto { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=estacionamento.db;Cache=Shared");
    }
}