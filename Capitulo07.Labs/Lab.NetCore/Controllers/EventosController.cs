using Lab.NetCore.Dao;
using Lab.NetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.NetCore.Controllers
{
    public class EventosController : Controller
    {
        // criar uma variável PRIVADA que receberá a injeção de dependência
        // esta variável receberá este objeto no construtor da controller 
        // este objeto é enviado pelo próprio DOTNET e Entity Core

        private EventosDao eventosDao{ get; set; }

        public EventosController(EventosContext dbContexto)
        {
            this.eventosDao = new EventosDao(dbContexto);
        }


        // GET: EventosController
        public ActionResult Index()
        {
            return View();
        }

       
        // GET: EventosController/Create
        public ActionResult IncluirEvento()
        {
            return View();
        }

        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncluirEvento(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            try
            {
                eventosDao.Executar(evento, TipoOperacaoDB.Added);
                return RedirectToAction("LIstarEventos");
            }
            catch(Exception)
            {
                return View();
            }
        }


        public ActionResult ListarEventos()
        {
            try
            {
                var lista = eventosDao.Listar();
                return View(lista);
            }
            catch (Exception)
            {

                return View();
            }
        }

        [HttpGet]
        public IActionResult AlterarEvento(int id)
            {
                return ExecutarEvento(id, "AlterarEvento");
            }


        [HttpPost]
        public IActionResult AlterarEvento(Evento evento)
        {
            eventosDao.Executar(evento, TipoOperacaoDB.Modified);
            return RedirectToAction("ListarEventos");
        }

        //action HTTP Get Comum
        private IActionResult ExecutarEvento(int id, string viewName)
        {
            var evento = eventosDao.BuscarPorId(id);
            if (evento == null)
            {
                ViewData["MensagemErro"] = "Nenhum evento encontrado";
                return View("_Erro");
            }
            return View(viewName, evento);
        }

        //removendo um evento
        [HttpGet]
        public IActionResult RemoverEvento(int id)
        {
            return ExecutarEvento(id, "RemoverEvento");
        }
        [HttpPost]
        public IActionResult RemoverEvento(Evento evento)
        {
            eventosDao.Executar(evento, TipoOperacaoDB.Deleted);
            return RedirectToAction("ListarEventos");
        }

    }
}
