using System;

namespace JogoDeAdivinhcao.ConsoleApp
{
    internal class Program
    {
        //  Versão 1: Estrutura básica e entrada do usuário
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Jogo de Adivinhção");
            Console.WriteLine("--------------------------------------------");

            //Versão 2: Gerar um número secreto aleatório
            // Lógica do jogo
            Random geradorDeNumeros = new Random();

            int numeroSecreto = geradorDeNumeros.Next(1, 21);

            Console.Write("Digite um número (de 1 à 20) para chutar: ");
            int numeroDigitado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Você digitou o número: " + numeroDigitado);
            Console.WriteLine("O número secreto é: " + numeroSecreto);


            Console.ReadLine();

        }
    }
}
