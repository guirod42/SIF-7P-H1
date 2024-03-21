namespace Empresa.Core
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public NivelProfissional NivelProfissional;
        public string CPF { get; set; }
        public List<string> Habilidades { get; set; }

        public Funcionario(string nome, double salario, string cpf, List<string> habilidades)
        {
            DadosCPF resp = DadosCPF.VerificarCPF(cpf);
            if (!resp.Valido) throw new Exception("CPF invalido");
            if (salario <= 0) throw new Exception("Salario zerado ou negativo");
            if (habilidades.Count < 3) throw new Exception("Precisa de ao menos 3 habilidades");
            int qtdHab = 0;
            foreach (var hab in habilidades)
            {
                if (hab != "") qtdHab++;
            }
            if (qtdHab < 3) throw new Exception("Precisa de ao menos 3 habilidades");
            if (nome.Length == 0) throw new Exception("Nome em branco");

            Nome = nome;
            Salario = salario;
            CPF = cpf;
            Habilidades = habilidades;

            if (salario < 2000) NivelProfissional = NivelProfissional.Junior;
            else if (salario >= 2000 && salario < 8000) NivelProfissional = NivelProfissional.Pleno;
            else NivelProfissional = NivelProfissional.Senior;
        }
    }
}
