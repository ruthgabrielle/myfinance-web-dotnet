using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain.Services.Interfaces
{
    public interface IPlanoContaService
    {
        List<PlanoContaModel> GetAll();
        PlanoContaModel Get(int id);
        void Save(PlanoContaModel model);
        void Delete(int id);
    }
}