using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


namespace Lab.NetCore.Dao
{
    public class GenericDao<T> where T: class
    {
        //Propriedade que representa nosso contexto
        private EventosContext Contexto { get; set; }

        //Construtor que receberá a instância do nosso contexto
        public GenericDao( EventosContext contexto)
        {
            // usamos a palavra this para diferenciar as nomeclaturas iguais
            this.Contexto = contexto;
        }


        public void Executar(T item, TipoOperacaoDB tipo)
        {
            Contexto.Entry<T>(item).State = (EntityState)tipo;

            // executamos a query via EF core, usando o saveChanges
            Contexto.SaveChanges();
        }


        public IEnumerable<T> Listar()
        {
            return Contexto.Set<T>().ToList();
        }


        public T BuscarPorId(int id)
        {
            return Contexto.Set<T>().Find(id);
        }

    }
}
