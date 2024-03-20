using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Jogador
    {
        public List<Carta> Cartas { get; set; }

        public Jogador()
        {
            Cartas = new List<Carta>();
        }

        public int CalcularPontuacao()
        {
            int pontuacao = 0;
            bool temAs = false;

            foreach (Carta carta in Cartas)
            {
                pontuacao += carta.Valor;
                if (carta.Nome.Contains("Ás"))
                {
                    temAs = true;
                }
            }

            if (temAs && pontuacao + 10 <= 21)
            {
                pontuacao += 10;
            }

            return pontuacao;
        }

        public void ExibirCartas()
        {
            Console.WriteLine("Cartas do jogador:");
            foreach (Carta carta in Cartas)
            {
                Console.WriteLine(carta.Nome);
            }
        }
    }

}
