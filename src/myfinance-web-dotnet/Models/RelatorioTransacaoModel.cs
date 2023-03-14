using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_dotnet.Models
{
    public class RelatorioTransacaoModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<TransacaoModel> Transacoes { get; set; }
        public int CountEntradasTransacao { get; set; }
        public int CountDespesasTransacao { get; set; }

        public RelatorioTransacaoModel()
        {
            Transacoes = new List<TransacaoModel>();
        }
    }
}