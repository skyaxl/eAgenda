using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.eAgenda.Dominio.DespesaModule;
using Uniplac.eAgenda.Infraestrutura.Dao.DespesaModule;

namespace Uniplac.eAgenda.ConsoleApp.Telas
{
    public class DespesaConsole : CadastroConsole
    {
        IDespesaRepository repositorioDespesas = new DespesaDao();

        public DespesaConsole()
            : base("Cadastro de Despesas")
        {
        }

        public override void InserirRegistro()
        {
            Despesa novaDespesa = MontarDespesa();

            repositorioDespesas.AdicionarDespesa(novaDespesa);
        }
      
        public override void AtualizarRegistro()
        {
            MostrarRegistros("ATUALIZAÇÃO");

            Despesa despesaEncontrada = PesquisarDespesa(atualizando: true);

            MostrarDetalhesDespesa(despesaEncontrada);

            Despesa despesa = MontarDespesa();

            despesa.Numero = despesaEncontrada.Numero;

            repositorioDespesas.AtualizarDespesa(despesa);
        }

        public override bool ExcluirRegistro()
        {
            MostrarRegistros("EXCLUSÃO");

            Despesa despesaEncontrada = PesquisarDespesa(atualizando: true);

            MostrarDetalhesDespesa(despesaEncontrada);

            Console.WriteLine("Tem certeza que deseja excluir a despesa: {0}", despesaEncontrada.Descricao);

            Console.WriteLine("Digite 'S' para confirmar e 'N' para cancelar");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                repositorioDespesas.ExcluirDespesa(despesaEncontrada);
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
            List<Despesa> despesas = null;

            if (operacao == "ATUALIZAÇÃO" || operacao == "EXCLUSÃO")
            {
                Console.WriteLine("Despesas");

                despesas = repositorioDespesas.SelecionarTodasDespesas();

                foreach (Despesa despesa in despesas)
                {
                    Console.WriteLine(despesa);
                }

                return;
            }

            ConsoleKey opcao;

            do
            {
                opcao = MostrarSubMenuDeConsulta();

                if (opcao == ConsoleKey.Escape)
                    return;

                Console.Write("Digite o mês: ");

                int mes = int.Parse(Console.ReadLine());
              
                DespesaMensal despesaMensal = repositorioDespesas.SelecionarDespesaPorMes(mes);

                Console.Clear();

                switch (opcao)
                {
                    case ConsoleKey.F1:

                        Console.WriteLine("Despesas do mês de: {0} ", despesaMensal.Mes);

                        Console.WriteLine("Total: {0}", despesaMensal.ObtemValorTotal().ToString("C"));                        

                        Console.WriteLine("------------------------------------------");

                        MostrarDespesas(despesaMensal.Despesas);

                        break;

                    case ConsoleKey.F2:

                        Console.WriteLine("Visualizando as despesas do mês de {0} agrupadas por categoria: ", despesaMensal.Mes);

                        Console.WriteLine();

                        MostrarDespesasAgrupadas(despesaMensal.DespesasAgrupadasPorCategoria);

                        break;                    
                }
                

                PararExecucaoAplicativo();

            } while (opcao != ConsoleKey.Escape);

        }


        #region Métodos privados

        private void MostrarDespesasAgrupadas(List<DespesaMensalAgrupada> despesasAgrupadas)
        {
            if (despesasAgrupadas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma Despesa encontrada!");
                Console.ResetColor();
            }

            foreach (DespesaMensalAgrupada despesa in despesasAgrupadas)
            {
                Console.WriteLine(despesa);
            }
        }

        private void MostrarDespesas(List<Despesa> despesas)
        {
            if (despesas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma Despesa encontrada!");
                Console.ResetColor();
            }

            foreach (Despesa despesa in despesas)
            {
                Console.WriteLine(despesa);                               
            }
        }

        private ConsoleKey MostrarSubMenuDeConsulta()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para visualizar as despesas mensais");

