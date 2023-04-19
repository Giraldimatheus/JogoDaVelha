using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {


                string[,] tabuleiro = new string[3, 3];

                void desenharTabuleiro(string x = "i", string y = "i", string jogada = "-")
                {

                    int linha, coluna;

                    for (coluna = 0; coluna < tabuleiro.GetLength(1); coluna++)
                    {
                        Console.Write($"\t{coluna}");
                    }

                    Console.WriteLine();

                    for (linha = 0; linha < tabuleiro.GetLength(0); linha++)
                    {

                        Console.Write($" {linha} |");

                        for (coluna = 0; coluna < tabuleiro.GetLength(1); coluna++)
                        {
                            if (x == "i" && y == "i")
                            {
                                tabuleiro[linha, coluna] = "-";
                            }
                            else
                            {
                                tabuleiro[int.Parse(x), int.Parse(y)] = jogada;
                            }
                            Console.Write($"\t{tabuleiro[linha, coluna]}");
                        }

                        Console.WriteLine();
                    }

                }

                desenharTabuleiro();

                string jogadorAtual = "X";
                while (true)
                {
                    Console.WriteLine($"Vez do jogador {jogadorAtual}:\n");
                    Console.Write("Informe a linha da jogada: ");
                    string linha = Console.ReadLine();
                    if (linha != "0" && linha != "1" && linha != "2")
                    {
                        Console.WriteLine("Você escolheu uma linha que não existe, tente novamente.");
                        continue;
                    }

                    Console.Write("Informe a coluna da jogada: ");
                    string coluna = Console.ReadLine();
                    if (coluna != "0" && coluna != "1" && coluna != "2")
                    {
                        Console.WriteLine("Você escolheu uma coluna que não existe, tente novamente. ");
                        continue;
                    }

                    if (tabuleiro[int.Parse(linha), int.Parse(coluna)] != "-")
                    {
                        Console.WriteLine("Você escolheu um campo já preenchido, tente novamente. ");
                        continue;
                    }

                    desenharTabuleiro(linha, coluna, jogadorAtual);

                    if (verificarVitoria(tabuleiro, jogadorAtual))
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Jogador {jogadorAtual} venceu!");
                        break;
                    }
                    if (verificarEmpate(tabuleiro))
                    {
                        Console.WriteLine();
                        Console.WriteLine("O jogo empatou!");
                        break;
                    }


                    jogadorAtual = jogadorAtual == "X" ? "O" : "X";
                }


                Console.ReadLine();
            }


        }

        public static bool verificarVitoria(string[,] tabuleiro, string jogada)
        {
            // Verificar linhas
            for (int i = 0; i < tabuleiro.GetLength(0); i++)
            {
                if (tabuleiro[i, 0] == jogada && tabuleiro[i, 1] == jogada && tabuleiro[i, 2] == jogada)
                {
                    return true;
                }
            }

            // Verificar colunas
            for (int j = 0; j < tabuleiro.GetLength(1); j++)
            {
                if (tabuleiro[0, j] == jogada && tabuleiro[1, j] == jogada && tabuleiro[2, j] == jogada)
                {
                    return true;
                }
            }

            // Verificar diagonal principal
            if (tabuleiro[0, 0] == jogada && tabuleiro[1, 1] == jogada && tabuleiro[2, 2] == jogada)
            {
                return true;
            }

            // Verificar diagonal secundária
            if (tabuleiro[0, 2] == jogada && tabuleiro[1, 1] == jogada && tabuleiro[2, 0] == jogada)
            {
                return true;
            }

            return false;
        }

        public static bool verificarEmpate(string[,] tabuleiro)
        {
            int casasPreenchidas = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tabuleiro[i, j] != "-")
                    {
                        casasPreenchidas++;
                    }
                }
            }
            if (casasPreenchidas == 9)
            {
                Console.WriteLine("O jogo empatou!");
                return true;
            }

            return false;
        }
    }
}
