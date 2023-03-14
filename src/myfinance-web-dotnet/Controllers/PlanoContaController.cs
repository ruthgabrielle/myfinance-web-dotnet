using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Domain.Services.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _service;


        public PlanoContaController(ILogger<PlanoContaController> logger, IPlanoContaService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.ListaPlanoConta = _service.GetAll();
            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]

        public IActionResult Cadastrar(int? id)
        {
            if (id != null)
            {
                var planoConta = _service.Get((int)id);
                return View(planoConta);
            }
            return View();
        }


        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]

        public IActionResult Cadastrar(PlanoContaModel PlanoConta)
        {
            _service.Save(PlanoConta);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}