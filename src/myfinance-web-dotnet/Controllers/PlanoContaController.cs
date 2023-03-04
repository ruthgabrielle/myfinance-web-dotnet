using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
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
        public IActionResult Cadastrar(PlanoContaModel PlanoConta)
        {
            return View();
        }
    }
}