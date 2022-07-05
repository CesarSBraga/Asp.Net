using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCadFuncionario.Models;
using WebApiCadFuncionario.Services;

namespace WebApiCadFuncionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

    
     IFuncionarioService _funcionarioService;
   


    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetTodosFuncionarios()
        {
                /*à variável funcionario. Se a variável não for nula, retornamos o status ok com
               * esta variável, caso contrário, retornamos não encontrado.*/
                try
                {
                    var funcionarios = _funcionarioService.GetFuncionarios();

                    if (funcionarios == null || funcionarios.Count <= 0 )
                    {
                        return NotFound();
                    }

                    return Ok(funcionarios);

                }
                catch (Exception)
                {

                    return BadRequest();
                }

        }


        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetFuncionarioPorId(int id)
        {
            try
            {
                var funcionarios = _funcionarioService.GetDetalhesFuncionarioPorId(id);

                if (funcionarios == null)
                    return NotFound();

                return Ok(funcionarios);

               
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SalvarFuncionarios(Funcionario funcinarioMOD)
        {
            try
            {
                var model = _funcionarioService.SalvarFuncionario(funcinarioMOD);

                return Ok(model);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult ExcluirFuncionario(int id)
        {
            try
            {
                var model = _funcionarioService.ExcluirFuncionarioPorId(id);
                return Ok(model);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
