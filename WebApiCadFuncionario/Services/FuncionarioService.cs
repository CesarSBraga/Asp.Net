using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCadFuncionario.Models;


namespace WebApiCadFuncionario.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        // variável que receberá nossa injeção de dependência
        private FuncContexto contextoDb;

        public FuncionarioService(FuncContexto contexto)
        {
            contextoDb = contexto;
        }


        public RespostaModel ExcluirFuncionarioPorId(int idFunc)
        {
            RespostaModel resposta = new RespostaModel();
            try
            {
                Funcionario func = GetDetalhesFuncionarioPorId(idFunc);

                if (func != null)
                {
                    contextoDb.Remove<Funcionario>(func);
                    contextoDb.SaveChanges();
                    resposta.Sucesso = true;
                    resposta.Mensagem = "Registro excluído com sucesso";
                }
                else
                {
                    resposta.Sucesso = false;
                    resposta.Mensagem = "Funcionário nâo existe:";
                }

            }
            catch (Exception erro)
            {

                resposta.Sucesso = false;
                resposta.Mensagem = "Ocorreu um erro" + erro.Message;
            }
            return resposta;
        }

        public Funcionario GetDetalhesFuncionarioPorId(int idFunc)
        {
            Funcionario func;

            try
            {
                func = contextoDb.Find<Funcionario>(idFunc);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return func;
        }

        public List<Funcionario> GetFuncionarios()
        {
            List<Funcionario> funcLista;

            try
            {
                funcLista = contextoDb.Set<Funcionario>().ToList();
            }
            catch (Exception )
            {

                throw;
            }

            return funcLista;
        }

        public RespostaModel SalvarFuncionario(Funcionario func)
        {
            RespostaModel resposta = new RespostaModel();

            try
            {
                Funcionario funcionario = GetDetalhesFuncionarioPorId(func.FuncionarioId);

                //se o retorno for null é pq não existe o registro na base de dados e 
                // devemos fazer um insert
                if (funcionario == null)
                {
                    contextoDb.Add<Funcionario>(func);
                    resposta.Mensagem = "Funcionario inserido com sucesso";
                }
                else
                {
                    // se caiu a execução aqui, é pq o objeto não é null, e devemos fazer um UPDAT
                    contextoDb.Update<Funcionario>(func);
                    resposta.Mensagem = "Registro Alterado com sucesso";
                }

                contextoDb.SaveChanges();
                resposta.Sucesso = true;

            }
            catch (Exception ex)
            {

                resposta.Sucesso = false;
                resposta.Mensagem = "Verifique o Erro:" + ex.Message;
            }

            return resposta;
        }
    }
}
