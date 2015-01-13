using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.eAgenda.Dominio.DespesaModule
{
    public class DespesaMensalAgrupada
    {
        public DespesaMensalAgrupada(string categoria, List<Despesa> despesas)
        {
            Categoria = categoria;
            Despesas = despesas;
        }
        public string Categoria { get; set; }

        public double ObtemSubTotal()
        {
            return Despesas.Sum(x => x.Valor);
        }

        public List<Despesa> Despesas { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Categoria, ObtemSubTotal().ToString("C"));
        }

    }
}
