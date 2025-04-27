using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JogoDeAdivinhcao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] historicoDeTentivas = new string[100];
            int contadorHistorico = 0;




            while (true)
            {

                int totalDetentativas = 0;

                int pontuacao = 1000;

                int algoritmo = 0;

                int resultado = 0;


                string entrada = ExibirMenu();

                if (entrada == "1")
                    totalDetentativas = 10;
                else if (entrada == "2")
                    totalDetentativas = 5;
                else if (entrada == "3")
                    totalDetentativas = 3;



                else if (entrada == "4")
                {
                    ExibirHistoricoDeOperacoes(contadorHistorico, historicoDeTentivas);

                }


                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);


                for (int tentativa = 1; tentativa <= totalDetentativas; tentativa++)
                {


                    ExibirMenuEscolha(contadorHistorico, tentativa);
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    historicoDeTentivas[contadorHistorico] = $"o numero chutado foi : {numeroDigitado}";
                    contadorHistorico++;



                    if (numeroDigitado == numeroSecreto)
                    {
                        ExibirVitoria();
                        break;
                    }
                    if (tentativa == totalDetentativas)
                    {
                        ExibirDerrota(numeroSecreto);
                        break;
                    }

                    else if (numeroDigitado > numeroSecreto)
                    {
                        NumeroMaior();
                        Pontuacao(algoritmo, resultado, pontuacao, numeroSecreto, numeroDigitado);

                        
                    }
                    else
                    {
                        NumeroMenor();
                        Pontuacao(algoritmo, resultado, pontuacao, numeroSecreto, numeroDigitado);

                    }

                    Console.WriteLine("Aperte ENTER para continuar...");
                    Console.ReadLine();

                }

                MenuFinal(resultado);
                string opcaoContinuar = Console.ReadLine().ToUpper();
                if (opcaoContinuar != "S")
                    break;

                contadorHistorico++;

            }

        }


        static string ExibirMenu()
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




            Console.Write("Digite sua escolha: ");
            string entrada = Console.ReadLine();

            return entrada;
        }
        

        static bool OpcaoHistoricoDeOperacoes(string entrada)
        {
            return entrada == "4";
        }

        static void ExibirHistoricoDeOperacoes(int contadorHistorico, string[] historicoDeTentivas)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Histórico de Tentativas");
            Console.WriteLine("--------------------------------------------");

            for (int contador = 0; contador < contadorHistorico; contador++)
            {
                Console.WriteLine(historicoDeTentivas[contador]);
            }

            Console.ReadLine();
        }

        static void ExibirMenuEscolha(int tentativa, int totalDetentativas)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {totalDetentativas}");
            Console.WriteLine("--------------------------------------------");


            Console.Write("Digite um número entre 1 e 20: ");



        }

        static string ExibirVitoria()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Parabéns, você acertou!");
            Console.WriteLine("--------------------------------------------");

            return ExibirVitoria();
        }

        static void ExibirDerrota(int numeroSecreto)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Que pena! Você usou todas as tentativas. O número era {numeroSecreto}.");
            Console.WriteLine("----------------------------------------");

            
        }

        static void Pontuacao(int algoritmo, int resultado, int pontuacao, int numeroDigitado, int numeroSecreto)
        {
            algoritmo = (numeroDigitado - numeroSecreto) / 2;
            resultado = pontuacao - algoritmo;
        }

        static void NumeroMaior()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("O número digitado foi maior que o número secreto");
            Console.WriteLine("--------------------------------------------");
        }

        static void NumeroMenor()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("O número digitado foi menor que o número secreto");
            Console.WriteLine("--------------------------------------------");
        }
        
        static void MenuFinal(int resultado)
        {
            Console.WriteLine("Tua pontuação foi de: " + resultado);
            Console.Write("Deseja continuar? (S/N): ");
            

            
        }
    }
}