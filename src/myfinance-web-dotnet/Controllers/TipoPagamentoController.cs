using myfinance_web_dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Controllers
{
    public class PagamentoController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.PagamentoId = new SelectList
                (
                    new TipoPagamento().ListaTipoPagamento(),
                    "PagamentoId",
                    "Descricao");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string id)
        {

            ViewBag.PagamentoId = new SelectList(
                new TipoPagamento().ListaTipoPagamento(),
                    "PagamentoId",
                    "Descricao",
                    id
                );

            return View();

        }


    }
}
