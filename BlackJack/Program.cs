using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Baralho baralho = new Baralho();
            Jogador jogador = new Jogador();
            Jogador computador = new Jogador();

            // Inicialmente, distribui duas cartas para o jogador e duas cartas para o computador.
            jogador.Cartas.Add(baralho.DistribuirCarta());
            jogador.Cartas.Add(baralho.DistribuirCarta());
            computador.Cartas.Add(baralho.DistribuirCarta());
            computador.Cartas.Add(baralho.DistribuirCarta());

            Console.WriteLine("=== Bem-vindo ao Blackjack! ===");
            Console.WriteLine();

            // Exibe uma das cartas do computador e todas as cartas do jogador
            Console.WriteLine("Computador:");
            Console.WriteLine(computador.Cartas[0].Nome);
            Console.WriteLine();
            jogador.ExibirCartas();
            Console.WriteLine();

            // Verifica se o jogador obteve um Blackjack (21 pontos)
            if (jogador.CalcularPontuacao() == 21)
            {
                Console.WriteLine("Parabéns! Você obteve um Blackjack!");
                return;
            }

            // Loop principal do jogo
            while (true)
            {
                Console.WriteLine("O que você deseja fazer?");
                Console.WriteLine("1. Pedir mais uma carta");
                Console.WriteLine("2. Parar");

                string escolha = Console.ReadLine();
                Console.WriteLine();

                if (escolha == "1")
                {
                    Carta novaCarta = baralho.DistribuirCarta();
                    jogador.Cartas.Add(novaCarta);
                    Console.WriteLine($"Você recebeu uma nova carta: {novaCarta.Nome}");
                    Console.WriteLine();

                    if (jogador.CalcularPontuacao() > 21)
                    {
                        Console.WriteLine("Você estourou! Pontuação maior que 21.");
                        Console.WriteLine("Fim de jogo.");
                        return;
                    }
                    else
                    {
                        jogador.ExibirCartas();
                        Console.WriteLine();
                    }
                }
                else if (escolha == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha novamente.");
                    Console.WriteLine();
                }
            }

            // Exibe as cartas do computador
            Console.WriteLine("Computador:");
            foreach (Carta carta in computador.Cartas)
            {
                Console.WriteLine(carta.Nome);
            }
            Console.WriteLine();

            // Computador decide se deve pedir mais cartas
            while (computador.CalcularPontuacao() < 17)
            {
                Carta novaCarta = baralho.DistribuirCarta();
                computador.Cartas.Add(novaCarta);
                Console.WriteLine($"O computador recebeu uma nova carta: {novaCarta.Nome}");
            }

            Console.WriteLine();

            // Exibe as cartas e pontuações finais
            jogador.ExibirCartas();
            Console.WriteLine($"Pontuação do jogador: {jogador.CalcularPontuacao()}");
            Console.WriteLine();

            computador.ExibirCartas();
            Console.WriteLine($"Pontuação do computador: {computador.CalcularPontuacao()}");
            Console.WriteLine();

            // Verifica o resultado do jogo
            if (jogador.CalcularPontuacao() > 21)
            {
                Console.WriteLine("Você perdeu! Sua pontuação ultrapassou 21.");
            }
            else if (computador.CalcularPontuacao() > 21)
            {
                Console.WriteLine("O computador perdeu! Sua pontuação ultrapassou 21.");
            }
            else if (jogador.CalcularPontuacao() > computador.CalcularPontuacao())
            {
                Console.WriteLine("Você ganhou! Sua pontuação é maior que a do computador.");
            }
            else if (jogador.CalcularPontuacao() < computador.CalcularPontuacao())
            {
                Console.WriteLine("Você perdeu! Sua pontuação é menor que a do computador.");
            }
            else
            {
                Console.WriteLine("Empate! Sua pontuação é igual à do computador.");
            }
        }
    }
}
