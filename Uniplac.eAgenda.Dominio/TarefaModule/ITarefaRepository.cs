using System;
namespace Uniplac.eAgenda.Dominio.TarefaModule
{
    public interface ITarefaRepository
    {
        Tarefa AdicionarTarefa(Tarefa tarefa);
        void AtualizarTarefa(Tarefa tarefaAtualizada);
        void ExcluirTarefa(Tarefa tarefaEncontrada);
        Tarefa SelecionarTarefaPorNumero(int numero);
        System.Collections.Generic.List<Tarefa> SelecionarTarefasConcluidas();
        System.Collections.Generic.List<Tarefa> SelecionarTarefasPendentes();
        System.Collections.Generic.List<Tarefa> SelecionarTodasTarefas();
    }
}
