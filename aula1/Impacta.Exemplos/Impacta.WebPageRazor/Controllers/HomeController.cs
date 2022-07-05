using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Impacta.WebPageRazor.Models;

using Impacta.WebPageRazor.Models.Repositorio;

namespace Impacta.WebPageRazor.Controllers
{
    public class HomeController : Controller
    {
        // quando criar variaveis ou propriedades na controller,
        // nao esqueça de deixa-las privadas.
        private CursoDBContext db = null;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult IncluirCurso()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IncluirCurso(Curso curso)
        {
            //verificamos se estado do objeto recebido é valido
            if (!ModelState.IsValid)
            {
                //caso não seja valido, retornamos a mesma pagina
                ViewBag.MensagemErro = "Formulário inválido.";



                return View();
            }

            //criamos um objeto contexto para incluir o curso no BD
            CursoDBContext dBCurso = new CursoDBContext();

            // prepara o comando insert

            dBCurso.Cursos.Add(curso);
            // o entity framework executa o insert no banco de dados

            var retorno = dBCurso.SaveChanges();

            if (retorno <= 0)
            {
                ViewBag.MensagemErro = ("Falha ao realizar o cadastro");
                return View();

            }

            TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";
            return RedirectToAction("IncluirCurso");



        }


    

        [HttpGet]
        public ActionResult CadastrarCurso()
        {
            return View();
        }




        [HttpPost]
        public ActionResult CadastrarCurso(FormCollection formulario)
        {
            var titulo = formulario["Titulo"];
            var descricao = formulario["Descrição"];
            var valor = Convert.ToDecimal(formulario["Valor"]);

            // vamos criar um objeto curso
            Curso curso = new Curso
            {
                Titulo = titulo,
                Descricao = descricao,
                Valor = valor
            };
            return View("Index");
        }


        public ActionResult ListarCursos()
        {
            CursoDBContext dbCurso = new CursoDBContext();
            // fazemos o nosso SELECT do sql (Select * from cursos)
            try             

            {
                var lista = dbCurso.Cursos.ToList();

                if (lista == null)
                {
                    ViewBag.MensagemErro = "Não existe cursos a serem apresentados";
                    return View();
                }

                return View(lista);

            }
            catch (Exception ex)
            {

                ViewBag.MensagemErro = "Ocorreu uma falha ao executar a consulta da lista";
                return View();
            }

        }
        [HttpGet]
        public ActionResult EditarCurso(int ? id)
        {
            // se for nulo ja devolve um erro 400 no padrão HTTP / RESTFULL
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            //criar a instancia do objeto do nosso contexto
            db = new CursoDBContext();
            // senão, busca no bco.dados um SELECT com Where
            Curso curso = db.Cursos.Find(id);

            // se retornou nulo é pq o registro não existe, devolve o erro
            if (curso == null)
            {
                return HttpNotFound();
            }
            //se voltou diferente de nulo é valido, devolve para a view tipada
            return View(curso);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCurso(Curso curso)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            //instanciamos um objeto context para alterar o curso no BD
            db = new CursoDBContext();

            // indica para Entity que vamos realizar um UPDATE
            db.Entry(curso).State = System.Data.Entity.EntityState.Modified;

            // o SaveChanges executa o UPDATE no banco
            db.SaveChanges();

            return RedirectToAction("ListarCurso");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        /*
                 [Bind(Include =
                 -> Pode ser usado como uma facilitador ou como segurança para garantir 
                que nada além do que é necessário será afetado inadvertidamente.
                 */
        public ActionResult EditarCurso_Bind([Bind(Include = "ID,Titulo,Valor,Descricao")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                // indica para o EntityFramework que será realizado um UPDATE
                db.Entry(curso).State = System.Data.Entity.EntityState.Modified;

                // Executa o UPDATE no Banco de dados
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(curso);
        }

        [HttpGet]
        public ActionResult DetalheCurso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            db = new CursoDBContext();
            Curso curso = db.Cursos.Find(id);

            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);

        }
        
        [HttpGet]
        public ActionResult ExcluirCurso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // opcionalmente pode-se verificar se o objeto ja esta instanciado, senão tiver então instanciamos
            if (db == null)
                db = new CursoDBContext();

        Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }
        
        [HttpPost, ActionName("ExcluirCurso")]
        [ValidateAntiForgeryToken]
        public ActionResult ExclusaoConfirmada(int id)
        {
            db = new CursoDBContext();
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
            db.SaveChanges();
            return RedirectToAction("ListarCursos");
        }



        /* comentamos o métod de exempolo de utilização dos viewbags e viewdata
        public ActionResult Cursos()
        {
            var curso = new Curso();

            curso.Titulo = "C# com ASP.NET MVC";
            curso.Descricao = "Curso de Desenvolvimento Web";
            curso.Valor = 100m;

            // Lista tipada de cursos
            List<Curso> listaDeCursos = new List<Curso>();
            // adiciona um objeto do tipo curso na lista
            listaDeCursos.Add(curso);

            //cria um array de string para enviar via viewbag
            string[] listaDeAlunos = new string[10];
            listaDeAlunos[0] = "Alex";
            listaDeAlunos[1] = "Jonatas";


            ViewBag.ListaCursos = listaDeCursos;
            ViewBag.Alunos = listaDeAlunos;

            return View(curso);
        }
        */



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}