using System;
using System.Collections.Generic;
using Uniplac.eAgenda.Dominio.TarefaModule;
using Uniplac.eAgenda.Infraestrutura.Memoria.TarefaModule;
using Uniplac.eAgenda.Infraestrutura.Dao.TarefaModule;


namespace Uniplac.eAgenda.ConsoleApp.Telas
{
    public class TarefaConsole : CadastroConsole
    {
        ITarefaRepository repositorioTarefas = new TarefaDao();

        public TarefaConsole()
            : base("Cadastro de Tarefas")
        {
        }

        public override bool ExcluirRegistro()
        {
            MostrarRegistros("EXCLUSÃO");

            Tarefa tarefaEncontrada = PesquisarTarefa(atualizando: false);

            MostrarDetalhesTarefa(tarefaEncontrada);

            Console.WriteLine("Tem certeza que deseja excluir a tarefa: {0}", tarefaEncontrada.Titulo);

            Console.WriteLine("Digite 'S' para confirmar e 'N' para cancelar");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                if (tarefaEncontrada.EstaConcluida())
                {
                    repositorioTarefas.ExcluirTarefa(tarefaEncontrada);
                    return true;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Esta tarefa não pode ser excluída");
                Console.ReadKey();
                Console.ResetColor();                
            }

            return false;
        }

        public override void MostrarRegistros(string operacao)
        {
            Console.Clear();

            List<Tarefa> tarefas = null;

            if (operacao == "ATUALIZAÇÃO" || operacao == "EXCLUSÃO")
            {
                tarefas = repositorioTarefas.SelecionarTodasTarefas();

                MostrarTarefas(tarefas);

                return;
            }

            ConsoleKey opcao;

            do
            {
                opcao = MostrarSubMenuDeConsulta();

                switch (opcao)
                {
                    case ConsoleKey.F1:
                        Console.WriteLine("Visualizando as tarefas pendentes: ");
                        Console.WriteLine();
                        tarefas = repositorioTarefas.SelecionarTarefasPendentes();
                        break;

                    case ConsoleKey.F2:
                        Console.WriteLine("Visualizando as tarefas concluídas: ");
                        Console.WriteLine();
                        tarefas = repositorioTarefas.SelecionarTarefasConcluidas();
                        break;

                    case ConsoleKey.F3:
                        Console.WriteLine("Visualizando todas as tarefas: ");
                        Console.WriteLine();
                        tarefas = repositorioTarefas.SelecionarTodasTarefas();
                        break;

                    case ConsoleKey.Escape:
                        return;
                }

                MostrarTarefas(tarefas);

                PararExecucaoAplicativo();

            } while (opcao != ConsoleKey.Escape);

        }

        public override void AtualizarRegistro()
        {
            MostrarRegistros("ATUALIZAÇÃO");

            Tarefa tarefaEncontrada = PesquisarTarefa(atualizando: true);

            MostrarDetalhesTarefa(tarefaEncontrada);

            ConsoleKey opcao = MostrarSubMenuDeAtualizacao();

            do
            {
                switch (opcao)
                {
                    case ConsoleKey.F1:

                        Tarefa tarefa = MontarTarefa();

                        tarefa.Numero = tarefaEncontrada.Numero;

                        repositorioTarefas.AtualizarTarefa(tarefa);

                        break;

                    case ConsoleKey.F2:

                        Console.WriteLine("Itens de Execução: ");

                        foreach (ItemTarefa itemExecucao in tarefaEncontrada.ItensExecucacao)
                        {
                            Console.WriteLine("\t ->" + itemExecucao);
                        }

                        Console.Write("Digite o número do item de execução que gostaria de atualizar o percentual: ");

                        int numero = int.Parse(Console.ReadLine());

                        Console.Write("Digite o percentual do item de execução: ");

                        int percentual = int.Parse(Console.ReadLine());

                        tarefaEncontrada.AtualizarPercentual(numero, percentual);

                        break;

                }

                opcao = MostrarSubMenuDeAtualizacao();

            } while (opcao != ConsoleKey.Escape);

            repositorioTarefas.AtualizarTarefa(tarefaEncontrada);
        }

        public override void InserirRegistro()
        {
            Tarefa novaTarefa = MontarTarefa();

            ConsoleKey opcao;

            Console.WriteLine();

            Console.WriteLine("Adicionado itens de execução...");

            Console.WriteLine();
            do
            {
                ItemTarefa item = MontarItemExecucaoTarefa();

                novaTarefa.AdicionaItemExecucao(item);

                opcao = MostrarSubMenuItensExecucao();

            } while (opcao != ConsoleKey.Enter);

            repositorioTarefas.AdicionarTarefa(novaTarefa);

            Console.WriteLine();
        }

