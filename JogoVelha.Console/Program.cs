// See https://aka.ms/new-console-template for more information
using JogoVelha.App;

Console.WriteLine("Bem vindo ao jogo da Velha do H1!");

JogoVelhaApp jogoVelha = new();
jogoVelha.IniciarJogo();
jogoVelha.RealizarJogada(jogoVelha.JogadorX, 1, 1);
jogoVelha.RealizarJogada(jogoVelha.JogadorO, 1, 2);