using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.eAgenda.Dominio.TarefaModule;

namespace Uniplac.eAgenda.Infraestrutura.Dao.TarefaModule
{
    public class TarefaDao : ITarefaRepository
    {
        #region Queries Tarefa

        private const string SqlInsereTarefa =
           @"INSERT INTO [TBTarefa]
                (
                    [Titulo],       
                    [Prioridade],             
                    [DataConclusao],                    
                    [Percentual]                    
                )
            VALUES
                (
                    {0}Titulo,
                    {0}Prioridade,
                    {0}DataConclusao,
                    {0}Percentual
                )";

        private const string SqlAtualizaTarefa =
            @" UPDATE [TBTarefa]
                    SET 
                        [Prioridade] = {0}Prioridade, 
                        [Titulo] = {0}Titulo, 
                        [DataConclusao] = {0}DataConclusao, 
                        [Percentual] = {0}Percentual 

                    WHERE [Numero] = {0}Numero";

        private const string SqlExcluiTarefa =
            @"DELETE FROM [TBTarefa] 
                    WHERE [Numero] = {0}Numero";

        private const string SqlSelecionaTodasTarefas =
            @"SELECT 
                    [Numero],       
                    [Titulo],       
                    [Prioridade],             
                    [DataConclusao],                    
                    [Percentual]
              FROM
                    [TBTarefa]";

        private const string SqlSelecionaTodasTarefasConcluidas =
            @"SELECT 
                    [Numero],
                    [Titulo],       
                    [Prioridade],             
                    [DataConclusao],                    
                    [Percentual]
              FROM
                    [TBTarefa]

              WHERE [Percentual] = 100";

        private const string SqlSelecionaTodasTarefasPendentes =
         @"SELECT 
                    [Numero],
                    [Titulo],       
                    [Prioridade],             
                    [DataConclusao],                    
                    [Percentual]
              FROM
                    [TBTarefa]

              WHERE [Percentual] < 100";

        private const string SqlSelecionaTarefaPorNumero =
           @"SELECT 
                    [Numero],
                    [Titulo],       
                    [Prioridade],             
                    [DataConclusao],                    
                    [Percentual]
             FROM
                    [TBTarefa]

             WHERE [Numero] = {0}Numero";

        #endregion

        #region Queries Item da Tarefa

        private const string SqlInsereItemTarefa =
          @"INSERT INTO [TBItemTarefa]
                (
                    [Titulo],                                                                         
                    [Percentual],
                    [TarefaNumero]
                )
            VALUES
                (
                    {0}Titulo,                    
                    {0}Percentual,
                    {0}TarefaNumero
                )";

        private const string SqlAtualizaItemTarefa =
           @" UPDATE [TBItemTarefa]
                    SET                                                                           
                        [Percentual] = {0}Percentual 

                    WHERE [Numero] = {0}Numero";

        private const string SqlExcluiItensTarefa =
           @"DELETE FROM [TBItemTarefa] 
                    WHERE [TarefaNumero] = {0}TarefaNumero";

        private const string SqlSelecionaTodosItensTarefa =
          @"SELECT 
                    [Numero],
                    [Titulo],                                                           
                    [Percentual]
            FROM
                    [TBItemTarefa]

            WHERE [TarefaNumero] = {0}TarefaNumero";

        #endregion

        public Tarefa AdicionarTarefa(Tarefa tarefa)
        {
            tarefa.Numero = Db.Insert(SqlInsereTarefa, GetParametrosTarefa(tarefa));

            foreach (ItemTarefa item in tarefa.ItensExecucacao)
            {
                Db.Insert(SqlInsereItemTarefa, GetParametrosItemTarefa(item));
            }

            return tarefa;
        }

        public void AtualizarTarefa(Tarefa tarefaAtualizada)
        {
            Db.Update(SqlAtualizaTarefa, GetParametrosTarefa(tarefaAtualizada));

            foreach (ItemTarefa item in tarefaAtualizada.ItensExecucacao)
            {
                if (item.Numero != 0)
                {
                    Db.Update(SqlAtualizaItemTarefa, GetParametrosItemTarefa(item));
                    continue;
                }
                Db.Insert(SqlInsereItemTarefa, GetParametrosItemTarefa(item));
            }
        }

        public void ExcluirTarefa(Tarefa tarefaEncontrada)
        {
            Db.Delete(SqlExcluiItensTarefa, new object[] { "TarefaNumero", tarefaEncontrada.Numero });

            Db.Delete(SqlExcluiTarefa, GetParametrosTarefa(tarefaEncontrada));
        }

        public Tarefa SelecionarTarefaPorNumero(int numero)
        {
            Tarefa tarefa = Db.Get<Tarefa>(SqlSelecionaTarefaPorNumero, ConverterEmTarefa, new object[] { "Numero", numero });

            List<ItemTarefa> itens = Db.GetAll<ItemTarefa>(SqlSelecionaTodosItensTarefa, ConverterEmItemTarefa, new object[] { "TarefaNumero", numero });

            foreach (ItemTarefa item in itens)
            {
                tarefa.AdicionaItemExecucao(item);
            }

            return tarefa;
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
            return Db.GetAll(SqlSelecionaTodasTarefasConcluidas, ConverterEmTarefa);
        }

        public List<Tarefa> SelecionarTarefasPendentes()
        {
            return Db.GetAll(SqlSelecionaTodasTarefasPendentes, ConverterEmTarefa);
        }

        public List<Tarefa> SelecionarTodasTarefas()
        {
            return Db.GetAll(SqlSelecionaTodasTarefas, ConverterEmTarefa);
        }

        #region métodos privados

        private Tarefa ConverterEmTarefa(IDataReader reader)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Numero = Convert.ToInt32(reader["Numero"]);
            tarefa.Titulo = Convert.ToString(reader["Titulo"]);
            tarefa.DataConclusao = Convert.ToDateTime(reader["DataConclusao"]);
            tarefa.Prioridade = Convert.ToInt32(reader["Prioridade"]);
            tarefa.Percentual = Convert.ToDouble(reader["Percentual"]);

            return tarefa;
        }

        private ItemTarefa ConverterEmItemTarefa(IDataReader reader)
        {
            ItemTarefa itemTarefa = new ItemTarefa();
            itemTarefa.Numero = Convert.ToInt32(reader["Numero"]);
            itemTarefa.Titulo = Convert.ToString(reader["Titulo"]);
            itemTarefa.Percentual = Convert.ToDouble(reader["Percentual"]);

            return itemTarefa;
        }

        private object[] GetParametrosTarefa(Tarefa tarefa)
        {
            return new Object[]
            {
                "Titulo", tarefa.Titulo, 
                "Prioridade", tarefa.Prioridade, 
                "Percentual", tarefa.Percentual, 
                "DataConclusao", tarefa.DataConclusao, 
                "Numero", tarefa.Numero
            };
        }

        private object[] GetParametrosItemTarefa(ItemTarefa itemTarefa)
        {
            return new Object[]
            {
                "Titulo", itemTarefa.Titulo,                 
                "Percentual", itemTarefa.Percentual, 
                "TarefaNumero", itemTarefa.Tarefa.Numero, 
                "Numero", itemTarefa.Numero
            };
        }

        #endregion
    }
}