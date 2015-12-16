using BlogVivi.db;
using BlogVivi.db.Classes;
using BlogVivi.Web.Models.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogVivi.Web.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index(int? pagina, string Tag, string pesquisa)
           
        {
           var paginaCorreta = pagina.GetValueOrDefault(1);
            var  registrosPorPagina = 10;

            var conexaoBanco = new ConexaoBanco();

           var posts = (from p in conexaoBanco.Posts where p.Visivel == true select p);
            if (!string.IsNullOrEmpty(Tag))
            {
                posts = (from p in posts where p.PostTag.Any(x=> x.IdTag.ToUpper()== Tag.ToUpper()) select p);
            }

            if (!string.IsNullOrEmpty(pesquisa))
            {
                posts = (from p in posts where p.Titulo.ToUpper().Contains(pesquisa.ToUpper())
                        || p.Resumo.ToUpper().Contains(pesquisa.ToUpper())
                        || p.Descricao.ToUpper().Contains(pesquisa.ToUpper())
                        select p);




            }
            var qtdRegistros = posts.Count();
            var indiceDaPagina = paginaCorreta - 1;
            var qtdeRegistrosPular = (indiceDaPagina * registrosPorPagina);
            var qtdePaginas = Math.Ceiling((decimal) qtdRegistros / registrosPorPagina);

            var viewModel = new ListarPostViewModel();
            viewModel.Posts = (from p in posts orderby p.DataPublicacao descending select p).Skip(qtdeRegistrosPular).Take (registrosPorPagina).ToList();
            viewModel.PaginaAtual = paginaCorreta;
            viewModel.TotalPaginas = (int)qtdePaginas;
            viewModel.Tag = Tag;
            viewModel.Tags = (from p in conexaoBanco.TagClass  where conexaoBanco.PostsTags.Any(x => x.IdTag == p.Tag) orderby p.Tag select p.Tag).ToList();
            viewModel.Pesquisa = pesquisa;
            return View(viewModel);
            
        }

        public ActionResult _Paginacao()
        {
            return PartialView();
        }

        public ActionResult Post(int id)
        {
            var conexaoBanco = new ConexaoBanco();
            var posts = (from x in conexaoBanco.Posts where x.Id == id select x).FirstOrDefault();
           
            var viewModel = new DetalhesPostViewModel();
            viewModel.id = posts.Id;
            viewModel.Resumo = posts.Resumo;
            viewModel.Titulo = posts.Titulo;
            viewModel.datadepublicacao = posts.DataPublicacao;
            viewModel.Autor = posts.Autor;
            viewModel.descricao = posts.Descricao;
            viewModel.Tags = (from p in posts.PostTag select p.IdTag).ToList();
            return View(viewModel);
        }
    }
}