using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVelha.App
{
    public class Tabuleiro
    {
        public Simbolo[,] matriz { get; private set; }

        public Tabuleiro()
        {
            this.matriz = new Simbolo[3, 3];
            InicializaTabuleiro();
        }

        private void InicializaTabuleiro()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matriz[i, j] = Simbolo.Vazio;
                }
            }
        }

        public void RealizaJogada(Jogador jogador, int linha, int coluna)
        {
            if (CelulaOcupada(linha, coluna))
                throw new Exception("Celula ocupada, jogada não pode ser realizada");

            matriz[linha, coluna] = jogador.Simbolo;
        }

        public bool CelulaOcupada(int linha, int coluna)
        {
            return matriz[linha, coluna] != Simbolo.Vazio;
        }

        public Simbolo ValorCelula(int linha, int coluna)
        {
            return matriz[linha, coluna];
        }
    }
}
