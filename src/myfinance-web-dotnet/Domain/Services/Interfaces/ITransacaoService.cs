using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Domain.Services.Interfaces
{
    public interface ITransacaoService
    {
        List<TransacaoModel> GetAll();
        TransacaoModel Get(int id);
        void Save(TransacaoModel model);
        void Delete(int id);
    }
}