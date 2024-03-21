namespace JogoVelha.App
{
    public class Jogador
    {
        public Jogador(string nome, Simbolo simbolo)
        {
            Nome = nome;
            Simbolo = simbolo;
        }

        public string Nome { get; private set; }
        public Simbolo Simbolo { get; private set; }
    }
}