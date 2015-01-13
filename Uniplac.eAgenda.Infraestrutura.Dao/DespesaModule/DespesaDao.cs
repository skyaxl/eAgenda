using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.eAgenda.Dominio.DespesaModule;

namespace Uniplac.eAgenda.Infraestrutura.Dao.DespesaModule
{
    public class DespesaDao : IDespesaRepository
    {
        #region Queries Tarefa

        private const string SqlInsereDespesa=
           @"INSERT INTO [TBDespesa]
                (
                    [Descricao],       
                    [Categoria],             
                    [Data],                    
                    [Valor],
                    [FormaPagamento]
                )
            VALUES
                (
                    {0}Descricao,       
                    {0}Categoria,             
                    {0}Data,                    
                    {0}Valor,
                    {0}FormaPagamento
                )";

        private const string SqlAtualizaDespesa=
            @" UPDATE [TBDespesa]
                    SET 
                        [Descricao] = {0}Descricao,
                        [Categoria]= {0}Categoria,
                        [Data]= {0}Data,
                        [Valor]= {0}Valor,
                        [FormaPagamento]={0}FormaPagamento

                    WHERE [Numero] = {0}Numero";

        private const string SqlExcluiDespesa=
            @"DELETE FROM [TBDespesa] 
                    WHERE [Numero] = {0}Numero";

        private const string SqlSelecionaTodasDespesas =
            @"SELECT 
                    [Numero],       
                    [Descricao],       
                    [Categoria],             
                    [Data],                    
                    [Valor],
                    [FormaPagamento]
              FROM
                    [TBDespesa]";      

        private const string SqlSelecionaDespesaPorNumero =
           @"SELECT 
                    [Numero],       
                    [Descricao],       
                    [Categoria],             
                    [Data],                    
                    [Valor],
                    [FormaPagamento]
             FROM
                    [TBDespesa]

             WHERE [Numero] = {0}Numero";


        private const string SqlSelecionaDespesaPorMes =
           @"SELECT 
                    [Numero],       
                    [Descricao],       
                    [Categoria],             
                    [Data],                    
                    [Valor],
                    [FormaPagamento]
             FROM
                    [TBDespesa]

             WHERE DATEPART(month, [Data]) = {0}Mes";       

        #endregion

        public Despesa AdicionarDespesa(Despesa despesa)
        {
            despesa.Numero = Db.Insert(SqlInsereDespesa, GetParametros(despesa));
            return despesa;    
        }

        public void AtualizarDespesa(Despesa despesaAtualizada)
        {
            Db.Update(SqlAtualizaDespesa,GetParametros(despesaAtualizada));
        }

        public void ExcluirDespesa(Despesa despesaEncontrada)
        {
            Db.Delete(SqlExcluiDespesa, GetParametros(despesaEncontrada));
        }

        public Despesa SelecionarDespesaPorNumero(int numero)
        {
            return Db.Get(SqlSelecionaDespesaPorNumero, Converter, new object[] { "Numero", numero });
        }

        public List<Despesa> SelecionarTodasDespesas()
        {
            return Db.GetAll(SqlSelecionaTodasDespesas, Converter);
        }

        public DespesaMensal SelecionarDespesaPorMes(int mes)
        {
            List<Despesa> despesas = Db.GetAll(SqlSelecionaDespesaPorMes, Converter, new object[] { "Mes", mes });

            DespesaMensal despesaMensal = new DespesaMensal(mes, despesas);

            return despesaMensal;
        }

        #region métodos privados
        private Despesa Converter(IDataReader reader)
        {
            Despesa despesa = new Despesa();
            despesa.Numero = Convert.ToInt32(reader["Numero"]);
            despesa.Descricao = Convert.ToString(reader["Descricao"]);
            despesa.Categoria = Convert.ToString(reader["Categoria"]);
            despesa.Data = Convert.ToDateTime(reader["Data"]);
            despesa.Valor = Convert.ToDouble(reader["Valor"]);
            despesa.FormaPagamento = Convert.ToString(reader["FormaPagamento"]);

            return despesa;
        }

        private object[] GetParametros(Despesa despesa)
        {
            return new Object[]
            {
                "Descricao", despesa.Descricao, 
                "Data", despesa.Data, 
                "FormaPagamento", despesa.FormaPagamento, 
                "Categoria", despesa.Categoria,                               
                "Valor", despesa.Valor,  
                "Numero", despesa.Numero
            };
        }

        #endregion
        
        
    }
}
