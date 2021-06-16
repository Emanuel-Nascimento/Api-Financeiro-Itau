using System.Collections.Generic;
using System.Threading.Tasks;
using SistFinanceiroTest.Entity;
using SistFinanceiroTest.Persistence;
using SistFinanceiroTest.SeedWork;
using SistFinanceiroTest.VM;

namespace SistFinanceiroTest.Service
{
    public class TransactionService : ITransactionService
    {
        public IDao _dao;

        public TransactionService(IDao dao)
        {
            _dao = dao;
        }

        public async Task<Result<Lancamento>> InsertLancamentos(LancamentoVM vm){
            var valid = new List<Lancamento>();
            //se ao menos um vier invalido, paro a criação-validação
            //e retorno aquele que deu errado + erros de validação
            foreach(Item lancamento in vm.Itens){
                var res = Lancamento.Create(lancamento);
                if (res.Valid)
                    valid.Add(res.Object);
                else return res;
            }
            //já que todos são válidos...
            foreach(Lancamento lancamento in valid){
                await _dao.AddLancamento(lancamento);
            }
            return new Result<Lancamento>(){Valid = false};
        }

        public async Task<Result<ConsultaLancamentoVM>> ConsultaLancamentos(string mes, string ano){
            // TODO - Implementar
            return await Task.FromResult<Result<ConsultaLancamentoVM>>(null);
        }
    }
}