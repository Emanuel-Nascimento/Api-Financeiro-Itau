using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using SistFinanceiroTest.Entity;

namespace SistFinanceiroTest.Persistence
{
    public class Dao : IDao
    {
        // TODO - ajustar connString
        private string connection = 
            "Server=localhost,11433;User=sa;Password=Pass123!;Database=basics;";


        public async Task AddLancamento(Lancamento l)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                try
                {
                    db.Open();
                    var query = "INSERT INTO Lancamentos(data, Valor, descricao, conta, tipo) VALUES(@data, @valor, @descricao, @conta, @tipo);";
                    await db.ExecuteAsync(query, l);
                }
                catch (Exception)
                {
                    //TODO - Logs
                }
                finally
                {
                    db.Close();
                }
            }
        }
    }
}