using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.eAgenda.Dominio.TarefaModule;

namespace Uniplac.eAgenda.Infraestrutura.Memoria.TarefaModule
{
    public class TarefaMem : ITarefaRepository
    {
        private List<Tarefa> tarefas = new List<Tarefa>();

        private static int contador = 0;

        public Tarefa AdicionarTarefa(Tarefa tarefa)
        {
            contador++;
            tarefa.Numero = contador;

            tarefas.Add(tarefa);

            return tarefa;
        }

        public Tarefa SelecionarTarefaPorNumero(int numero)
        {
            return tarefas.Find(delegate(Tarefa tarefa)
            {
                return tarefa.Numero == numero;
            });
        }

        public void AtualizarTarefa(Tarefa tarefaAtualizada)
        {
            Tarefa t = SelecionarTarefaPorNumero(tarefaAtualizada.Numero);

            t.DataConclusao = tarefaAtualizada.DataConclusao;
            t.Prioridade = tarefaAtualizada.Prioridade;
            t.Titulo = tarefaAtualizada.Titulo;
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
