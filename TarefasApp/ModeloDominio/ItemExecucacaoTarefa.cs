namespace Exemplo2.TarefasApp.ModeloDominio
{
    public  class ItemExecucaoTarefa
    {
        public static int contador = 0;
        public int numero;
        public string titulo;
        public double percentual;

        public ItemExecucaoTarefa()
        {
            contador++;
            numero = contador;
        }

        public void AtualizaPercentual(double p)
        {
            percentual = p;
        }

        public bool EstaFechado()
        {
            return percentual == 100;
        }

        public override string ToString()
        {
            return string.Format("Nº: {0} - Título: {1} - Percentual: {2}", numero, titulo, percentual);
        }
    }
}