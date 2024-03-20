using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Carta
    {
        public string Nome { get; set; }
        public int Valor { get; set; }

        public Carta(string nome, int valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
