using Capitulo06.Labs.Enumerations;
using Capitulo06.Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitulo06.Labs.Data
{
    public class PagamentosDao
    {
        public static IEnumerable<Fatura> ListarFaturas()
        {
            using (var ctx = new PagamentosContext())
            {
                return ctx.Faturas.ToList();

            }
        }

        public static StatusPagamento IncluirFatura(Fatura fatura)
        {
            using (var ctx = new PagamentosContext())
            {
                //verificando se o cartão existe
                //Se existir, definimos uma referência a ele
                var cartao = ctx.Cartoes.FirstOrDefault(p => p.NumeroCartao.Equals(fatura.NumeroCartao));

                if (cartao == null)
                {
                    return StatusPagamento.CARTAO_INEXISTENTE;
                }
                //verificando se o pedido já foi pago
                var fat = ctx.Faturas.FirstOrDefault(p => p.NumeroPedido.Equals(fatura.NumeroPedido));
                
                if (fat != null)
                {
                    return StatusPagamento.PEDIDO_JA_PAGO;
                }

                //verificando se existe saldo no cartão, assumindo que:
                //Status = 1 -> Fatura ainda não paga (em aberto)
                //Status = 2 -> Fatura já paga (fechada)
                double total = fatura.Valor;
                var pagamentos = ctx.Faturas.Where(p => p.NumeroCartao.Equals(fatura.NumeroCartao));
                
                if (pagamentos.Count() > 0)
                {
                    total += pagamentos.Sum(s => s.Valor);
                }

                if (total > cartao.Limite)
                {
                    return StatusPagamento.SALDO_INDISPONIVEL;
                }

                //Se passar pelas validações, efetuamos o pagamento
                ctx.Faturas.Add(fatura);
                ctx.SaveChanges();

                return StatusPagamento.PAGAMENTO_OK;
            }
        }
    }
}