            Console.WriteLine("Digite F2 para visualizar as despesas mensais agrupadas por categoria ");

            Console.WriteLine("Digite Esc para Voltar");

            ConsoleKey opcao = Console.ReadKey().Key;

            return opcao;
        }

        private Despesa MontarDespesa()
        {
            Console.Write("Digite a descrição do Despesa: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite o tipo do Despesa: ");
            
            Console.WriteLine();

            Console.WriteLine("Digite \"F1\" para Habitação"); 
            Console.WriteLine("Digite \"F2\" para Transporte");
            Console.WriteLine("Digite \"F3\" para Alimentação");
            Console.WriteLine("Digite \"F4\" para Saúde");
            Console.WriteLine("Digite \"F5\" para Cuidados Pessoais");

            Console.WriteLine();

            ConsoleKey opcao = Console.ReadKey().Key;

            string categoria = "";

            switch (opcao)
            {
                case ConsoleKey.F1: categoria = "Habitação";
                    break;
                case ConsoleKey.F2: categoria = "Transporte";
                    break;
                case ConsoleKey.F3: categoria = "Alimentação";
                    break;
                case ConsoleKey.F4: categoria = "Saúde";
                    break;
                case ConsoleKey.F5: categoria = "Cuidados Pessoais";
                    break;
                
                default:
                    break;
            }            

            Console.Write("Digite a data da Despesa: ");
            string strData = Console.ReadLine();

            Console.Write("Digite o valor da Despesa: ");
            string strValor = Console.ReadLine();

            Console.Write("Digite a forma de pagamento da Despesa: ");

            Console.WriteLine();

            Console.WriteLine("Digite \"F1\" para Cartão de Crédito");
            Console.WriteLine("Digite \"F2\" para Dinheiro");

            opcao = Console.ReadKey().Key;

            string formaPgto = "";

            switch (opcao)
            {
                case ConsoleKey.F1: formaPgto = "Cartão de Crédito";
                    break;
                case ConsoleKey.F2: formaPgto = "Dinheiro";
                    break;              

                default:
                    break;
            }            

            Despesa despesa = new Despesa();

            despesa.Descricao = descricao;
            despesa.Categoria = categoria;
            despesa.Data = Convert.ToDateTime(strData);
            despesa.Valor = Convert.ToDouble(strValor);
            despesa.FormaPagamento = formaPgto;

            return despesa;
        }

        private void MostrarDetalhesDespesa(Despesa despesaEncontrada)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Nº: {0}", despesaEncontrada.Numero);

            Console.WriteLine("Descrição: {0}", despesaEncontrada.Descricao);

            Console.WriteLine("Categoria: {0}", despesaEncontrada.Categoria);

            Console.WriteLine("Data: {0}", despesaEncontrada.Data);

            Console.WriteLine("Valor: {0}", despesaEncontrada.Valor);

            Console.WriteLine("Forma de pagamento: {0}", despesaEncontrada.FormaPagamento);

            Console.WriteLine();
        }

        private Despesa PesquisarDespesa(bool atualizando)
        {
            Despesa despesaSelecionada = null;

            bool despesaEncontrada;
            do
            {
                Console.Write("Digite o número da Despesa a ser {0} ", atualizando ? "atualizado" : "excluído");

                int id = Convert.ToInt32(Console.ReadLine());

                despesaSelecionada = repositorioDespesas.SelecionarDespesaPorNumero(id);

                if (despesaSelecionada != null)
                {
                    Console.Clear();

                    MostrarDetalhesDespesa(despesaSelecionada);

                    despesaEncontrada = true;
                }
                else
                {
                    despesaEncontrada = false;
                    Console.WriteLine("Despesa não encontrada! Aperte uma tecla para continuar...");
                    Console.ReadKey();
                }

            } while (despesaEncontrada == false);

            return despesaSelecionada;
        }

        #endregion
    }
}
