using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Lab.NetCore.Models;

namespace Lab.NetCore.Dao
{
    public class EventosDao : GenericDao<Evento>
    {
        public EventosDao(EventosContext contexto) : base(contexto)
        {

        }
    }
}
