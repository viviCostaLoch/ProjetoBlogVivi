using BlogVivi.db;
using BlogVivi.Web.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogVivi.Web.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel viewModel, string ReturnUrl) {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var conexao = new ConexaoBanco();
            var usuario = (from p in conexao.Usuarios
                           where p.Login.ToUpper() == viewModel.Login.ToUpper()
                           && p.Senha == viewModel.senha
                           select p).FirstOrDefault();
            if (usuario== null)
            {
                ModelState.AddModelError("", "Usuario e/ou senha estão incorretos.");
                return View(viewModel);
            }
            FormsAuthentication.SetAuthCookie(usuario.Login, viewModel.Lembrar);
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index","Blog");
        }

        public ActionResult Sair() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}