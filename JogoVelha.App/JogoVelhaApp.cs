using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoVelha.App
{
    public class JogoVelhaApp
    {
        public Jogador JogadorX { get; private set; }
        public Jogador JogadorO { get; private set; }
        public Jogador JogadorDaVez { get; private set; }
        public bool JogoIniciado { get; private set; }
        public Tabuleiro Tabuleiro { get; private set; }
        public JogoVelhaApp()
        {
            JogoIniciado = false;
        }

        public void IniciarJogo()
        {
            JogoIniciado = true;
            Tabuleiro = new Tabuleiro();
            JogadorX = new Jogador("Jogador X", Simbolo.X);
            JogadorO = new Jogador("Jogador O", Simbolo.O);
            JogadorDaVez = JogadorX;
        }

        public void RealizarJogada(Jogador jogador, int linha, int coluna)
        {
            if (!JogoIniciado)
                throw new Exception("Jogo não iniciado, jogada não pode ser realizada");

            if (JogadorDaVez.Simbolo != jogador.Simbolo)
                throw new Exception("Jogada não realizada, o Jogador fazer jogadas seguidas");

            Tabuleiro.RealizaJogada(jogador, linha, coluna);

            JogadorDaVez = ProximoJogador();
        }

        private Jogador ProximoJogador()
        {
            return JogadorDaVez == JogadorX ? JogadorO : JogadorX;
        }

        public bool CelularOcupada(int linha, int coluna) =>
         Tabuleiro.CelulaOcupada(linha, coluna);

        public Simbolo ObterValorCelula(int linha, int coluna)
        {
            return Tabuleiro.ValorCelula(linha, coluna);
        }

        public bool ChecarVitoria(Tabuleiro tabuleiro, Simbolo simbolo)
        {
            Simbolo a = tabuleiro.matriz[0, 0];
            Simbolo b = tabuleiro.matriz[0, 1];
            Simbolo c = tabuleiro.matriz[0, 2];
            Simbolo d = tabuleiro.matriz[1, 0];
            Simbolo e = tabuleiro.matriz[1, 1];
            Simbolo f = tabuleiro.matriz[1, 2];
            Simbolo g = tabuleiro.matriz[2, 0];
            Simbolo h = tabuleiro.matriz[2, 1];
            Simbolo i = tabuleiro.matriz[2, 2];

            if (a == b & a == c & a == simbolo) { return true; }
            else if (d == e & d == f & d == simbolo) { return true; }
            else if (g == h & g == i & g == simbolo) { return true; }
            else if (a == d & a == g & a == simbolo) { return true; }
            else if (b == e & b == h & b == simbolo) { return true; }
            else if (c == f & c == i & c == simbolo) { return true; }
            else if (a == e & a == i & a == simbolo) { return true; }
            else if (g == e & g == c & g == simbolo) { return true; }
            else return false;
        }
    }
}
