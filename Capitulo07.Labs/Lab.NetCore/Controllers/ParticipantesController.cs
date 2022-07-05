using Lab.NetCore.Dao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.NetCore.Controllers
{
    public class ParticipantesController : Controller
    {

        private EventosDao eventosDao { get; set; }
        private ParticipantesDao participantesDao { get; set; }
        public ParticipantesController(EventosContext context)
        {
            this.eventosDao = new EventosDao(context);
            this.participantesDao = new ParticipantesDao(context);
        }




        public IActionResult Index()
        {
            return View();
        }
    }

    [HttpGet]
    public ActionResult IncluirParticipante()
    {
        ViewBag.ListaDeEventos = new
        SelectList(eventosDao.Listar(), "Id", "Descricao");
        return View();
    }
    [HttpPost]
    public IActionResult IncluirParticipante(Participante participante)
    {
        if (participante.EventoInfoId == 0)
        {
            ModelState.AddModelError("IdEvento",
            "Nenhum evento selecionado ");
        }
        if (!ModelState.IsValid)
        {
            return IncluirParticipante();
        }
        participantesDao.Executar(participante, TipoOperacaoBD.Added);
        return RedirectToAction("Index");
    }
}




