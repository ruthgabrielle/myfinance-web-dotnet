using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Models
{
    public class TipoPagamento
    {
        public int PagamentoId { get; set; }

        public string Descricao { get; set; }

        public List<TipoPagamento> ListaTipoPagamento()
        {
            return new List<TipoPagamento>
            {

                new TipoPagamento { PagamentoId = 1, Descricao = "Dinheiro"},
                new TipoPagamento { PagamentoId = 2, Descricao = "Débito"},
                new TipoPagamento { PagamentoId = 3, Descricao = "Crédito"},
                new TipoPagamento { PagamentoId = 4, Descricao = "Pix"},
                new TipoPagamento { PagamentoId = 5, Descricao = "Boleto"}

            };

        }


    }
}
