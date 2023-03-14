namespace myfinance_web_dotnet.Models
{
    public class TipoPagamento
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public List<TipoPagamento> ListaTipoPagamento()
        {
            return new List<TipoPagamento>
            {

                new TipoPagamento { Id = 1, Descricao = "Dinheiro"},
                new TipoPagamento { Id = 2, Descricao = "Débito"},
                new TipoPagamento { Id = 3, Descricao = "Crédito"},
                new TipoPagamento { Id = 4, Descricao = "Pix"},
                new TipoPagamento { Id = 5, Descricao = "Boleto"}

            };

        }


    }
}
