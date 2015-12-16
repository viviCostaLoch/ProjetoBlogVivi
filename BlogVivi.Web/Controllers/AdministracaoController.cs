using BlogVivi.db;
using BlogVivi.db.Classes;
using BlogVivi.Web.Models.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogVivi.Web.Controllers
{
     [Authorize]
    public class AdministracaoController : Controller
    {
        // GET: Administracao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarPost()
        {
            var viewModel = new CadastrarPostViewModel();
            viewModel.datadepublicacao = DateTime.Now;
            viewModel.horadepublicacao = DateTime.Now;


            return View(viewModel);
        }

        [HttpPost]// define que vai salvar no banco
        public ActionResult CadastrarPost(CadastrarPostViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
               
                var conexao = new ConexaoBanco();
                var post = new Post();
                var horaPublicacao = ViewModel.horadepublicacao;
                var dataPublicacao = ViewModel.datadepublicacao.Date;
                var dataConc = new DateTime(dataPublicacao.Year, dataPublicacao.Month, dataPublicacao.Day, horaPublicacao.Hour, horaPublicacao.Minute, horaPublicacao.Second);
                post.Autor = ViewModel.Autor;
                post.Titulo = ViewModel.Titulo;
                post.DataPublicacao = dataConc;
                post.Descricao = ViewModel.descricao;
                post.Resumo = ViewModel.Resumo;
                post.Visivel = ViewModel.Visivel;
                post.PostTag = new List<PostTag>();

                if (ViewModel.Tags != null)
                {
                    foreach (var item in ViewModel.Tags)
                    {
                        var tagExiste = (from p in conexao.TagClass where p.Tag.ToLower() == item.ToLower() select p).Any();

                        if (!tagExiste)
                        {
                            var tagClass = new TagClass();
                            tagClass.Tag = item;
                            conexao.TagClass.Add(tagClass);
                        }
                        var postTag = new PostTag();
                        postTag.IdTag = item;
                        post.PostTag.Add(postTag);
                    }
                }
                conexao.Posts.Add(post);
                try
                {
                    conexao.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception exp)
                {

                    ModelState.AddModelError("", exp.Message);

                }

               
            }
            return View(ViewModel);// serve para não perder as informaçãoes do usuario caso ele digite algum campo errado
        }
    
        // ---- Editar Post Abrir a Tela eCarregar informções na view ------------

        public ActionResult EditarPost(int id)
        {
            var conexao = new ConexaoBanco();
            var posts = (from x in conexao.Posts where x.Id == id select x).FirstOrDefault();
            if (posts == null)
            {
                throw new Exception(string.Format("Post com código {0} não encontrado", id));
            }
            var viewModel = new CadastrarPostViewModel();
            viewModel.Titulo = posts.Titulo;
            viewModel.Autor = posts.Autor;
            viewModel.datadepublicacao = posts.DataPublicacao;
            viewModel.horadepublicacao = posts.DataPublicacao;
            viewModel.Resumo = posts.Resumo;
            viewModel.descricao = posts.Descricao;
            viewModel.Visivel = posts.Visivel;
            viewModel.id = posts.Id;
            viewModel.Tags = (from p in posts.PostTag select p.IdTag).ToList();
            
            return View(viewModel);
        }


        // ------ Editar Post Parte do Banco-------

        [HttpPost]// passo2 colocacar httpPost que define que vai salvar no banco
        public ActionResult EditarPost(CadastrarPostViewModel ViewModel) // passo 1: criar action editar post que recebe a viewModel por parametro
        {
            if (ModelState.IsValid)// Passo 3:validar modelo
            {
                var conexao = new ConexaoBanco();// passo 4 abrir conexão
                var codigo = ViewModel.id;
                var post = (from x in conexao.Posts where x.Id == codigo select x).FirstOrDefault(); // passo 5 buscar o post que vou alterar
                if (post != null)
                {
                    var horaPublicacao = ViewModel.horadepublicacao;// passo 6 carregar os dados alterados na view para o post
                    var dataPublicacao = ViewModel.datadepublicacao.Date;
                    var dataConc = new DateTime(dataPublicacao.Year, dataPublicacao.Month, dataPublicacao.Day, horaPublicacao.Hour, horaPublicacao.Minute, horaPublicacao.Second);
                    post.Autor = ViewModel.Autor;
                    post.Titulo = ViewModel.Titulo;
                    post.DataPublicacao = dataConc;
                    post.Descricao = ViewModel.descricao;
                    post.Resumo = ViewModel.Resumo;
                    post.Visivel = ViewModel.Visivel;

                    var postsTagsAtuais = post.PostTag.ToList();
                    foreach (var item in postsTagsAtuais)
                    {
                        conexao.PostsTags.Remove(item);
                    }
                    if (ViewModel.Tags != null)
                    {
                        foreach (var item in ViewModel.Tags)
                        {
                            var tagExiste = (from p in conexao.TagClass where p.Tag.ToLower() == item.ToLower() select p).Any();

                            if (!tagExiste)
                            {
                                var tagClass = new TagClass();
                                tagClass.Tag = item;
                                conexao.TagClass.Add(tagClass);
                            }
                            var postTag = new PostTag();
                            postTag.IdTag = item;
                            post.PostTag.Add(postTag);
                        }
                    }
                    try
                    {
                        conexao.SaveChanges();// salvar alterações
                        return RedirectToAction("Index");
                    }
                    catch (Exception exp)
                    {
                        ModelState.AddModelError("", exp.Message);
                        
                    }
                  
                }


            }

            return View(ViewModel);// continuação do passo 3 serve para não perder as informaçãoes do usuario caso ele digite algum campo errado
        }
        public ActionResult ExcluirPost(int id)
        {
            var conexaoBanco = new ConexaoBanco();
            var post = (from p in conexaoBanco.Posts
                        where p.Id == id
                        select p).FirstOrDefault();
            if (post == null)
            {
                throw new Exception(string.Format("Post código {0} não existe.", id));
            }
            conexaoBanco.Posts.Remove(post);
            conexaoBanco.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }


    }
}