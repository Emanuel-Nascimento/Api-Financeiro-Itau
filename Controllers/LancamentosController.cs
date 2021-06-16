using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistFinanceiroTest.Service;
using SistFinanceiroTest.VM;

namespace SistFinanceiroTest.Controllers
{
    [ApiController]
    [Route("api/lancamentos")]
    public class LancamentosController
    {

        public ITransactionService _service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult> Post([FromBody] LancamentoVM lancamentoVM)
        {
            var result = await _service.InsertLancamentos(lancamentoVM);
            if(result.Valid){
                return new OkResult();
            } else return new BadRequestObjectResult(result);
        }

        //GET api/lancamentos
        [HttpGet("{data}")]
        [Consumes("application/json")]
        public async Task<ActionResult> Get(string data)
        {
            //TODO - Validar ano e mes.
            var splittedData = data.Split("-");
            var result = await _service.ConsultaLancamentos(splittedData[0], splittedData[1]);
            if(result.Valid)
                return new OkResult();

            return new BadRequestObjectResult(result);
        }
        
    }
}