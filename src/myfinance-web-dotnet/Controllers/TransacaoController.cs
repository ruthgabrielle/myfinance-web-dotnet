using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class Transacao : Controller
    {
        private readonly ILogger<Transacao> _logger;
        private readonly ITransacaoService _service;
        private readonly IPlanoContaService _planoContaService;

        public Transacao(ILogger<Transacao> logger, ITransacaoService service, IPlanoContaService planoContaService)
        {
            _logger = logger;
            _service = service;
            _planoContaService = planoContaService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.TransacaoLista = _service.GetAll();
            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]

        public IActionResult Cadastrar(int? id)
        {
            var model = new TransacaoModel();
            if (id != null)
            {
                model = _service.Get((int)id);
            }
            var listaPlanoConta = _planoContaService.GetAll();
            model.PlanoContas = new SelectList(listaPlanoConta, "Id", "Descricao");
            return View(model);
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]

        public IActionResult Cadastrar(TransacaoModel Transacao)
        {
            _service.Save(Transacao);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Relatorio")]
        public IActionResult Reports()
        {
            RelatorioTransacaoModel model = new RelatorioTransacaoModel();
            model.DataInicio = DateTime.Now;
            model.DataFim = DateTime.Now;
            return View(model);
        }

    }
}