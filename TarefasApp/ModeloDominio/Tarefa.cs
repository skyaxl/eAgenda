using System;
using System.Collections.Generic;

namespace Exemplo2.TarefasApp.ModeloDominio
{
    public class Tarefa
    {
        public static int contador = 0;
        public int numero;
        public double prioridade;
        public string titulo;
        public DateTime dataExecucao;
        public List<ItemExecucaoTarefa> itensExecucacao;

        public Tarefa()
        {
            contador++;
            numero = contador;
            itensExecucacao = new List<ItemExecucaoTarefa>();
        }

        public void AdicionaItemExecucao(ItemExecucaoTarefa itemExecucao)
        {
            itensExecucacao.Add(itemExecucao);
        }

        public double ObtemPercentual()
        {
            double totalItensConcluidos = ObtemQuantidadeItensConcluidos();

            double totalItens = ObtemQuantidadeItensTarefa();

            double percentual = (totalItensConcluidos / totalItens) * 100d;

            return percentual;
        }

        public void AtualizarPercentual(int n, double percentual)
        {
            ItemExecucaoTarefa item = itensExecucacao.Find(delegate(ItemExecucaoTarefa iet)
            {
                return iet.numero == n;
            });

            item.AtualizaPercentual(percentual);
        }

        public override string ToString()
        {
            return string.Format("Nº: {0} - Título: {1} - Percentual: {2}", numero, titulo, ObtemPercentual().ToString("#0.00") );
        }

        public bool EstaConcluida()
        {
           //return ObtemPercentual() == 100;

            int percentual = (int)ObtemPercentual();

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
        private int ObtemQuantidadeItensConcluidos()
        {
            int qtdItensConcluidos = 0;

            foreach (ItemExecucaoTarefa itemExecucaoTarefa in itensExecucacao)
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
            return itensExecucacao.Count;
        }

        #endregion
    }
}