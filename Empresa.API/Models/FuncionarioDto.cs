using Empresa.Core;

namespace Empresa.WebAPI.Models
{
    public class FuncionarioDto
    {
        public string Nome { get; set; }
        public double Salario { get; set; }
        public NivelProfissional NivelProfissional;
        public string CPF { get; set; }
        public List<string> Habilidades { get; set; }
    }
}
