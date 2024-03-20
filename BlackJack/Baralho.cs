using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Baralho
    {
        private List<Carta> cartas;
        private Random random;

        public Baralho()
        {
            cartas = new List<Carta>();
            random = new Random();
            CriarBaralho();
        }

        private void CriarBaralho()
        {
            string[] naipes = { "Espadas", "Paus", "Copas", "Ouros" };
            string[] nomes = { "Ás", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valete", "Dama", "Rei" };
            int[] valores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            for (int i = 0; i < naipes.Length; i++)
            {
                for (int j = 0; j < nomes.Length; j++)
                {
                    Carta carta = new Carta($"{nomes[j]} de {naipes[i]}", valores[j]);
                    cartas.Add(carta);
                }
            }
        }

        public Carta DistribuirCarta()
        {
            int index = random.Next(cartas.Count);
            Carta carta = cartas[index];
            cartas.RemoveAt(index);
            return carta;
        }
    }
}
