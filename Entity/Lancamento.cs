using System;
using System.Collections.Generic;
using SistFinanceiroTest.SeedWork;
using SistFinanceiroTest.VM;

namespace SistFinanceiroTest.Entity
{
    // Considerado uma Classe Value Object
    public class Lancamento
    {
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public string Conta { get; private set; }
        public string Tipo { get; private set; }
        private Lancamento(){} 

        private static void ValidatePresence(string name, string data, List<string> errors){
            if (String.IsNullOrWhiteSpace(data))
                errors.Add("Campo " + name + " não informado");
        }

        public static Result<Lancamento> Create(Item item){
            return Create(item.Data, item.Valor, item.Descricao, item.Conta, item.Tipo);
        }

        public static Result<Lancamento> Create(DateTime data, decimal valor, string descricao, 
            string conta, string tipo){
            var errors = new List<string>();
            ValidatePresence("Data", data.ToString(), errors);
            ValidatePresence("Valor", valor.ToString(), errors);
            ValidatePresence("Descricao", descricao, errors);
            ValidatePresence("Conta", conta, errors);
            ValidatePresence("Tipo", tipo, errors);

            if (tipo == "c" || tipo == "d")
                errors.Add("Campo tipo pode apenas c e d");

            if (valor < 0)
                errors.Add("Campo valor pode apenas positivos");

            if (errors.Count > 0)
                return new Result<Lancamento>(){Valid = false};

            return new Result<Lancamento>(){
                Valid = true,
                Object = new Lancamento(){
                    Data = data,
                    Valor = valor,
                    Descricao = descricao,
                    Conta = conta,
                    Tipo = tipo
                }
            };
        }
    }
}