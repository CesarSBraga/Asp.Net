using Lab.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Data
{
    public class ItensDao
    {
        public static void IncluirItem(Item item)
        {
            // criar nossa estrutura para acesso a base de dados
            // via EntityFramework
            using (var ctx = new DB_VENDASEntities())
            {
                //estamos alterando o estado do objeto que se relaciona com a Tabela Item
                ctx.Entry<Item>(item).State = System.Data.Entity.EntityState.Added;
                // o SaveChanges Executa a Query na mão
                ctx.SaveChanges();

                /* outra forma de fazer o insert com entity
                ctx.Itens.Add(item);
                ctx.SaveChanges();*/
            }
        }

        public static void RemoverItem(Item item)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                ctx.Entry<Item>(item).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public static Item BuscarItem(int id)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                return ctx.Itens.FirstOrDefault(p => p.Id == id);
                /*
                 select * from itens where id= id
                 */
            }
        }

        public static IEnumerable<ClientePedidoViewModel> ListarPedidos()
        {
            using (var ctx = new DB_VENDASEntities())
            {
                var lista = ctx.Clientes.Join(
                    ctx.Pedidos,
                    c => c.Documento,
                    p => p.DocCliente,
                    (c, p) => new ClientePedidoViewModel
                    {
                        Documento = c.Documento,
                        NomeCliente = c.Nome + " - " + p.NumeroPedido,
                        IdPedido = p.Id,
                        NumeroPedido = p.NumeroPedido
                    });
                return lista.ToList();
            }
        }
        public static IEnumerable<ItensPedidoViewModel> ListarItensPorPedido(int? idPedido)
        {
            List<ItensPedidoViewModel> lista = new List<ItensPedidoViewModel>();
            if (idPedido != null)
            {
                using (var ctx = new DB_VENDASEntities())
                {
                    lista = (from pedido in ctx.Pedidos
                             join item in ctx.Itens
                             on pedido.Id equals item.IdPedido
                             join produto in ctx.Produtos
                             on item.IdProduto equals produto.Id
                             where pedido.Id == (int)idPedido
                             select new ItensPedidoViewModel
                             {
                                 IdItem = item.Id,
                                 QuantItens = item.Quantidade,
                                 IdPedido = pedido.Id,
                                 NumeroPedido = pedido.NumeroPedido,
                                 DescProduto = produto.Descricao,
                                 TotalItem = item.Quantidade * (double)produto.Preco
                             }).ToList();


                }
            }
            return lista;


        }


    }
}