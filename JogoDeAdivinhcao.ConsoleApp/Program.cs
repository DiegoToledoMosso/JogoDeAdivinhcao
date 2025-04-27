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

                //Sistema de amazenamento de númeors já chutados.
                int[] numerosChutados = new int[100];
                int contadorNumerosChutados = 0;

                // Sistema de Pontuação
                int pontuacao = 1000;



                for (int tentativa = 1; tentativa <= totalDetentativas; tentativa++)
                {

                    ExibirMenuEscolha(tentativa, totalDetentativas, pontuacao);
                    
                    for (int i = 0; i < numerosChutados.Length; i++)
                    {
                        if (numerosChutados[i] > 0)
                        {
                            Console.Write(numerosChutados[i] + " ");
                        }
                    }

                    Espaco();

                    int numeroDigitado;
                    bool numeroRepetido;

                    do
                    {
                        numeroRepetido = false;

                        Console.Write("Digite um número entre 1 e 20: ");                        
                        numeroDigitado = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < numerosChutados.Length; i++)
                        {
                            if (numerosChutados[i] == numeroDigitado)
                            {
                                NumeroJaDigitado();

                                numeroRepetido = true;
                                break;
                            }
                        }

                    } while (numeroRepetido == true);

                    

                    numerosChutados[contadorNumerosChutados] = numeroDigitado;
                    contadorNumerosChutados++;

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
                        pontuacao -= Math.Abs(numeroDigitado - numeroSecreto) / 2;

                    }
                    else
                    {
                        NumeroMenor();
                        pontuacao -= Math.Abs(numeroDigitado - numeroSecreto) / 2;

                    }

                    MenuContinuar();

                }

                MenuFinal();
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

        static void ExibirMenuEscolha(int tentativa, int totalDetentativas, int pontuacao)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {totalDetentativas}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Pontuação " + pontuacao + " pontos");
            Console.WriteLine("----------------------------");
            Console.WriteLine();



            Console.WriteLine("Números já chutados:  ");
                       

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

        static void Pontuacao(int pontuacao, int numeroDigitado, int numeroSecreto)
        {
            pontuacao -= Math.Abs(numeroDigitado - numeroSecreto) / 2;
            //-= decrementar
            //+= incrementar
        }

        static void Espaco()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
        
        static void NumeroJaDigitado()
        {
            Console.WriteLine("Você já digitou esse número!! Aperte ENTER para tentar novamente ...");
            Console.ReadLine();
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
        
        static void MenuFinal()
        {
            
            Console.Write("Deseja continuar? (S/N): ");           

            
        }

        static void MenuContinuar()
        {
            Console.WriteLine("Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
}