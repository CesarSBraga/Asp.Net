using Lab.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.NetCore.Dao
{
    public class ParticipantesDao : GenericDao<Participante>
    {
        private EventosContext Context { get; set; }
        public ParticipantesDao(EventosContext context)
        : base(context)
        {
            this.Context = context;
        }
        //método para listar os participantes por evento
        public IEnumerable<Participante> ListarPorEvento(
        int idEvento)
        {
            return Context.Participantes
            .Where(p => p.EventoInfoId == idEvento)
            .ToList();
        }
    } 
}
        
