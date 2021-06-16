using System.Threading.Tasks;
using SistFinanceiroTest.Entity;
using SistFinanceiroTest.SeedWork;
using SistFinanceiroTest.VM;

namespace SistFinanceiroTest.Service
{
    public interface ITransactionService
    {
        Task<Result<ConsultaLancamentoVM>> ConsultaLancamentos(string mes, string ano);
        Task<Result<Lancamento>> InsertLancamentos(LancamentoVM vm);
    }
}