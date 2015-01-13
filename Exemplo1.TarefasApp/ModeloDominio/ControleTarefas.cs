using System;

namespace Exemplo1.TarefasApp.ModeloDominio
{
    public class ControleTarefas
    {
        private Tarefa[] tarefas = new Tarefa[10];

        public Tarefa CriarNovaTarefa(double prioridade, string titulo, DateTime dataExecucao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.prioridade = prioridade;
            tarefa.titulo = titulo;
            tarefa.dataExecucao = dataExecucao;

            int posicaoVazia = Array.IndexOf(tarefas, null);

            tarefas[posicaoVazia] = tarefa;

            return tarefa;
        }

        public void MostrarTarefasFinalizadas()
        {
            foreach (Tarefa tarefa in tarefas)
            {
                if(tarefa != null)
                    Console.WriteLine(tarefa);
            }
        }
    }
}