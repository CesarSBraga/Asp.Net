using Lab.MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lab.MVC.Controllers
{
    public class UsuariosController : Controller
    {
     
        [HttpGet]
        public ActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarUsuario(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                //criar usuario no identity
                //precisamos de uma instancia de userstore para depois criar um usermanager
                var usuarioStore = new UserStore<IdentityUser>();

                //criamos agora o objeto userManager para gerenciar os usuarios
                var usuarioManager = new UserManager<IdentityUser>(usuarioStore);

                // cria uma identidade do usuario
                var usuarioInfo = new IdentityUser()
                {
                    UserName = usuario.Nome
                };
                // cria usuario
                IdentityResult resultado = usuarioManager.Create(usuarioInfo, usuario.Senha);

                if (resultado.Succeeded)
                {
                    //Autentica e volta para pagina inicial
                    var autManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                    var identidadeUsuario = usuarioManager.CreateIdentity(usuarioInfo, DefaultAuthenticationTypes.ApplicationCookie);
                    autManager.SignIn(new AuthenticationProperties() { }, identidadeUsuario);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    throw new Exception(resultado.Errors.FirstOrDefault());
                }

            }
            catch (Exception ex)
            {

               ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel usuario, string returnUrl)
        {
            // recomendado o uso do model view state
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var usuarioStore = new UserStore<IdentityUser>();
                var usuarioManager = new UserManager<IdentityUser>(usuarioStore);

                var usuarioInfo = usuarioManager.Find(usuario.Nome, usuario.Senha);

                if (usuarioInfo != null)
                {
                    var autManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;

                    var identidadeUsuario = usuarioManager.CreateIdentity(usuarioInfo, DefaultAuthenticationTypes.ApplicationCookie);

                    autManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identidadeUsuario);
                    return returnUrl == null ? Redirect("/Home/Index") : Redirect(returnUrl);
                }

                else
                {
                    throw new Exception("Usuário ou Senha invállidos");
                }

            }
            catch (Exception ex)
            {

                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }


        [HttpGet]
        public ActionResult Logout()
        {
            var autManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            autManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}