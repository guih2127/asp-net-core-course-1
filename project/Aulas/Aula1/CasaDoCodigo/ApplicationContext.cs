using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(t => t.Id); 
            // Com o HasKey definimos a chave primária da entidade Produto.

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido);
            // Aqui indicamos que um pedido irá ter um relacionamento com vários itens e cada item terá relacionamento para um com o pedido.
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).IsRequired();
            // Aqui indicamos que um pedido irá ter um relacionamento com apenas um cadastro. Definimos também que o cadastro é obrigatório.

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            // Aqui indicamos que um ItemPedido tem relacionamento com um produto e com um pedido.

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);
            // Aqui indicamos que um cadastro tem um relacionamento com apenas um pedido.
        }
    }
}
