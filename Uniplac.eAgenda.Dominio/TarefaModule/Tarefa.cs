using System;
using System.Collections.Generic;
using System.Linq;

namespace Uniplac.eAgenda.Dominio.TarefaModule
{
    public class Tarefa
    {
        public Tarefa()
        {
            DataConclusao = DateTime.Now.AddDays(1);
        }

        public int Numero { get; set; }
        public double Prioridade { get; set; }
        public string Titulo { get; set; }
        public DateTime DataConclusao { get; set; }
        public List<ItemTarefa> ItensExecucacao { get; set; }
        public double Percentual { get; set; }

        private static int contador = 0;

        public void AdicionaItemExecucao(ItemTarefa itemExecucao)
        {
            if(ItensExecucacao == null)
                ItensExecucacao = new List<ItemTarefa>();

            ItensExecucacao.Add(itemExecucao);
            itemExecucao.Tarefa = this;

            CalculaPercentual();
        }

        public void RemoveItemExecucao(ItemTarefa itemExecucao)
        {            
            ItensExecucacao.Remove(itemExecucao);

            CalculaPercentual();
        }


        public void AtualizarPercentual(int n, double percentual)
        {
            ItemTarefa item = ItensExecucacao.Find(delegate(ItemTarefa iet)
            {
                return iet.Numero == n;
            });

            item.AtualizaPercentual(percentual);

            CalculaPercentual();
        }

        public override string ToString()
        {
            return string.Format("Nº: {0} - Título: {1} - Percentual: {2}", Numero, Titulo, Percentual.ToString("#0.00"));
        }

        public bool EstaConcluida()
        {          
            int percentual = (int)Percentual;

            bool estaFechada = false;

            if (percentual == 100)
                estaFechada = true;

            return estaFechada;
        }
        public bool EstaPendente()
        {
            return !EstaConcluida();
        }

        #region métodos privados

        private void CalculaPercentual()
        {
            double totalItensConcluidos = ObtemQuantidadeItensConcluidos();

            double totalItens = ObtemQuantidadeItensTarefa();

            Percentual = (totalItensConcluidos / totalItens) * 100d;
        }

        private int ObtemQuantidadeItensConcluidos()
        {
            int qtdItensConcluidos = 0;

            foreach (ItemTarefa itemExecucaoTarefa in ItensExecucacao)
            {
                if (itemExecucaoTarefa.EstaFechado())
                {
                    qtdItensConcluidos++;
                }
            }

            return qtdItensConcluidos;
        }

        private int ObtemQuantidadeItensTarefa()
        {
            return ItensExecucacao.Count;
        }

        #endregion

        public void Valida()
        {
           if(string.IsNullOrEmpty(Titulo))
               throw new ApplicationException("O titulo da tarefa deve ser preenchido.");
           if (ItensExecucacao== null || !ItensExecucacao.Any())
               throw new ApplicationException("A tarefa deve possuir ao menos um item de execução.");
        }
    }
}
