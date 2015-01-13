using System.Collections.Generic;

namespace Exemplo2.TarefasApp.ModeloDominio
{
    public class ControleTarefas
    {
        private List<Tarefa> tarefas = new List<Tarefa>();

        public Tarefa AdicionarTarefa(Tarefa tarefa)
        {
            tarefas.Add(tarefa);

            return tarefa;
        }

        public Tarefa PesquisaTarefaPorNumero(int numero)
        {
            return tarefas.Find(delegate(Tarefa tarefa)
            {
                return tarefa.numero == numero;
            });
        }

        public void AtualizarTarefa(Tarefa tarefaAtualizada)
        {
            Tarefa t = PesquisaTarefaPorNumero(tarefaAtualizada.numero);

            t.dataExecucao = tarefaAtualizada.dataExecucao;
            t.prioridade = tarefaAtualizada.prioridade;
            t.titulo = tarefaAtualizada.titulo;
        }

        public List<Tarefa> SelecionarTodasTarefas()
        {
            return tarefas;
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
            #region implementado sem delegates
            /*
            List<Tarefa> tarefasConcluidas = new List<Tarefa>();

            foreach (Tarefa t in tarefas)
            {
                if (t.EstaConcluida())
                {
                    tarefasConcluidas.Add(t);
                }
            }

            return tarefasConcluidas;
             */
            #endregion

            List<Tarefa> tarefasConcluidas = tarefas.FindAll(delegate(Tarefa t)
            {
                return t.EstaConcluida();
            });

            return tarefasConcluidas;
        }

        public List<Tarefa> SelecionarTarefasPendentes()
        {
            #region implementado sem delegates
            /*
            List<Tarefa> tarefasPendentes = new List<Tarefa>();

            foreach (Tarefa t in tarefas)
            {
                if (t.EstaPendente())
                {
                    tarefasPendentes.Add(t);
                }
            }

            return tarefasPendentes;
             */
            #endregion

            List<Tarefa> tarefasPendentes = tarefas.FindAll(delegate(Tarefa t)
            {
                return t.EstaPendente();
            });

            return tarefasPendentes;
        }

        public void ExcluirTarefa(Tarefa tarefaEncontrada)
        {
            tarefas.Remove(tarefaEncontrada);
        }
    }
}