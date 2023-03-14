using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain.Entities;
using myfinance_web_dotnet.Domain.Services.Interfaces;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDBContext _dbContext;

        public PlanoContaService(MyFinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PlanoContaModel> GetAll()
        {
            var result = new List<PlanoContaModel>();
            var dbSet = _dbContext.PlanoConta;

            foreach (var item in dbSet)
            {
                var itemPlanoConta = new PlanoContaModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo,
                };
                result.Add(itemPlanoConta);
            }
            return result;
        }
        public void Save(PlanoContaModel model)
        {
            var dbSet = _dbContext.PlanoConta;
            var entidade = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo,
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

        public PlanoContaModel Get(int id)
        {
            var item = _dbContext.PlanoConta.Where(x => x.Id == id).First();
            var itemPlanoConta = new PlanoContaModel()
            {
                Id = item.Id,
                Descricao = item.Descricao,
                Tipo = item.Tipo,
            };
            return itemPlanoConta;
        }
        public void Delete(int id)
        {
            var planoConta = _dbContext.PlanoConta.Where(x => x.Id.Equals(id)).First();

            _dbContext.Attach(planoConta);
            _dbContext.Remove(planoConta);
            _dbContext.SaveChanges();
        }
    }
}