using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }

        public string? Tipo { get; set; }

        public PlanoContaModel() { }
    }
}