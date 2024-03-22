using JogoVelha.App;

namespace JogoVelha.Tests
{
    public class JogoVelhaTests
    {
        [Fact(DisplayName = "Iniciar Jogo Da Velha - Tabuleiro Esta Vazio")]
        [Trait("Categoria", "Jogo Da Velha - IniciarJogo")]
        public void JogoVelha_IniciarTabuleiro_DeveEstarVazio()
        {
            //Arrange
            var jogoVelha = new JogoVelhaApp();

            //Act
            jogoVelha.IniciarJogo();

            //Assert
            bool TabuleiroEstaVazio = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (jogoVelha.Tabuleiro.matriz[i, j] != Simbolo.Vazio)
                    {
                        TabuleiroEstaVazio = false;
                        break;
                    }
                }
            }
            Assert.True(TabuleiroEstaVazio);
        }

        [Fact(DisplayName = "Jogador X Realizar uma Jogada - Celula preenchida com X")]
        [Trait("Categoria", "Jogo Da Velha - X realizar Jogada")]
        public void JogoVelha_JogadorXrealizarJogada_CelulaDeveEstarPreenchida()
        {
            //Arrange
            var jogoVelha = new JogoVelhaApp();

            //Act
            jogoVelha.IniciarJogo();
            Simbolo valorCelulaAntesJogada = jogoVelha.ObterValorCelula(0, 0);
            jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
            bool celulaOcupada = jogoVelha.CelularOcupada(0, 0);
            Simbolo valorCelulaOcupada = jogoVelha.ObterValorCelula(0, 0);

            //Assert

            Assert.Equal(Simbolo.Vazio, valorCelulaAntesJogada);
            Assert.True(celulaOcupada);
            Assert.Equal(Simbolo.X, valorCelulaOcupada);
        }

        [Fact(DisplayName = "Jogador X Realizar Jogadas Seguidas - Dispara Excepetion")]
        [Trait("Categoria", "Jogo Da Velha - X Realizar Jogadas Seguidas")]
        public void JogoVelha_JogadorXrealizarJogadaSeguidas_ErroJogadaNaoPermitida()
        {
            //Arrange
            var jogoVelha = new JogoVelhaApp();

            //Act
            jogoVelha.IniciarJogo();
            jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);

            //Assert
            var excecao = Assert.Throws<Exception>(() => jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0));

            Assert.Equal("Jogada não realizada, o Jogador fazer jogadas seguidas", excecao.Message);

        }

        [Fact(DisplayName = "Jogador X Venceu a Partida")]
        [Trait("Categoria", "Jogo Da Velha - X Vence a partida")]
        public void JogoVelha_JogadorXvencePartida()
        {
            //Arrange
            var jogoVelha = new JogoVelhaApp();

            //Act
            bool c1 = cenario1();
            bool c2 = cenario2();
            bool c3 = cenario3();
            bool c4 = cenario4();
            bool c5 = cenario5();
            bool c6 = cenario6();
            bool c7 = cenario7();
            bool c8 = cenario8();

            bool cenario1()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario2()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario3()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario4()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario5()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario6()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario7()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }
            bool cenario8()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (X & !O) return true;
                else return false;
            }

            Assert.True(c1);
            Assert.True(c2);
            Assert.True(c3);
            Assert.True(c4);
            Assert.True(c5);
            Assert.True(c6);
            Assert.True(c7);
            Assert.True(c8);
        }

        [Fact(DisplayName = "Partida deu Velha")]
        [Trait("Categoria", "Jogo Da Velha - Empate")]
        public void JogoVelha_PartidaEmpatada()
        {
            var jogoVelha = new JogoVelhaApp();

            bool c1 = cenario1();
            bool c2 = cenario2();
            bool c3 = cenario3();
            bool c4 = cenario4();
            bool c5 = cenario5();
            bool c6 = cenario6();
            bool c7 = cenario7();
            bool c8 = cenario8();
            bool c9 = cenario9();
            bool c10 = cenario10();
            bool c11 = cenario11();
            bool c12 = cenario12();
            bool c13 = cenario13();
            bool c14 = cenario14();
            bool c15 = cenario15();
            bool c16 = cenario16();

            bool cenario1()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario2()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario3()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario4()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario5()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario6()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario7()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario8()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario9()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario10()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario11()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario12()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario13()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario14()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario15()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }
            bool cenario16()
            {
                jogoVelha.IniciarJogo();

                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 0, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 0, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 0);
                jogoVelha.RealizarJogada(jogoVelha.JogadorO, 2, 1);
                jogoVelha.RealizarJogada(jogoVelha.JogadorX, 2, 2);

                bool X = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.X);
                bool O = jogoVelha.ChecarVitoria(jogoVelha.Tabuleiro, Simbolo.O);

                if (!X & !O) return true;
                else return false;
            }

            Assert.True(c1);
            Assert.True(c2);
            Assert.True(c3);
            Assert.True(c4);
            Assert.True(c5);
            Assert.True(c6);
            Assert.True(c7);
            Assert.True(c8);
            Assert.True(c9);
            Assert.True(c10);
            Assert.True(c11);
            Assert.True(c12);
            Assert.True(c13);
            Assert.True(c14);
            Assert.True(c15);
            Assert.True(c16);
        }
    }
}
