using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.eAgenda.Dominio.DespesaModule
{
    public class DespesaMensal
    {
        public DespesaMensal(int mes, List<Despesa> despesas)
        {
            Despesas = despesas;

            Mes = System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.GetMonthName(mes);             
        }

        public string Mes { get; set; }

        public double ObtemValorTotal()
        {
            return Despesas.Sum(x => x.Valor);
        }

        public List<Despesa> Despesas { get; set; }

        public List<DespesaMensalAgrupada> DespesasAgrupadasPorCategoria
        {
            get
            {
                string[] categorias = new string[] { "Habitação", "Transporte", "Alimentação", "Saúde", "Cuidados Pessoais" };

                List<DespesaMensalAgrupada> list = new List<DespesaMensalAgrupada>();

                foreach (var c in categorias)
                {
                    var listAgrupadas = Despesas.Where(x => x.Categoria == c).ToList();

                    if (!listAgrupadas.Any()) 
                        continue;

                    DespesaMensalAgrupada despesasAgrupada = new DespesaMensalAgrupada(c, listAgrupadas);

                    list.Add(despesasAgrupada);
                }

                return list;
            }
        }


    }

  

}
