using Capitulo06.Labs.Data;
using Capitulo06.Labs.Enumerations;
using Capitulo06.Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capitulo06.Labs.Controllers
{
    public class PagamentosController : ApiController
    {
        public IEnumerable<Fatura> GetFaturas()
        {
            return PagamentosDao.ListarFaturas();
        }

        public HttpResponseMessage PostFatura(Fatura fatura)
        {
            StatusPagamento status = PagamentosDao.IncluirFatura(fatura);
            
            // verifica se o pagamento foi processado com sucesso
            if (status != StatusPagamento.PAGAMENTO_OK)
            {
                var mensagem = string.Empty;

                switch (status)
                {
                    case StatusPagamento.CARTAO_INEXISTENTE:
                        mensagem = "O cartão informado não existe";
                        break;
                    case StatusPagamento.PEDIDO_JA_PAGO:
                        mensagem = "Ja foi realizado o pagamento desse pedido";
                        break;
                    case StatusPagamento.SALDO_INDISPONIVEL:
                        mensagem = "O cartão não possui saldo disponível";
                        break;
                    default:
                        mensagem = "Erro no processamento do pagamento";
                        break;
                }
                // vamos criar uma resposta para mensagem retorno
                var erro = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Erro no servidor"),
                    ReasonPhrase = mensagem
                };
                throw new HttpResponseException(erro);
            }
            else
            {
                // cria o cabeçalho da resposta
                var response = Request.CreateResponse<Fatura>( HttpStatusCode.Created, fatura);
                string uri = Url.Link("DefaultApi", new { id = fatura.Id });

                response.Headers.Location = new Uri(uri);

                return response;
            }
        }
    }
}
