using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.eAgenda.Dominio.TarefaModule
{
    public class ItemTarefa
    {
        public int Numero { get; set; }
        public string Titulo { get; set; }
        public double Percentual { get; set; }
        public Tarefa Tarefa { get; set; }

        public void AtualizaPercentual(double p)
        {
            Percentual = p;
        }

        public bool EstaFechado()
        {
            return Percentual == 100;
        }

        public override string ToString()
        {
            return string.Format("Nº: {0} - Título: {1} - Percentual: {2}", Numero, Titulo, Percentual);
        }
    }
}
