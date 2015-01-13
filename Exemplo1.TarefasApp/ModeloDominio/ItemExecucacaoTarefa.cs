using System;

namespace Exemplo1.TarefasApp.ModeloDominio
{
    public  class ItemExecucaoTarefa
    {

        public ItemExecucaoTarefa(string t, DateTime dc)
        {
            contador++;
            codigo = contador;

            titulo = t;
            dataConclusao = dc;
        }

        public void AtualizaPercentual(double p)
        {
            percentual = p;
        }

        public static int contador = 0;
        public int codigo;
        public string titulo;
        public DateTime dataConclusao;
        public double percentual;

        public bool EstaFechado()
        {
            return percentual == 100;
        }
    }
}