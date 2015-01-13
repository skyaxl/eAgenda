using System;

namespace Uniplac.eAgenda.Dominio.DespesaModule
{
    public class Despesa
    {
        public int Numero { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public DateTime Data { get; set; }

        public double Valor { get; set; }

        public string FormaPagamento { get; set; }

        public override string ToString()
        {
            return string.Format("{3} - {0}: {1} -> {2}", Data.ToString("dd/MM/yyyy"), Descricao, Valor.ToString("C"), Numero);
        }

        public void Valida()
        {
            if (String.IsNullOrEmpty(Descricao))
                throw new ApplicationException("A descrição da despesa é obrigatória");
            if (Valor <= 0)
                throw new ApplicationException("O valor da despesa deve ser maior que 0");
        }
    }
}