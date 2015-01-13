using System;

namespace Uniplac.eAgenda.ConsoleApp.Telas
{
    public abstract class CadastroConsole
    {

        private string _tituloTela;

        public CadastroConsole(string tituloTela)
        {
            _tituloTela = tituloTela;
        }

        public void MostrarMenu()
        {
            ConsoleKey opcao = MostrarSubMenu();

            do
            {
                if (opcao == ConsoleKey.Escape)
                    break;

                Console.Clear();
                Console.WriteLine(_tituloTela);
                Console.WriteLine();

                switch (opcao)
                {
                    case ConsoleKey.F1:
                        Console.WriteLine( "Inserindo registros...\n" );
                        InserirRegistro();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine( "Registro inserido com sucesso!" );
                        Console.ResetColor();
                        break;

                    case ConsoleKey.F2:
                        Console.WriteLine("Atualizando registros...\n");
                        AtualizarRegistro();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Registro atualizado com sucesso!");
                        Console.ResetColor();
                        break;

                    case ConsoleKey.F3:
                        Console.WriteLine("Excluindo registros...\n");
                        bool excluidoComSucesso = ExcluirRegistro();
                        if (excluidoComSucesso)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registro excluido com sucesso!");
                            Console.ResetColor();
                        }
                        break;

                    case ConsoleKey.F4:
                        Console.WriteLine("Mostrando todos os registros...\n");
                        MostrarRegistros("CONSULTA");
                        break;

                    default: Console.WriteLine("Opção inválida..."); 
                        break;
                }

                Console.WriteLine();
                Console.WriteLine( "Aperte uma tecla para continuar..." );
                Console.ReadKey();

                opcao = MostrarSubMenu();

            } while (opcao != ConsoleKey.Escape);
        }

        protected static void PararExecucaoAplicativo()
        {
            Console.WriteLine();

            Console.WriteLine("Aperte uma tecla para continuar...");

            Console.ReadKey();
        }

        private ConsoleKey MostrarSubMenu()
        {
            Console.Clear();

            Console.WriteLine(_tituloTela);

            Console.WriteLine();

            Console.WriteLine("Digite F1 para Inserir um novo registro");
            Console.WriteLine("Digite F2 para Atualizar as informações");
            Console.WriteLine("Digite F3 para Excluir um registro");
            Console.WriteLine("Digite F4 para Consultar registros");

            Console.WriteLine("Digite Esc para Voltar");

            ConsoleKey opcao = Console.ReadKey().Key;
            return opcao;
        }
        
        public abstract void InserirRegistro();

        public abstract void AtualizarRegistro();

        public abstract bool ExcluirRegistro();
        
        public abstract void MostrarRegistros(string operacao);

     

    }
}
