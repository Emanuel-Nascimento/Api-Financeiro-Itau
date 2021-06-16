using System;
using System.Collections.Generic;

namespace SistFinanceiroTest.VM
{
    public class LancamentoVM
    {
        public List<Item> Itens;
        
    }

    public class Item {
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public string Conta { get; private set; }
        public string Tipo { get; private set; }
    }
}