using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab.MVC.Data
{
    public class ProdutosDao
    {
        public static void IncluirProduto(Produto produto)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
            }
        }

        public static Produto BuscarProduto(int id)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                return ctx.Produtos.FirstOrDefault(p =>
                p.Id == id);
            }
        }

        public static IEnumerable<Produto> ListarProdutos()
        {
            using (var ctx = new DB_VENDASEntities())
            {
                return ctx.Produtos.ToList();
            }
        }

        public static void AlterarProduto(Produto produto)
        {
            using (var ctx = new DB_VENDASEntities())
            {
                ctx.Entry<Produto>(produto).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static IEnumerable<Categoria> ListarCategorias()
        {
            using (var ctx = new DB_VENDASEntities())
            {
                return ctx.Categorias.ToList();
            }
        }



    }
}