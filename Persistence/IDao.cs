using System.Threading.Tasks;
using SistFinanceiroTest.Entity;

namespace SistFinanceiroTest.Persistence
{
    public interface IDao
    {
        Task AddLancamento(Lancamento l);
    }
}