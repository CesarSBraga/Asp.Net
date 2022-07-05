using Lab.MVC.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private IEnumerable produtosDao;

        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Incluir()
        {
            /*
            Ao objeto ViewBag atribuímos uma instância de SelectList. Esta classe é
           requerida no componente DropDowListFor que usaremos na view. Como
           parâmetros, informamos a coleção, a propriedade que representará o
           item selecionado (Id) e a propriedade que representará o item visualizado
           (Descricao).
            * */
            ViewBag.ListaDeCategorias =
                new SelectList(ProdutosDao.ListarCategorias(), "id", "Descricao");

            return View();
        }

        [HttpPost]
        public ActionResult Incluir(Produto produto, HttpPostedFileBase
image)
        {
            if (!ModelState.IsValid)
            {
                return Incluir();
            }
            try
            {
                // verifica se foi enviado o arquivo imagem
                if (image != null)
                {
                    // aqui fazemos a conversão da imagem para binario para seu armazenamento
                    produto.MimeType = image.ContentType;
                    byte[] bytes = new byte[image.ContentLength];
                    image.InputStream.Read(bytes, 0, image.ContentLength);
                    produto.Foto = bytes;
                }
                ProdutosDao.IncluirProduto(produto);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");

            }

        }
            public FileResult BuscarFoto(int id)
            {
                var foto = ProdutosDao.BuscarProduto(id);
                return File(foto.Foto, foto.MimeType);
            }

        public ActionResult Listar()
        {
            return View(ProdutosDao.ListarProdutos());
        }


        [HttpGet]
        public ActionResult Alterar(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Nenhum código fornecido");
                }
                var produto = ProdutosDao.BuscarProduto((int)id);
                if (produto == null)
                {
                    throw new
                    Exception("Nenhum produto encontrado com este código");
                }
                ViewBag.ListaDeCategorias = new SelectList(
                ProdutosDao.ListarCategorias(), "Id", "Descricao");
                return View(produto);
            }
            catch (Exception ex)
            {
                ViewBag.MensagemErro = ex.Message;
                return View("_Erro");
            }
        }


        [HttpPost]
        public ActionResult Alterar(Produto produto, HttpPostedFileBase
image)
        {
            if (!ModelState.IsValid)
            {
                return Alterar(produto.Id);
            }
            try
            {
                if (image != null)
                {
                    produto.MimeType = image.ContentType;
                    byte[] bytes = new byte[image.ContentLength];
                    image.InputStream.Read(bytes, 0, image.ContentLength);
                    produto.Foto = bytes;
                }
                ProdutosDao.AlterarProduto(produto);
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