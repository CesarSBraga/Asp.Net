using Lab.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class ItensController : Controller
    {
        // GET: Itens
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Incluir(int? idPedido)
        {
            try
            {
                ViewBag.ListaDeProdutos = new SelectList(
                ProdutosDao.ListarProdutos(), "Id", "Descricao");
                ViewBag.ListaDePedidos = new SelectList(
                ItensDao.ListarPedidos(), "IdPedido", "NomeCliente");
                ViewBag.ListaDeItens = ItensDao.ListarItensPorPedido(idPedido);
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");

            }
        }
    }
}