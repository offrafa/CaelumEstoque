using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class EstoqueContext : DbContext  // Hedando as intidade pronta do framework
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CategoriaDoProduto> Categorias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}