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
            viewModel.Posts = (from p in posts orderby p.DataPublicacao
                               descending select new DetalhesPostViewModel {
                                   datadepublicacao = p.DataPublicacao,
                                   Autor = p.Autor,
                                   descricao = p.Descricao,
                                   id = p.Id,
                                   Resumo = p.Resumo,
                                   Titulo = p.Titulo,
                                   Visivel = p.Visivel,
                                   QtdComentarios = p.Comentario.Count,

                               }).Skip(qtdeRegistrosPular).Take (registrosPorPagina).ToList();
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

        public ActionResult Post(int id,int?pagina )
        {
            var conexaoBanco = new ConexaoBanco();
            var posts = (from x in conexaoBanco.Posts where x.Id == id select x).FirstOrDefault();

            var viewModel = new DetalhesPostViewModel();
            PreencherViewModel(posts, viewModel, pagina);
            return View(viewModel);
        }

        private  void PreencherViewModel(Post posts, DetalhesPostViewModel viewModel, int? pagina)
        {
            viewModel.id = posts.Id;
            viewModel.Resumo = posts.Resumo;
            viewModel.Titulo = posts.Titulo;
            viewModel.datadepublicacao = posts.DataPublicacao;
            viewModel.Autor = posts.Autor;
            viewModel.descricao = posts.Descricao;
            viewModel.QtdComentarios = posts.Comentario.Count;
            viewModel.Tags = (from p in posts.PostTag select p.IdTag).ToList();

            var paginaCorreta = pagina.GetValueOrDefault(1);
            var registrosPorPagina = 10;
            var qtdRegistros = posts.Comentario.Count();
            var indiceDaPagina = paginaCorreta - 1;
            var qtdeRegistrosPular = (indiceDaPagina * registrosPorPagina);
            var qtdePaginas = Math.Ceiling((decimal)qtdRegistros / registrosPorPagina);
            viewModel.Comentarios = (from p in posts.Comentario
                                     orderby p.DataHora descending
                                     select p).Skip(qtdeRegistrosPular).Take(registrosPorPagina).ToList();
            viewModel.PaginaAtual = paginaCorreta;
            viewModel.TotalPaginas =(int)qtdePaginas;

        }

        [HttpPost]
        public ActionResult Post(DetalhesPostViewModel viewModel)
        {
            var conexaoBanco = new ConexaoBanco();
            var post = (from p in conexaoBanco.Posts
                        where p.Id == viewModel.id
                        select p).FirstOrDefault();
            if (ModelState.IsValid)
            {

           
           
            if (post== null)
            {
                throw new Exception(string.Format("Post codigo {0} não encontrado ", viewModel.id));
            }

            var comentario = new Comentario();
            comentario.AdmPost = HttpContext.User.Identity.IsAuthenticated;
            comentario.Descricao = viewModel.ComentarioDescricao;
            comentario.Email = viewModel.ComentarioEmail;
            comentario.IdPost = viewModel.id;
            comentario.Nome = viewModel.ComentarioNome;
            comentario.PaginaWeb = viewModel.ComentarioPaginaWeb;
            comentario.DataHora = DateTime.Now;

            try
            {
                conexaoBanco.Comentarios.Add(comentario);
                conexaoBanco.SaveChanges();
                return Redirect(Url.Action("Post", new
                {
                    ano = post.DataPublicacao.Year,
                    mes = post.DataPublicacao.Month,
                    dia = post.DataPublicacao.Day,
                    titulo = post.Titulo,
                    id = post.Id
                })+ "#comentarios");
            }
            catch (Exception exp)
            {

                ModelState.AddModelError("", exp.Message);
            }
            }
            PreencherViewModel(post, viewModel,null);
            return View(viewModel);

        }
        public ActionResult _PaginacaoPost() {
            return PartialView();
        }
    }
}