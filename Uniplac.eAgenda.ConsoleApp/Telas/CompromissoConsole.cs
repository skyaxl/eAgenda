using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.eAgenda.Dominio.CompromissoModule;
using Uniplac.eAgenda.Infraestrutura.Dao.CompromissoModule;

namespace Uniplac.eAgenda.ConsoleApp.Telas
{
    public class CompromissoConsole : CadastroConsole
    {
        ICompromissoRepository repositorioCompromissos = new CompromissoDao();

        public CompromissoConsole()
            : base("Cadastro de Compromissos")
        {
        }

        public override void InserirRegistro()
        {
            Compromisso novoCompromisso = MontarCompromisso();

            repositorioCompromissos.AdicionarCompromisso(novoCompromisso);

        }
      
        public override void AtualizarRegistro()
        {
            MostrarRegistros("ATUALIZAÇÃO");

            Compromisso compromissoEncontrado = PesquisarCompromisso(atualizando: true);

            MostrarDetalhesCompromisso(compromissoEncontrado);

            Compromisso compromisso = MontarCompromisso();

            compromisso.Numero = compromissoEncontrado.Numero;

            repositorioCompromissos.AtualizarCompromisso(compromisso);
        }

        public override bool ExcluirRegistro()
        {
            MostrarRegistros("EXCLUSÃO");

            Compromisso compromissoEncontrado = PesquisarCompromisso(atualizando: true);

            MostrarDetalhesCompromisso(compromissoEncontrado);

            Console.WriteLine("Tem certeza que deseja excluir a tarefa: {0}", compromissoEncontrado.Assunto);

            Console.WriteLine("Digite 'S' para confirmar e 'N' para cancelar");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                repositorioCompromissos.ExcluirCompromisso(compromissoEncontrado);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Operação cancelada!");
                Console.ResetColor();
                return false;
            }
        }

        public override void MostrarRegistros(string operacao)
        {
            Console.WriteLine("Compromissos: ");

            List<Compromisso> compromissos = repositorioCompromissos.SelecionarTodosCompromissos();

            foreach (Compromisso compromisso in compromissos)
            {
                Console.WriteLine(compromisso);                
            }
        }

        #region Métodos privados
        private Compromisso MontarCompromisso()
        {
            Console.Write("Digite o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local do compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data de início do compromisso: ");
            string strDataInicio = Console.ReadLine();

            Console.Write("Digite a data de término do compromisso: ");
            string strDataTermino = Console.ReadLine();

            Console.Write("O compromisso é o dia inteiro? Digite 'S' para SIM e 'N' para NÃO");
            ConsoleKeyInfo ehDiaInteiro = Console.ReadKey();

            Compromisso compromisso = new Compromisso();

            compromisso.Assunto = assunto;
            compromisso.Local = local;
            compromisso.DataInicio = Convert.ToDateTime(strDataInicio);
            compromisso.DataTermino = Convert.ToDateTime(strDataTermino);
            compromisso.DiaInteiro = ehDiaInteiro.Key == ConsoleKey.S;

            return compromisso;
        }

        private void MostrarDetalhesCompromisso(Compromisso compromissoEncontrado)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Nº: {0}", compromissoEncontrado.Numero);

            Console.WriteLine("Assunto: {0}", compromissoEncontrado.Assunto);

            Console.WriteLine("Data de Ínicio: {0}", compromissoEncontrado.DataInicio);

            Console.WriteLine("Data de Término: {0}", compromissoEncontrado.DataTermino);

            Console.WriteLine("Dia inteiro? {0}", compromissoEncontrado.DiaInteiro ? "Sim" : "Não");

            Console.WriteLine();
        }

        private Compromisso PesquisarCompromisso(bool atualizando)
        {
            Compromisso compromissoSelecionado = null;

            bool compromissoEncontrado;
            do
            {
                Console.Write("Digite o número da Compromisso a ser {0} ", atualizando ? "atualizado" : "excluído");

                int id = Convert.ToInt32(Console.ReadLine());

                compromissoSelecionado = repositorioCompromissos.SelecionarCompromissoPorNumero(id);

                if (compromissoSelecionado != null)
                {
                    Console.Clear();

                    MostrarDetalhesCompromisso(compromissoSelecionado);

                    compromissoEncontrado = true;
                }
                else
                {
                    compromissoEncontrado = false;
                    Console.WriteLine("Compromisso não encontrado! Aperte uma tecla para continuar...");
                    Console.ReadKey();
                }

            } while (compromissoEncontrado == false);

            return compromissoSelecionado;
        }

        #endregion
    }
}
