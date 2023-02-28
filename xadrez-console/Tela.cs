using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {

        private const int LINHAS = 8;
        private const int COLUNAS = 8;
        private const string COLUNAS_LETRAS ="a b c d e f g h";
        private const string VAZIO = "- ";

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < LINHAS; i++)
            {
                Console.Write(COLUNAS - i + " ");
                for (int j = 0; j < COLUNAS; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  "+COLUNAS_LETRAS);
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            
            for (int i = 0; i < LINHAS; i++)
            {
                Console.Write(COLUNAS - i + " ");
                for (int j = 0; j < COLUNAS; j++)
                {
                    Console.BackgroundColor = posicoesPossiveis[i,j] ? fundoAlterado : fundoOriginal;
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}