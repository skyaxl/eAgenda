using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.eAgenda.Dominio.CompromissoModule
{
    public class Compromisso
    {
        /*
         * Número, 
         * Assunto, 
         * Local, 
         * Data de início e término, 
         * Hora de início e término 
         * ou se compromisso será o dia inteiro.
         */

        public Compromisso()
        {
            DataInicio = DateTime.Now;
        }

        public int Numero { get; set; }

        public string Assunto { get; set; }

        public string Local { get; set; }

        public DateTime DataInicio { get; set; }
        
        public DateTime? DataTermino { get; set; }

        public bool DiaInteiro { get; set; }

        public override string ToString()
        {
            return string.Format("Nº: {0} - {1}", Numero, Assunto);
        }

        public void Valida()
        {
            if (String.IsNullOrEmpty(Assunto))
                throw new ApplicationException("O assunto do compromisso é obrigatório");

            if(DataTermino < DataInicio)
                throw new ApplicationException("Data término do compromisso está inválido");
        }
    }
}