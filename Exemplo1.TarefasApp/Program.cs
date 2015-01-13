using System;
using Exemplo1.TarefasApp.ModeloDominio;

namespace Exemplo1.TarefasApp
{
    class Program
    {
        public static void Main()
        {
            int[] arrayInt = new int[] { 10, 10, 5, 6, 3, 36 };

            Pessoa[] pessoas = new Pessoa[] { new Pessoa { nome = "rech", altura = 2 }, new Pessoa { nome = "wesley", altura = 4 }, new Pessoa { nome = "kaio", altura = 3 } };

            Pessoa p = EncontraMaior(pessoas);

            Console.WriteLine("A maior pessoa é: {0}", p.nome);

            int numeroMaior = EncontraMaior(arrayInt);

            Console.WriteLine("Array de Inteiros: {0}", String.Join(", ", arrayInt));

            Console.WriteLine("O maior número é: {0}", numeroMaior);

            Console.WriteLine();

            double[] arrayDouble = new double[] { 10.89, 10.90, 5, 6, 3 };

            double numeroMaior2 = EncontraMaior(arrayDouble);

            Console.WriteLine("Array de Double: {0}", String.Join(", ", arrayDouble));

            Console.WriteLine("O maior número é: {0}", numeroMaior2);
        }

        public static T EncontraMaior<T>(T[] numeros) where T : IComparable<T>
        {
            T maior = Activator.CreateInstance<T>();

            foreach (T numero in numeros)
            {
                if (numero.CompareTo(maior) > 0)
                {
                    maior = numero;
                }
            }

            return maior;
        }
    }


    public class Pessoa : IComparable<Pessoa>
    {
        public string nome;
        public int altura;

        public int CompareTo(Pessoa p)
        {

            if (this.altura > p.altura) return 1;

            else if (this.altura < p.altura) return -1;

            return 0;

        }
    }
}