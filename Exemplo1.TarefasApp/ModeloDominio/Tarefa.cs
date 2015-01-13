using System;

namespace Exemplo1.TarefasApp.ModeloDominio
{
    public class Tarefa
    {
        public static int contador = 0;
        public int numero;
        public double prioridade;
        public string titulo;
        public DateTime dataExecucao;
        private ItemExecucaoTarefa[] itensExecucacao;

        public Tarefa()
        {
            contador++;
            numero = contador;
            itensExecucacao = new ItemExecucaoTarefa[10];
        }

        public void AdicionaItemExecucao(ItemExecucaoTarefa itemExecucao)
        {
            int posicaoVazia = Array.IndexOf(itensExecucacao, null);

            itensExecucacao[posicaoVazia] = itemExecucao;
        }

        public double ObtemPercentual()
        {
            int totalItensConcluidos = ObtemQuantidadeItensConcluidos();

            int totalItens = ObtemQuantidadeItensTarefa();

            double percentual = (totalItensConcluidos/totalItens) * 100;

            return percentual;
        }

        public void AtualizarPercentual(string tituloPesquisado, double percentual)
        {
            foreach (ItemExecucaoTarefa itemExecucaoTarefa in itensExecucacao)
            {
                if (itemExecucaoTarefa.titulo == tituloPesquisado)
                {
                    itemExecucaoTarefa.AtualizaPercentual(percentual);
                    break;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Nº: {0} - Título: {1} - Percentual: {2}", numero, titulo, ObtemPercentual().ToString("#0.00"));
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
            int qtdItens = 0;

            foreach (ItemExecucaoTarefa itemExecucaoTarefa in itensExecucacao)
            {
                if (itemExecucaoTarefa != null)
                {
                    qtdItens++;
                }
            }

            return qtdItens;
        }

        #endregion
    }
}