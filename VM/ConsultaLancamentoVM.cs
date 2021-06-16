using System;
using System.Collections.Generic;

namespace SistFinanceiroTest.VM
{
    public class ConsultaLancamentoVM
    {
        public Totalizadores Totalizadores;
        public List<Item> Lancamentos;
        
    }

    public class Totalizadores{
        public decimal Itau { get; set; }
        public decimal Carteira { get; set; }
        public decimal Saldo { get; set; }
    }
}