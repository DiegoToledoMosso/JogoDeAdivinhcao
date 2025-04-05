using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JogoDeAdivinhcao.ConsoleApp
{
    internal class Program
    {
        //Versão 3: Verificar se o jogador acertou
        static void Main(string[] args)
        {

            string[] historicoDeTentivas = new string[100];
            int contadorHistorico = 0;

                                


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
                Console.WriteLine("4 - Histórico de Tentativas");
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

                else if (entrada == "4")
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Histórico de Tentativas");
                    Console.WriteLine("--------------------------------------------");

                    for (int contador = 0; contador < contadorHistorico; contador++)
                    {
                        Console.WriteLine(historicoDeTentivas[contador]);
                    }

                    Console.ReadLine();
                    continue;

                }

                int pontuacao = 1000;
                int algoritmo = 0;
                int resultado = 0;



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

                    historicoDeTentivas[contadorHistorico] = $"o numero chutado foi : {numeroDigitado}";
                    contadorHistorico++;

                   

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

                    else if (numeroDigitado > numeroSecreto)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("O número digitado foi maior que o número secreto");
                        Console.WriteLine("--------------------------------------------");

                        algoritmo = (numeroDigitado - numeroSecreto) / 2;
                        resultado = pontuacao - algoritmo;





                    }
                    else
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("O número digitado foi menor que o número secreto");
                        Console.WriteLine("--------------------------------------------");

                        

                        algoritmo = (numeroDigitado - numeroSecreto) / 2;
                        resultado = pontuacao - algoritmo;




                    }



                    
                    Console.WriteLine("Aperte ENTER para continuar...");
                    Console.ReadLine();
                    



                }

                Console.WriteLine("Tua pontuação foi de: " + resultado);
                Console.Write("Deseja continuar? (S/N): ");
                string opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S")
                    break;

                contadorHistorico++;

            }
              
        }
    }
}