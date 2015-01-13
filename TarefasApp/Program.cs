using System;
using Exemplo2.TarefasApp.Telas;

namespace Exemplo2.TarefasApp
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

            Console.WriteLine("Digite F2 para gerenciar Compromissos");

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
              
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida! Aperte uma tecla para continuar...");
                Console.ResetColor();

                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("Digite F1 para gerenciar Tarefas");

                Console.WriteLine("Digite Esc para sair");

                opcao = Console.ReadKey().Key;


            } while (opcao != ConsoleKey.Escape);

            return cadastroSelecionado;
        }
     
    }
}