using System;

namespace JogoDeAdivinhcao.ConsoleApp
{
    internal class Program
    {
        //Versão 3: Verificar se o jogador acertou
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Jogo de Adivinhção");
                Console.WriteLine("--------------------------------------------");

                // Escolha de dificuldade
                Console.WriteLine("Escolha um nível de dificuldade:");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1 - Fácil (10 tentativas)");
                Console.WriteLine("2 - Médio (5 tentativas)");
                Console.WriteLine("3 - Difícil (3 tentativas)");
                Console.WriteLine("----------------------------------------");

                int totalDetentativas = 0;

                Console.Write("Digite sua escolha: ");
                string entrada = Console.ReadLine();

                if (entrada == "1")
                    totalDetentativas = 10;
                else if (entrada == "2")
                    totalDetentativas = 5;
                else if (entrada == "3")
                    totalDetentativas = 3;



                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);

                //Console.Write("Digite um número (de 1 à 20) para chutar: ");
                //int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                // Console.WriteLine("Você digitou o número: " + numeroDigitado);
                //Console.WriteLine("O número secreto é: " + numeroSecreto);

                for (int tentativa = 1; tentativa <= totalDetentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDetentativas}");
                    Console.WriteLine("--------------------------------------------");


                    // Lógica do jogo
                    Console.Write("Digite um número entre 1 e 20: ");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    if (numeroDigitado == numeroSecreto)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Parabéns, você acertou!");
                        Console.WriteLine("--------------------------------------------");

                        break;
                    }
                    if (tentativa == totalDetentativas)
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
                        Console.WriteLine("----------------------------------------");

                        break;
                    }
                    else if (numeroDigitado > totalDetentativas)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("O número digitado foi maior que o número secreto");
                        Console.WriteLine("--------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("O número digitado foi menor que o número secreto");
                        Console.WriteLine("--------------------------------------------");


                    }

                    Console.WriteLine("Aperte ENTER para continuar...");
                    Console.ReadLine();
                }

                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S")
                    break;

            }
              
        }
    }
}