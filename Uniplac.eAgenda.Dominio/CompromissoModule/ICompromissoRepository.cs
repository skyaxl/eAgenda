using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.eAgenda.Dominio.CompromissoModule
{    
    public interface ICompromissoRepository
    {
        Compromisso AdicionarCompromisso(Compromisso compromisso);
        void AtualizarCompromisso(Compromisso compromissoAtualizado);
        void ExcluirCompromisso(Compromisso compromissoEncontrado);
        Compromisso SelecionarCompromissoPorNumero(int numero);        
        System.Collections.Generic.List<Compromisso> SelecionarTodosCompromissos();
    }
}
