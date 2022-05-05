using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {

            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();     // Esse motodo me retorna um Ilista 
            return View(produtos);
        }

        public ActionResult Form()
        {
            ViewBag.Produto = new Produto();
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;  // Enviano as informações para a camada de vies
            return View(categorias);
        }

        [HttpPost] // Essa função só aceita requisição do tipo post regeitando do tipo get
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index"); // Redirecionando a ação para a index do produto
            }
            else
            {
                ViewBag.Produto = produto;
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                return View("Form");
            }
        }
        [Route("produtos/{id}", Name = "VisualizaProduto")]  // Metodo de link personalizado criando o nome e alterando a rota no Index
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);  // Retorna o objeto em JavaScritp
        }
    }
}