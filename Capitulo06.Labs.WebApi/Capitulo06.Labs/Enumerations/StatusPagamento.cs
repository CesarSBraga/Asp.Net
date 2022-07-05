using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capitulo06.Labs.Enumerations
{
    public enum StatusPagamento
    {
        SALDO_INDISPONIVEL,
        PEDIDO_JA_PAGO,
        CARTAO_INEXISTENTE,
        PAGAMENTO_OK
    }
}