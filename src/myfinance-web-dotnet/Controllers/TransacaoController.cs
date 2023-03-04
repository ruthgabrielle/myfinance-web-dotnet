using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class Transacao : Controller
    {
        private readonly ILogger<Transacao> _logger;

        public Transacao(ILogger<Transacao> logger)
        {
            _logger = logger;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();
        }

         [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(TransacaoModel Transacao)
        {
            return View();
        }
    }
}