        #region métodos privados

        private ConsoleKey MostrarSubMenuDeConsulta()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para visualizar as tarefas pendentes");

            Console.WriteLine("Digite F2 para visualizar as tarefas concluídas");

            Console.WriteLine("Digite F3 para visualizar todas as tarefas");

            Console.WriteLine("Digite Esc para Voltar");

            ConsoleKey opcao = Console.ReadKey().Key;

            return opcao;
        }

        private ConsoleKey MostrarSubMenuDeAtualizacao()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para atualizar os dados básicos da tarefa");

            Console.WriteLine("Digite F2 para atualizar os percentuais dos itens de execução");

            Console.WriteLine("Digite Esc para Voltar");

            ConsoleKey opcao = Console.ReadKey().Key;

            return opcao;
        }

        private ConsoleKey MostrarSubMenuItensExecucao()
        {
            Console.WriteLine();

            Console.WriteLine("Digite F1 para Inserir um novo item de execução");

            Console.WriteLine("Aperte Enter para confirmar");

            Console.WriteLine();

            ConsoleKey opcao = Console.ReadKey().Key;

            Console.SetCursorPosition(0, Console.CursorTop);

            return opcao;
        }

        private static void MostrarDetalhesTarefa(Tarefa tarefaEncontrada)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Nº: {0}", tarefaEncontrada.Numero);

            Console.WriteLine("Título da tarefa: {0}", tarefaEncontrada.Titulo);

            Console.WriteLine("Percentual de Conclusão: {0}", tarefaEncontrada.Percentual);

            Console.WriteLine("Data de Execução: {0}", tarefaEncontrada.DataConclusao);

            Console.WriteLine("Prioridade: {0}", tarefaEncontrada.Prioridade);

            Console.WriteLine();

            if (tarefaEncontrada.ItensExecucacao == null)
                return;

            Console.WriteLine("Itens de Execução: ");

            foreach (var itemExecucao in tarefaEncontrada.ItensExecucacao)
            {
                Console.WriteLine("Nº: {0}", itemExecucao.Numero);

                Console.WriteLine("Título do item de execução: {0}", itemExecucao.Titulo);

                Console.WriteLine("Percentual de Conclusão: {0}", itemExecucao.Percentual);
            }

            Console.WriteLine();
        }

        private static void MostrarTarefas(List<Tarefa> tarefas)
        {            
            if (tarefas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma tarefa encontrada!");
                Console.ResetColor();
            }

            foreach (Tarefa tarefa in tarefas)
            {
                Console.WriteLine(tarefa);

                if (tarefa.ItensExecucacao == null)
                {
                    continue;
                }

                Console.WriteLine("Itens de Execução: ");

                foreach (ItemTarefa itemExecucao in tarefa.ItensExecucacao)
                {
                    Console.WriteLine("\t ->" + itemExecucao);
                }
            }
        }

        private Tarefa PesquisarTarefa(bool atualizando)
        {
            Tarefa tarefaSelecionada = null;
            bool tarefaEncontrada;
            do
            {
                Console.WriteLine();

                Console.Write("Digite o número da tarefa a ser {0} ", atualizando ? "atualizada" : "excluída");

                int id = Convert.ToInt32(Console.ReadLine());

                tarefaSelecionada = repositorioTarefas.SelecionarTarefaPorNumero(id);

                if (tarefaSelecionada != null)
                {
                    Console.Clear();

                    MostrarDetalhesTarefa(tarefaSelecionada);

                    tarefaEncontrada = true;
                }
                else
                {
                    tarefaEncontrada = false;
                    Console.WriteLine("Tarefa não encontrada! Aperte uma tecla para continuar...");
                    Console.ReadKey();
                }

            } while (tarefaEncontrada == false);

            return tarefaSelecionada;
        }

        private static Tarefa MontarTarefa()
        {
            Console.Write("Digite o título da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data de conclusão da Tarefa: ");
            string dataConclusao = Console.ReadLine();

            Console.Write("Digite a prioridade da Tarefa: ");
            string prioridade = Console.ReadLine();

            Tarefa tarefa = new Tarefa();

            tarefa.Titulo = titulo;

            tarefa.DataConclusao = Convert.ToDateTime(dataConclusao);

            tarefa.Prioridade = Convert.ToInt16(prioridade);

            return tarefa;
        }

        private static ItemTarefa MontarItemExecucaoTarefa()
        {
            Console.Write("Digite o título do Item de Execução: ");

            string titulo = Console.ReadLine();

            ItemTarefa itemExecucao = new ItemTarefa();

            itemExecucao.Titulo = titulo;

            return itemExecucao;
        }

        #endregion

    }
}