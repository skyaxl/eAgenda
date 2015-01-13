using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.eAgenda.Dominio.DespesaModule
{
    public interface IDespesaRepository
    {
        Despesa AdicionarDespesa(Despesa despesa);
        void AtualizarDespesa(Despesa despesaAtualizada);
        void ExcluirDespesa(Despesa despesaEncontrada);
        Despesa SelecionarDespesaPorNumero(int numero);        
        System.Collections.Generic.List<Despesa> SelecionarTodasDespesas();
        DespesaMensal SelecionarDespesaPorMes(int mes);        
    }
}