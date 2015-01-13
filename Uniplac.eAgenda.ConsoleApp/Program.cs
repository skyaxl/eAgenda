
using System;
using System.Data;
using System.Text;
using Uniplac.eAgenda.ConsoleApp.Telas;
using Uniplac.eAgenda.Dominio.TarefaModule;
using Uniplac.eAgenda.Infraestrutura.Dao;
using Uniplac.eAgenda.Infraestrutura.Dao.TarefaModule;

namespace Uniplac.eAgenda.ConsoleApp
{

    class Program
    {



        public static void Main(string[] args)
        {
            CadastroConsole cadastroSelecionado = null;

            do
            {
                cadastroSelecionado = SelecionarCadastro();

                if (cadastroSelecionado != null)
                    cadastroSelecionado.MostrarMenu();

            } while (cadastroSelecionado != null);

        }



        private static CadastroConsole SelecionarCadastro()
        {
            Console.Clear();

            Console.WriteLine("Digite F1 para gerenciar Tarefas");

            Console.WriteLine();

            Console.WriteLine("Digite F2 para gerenciar Compromissos");

            Console.WriteLine();

            Console.WriteLine("Digite F3 para gerenciar Despesas");

            Console.WriteLine();

            Console.WriteLine("Digite Esc para sair");

            CadastroConsole cadastroSelecionado = null;

            ConsoleKey opcao = Console.ReadKey().Key;

            if (opcao == ConsoleKey.Escape)
                return null;

            do
            {

                if (opcao == ConsoleKey.F1)
                {
                    cadastroSelecionado = new TarefaConsole();
                    break;
                }
                else if (opcao == ConsoleKey.F2)
                {
                    cadastroSelecionado = new CompromissoConsole();
                    break;
                }
                else if (opcao == ConsoleKey.F3)
                {
                    cadastroSelecionado = new DespesaConsole();
                    break;
                }

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida! Aperte uma tecla para continuar...");
                Console.ResetColor();

                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Digite F1 para gerenciar Tarefas");

                Console.WriteLine();

                Console.WriteLine("Digite F2 para gerenciar Compromissos");

                Console.WriteLine();

                Console.WriteLine("Digite F3 para gerenciar Despesas");

                Console.WriteLine();

                Console.WriteLine("Digite Esc para sair");

                opcao = Console.ReadKey().Key;

            } while (opcao != ConsoleKey.Escape);

            return cadastroSelecionado;
        }
    }
}
