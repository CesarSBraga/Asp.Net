using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Data
{
    public class ClientesDAO
    {
        public static void IncluirCliente(Cliente cliente)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
            }
        }
        
        //método para buscar um cliente pelo número do documento
        public static Cliente BuscarCliente(string documento)
        {
            using(var ctx = new DB_VENDASEntities())
            {
                return ctx.Clientes.FirstOrDefault(p =>
                p.Documento.Equals(documento));
            }
        }
   
        public static IEnumerable<Cliente> ListarClientes()
        {
            using (var ctx = new DB_VENDASEntities())
            {
                return ctx.Clientes.ToList();
            }
        }
        //método para alterar um cliente
        public static void AlterarCliente(Cliente cliente)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                //para alterar um registtro, vc tem que informar ao EF
                //que a tabela vai entrar em modo de  modificaçãp
                ctx.Entry<Cliente>(cliente).State = System.Data.Entity.EntityState.Modified;
                
                // aplica o Update com a execução do saveChanges
                ctx.SaveChanges();
            }
        }
        //método para remover um cliente
        public static void RemoverCliente(Cliente cliente)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                ctx.Entry<Cliente>(cliente).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            
        }

    }
}