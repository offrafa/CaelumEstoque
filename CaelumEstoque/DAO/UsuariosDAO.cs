using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaelumEstoque.DAO
{
    public class UsuariosDAO
    {
        public void Adiciona(Usuario usuario)  // Pegando o valor do objeto usuario
        {
            using (var context = new EstoqueContext())  // Criando a classe de contexto
            {
                context.Usuarios.Add(usuario); // Savlvando no banco de dados
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.ToList();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.Find(id);
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public Usuario Busca(string login, string senha)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Nome == login && u.Senha == senha);
            }
        }
    }
}