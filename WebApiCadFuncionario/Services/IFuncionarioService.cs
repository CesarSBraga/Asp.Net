using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCadFuncionario.Models;

namespace WebApiCadFuncionario.Services
{
    public interface IFuncionarioService
    {
        List<Funcionario> GetFuncionarios();

        Funcionario GetDetalhesFuncionarioPorId(int idFunc);

        RespostaModel SalvarFuncionario(Funcionario func);

        RespostaModel ExcluirFuncionarioPorId(int idFunc);
    }
}
