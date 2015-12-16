using BlogVivi.db;
using BlogVivi.db.Classes;
using BlogVivi.Web.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogVivi.Web.Controllers
{
    public class UsuariosController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {

            var conexaoBanco = new ConexaoBanco();
            var usuarios = (from p in conexaoBanco.Usuarios orderby p.Nome ascending select p).ToList();
            return View(usuarios);
        }

        public ActionResult CadastrarUsuario()
        {

            return View();
        }

        [HttpPost]// define que vai salvar no banco
        public ActionResult CadastrarUsuario(CadastrarUsuariosViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {

                var conexao = new ConexaoBanco();
                var usuario = new Usuario();
                usuario.Nome = ViewModel.Nome;
                usuario.Login = ViewModel.Login;
                usuario.Senha = ViewModel.Senha;

                conexao.Usuarios.Add(usuario);
                
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
            return View(ViewModel);
        }

        // ---- Editar Post Abrir a Tela eCarregar informções na view ------------

        public ActionResult EditarUsuario(int id)
        {
            var conexao = new ConexaoBanco();
            var usuario = (from x in conexao.Usuarios where x.Id == id select x).FirstOrDefault();
            if (usuario == null)
            {
                throw new Exception(string.Format("Usuario com código {0} não encontrado", id));
            }
            var viewModel = new CadastrarUsuariosViewModel();
            viewModel.Nome = usuario.Nome;
            viewModel.Login = usuario.Login;
            viewModel.Senha = usuario.Senha;
            viewModel.id = usuario.Id;
            
            return View(viewModel);
        }

        //---- EDITAR


        [HttpPost]// passo2 colocacar httpPost que define que vai salvar no banco

        public ActionResult EditarUsuario(CadastrarUsuariosViewModel ViewModel) // passo 1: criar action editar  que recebe a viewModel por parametro
        {
            if (ModelState.IsValid)// Passo 3:validar modelo
            {
                var conexao = new ConexaoBanco();// passo 4 abrir conexão
                var codigo = ViewModel.id;
                var usuario = (from x in conexao.Usuarios where x.Id == codigo select x).FirstOrDefault(); // passo 5 buscar o post que vou alterar
                if (usuario != null)
                {
                    // passo 6 carregar os dados alterados na view para o post

                    usuario.Nome = ViewModel.Nome;
                    usuario.Login = ViewModel.Login;
                    usuario.Senha = ViewModel.Senha;
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

        public ActionResult ExcluirUsuario(int id)
        {
            var conexaoBanco = new ConexaoBanco();
            var usuario = (from p in conexaoBanco.Usuarios
                        where p.Id == id
                        select p).FirstOrDefault();
            if (usuario == null)
            {
                throw new Exception(string.Format("Post código {0} não existe.", id));
            }
            conexaoBanco.Usuarios.Remove(usuario);
            conexaoBanco.SaveChanges();

            return RedirectToAction("Index", "Usuarios");
        }

    }
}