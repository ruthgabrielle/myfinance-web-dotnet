using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain.Entities;
using myfinance_web_dotnet.Domain.Services.Interfaces;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDBContext _dbContext;

        public TransacaoService(MyFinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TransacaoModel> GetAll()
        {
            List<TransacaoModel> result = new List<TransacaoModel>();
            var dbSet = _dbContext.Transacao.Include(x => x.PlanoConta);

            foreach (var item in dbSet)
            {
                var itemTransacao = new TransacaoModel()
                {
                    Id = item.Id,
                    Data = item.Data,
                    Historico = item.Historico,
                    Valor = item.Valor,
                    PlanoContaTransacao = new PlanoContaModel
                    {
                        Id = item.PlanoConta.Id,
                        Descricao = item.PlanoConta.Descricao,
                        Tipo = item.PlanoConta.Tipo
                    },
                    PlanoContaId = (int)item.PlanoContaId,
                };
                result.Add(itemTransacao);
            }
            return result;
        }
        public void Save(TransacaoModel model)
        {
            var dbSet = _dbContext.Transacao;

            var entidade = new Transacao()
            {
                Id = model.Id,
                Data = model.Data,
                Historico = model.Historico,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };

            if (entidade.Id == null)
            {
                dbSet.Add(entidade);
            }
            else
            {
                dbSet.Attach(entidade);
                _dbContext.Entry(entidade).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public TransacaoModel Get(int id)
        {
            var item = _dbContext.Transacao.Where(x => x.Id == id).First();

            var itemTransacao = new TransacaoModel()
            {
                Id = item.Id,
                Data = item.Data,
                Historico = item.Historico,
                Valor = item.Valor,
                PlanoContaId = item.PlanoContaId,
            };
            return itemTransacao;
        }
        public void Delete(int id)
        {
            var item = _dbContext.Transacao.Where(x => x.Id == id).First();

            _dbContext.Attach(item);
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }

        public RelatorioTransacaoModel GetAllByPeriod(DateTime dataInicio, DateTime dataFim)
        {

            var dbSet = _dbContext.Transacao
                .Include(x => x.PlanoConta)
                .Where(x => x.Data >= dataInicio.Date && x.Data <= dataFim.Date);

            List<TransacaoModel> lista = new List<TransacaoModel>();

            foreach (var item in dbSet)
            {
                lista.Add(new TransacaoModel
                {
                    Id = item.Id,
                    Data = item.Data,
                    Historico = item.Historico,
                    Valor = item.Valor,
                    PlanoContaTransacao =
                        new PlanoContaModel
                        {
                            Id = item.PlanoConta.Id,
                            Descricao = item.PlanoConta.Descricao,
                            Tipo = item.PlanoConta.Tipo
                        },
                    PlanoContaId = (int)item.PlanoConta.Id,
                    PlanoContaTipo = item.PlanoConta.Tipo
                });
            }

            RelatorioTransacaoModel relatorio = new RelatorioTransacaoModel();
            relatorio.DataInicio = dataInicio;
            relatorio.DataFim = dataFim;
            relatorio.Transacoes = lista;
            relatorio.CountEntradasTransacao = lista
                .Where(x => x.PlanoContaTipo.Equals("R"))
                .ToList()
                .Count();
            relatorio.CountDespesasTransacao = lista
                .Where(x => x.PlanoContaTipo.Equals("D"))
                .ToList()
                .Count();
            return relatorio;
        }
    }
}