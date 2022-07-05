using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.MVC.Data;

namespace Lab.MVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Incluir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                ClientesDAO.IncluirCliente(cliente);
                return RedirectToAction("Listar");
                   
            }
            catch (Exception ex)
            {

                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        public ActionResult Listar()
        {
            try
            {
                return View(ClientesDAO.ListarClientes());
            }
            catch (Exception ex)
            {

                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        private ActionResult Buscar(string id, string viewName)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("O documento não foi informado corretamente");
                }
                var cliente = ClientesDAO.BuscarCliente(id);
                if (cliente == null)
                {
                    throw new Exception("Nenhum cliente encontrrado");
                }
                return View(viewName, cliente);
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {
                ClientesDAO.AlterarCliente(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }

        [HttpGet]
        public ActionResult Remover(int id)
        {
            return Buscar(id.ToString(), "Remover");
        }

        [HttpPost]
        public ActionResult Remover(string id)
        {
            try
            {
                var cliente = ClientesDAO.BuscarCliente(id);
                if (cliente == null)
                {
                    throw new Exception("Nenhum cliente encontrado");
                }
                ClientesDAO.RemoverCliente(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }
    }
}
